using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;

namespace soketmessasing
{

    class SocketServer
    {
        private  bool _isAktif = false;
        private bool _isWaitingForConnect = false;
        Socket listener = null;
        Socket _client = null;
        public enum ServerDurum
        {
            NULL,
            BaglantiBekleniyor,
            BaglantiKuruldu,
            VeriBekleniyor,
            VeriAliniyor,
            VeriAlindi,
            Kapali,
        };

        /// <summary>
        /// Serverin anlık durumunu string olarak doner.
        /// </summary>
        /// <returns></returns>
        public string GetDurum()
        {
            string _durum = "";
            switch (this.durum)
            {
                case SocketServer.ServerDurum.BaglantiBekleniyor:
                    _durum = "Baglanti bekleniyor...";
                    break;
                case SocketServer.ServerDurum.BaglantiKuruldu:
                    _durum = "Baglanti kuruldu.";
                    break;
                case SocketServer.ServerDurum.VeriBekleniyor:
                    _durum = "Veri bekleniyor...";
                    break;
                case SocketServer.ServerDurum.VeriAliniyor:
                    _durum = "Veri aliniyor...";
                    break;
                case SocketServer.ServerDurum.VeriAlindi:
                    _durum = "Veri alindi.";
                    break;
                case SocketServer.ServerDurum.Kapali:
                    _durum = "Server kapali.";
                    break;
                default:
                    _durum = "---";
                    break;

            }
            return _durum;
        }

        /// <summary>
        /// Serverin anlık pozisyonunu tutar.
        /// </summary>
        public  ServerDurum durum { get; private set; }

        /// <summary>
        /// Clientten gelen mesajlarin tutuldugu liste.
        /// </summary>
        public  List<Mesaj> gelenMesajlar = new List<Mesaj>();

        /// <summary>
        /// Serveri aktif hale getirir.
        /// </summary>
        /// <param name="ipAdresim"></param>
        /// <param name="port"></param>
        /// <returns></returns>
        public SocketServer StartServer(IPAddress ipAdresim, int port=11000)
        {
            _isAktif = true;
            listener = new Socket(ipAdresim.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                listener.Bind(new IPEndPoint(ipAdresim, port));

                Thread th_waitConn = new Thread(WaitForConnection);
                if(!_isWaitingForConnect)
                    th_waitConn.Start();

                return this;
                
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                   ex.Message, "Sunucu başlatılamadı",
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Warning);
            }
            return null;
        }

        /// <summary>
        /// Bize bagli clientin ip port bilgisini dondurur.
        /// </summary>
        /// <returns></returns>
        public EndPoint GetRemoteEndPoint()
        {
            if (_client != null && !IsClientDisconnect(_client))
            {
                return _client.RemoteEndPoint;
            }
            else
                return null;
        }

        /// <summary>
        /// Bir clientin baglanmasini bekleyen dongu
        /// </summary>
        public void WaitForConnection()
        {
            //Server durumu aktifse bir client baglanmasini bekle.
            while (_isAktif)
            {
                try
                {
                    durum = ServerDurum.BaglantiBekleniyor;
                    listener.Listen(1);
                    durum = ServerDurum.BaglantiBekleniyor;

                    var client = listener.Accept();
                    durum = ServerDurum.BaglantiKuruldu;
                    this._client = client;
                    ClientDinle();
                }
                catch (Exception) { }

            }
            durum = ServerDurum.Kapali;
        }
        
        /// <summary>
        /// serveri kapatir
        /// </summary>
        public void CloseServer()
        {
            _isAktif = false;
            listener.Close();
            listener = null;
            DisconnectFromClient();
        }

        /// <summary>
        /// Client ile server arasindaki baglantiyi keser.
        /// </summary>
        public void DisconnectFromClient()
        {
            try
            {
                if (_client != null)
                {
                    _client.Disconnect(false);
                    _client.Close();
                    _client = null;
                }
            }
            catch (Exception)
            { }



        }
        
        /// <summary>
        /// Clientin baglantisinin kesilip kesilmedigi bilgisini dondurur.
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        private  bool IsClientDisconnect(Socket client)
        {
            try
            {
                if(client != null)
                if (client.Poll(0, SelectMode.SelectRead))
                {
                    byte[] buff = new byte[1];
                    if (client.Receive(buff, SocketFlags.Peek) == 0)
                    {
                        // Client disconnected
                        return true;
                    }
                }
            }
            catch (Exception) { }
            return false;

        }

        /// <summary>
        /// Clientten gelen mesajlari gelenMesajlar icerisine atar.
        /// </summary>
        private void ClientDinle()
        {
            int gelenByte = 0;
            byte[] buffer  = new byte[1024];
            
            while (!IsClientDisconnect(_client) && _isAktif)
            {
                durum = ServerDurum.VeriBekleniyor;

                List<byte> okunanBytes = new List<byte>();
                while (_client.Available > 0)
                {
                    durum = ServerDurum.VeriAliniyor;

                    //clientten okunan byte sayısı
                    gelenByte = _client.Receive(buffer, 0, buffer.Length, SocketFlags.None);
                    
                    //gelen mesajin okunan bytlarini kaydediyoruz.
                    okunanBytes.AddRange(buffer.Take(gelenByte));
                }

                //okuma bittiginde bir mesaj okunduysa donusturup gelen mesajlar listesine atiyoruz
                if (okunanBytes.Count > 0)
                {
                    var alinanMesaj = Serializator.FromByteArray<Mesaj>(okunanBytes.ToArray());
                    durum = ServerDurum.VeriAlindi;
                    gelenMesajlar.Add(alinanMesaj);
                    if (alinanMesaj.dosyaEkliMi)
                        //Serializator.ByteArrayToFile("gelenDosyalar/"+alinanMesaj.fileName, alinanMesaj.dosyaByte);
                        alinanMesaj.DosyayiDisaAktar("transferedFiles/");
                }


                Thread.Sleep(1000);
            }
         
            durum = ServerDurum.BaglantiBekleniyor;
        }

        /// <summary>
        /// Mesaji bagli cliente yollar.
        /// </summary>
        /// <param name="mesaj"></param>
        /// <returns>Dosyanın hepsinin yollanıp yollanmadıgı bilgisini dondurur</returns>
        public bool SendMessage(Mesaj mesaj)
        {
  

            if (_client != null && !IsClientDisconnect(_client))
            {
                _client.SendTimeout = 1000;
                var yollanacakBytes = Serializator.ToByteArray<Mesaj>(mesaj);
                var gidenByte = _client.Send(yollanacakBytes);

                return yollanacakBytes.Length == gidenByte;

            }


            return false;
        }

    }
}
