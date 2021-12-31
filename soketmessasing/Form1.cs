using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace soketmessasing
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
           
        }

        string _spnKey = "xxxxxxxx";
        //
        bool isSifreleniyor = false;
        bool _kilitleriOtomatikAc = false;
        bool _programKapatildi = false;
        //
        int alinanToplamMesaj = 0, kilitliToplamMesaj = 0;
        //
        Dosya ekliDosya = null;
        SocketServer socketServer = null;
        SocketClient socketClient = null;


        //
        //
        #region Konsola yazı yazdırma Fonksiyonlari
        void ConsoleYazdir(string mesaj)
        {
            try
            {
                if (InvokeRequired)
                {
                    this.Invoke((MethodInvoker)delegate () { ConsoleYazdir(mesaj); });
                    return;
                }
                textBox_Console.Text += mesaj + Environment.NewLine;
            }
            catch (Exception) { }




        }

        /// <summary>
        /// Mesaj nesnesindeki değerleri consola yazdırır.
        /// </summary>
        /// <param name="mesaj">Degerleri yazdirilacak mesaj nesnesi</param>
        /// <param name="kilitleriAc">Kilitli mesajin ici acilsin mi</param>
        private void MesajBilgisiYazdir(Mesaj mesaj, bool kilitleriAc = false)
        {
            var icerik = "";
            if (kilitleriAc && mesaj.isSifreli)
            {
                if (mesaj.Desifrele(_spnKey))
                {
                    ConsoleYazdir("Kilit acildi. ->");
                    if (mesaj.dosyaEkliMi)
                        mesaj.DosyayiDisaAktar("transfaredUnlockedFiles/");
                }
                else
                    ConsoleYazdir("Kilit acilamadi. Mesaj farkli bir anahtarla kilitlenmis. ->");
            }

            if (!mesaj.isSifreli)
                icerik = "Gelen Mesaj: \n" +
                       "\tGonderen: " + mesaj.gonderen +
                       "\n\tMesaj: " + mesaj.icerik +
                       ((mesaj.dosyaEkliMi == true) ? "\n\tDosya: " + mesaj.fileName + "\n" : "\n") +
                       "-----------------\n";
            else
            {
                icerik = "Kilitli bir mesaj aldınız.\n----------------\n";

            }
            ConsoleYazdir(icerik);
        }

        /// <summary>
        /// Gelen mesajları yakalayıp anlık olarak yazdırır.
        /// </summary>
        void gelenMesajlariListele()
        {
            int gelenMesajSayisi = 0;
            while (!_programKapatildi)
            {
                try
                {
                    List<Mesaj> gelenMesajlar = null;
                    if (socketClient != null)
                    {
                        gelenMesajlar = socketClient.gelenMesajlar;
                    }
                    else if (socketServer != null)
                    {
                        gelenMesajlar = socketServer.gelenMesajlar;
                    }

                    if (gelenMesajlar != null && (gelenMesajlar.Count != alinanToplamMesaj))
                    {
                        alinanToplamMesaj = gelenMesajlar.Count;
                        var gelenMesaj = gelenMesajlar.Last();
                        MesajBilgisiYazdir(gelenMesaj, _kilitleriOtomatikAc);
                        if (gelenMesaj.isSifreli)
                            kilitliToplamMesaj++;
                        this.Invoke((MethodInvoker)delegate () {
                            label_kilitliMesajAdet.Text = "Kilitli Mesaj: " + kilitliToplamMesaj;
                            label_gelenTopMesaj.Text = "Alınan Mesaj: " + alinanToplamMesaj;
                        });
                    }
                }
                catch (Exception)  { }
                Thread.Sleep(100);
            }
        }
        #endregion

        //Uygulama acildiginda baglanma durumunu ve gelen mesajlari kontrol ettirir.
        private void Form1_Load(object sender, EventArgs e)
        {
            //Uygulamanın ne modda baglandgını algılar
            Thread th_changeTitle = new Thread(Connected);
            th_changeTitle.Start();

            //uygulamaya soketten atılan mesajları tekstboxa önizler
            Thread th_catchMessages = new Thread(gelenMesajlariListele);
            th_catchMessages.Start();


        }

        //
        //
        /// <summary>
        /// Uygulama bağlantı bilgisini gözler.
        /// </summary>
        void Connected()
        {
            while (!_programKapatildi)
            {
                var _title = "";
                if (socketServer != null)
                {
                    _title = "[SERVER] - ";
                    var baglanilanNokta =
                        socketServer.GetRemoteEndPoint();
                    _title += baglanilanNokta != null ? "Connected " + baglanilanNokta.ToString() : "Connect Waiting...";

                }
                else if (socketClient != null)
                {
                    _title = "[CLIENT] - ";
                    var baglanilanNokta =
                        socketClient.GetRemoteEndPoint();
                    _title += baglanilanNokta != null ? "Connected " + baglanilanNokta.ToString() : "Connect Waiting...";

                }
                else
                {
                    _title = "Soket Iletisim With Chiper - HMG Yazılım Junior Studios";
                }

                ChangeTitle(_title);
                Thread.Sleep(1000);
            }
        }
      
        //
        //
        /// <summary>
        /// Uygulama penceresinin basligini degistirir.
        /// </summary>
        /// <param name="newTitle">Yeni Baslik</param>
        public void ChangeTitle(string newTitle)
        {
            try
            {
                if (InvokeRequired)
                {
                    this.Invoke((MethodInvoker)delegate () { ChangeTitle(newTitle); });
                    return;
                }

                this.Text = newTitle;
            }
            catch (Exception) { }

        }


        //
        //
        #region Server Olma fonksiyonlari [SERVER]
        //Server startlar (server acikken baska bir sunucuya baglanamazsiniz, baskalari size baglanir.)
        private void button_serverStartStop_Click(object sender, EventArgs e)
        {
            if (socketServer == null)
            {
                socketServer = new SocketServer();
                try
                {

                    var ipAdres = IPAddress.Parse("127.0.0.1");
                    var port = Int32.Parse(textBox_portum.Text);
                    socketServer = socketServer.StartServer(ipAdres, port);
                    if (socketServer != null)
                    {
                        Thread.Sleep(100);
                        label_serverDurum.Text =
                            "Hosting: " + ipAdres + " : " + port + Environment.NewLine +
                            socketServer.GetDurum();

                        button_serverStop.Enabled = true;
                        button_serverStartStop.Enabled = false;
                    }

                }
                catch (Exception ex)
                {
                    socketServer = null;

                    MessageBox.Show(ex.Message,
                        "Server oluşturulurken bir şeyler ters gitti. Ops!",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }


        }

        //Serveri stoplar. 
        private void button_serverStop_Click(object sender, EventArgs e)
        {
            if (socketServer != null)
            {
                socketServer.CloseServer();
                button_serverStop.Enabled = false;
                button_serverStartStop.Enabled = true;
                socketServer = null;
                label_serverDurum.Text = "Pasif";
            }
            else
            {
                MessageBox.Show("Zaten sunucu görevini üstlenmiyorsun.",
                       "Server bağlantısı kesilmedi.",
                       MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        //Server durumunu bildirir.
        private void label_serverDurum_Click(object sender, EventArgs e)
        {
            if (socketServer != null)
                MessageBox.Show(socketServer.GetDurum());
        }
        #endregion


        //
        //
        #region Sunucuya Baglanma Fonksiyonlari [CLIENT]
        //Bir sunucuya baglanmayi tetikler.
        private void button_baglan_Click(object sender, EventArgs e)
        {
            //Eğer serverse program baglanti istegi yollamassina musade etme.
            if (socketServer != null)
            {
                MessageBox.Show(
                    "Serverken başka bir servere bağlanamazsınız. Server durumunu pasifleştirip tekrar deneyiniz. Ya da cliente ip ve port bilgilerinizi verin o size bağlansın.",
                    "Siz bir serversiniz!",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var ipAdresi = IPAddress.Parse(textBox_sunucuIP.Text);
                var portu = Int32.Parse(textBox_sunucuPort.Text);
                socketClient = new SocketClient();
                bool baglantiSaglandi = socketClient.ConnectToServer(ipAdresi, portu);
                if (baglantiSaglandi)
                {
                    button_baglan.Enabled = false;
                    button_baglantiKopar.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                        ex.Message,
                        "Siz bir serversiniz!",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }




        }

        //Sunucuyla olan baglantini koparir.
        private void button_baglantiKopar_Click(object sender, EventArgs e)
        {

            button_baglan.Enabled = true;
            button_baglantiKopar.Enabled = false;
            socketClient.DisconnectFromServer();
            socketClient = null;
        }
        #endregion


        //
        //
        #region Metin Sifreleme Fonksiyonlari 
        private void button_mesajSifrele_Click(object sender, EventArgs e)
        {

            //metin kutusundaki mesaji SPN algoritmasina gore cozer. (anahtar bolumuna girilen anahtarla)
            if (rdButon_spn.Checked == true)
            {
                var mesaj = textBox_sifrelenecekMesaj.Text;
                var anahtar = (String)textBox_sifrelemeAnahtar.Tag;
                var sifreliMesaj = SPN_Chiper.SPN_Sifrele(mesaj, anahtar);
                textBox_sifreliMesaj.Text = sifreliMesaj[1];
            }
            else if (rdButton_sha256.Checked == true)
            {
                textBox_sifreliMesaj.Text = SHA256_Chiper.StringToHash(textBox_sifrelenecekMesaj.Text);
            }

        }

        private void button_mesajCoz_Click(object sender, EventArgs e)
        {
            //metin kutusundaki mesaji SPN algoritmasina gore cozer (anahtar bolumuna girilen anahtarla)
            var mesajBin = textBox_sifrelenecekMesaj.Text;
            var anahtar = (String)textBox_sifrelemeAnahtar.Tag;
            var cozulenMesaj = SPN_Chiper.SPN_Cozumle(mesajBin, anahtar, true);
            textBox_sifreliMesaj.Text = cozulenMesaj[0];
        }

        private void textBox_textChipers_TextChanged(object sender, EventArgs e)
        {
            //spn algoritmasının calismasi icin anahtarin 8 karakterli olması lazım 
            //kullanıcıyı kısıtlamadan böyle bir şey yapabilmek icin kullanıcının 8den az girdiği
            //anahtarın sagını biz 'x' ile 8'e tammalıyoruz. Ama bunu kullanıcı ayıkmıyo.
            var key = (String)(((TextBox)sender).Tag = ((TextBox)sender).Text.PadRight(8, 'x'));
            label_KeyForSPNOnizleme.Text = "(key: " + key + ")";

        }

        private void rdButton_sha256_CheckedChanged(object sender, EventArgs e)
        {
            //metin sifreleme bolumunde sha256 seçeneği seçilirse
            //decrpyt edilemeyeceği için çözümle butonunu false ettik.
            button_mesajCoz.Enabled = false;
            //anahtara da ihtiyacı olmadıgı icin anahtar textboxunu da false ettik
            textBox_sifrelemeAnahtar.Enabled = false;
        }

        private void rdButon_spn_CheckedChanged(object sender, EventArgs e)
        {
            //metin sifreleme bolumunde spn seçeneği seçilirse
            //decrpyt edilebilecegi için çözümle butonunu true ettik.
            button_mesajCoz.Enabled = true;
            //anahtara da ihtiyacı oldugu icin anahtar textboxunu da false ettik
            textBox_sifrelemeAnahtar.Enabled = true;
        }

        #endregion

        //
        //
        #region Sunucu-Client arasi Mesaj gonderme fonksiyonlari

        #region Dosya Ilistirme Kodlari
        private void textBox_ekliDosya_MouseClick(object sender, MouseEventArgs e)
        {
            using (OpenFileDialog fileDialog = new OpenFileDialog())
            {
                ekliDosya = new Dosya();
                fileDialog.Filter = "metin belgeleri (*.txt)|*.txt|all files (*.*)|*.*";
                if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                    textBox_ekliDosya.Text = "Ekli Dosya (" + fileDialog.SafeFileName + ")";
                    ekliDosya.fileName = fileDialog.SafeFileName;
                    ekliDosya.filePath = fileDialog.FileName;
                }
            }
        }

        private void button_mesajEkSil_Click(object sender, EventArgs e)
        {
            textBox_ekliDosya.Text = "Ekli Dosya (...)";
            ekliDosya = null;
        }
        #endregion

        ///Sunucu-Client arasi mesajlasmalarda kullanilacak sifreleme anahtari bilgisini gunceller.
        private void textBox_mesajAnahtari_TextChanged(object sender, EventArgs e)
        {
            _spnKey = textBox_mesajAnahtari.Text.PadRight(8, 'x');
            checkBox_otomatikCoz.Text = "Gelen kilitli mesajları otomatik çöz (key: " + _spnKey + ")";
        }

        //Alınan mesajlarda kilitli mesaj varsa girili key degeri ile cozmeye calismasini tetikler.
        private void checkBox_otomatikCoz_CheckedChanged(object sender, EventArgs e)
        {
            _kilitleriOtomatikAc = checkBox_otomatikCoz.Checked;
        }

        //Mesaj gonderimini tetikler.
        private void button_mesajGonder_Click(object sender, EventArgs e)
        {
            if (socketClient == null && socketServer == null)
            {
                MessageBox.Show("Mesajlaşabilmen için önce bir sunucu ya da client ile bağlantı kurman lazım.",
                   "Mesaj gonderemezsin!",
                   MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
               

            if (textBox_gonderenAdi.Text == "" || (ekliDosya == null && textBox_gonderilecekMesaj.Text == ""))
            {
                MessageBox.Show("Karşı tarafın sizi tanıyabilmesi için bir gönderici imzası girmeli göndermek için bir dosya ya da bir mesaj yazmalısınız.",
                    "Eksik mesaj gonderemezsin!",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Mesaj gidecekMesaj = new Mesaj();
            gidecekMesaj.gonderen = textBox_gonderenAdi.Text;
            gidecekMesaj.icerik = textBox_gonderilecekMesaj.Text;
            if (ekliDosya != null)
                gidecekMesaj.DosyaEkle(ekliDosya.filePath, ekliDosya.fileName);

            if (checkBox_mesajiSifrele.Checked)
            {
                button_mesajGonder.Enabled = false;
                checkBox_mesajiSifrele.Enabled = false;
                Thread th_sifrele = new Thread(() => MesajiSifrele(gidecekMesaj, _spnKey));
                th_sifrele.Start();
            }

            Thread th_send = new Thread(() => SendMessage(gidecekMesaj));
            th_send.Start();


        }

        /// <summary>
        /// Eger mesaj kilitlenecekse mesaji kilitler ve baglantinin obur ucundakine yollar.
        /// </summary>
        /// <param name="mesaj"></param>
        void SendMessage(Mesaj mesaj)
        {
            while (isSifreleniyor)
                Thread.Sleep(1000);
            if (socketClient != null)
                socketClient.SendMessage(mesaj);
            if (socketServer != null)
                socketServer.SendMessage(mesaj);
        }

        /// <summary>
        /// Mesaji sifreler, eger ekli dosyanin boyutu fazlaysa islem biraz zaman alabilir.
        /// </summary>
        /// <param name="mesaj">Sifrelenecek mesaj</param>
        /// <param name="key">Sifreleme anahtari (SPN icin)</param>
        void MesajiSifrele(Mesaj mesaj, string key)
        {

            isSifreleniyor = true;
            mesaj.Sifrele(key);
            isSifreleniyor = false;

            if (InvokeRequired)
            {
                this.Invoke((MethodInvoker)delegate ()
                {

                    button_mesajGonder.Enabled = true;
                    checkBox_mesajiSifrele.Enabled = true;
                });
                return;
            }



        }


        #endregion

        //
        //
        #region Client-server arasinda gerceklesen mesajlari listeleme fonksiyonlari
        private void button_tumMesajlariYazdir_Click(object sender, EventArgs e)
        {
            textBox_Console.Text = "";
            button_tumMesajlariYazdir.Enabled = false;
            Thread th_mesajlariCozVeListele = new Thread(() => tumMesajlariCozVeYaz(_spnKey));
            th_mesajlariCozVeListele.Start();
        }

        void tumMesajlariCozVeYaz(string key)
        {
            List<Mesaj> mesajlar = null;
            int alinanMesaj_C = 0;
            int kilitliMesaj_C = 0;
            if (socketClient != null)
            {
                mesajlar = socketClient.gelenMesajlar;

            }
            else if (socketServer != null)
            {
                mesajlar = socketServer.gelenMesajlar;
            }

            if (mesajlar != null)
            {
                foreach (var mesaj in mesajlar)
                {
                    //mesaj bilgisinin sifresini acip yazdir.
                    MesajBilgisiYazdir(mesaj, true);
                    //Eger sifresi elimizdeki anahtarla acilmadiysa kilitlileri say.
                    if (mesaj.isSifreli == true)
                        kilitliMesaj_C++;
                }
                alinanToplamMesaj = alinanMesaj_C;
                kilitliToplamMesaj = kilitliMesaj_C;
                if (InvokeRequired)
                {
                    this.Invoke((MethodInvoker)delegate () {
                        label_kilitliMesajAdet.Text = "Kilitli Mesaj: " + kilitliMesaj_C;
                        label_gelenTopMesaj.Text = "Alınan Mesaj: " + alinanMesaj_C;
                        button_tumMesajlariYazdir.Enabled = true;
                    });
                    return;
                }

            }
        }

        #endregion

        //
        //
        #region Dosya Hashleme Fonksiyonlari
        private void textBox_dosyaYukleHsh_MouseClick(object sender, MouseEventArgs e)
        {
            using (OpenFileDialog fileDialog = new OpenFileDialog())
            {
                var yuklenenDosya = new Dosya();
                fileDialog.Filter = "metin belgeleri (*.txt)|*.txt|all files (*.*)|*.*";
                if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                    textBox_dosyaYukleHsh.Text = "Dosya Ekle (" + fileDialog.SafeFileName + ")";
                    yuklenenDosya.fileName = fileDialog.SafeFileName;
                    yuklenenDosya.filePath = fileDialog.FileName;
                    Thread th_dosyaHash = new Thread(() => dosyaHashle(File.ReadAllBytes(yuklenenDosya.filePath)));
                    th_dosyaHash.Start();
                }
            }
        }

        void dosyaHashle(byte[] fileBytes)
        {
            if (InvokeRequired)
            {
                this.Invoke((MethodInvoker)delegate () {
                    textBox_dosyaHash.Text = SHA256_Chiper.FileToHash(fileBytes);
                });
                return;
            }
        }
        #endregion

        //Uygulama kapanirken arkaplan islemlerini durduruyoruz.
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            _programKapatildi = true;
            if (socketServer != null)
            {
                socketServer.CloseServer();
            }
            if (socketClient != null)
            {
                socketClient.DisconnectFromServer();
            }
            
        }

    }
}
