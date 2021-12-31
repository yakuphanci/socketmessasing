
namespace soketmessasing
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button_serverStartStop = new System.Windows.Forms.Button();
            this.textBox_portum = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage_mesajSifrele = new System.Windows.Forms.TabPage();
            this.label_KeyForSPNOnizleme = new System.Windows.Forms.Label();
            this.panel_SifrelemeYontemi = new System.Windows.Forms.Panel();
            this.rdButton_sha256 = new System.Windows.Forms.RadioButton();
            this.rdButon_spn = new System.Windows.Forms.RadioButton();
            this.button_mesajCoz = new System.Windows.Forms.Button();
            this.button_mesajSifrele = new System.Windows.Forms.Button();
            this.textBox_sifrelemeAnahtar = new System.Windows.Forms.TextBox();
            this.textBox_sifreliMesaj = new System.Windows.Forms.TextBox();
            this.textBox_sifrelenecekMesaj = new System.Windows.Forms.TextBox();
            this.tabPage_dosyaHashle = new System.Windows.Forms.TabPage();
            this.textBox_dosyaHash = new System.Windows.Forms.TextBox();
            this.textBox_dosyaYukleHsh = new System.Windows.Forms.TextBox();
            this.tabPage_serverOl = new System.Windows.Forms.TabPage();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button_serverStop = new System.Windows.Forms.Button();
            this.label_serverDurum = new System.Windows.Forms.Label();
            this.tabPage_servereBaglan = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button_baglantiKopar = new System.Windows.Forms.Button();
            this.button_baglan = new System.Windows.Forms.Button();
            this.textBox_sunucuPort = new System.Windows.Forms.TextBox();
            this.textBox_sunucuIP = new System.Windows.Forms.TextBox();
            this.tabPage_mesajGonder = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.label_kilitliMesajAdet = new System.Windows.Forms.Label();
            this.label_gelenTopMesaj = new System.Windows.Forms.Label();
            this.button_tumMesajlariYazdir = new System.Windows.Forms.Button();
            this.checkBox_otomatikCoz = new System.Windows.Forms.CheckBox();
            this.textBox_mesajAnahtari = new System.Windows.Forms.TextBox();
            this.checkBox_mesajiSifrele = new System.Windows.Forms.CheckBox();
            this.textBox_Console = new System.Windows.Forms.RichTextBox();
            this.button_mesajGonder = new System.Windows.Forms.Button();
            this.button_mesajEkSil = new System.Windows.Forms.Button();
            this.textBox_ekliDosya = new System.Windows.Forms.TextBox();
            this.textBox_gonderilecekMesaj = new System.Windows.Forms.TextBox();
            this.textBox_gonderenAdi = new System.Windows.Forms.TextBox();
            this.label_spnKeyOnizleme = new System.Windows.Forms.Label();
            this.textBox_dosyaYukleHash = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.tabPage_mesajSifrele.SuspendLayout();
            this.panel_SifrelemeYontemi.SuspendLayout();
            this.tabPage_dosyaHashle.SuspendLayout();
            this.tabPage_serverOl.SuspendLayout();
            this.tabPage_servereBaglan.SuspendLayout();
            this.tabPage_mesajGonder.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_serverStartStop
            // 
            this.button_serverStartStop.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button_serverStartStop.Location = new System.Drawing.Point(262, 162);
            this.button_serverStartStop.Name = "button_serverStartStop";
            this.button_serverStartStop.Size = new System.Drawing.Size(218, 36);
            this.button_serverStartStop.TabIndex = 0;
            this.button_serverStartStop.Text = "Server Başlat";
            this.button_serverStartStop.UseVisualStyleBackColor = true;
            this.button_serverStartStop.Click += new System.EventHandler(this.button_serverStartStop_Click);
            // 
            // textBox_portum
            // 
            this.textBox_portum.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBox_portum.Location = new System.Drawing.Point(484, 133);
            this.textBox_portum.Name = "textBox_portum";
            this.textBox_portum.PlaceholderText = "Portum";
            this.textBox_portum.Size = new System.Drawing.Size(50, 23);
            this.textBox_portum.TabIndex = 2;
            this.textBox_portum.Text = "44";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage_mesajSifrele);
            this.tabControl1.Controls.Add(this.tabPage_dosyaHashle);
            this.tabControl1.Controls.Add(this.tabPage_serverOl);
            this.tabControl1.Controls.Add(this.tabPage_servereBaglan);
            this.tabControl1.Controls.Add(this.tabPage_mesajGonder);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(800, 450);
            this.tabControl1.TabIndex = 4;
            // 
            // tabPage_mesajSifrele
            // 
            this.tabPage_mesajSifrele.BackColor = System.Drawing.Color.Transparent;
            this.tabPage_mesajSifrele.Controls.Add(this.label_KeyForSPNOnizleme);
            this.tabPage_mesajSifrele.Controls.Add(this.panel_SifrelemeYontemi);
            this.tabPage_mesajSifrele.Controls.Add(this.button_mesajCoz);
            this.tabPage_mesajSifrele.Controls.Add(this.button_mesajSifrele);
            this.tabPage_mesajSifrele.Controls.Add(this.textBox_sifrelemeAnahtar);
            this.tabPage_mesajSifrele.Controls.Add(this.textBox_sifreliMesaj);
            this.tabPage_mesajSifrele.Controls.Add(this.textBox_sifrelenecekMesaj);
            this.tabPage_mesajSifrele.Location = new System.Drawing.Point(4, 24);
            this.tabPage_mesajSifrele.Name = "tabPage_mesajSifrele";
            this.tabPage_mesajSifrele.Size = new System.Drawing.Size(792, 422);
            this.tabPage_mesajSifrele.TabIndex = 2;
            this.tabPage_mesajSifrele.Text = "Metin Şifrele";
            // 
            // label_KeyForSPNOnizleme
            // 
            this.label_KeyForSPNOnizleme.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label_KeyForSPNOnizleme.AutoSize = true;
            this.label_KeyForSPNOnizleme.BackColor = System.Drawing.Color.Transparent;
            this.label_KeyForSPNOnizleme.Location = new System.Drawing.Point(450, 201);
            this.label_KeyForSPNOnizleme.Name = "label_KeyForSPNOnizleme";
            this.label_KeyForSPNOnizleme.Size = new System.Drawing.Size(87, 15);
            this.label_KeyForSPNOnizleme.TabIndex = 8;
            this.label_KeyForSPNOnizleme.Text = "(key: xxxxxxxx)";
            // 
            // panel_SifrelemeYontemi
            // 
            this.panel_SifrelemeYontemi.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel_SifrelemeYontemi.Controls.Add(this.rdButton_sha256);
            this.panel_SifrelemeYontemi.Controls.Add(this.rdButon_spn);
            this.panel_SifrelemeYontemi.Location = new System.Drawing.Point(201, 131);
            this.panel_SifrelemeYontemi.Name = "panel_SifrelemeYontemi";
            this.panel_SifrelemeYontemi.Size = new System.Drawing.Size(339, 61);
            this.panel_SifrelemeYontemi.TabIndex = 7;
            // 
            // rdButton_sha256
            // 
            this.rdButton_sha256.AutoSize = true;
            this.rdButton_sha256.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rdButton_sha256.Location = new System.Drawing.Point(6, 14);
            this.rdButton_sha256.Name = "rdButton_sha256";
            this.rdButton_sha256.Size = new System.Drawing.Size(132, 19);
            this.rdButton_sha256.TabIndex = 1;
            this.rdButton_sha256.Text = "SHA-256 (Tek yönlü)";
            this.rdButton_sha256.UseVisualStyleBackColor = true;
            this.rdButton_sha256.CheckedChanged += new System.EventHandler(this.rdButton_sha256_CheckedChanged);
            // 
            // rdButon_spn
            // 
            this.rdButon_spn.AutoSize = true;
            this.rdButon_spn.Checked = true;
            this.rdButon_spn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rdButon_spn.Location = new System.Drawing.Point(6, 39);
            this.rdButon_spn.Name = "rdButon_spn";
            this.rdButon_spn.Size = new System.Drawing.Size(298, 19);
            this.rdButon_spn.TabIndex = 0;
            this.rdButon_spn.TabStop = true;
            this.rdButon_spn.Text = "SPN (Anahtar gerektirir, Çift yönlü -geri çözülebilir-)";
            this.rdButon_spn.UseVisualStyleBackColor = true;
            this.rdButon_spn.CheckedChanged += new System.EventHandler(this.rdButon_spn_CheckedChanged);
            // 
            // button_mesajCoz
            // 
            this.button_mesajCoz.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button_mesajCoz.Location = new System.Drawing.Point(373, 227);
            this.button_mesajCoz.Name = "button_mesajCoz";
            this.button_mesajCoz.Size = new System.Drawing.Size(167, 46);
            this.button_mesajCoz.TabIndex = 6;
            this.button_mesajCoz.Text = "Çözümle";
            this.button_mesajCoz.UseVisualStyleBackColor = true;
            this.button_mesajCoz.Click += new System.EventHandler(this.button_mesajCoz_Click);
            // 
            // button_mesajSifrele
            // 
            this.button_mesajSifrele.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button_mesajSifrele.Location = new System.Drawing.Point(201, 227);
            this.button_mesajSifrele.Name = "button_mesajSifrele";
            this.button_mesajSifrele.Size = new System.Drawing.Size(166, 46);
            this.button_mesajSifrele.TabIndex = 2;
            this.button_mesajSifrele.Text = "Şifrele";
            this.button_mesajSifrele.UseVisualStyleBackColor = true;
            this.button_mesajSifrele.Click += new System.EventHandler(this.button_mesajSifrele_Click);
            // 
            // textBox_sifrelemeAnahtar
            // 
            this.textBox_sifrelemeAnahtar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBox_sifrelemeAnahtar.Location = new System.Drawing.Point(201, 198);
            this.textBox_sifrelemeAnahtar.MaxLength = 8;
            this.textBox_sifrelemeAnahtar.Name = "textBox_sifrelemeAnahtar";
            this.textBox_sifrelemeAnahtar.PlaceholderText = "Anahtar";
            this.textBox_sifrelemeAnahtar.Size = new System.Drawing.Size(339, 23);
            this.textBox_sifrelemeAnahtar.TabIndex = 1;
            this.textBox_sifrelemeAnahtar.Tag = "xxxxxxxx";
            this.textBox_sifrelemeAnahtar.TextChanged += new System.EventHandler(this.textBox_textChipers_TextChanged);
            // 
            // textBox_sifreliMesaj
            // 
            this.textBox_sifreliMesaj.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBox_sifreliMesaj.Location = new System.Drawing.Point(201, 280);
            this.textBox_sifreliMesaj.Multiline = true;
            this.textBox_sifreliMesaj.Name = "textBox_sifreliMesaj";
            this.textBox_sifreliMesaj.PlaceholderText = "İşlenmiş Metin";
            this.textBox_sifreliMesaj.ReadOnly = true;
            this.textBox_sifreliMesaj.Size = new System.Drawing.Size(339, 90);
            this.textBox_sifreliMesaj.TabIndex = 3;
            // 
            // textBox_sifrelenecekMesaj
            // 
            this.textBox_sifrelenecekMesaj.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBox_sifrelenecekMesaj.Location = new System.Drawing.Point(201, 37);
            this.textBox_sifrelenecekMesaj.Multiline = true;
            this.textBox_sifrelenecekMesaj.Name = "textBox_sifrelenecekMesaj";
            this.textBox_sifrelenecekMesaj.PlaceholderText = "Metin";
            this.textBox_sifrelenecekMesaj.Size = new System.Drawing.Size(339, 90);
            this.textBox_sifrelenecekMesaj.TabIndex = 0;
            // 
            // tabPage_dosyaHashle
            // 
            this.tabPage_dosyaHashle.BackColor = System.Drawing.Color.Transparent;
            this.tabPage_dosyaHashle.Controls.Add(this.textBox_dosyaHash);
            this.tabPage_dosyaHashle.Controls.Add(this.textBox_dosyaYukleHsh);
            this.tabPage_dosyaHashle.Location = new System.Drawing.Point(4, 24);
            this.tabPage_dosyaHashle.Name = "tabPage_dosyaHashle";
            this.tabPage_dosyaHashle.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_dosyaHashle.Size = new System.Drawing.Size(792, 422);
            this.tabPage_dosyaHashle.TabIndex = 4;
            this.tabPage_dosyaHashle.Text = "Dosya Hashle";
            // 
            // textBox_dosyaHash
            // 
            this.textBox_dosyaHash.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBox_dosyaHash.Location = new System.Drawing.Point(227, 105);
            this.textBox_dosyaHash.Multiline = true;
            this.textBox_dosyaHash.Name = "textBox_dosyaHash";
            this.textBox_dosyaHash.PlaceholderText = "Dosya Hash";
            this.textBox_dosyaHash.ReadOnly = true;
            this.textBox_dosyaHash.Size = new System.Drawing.Size(339, 141);
            this.textBox_dosyaHash.TabIndex = 6;
            // 
            // textBox_dosyaYukleHsh
            // 
            this.textBox_dosyaYukleHsh.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBox_dosyaYukleHsh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.textBox_dosyaYukleHsh.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.textBox_dosyaYukleHsh.Location = new System.Drawing.Point(227, 76);
            this.textBox_dosyaYukleHsh.Name = "textBox_dosyaYukleHsh";
            this.textBox_dosyaYukleHsh.PlaceholderText = "Ekli Dosya (...)";
            this.textBox_dosyaYukleHsh.ReadOnly = true;
            this.textBox_dosyaYukleHsh.Size = new System.Drawing.Size(339, 23);
            this.textBox_dosyaYukleHsh.TabIndex = 4;
            this.textBox_dosyaYukleHsh.Text = "Dosya Ekle (...)";
            this.textBox_dosyaYukleHsh.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_dosyaYukleHsh.MouseClick += new System.Windows.Forms.MouseEventHandler(this.textBox_dosyaYukleHsh_MouseClick);
            // 
            // tabPage_serverOl
            // 
            this.tabPage_serverOl.BackColor = System.Drawing.Color.Transparent;
            this.tabPage_serverOl.Controls.Add(this.textBox1);
            this.tabPage_serverOl.Controls.Add(this.button_serverStop);
            this.tabPage_serverOl.Controls.Add(this.label_serverDurum);
            this.tabPage_serverOl.Controls.Add(this.button_serverStartStop);
            this.tabPage_serverOl.Controls.Add(this.textBox_portum);
            this.tabPage_serverOl.Location = new System.Drawing.Point(4, 24);
            this.tabPage_serverOl.Name = "tabPage_serverOl";
            this.tabPage_serverOl.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_serverOl.Size = new System.Drawing.Size(792, 422);
            this.tabPage_serverOl.TabIndex = 0;
            this.tabPage_serverOl.Text = "Server Ol";
            // 
            // textBox1
            // 
            this.textBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBox1.Location = new System.Drawing.Point(262, 133);
            this.textBox1.Name = "textBox1";
            this.textBox1.PlaceholderText = "Portum";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(216, 23);
            this.textBox1.TabIndex = 5;
            this.textBox1.Text = "127.0.0.1";
            // 
            // button_serverStop
            // 
            this.button_serverStop.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button_serverStop.Enabled = false;
            this.button_serverStop.Location = new System.Drawing.Point(484, 162);
            this.button_serverStop.Name = "button_serverStop";
            this.button_serverStop.Size = new System.Drawing.Size(50, 36);
            this.button_serverStop.TabIndex = 4;
            this.button_serverStop.Text = "Stop";
            this.button_serverStop.UseVisualStyleBackColor = true;
            this.button_serverStop.Click += new System.EventHandler(this.button_serverStop_Click);
            // 
            // label_serverDurum
            // 
            this.label_serverDurum.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label_serverDurum.AutoSize = true;
            this.label_serverDurum.Location = new System.Drawing.Point(262, 201);
            this.label_serverDurum.Name = "label_serverDurum";
            this.label_serverDurum.Size = new System.Drawing.Size(16, 15);
            this.label_serverDurum.TabIndex = 3;
            this.label_serverDurum.Text = "...";
            this.label_serverDurum.Click += new System.EventHandler(this.label_serverDurum_Click);
            // 
            // tabPage_servereBaglan
            // 
            this.tabPage_servereBaglan.BackColor = System.Drawing.Color.Transparent;
            this.tabPage_servereBaglan.Controls.Add(this.label2);
            this.tabPage_servereBaglan.Controls.Add(this.label1);
            this.tabPage_servereBaglan.Controls.Add(this.button_baglantiKopar);
            this.tabPage_servereBaglan.Controls.Add(this.button_baglan);
            this.tabPage_servereBaglan.Controls.Add(this.textBox_sunucuPort);
            this.tabPage_servereBaglan.Controls.Add(this.textBox_sunucuIP);
            this.tabPage_servereBaglan.Location = new System.Drawing.Point(4, 24);
            this.tabPage_servereBaglan.Name = "tabPage_servereBaglan";
            this.tabPage_servereBaglan.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_servereBaglan.Size = new System.Drawing.Size(792, 422);
            this.tabPage_servereBaglan.TabIndex = 1;
            this.tabPage_servereBaglan.Text = "Servere Bağlan";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(410, 124);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "Server PORT";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(262, 124);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "Server IP";
            // 
            // button_baglantiKopar
            // 
            this.button_baglantiKopar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button_baglantiKopar.Enabled = false;
            this.button_baglantiKopar.Location = new System.Drawing.Point(262, 213);
            this.button_baglantiKopar.Name = "button_baglantiKopar";
            this.button_baglantiKopar.Size = new System.Drawing.Size(248, 23);
            this.button_baglantiKopar.TabIndex = 3;
            this.button_baglantiKopar.Text = "Bağlantıyı Kopar";
            this.button_baglantiKopar.UseVisualStyleBackColor = true;
            this.button_baglantiKopar.Click += new System.EventHandler(this.button_baglantiKopar_Click);
            // 
            // button_baglan
            // 
            this.button_baglan.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button_baglan.Location = new System.Drawing.Point(262, 171);
            this.button_baglan.Name = "button_baglan";
            this.button_baglan.Size = new System.Drawing.Size(248, 36);
            this.button_baglan.TabIndex = 2;
            this.button_baglan.Text = "Bağlan";
            this.button_baglan.UseVisualStyleBackColor = true;
            this.button_baglan.Click += new System.EventHandler(this.button_baglan_Click);
            // 
            // textBox_sunucuPort
            // 
            this.textBox_sunucuPort.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBox_sunucuPort.Location = new System.Drawing.Point(410, 142);
            this.textBox_sunucuPort.Name = "textBox_sunucuPort";
            this.textBox_sunucuPort.PlaceholderText = "Port";
            this.textBox_sunucuPort.Size = new System.Drawing.Size(100, 23);
            this.textBox_sunucuPort.TabIndex = 1;
            this.textBox_sunucuPort.Text = "44";
            // 
            // textBox_sunucuIP
            // 
            this.textBox_sunucuIP.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBox_sunucuIP.Location = new System.Drawing.Point(262, 142);
            this.textBox_sunucuIP.Name = "textBox_sunucuIP";
            this.textBox_sunucuIP.PlaceholderText = "Sunucu IP";
            this.textBox_sunucuIP.Size = new System.Drawing.Size(142, 23);
            this.textBox_sunucuIP.TabIndex = 0;
            this.textBox_sunucuIP.Text = "127.0.0.1";
            // 
            // tabPage_mesajGonder
            // 
            this.tabPage_mesajGonder.BackColor = System.Drawing.Color.Transparent;
            this.tabPage_mesajGonder.Controls.Add(this.label3);
            this.tabPage_mesajGonder.Controls.Add(this.label_kilitliMesajAdet);
            this.tabPage_mesajGonder.Controls.Add(this.label_gelenTopMesaj);
            this.tabPage_mesajGonder.Controls.Add(this.button_tumMesajlariYazdir);
            this.tabPage_mesajGonder.Controls.Add(this.checkBox_otomatikCoz);
            this.tabPage_mesajGonder.Controls.Add(this.textBox_mesajAnahtari);
            this.tabPage_mesajGonder.Controls.Add(this.checkBox_mesajiSifrele);
            this.tabPage_mesajGonder.Controls.Add(this.textBox_Console);
            this.tabPage_mesajGonder.Controls.Add(this.button_mesajGonder);
            this.tabPage_mesajGonder.Controls.Add(this.button_mesajEkSil);
            this.tabPage_mesajGonder.Controls.Add(this.textBox_ekliDosya);
            this.tabPage_mesajGonder.Controls.Add(this.textBox_gonderilecekMesaj);
            this.tabPage_mesajGonder.Controls.Add(this.textBox_gonderenAdi);
            this.tabPage_mesajGonder.Location = new System.Drawing.Point(4, 24);
            this.tabPage_mesajGonder.Name = "tabPage_mesajGonder";
            this.tabPage_mesajGonder.Size = new System.Drawing.Size(792, 422);
            this.tabPage_mesajGonder.TabIndex = 3;
            this.tabPage_mesajGonder.Text = "Mesaj Gönder";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(336, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 15);
            this.label3.TabIndex = 12;
            this.label3.Text = "Log Konsol:";
            // 
            // label_kilitliMesajAdet
            // 
            this.label_kilitliMesajAdet.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label_kilitliMesajAdet.Location = new System.Drawing.Point(523, 276);
            this.label_kilitliMesajAdet.Name = "label_kilitliMesajAdet";
            this.label_kilitliMesajAdet.Size = new System.Drawing.Size(164, 15);
            this.label_kilitliMesajAdet.TabIndex = 11;
            this.label_kilitliMesajAdet.Text = "Kilitli Mesaj: 0";
            this.label_kilitliMesajAdet.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label_gelenTopMesaj
            // 
            this.label_gelenTopMesaj.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label_gelenTopMesaj.AutoSize = true;
            this.label_gelenTopMesaj.Location = new System.Drawing.Point(337, 276);
            this.label_gelenTopMesaj.Name = "label_gelenTopMesaj";
            this.label_gelenTopMesaj.Size = new System.Drawing.Size(87, 15);
            this.label_gelenTopMesaj.TabIndex = 10;
            this.label_gelenTopMesaj.Text = "Alınan Mesaj: 0";
            // 
            // button_tumMesajlariYazdir
            // 
            this.button_tumMesajlariYazdir.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button_tumMesajlariYazdir.Location = new System.Drawing.Point(337, 294);
            this.button_tumMesajlariYazdir.Name = "button_tumMesajlariYazdir";
            this.button_tumMesajlariYazdir.Size = new System.Drawing.Size(350, 39);
            this.button_tumMesajlariYazdir.TabIndex = 9;
            this.button_tumMesajlariYazdir.Text = "Tüm mesajları çöz ve yazdır";
            this.button_tumMesajlariYazdir.UseVisualStyleBackColor = true;
            this.button_tumMesajlariYazdir.Click += new System.EventHandler(this.button_tumMesajlariYazdir_Click);
            // 
            // checkBox_otomatikCoz
            // 
            this.checkBox_otomatikCoz.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.checkBox_otomatikCoz.AutoSize = true;
            this.checkBox_otomatikCoz.Location = new System.Drawing.Point(336, 238);
            this.checkBox_otomatikCoz.Name = "checkBox_otomatikCoz";
            this.checkBox_otomatikCoz.Size = new System.Drawing.Size(217, 19);
            this.checkBox_otomatikCoz.TabIndex = 8;
            this.checkBox_otomatikCoz.Text = "Gelen Kilitli Mesajları Çöz (xxxxxxxx)";
            this.checkBox_otomatikCoz.UseVisualStyleBackColor = true;
            this.checkBox_otomatikCoz.CheckedChanged += new System.EventHandler(this.checkBox_otomatikCoz_CheckedChanged);
            // 
            // textBox_mesajAnahtari
            // 
            this.textBox_mesajAnahtari.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBox_mesajAnahtari.Location = new System.Drawing.Point(98, 149);
            this.textBox_mesajAnahtari.MaxLength = 8;
            this.textBox_mesajAnahtari.Name = "textBox_mesajAnahtari";
            this.textBox_mesajAnahtari.PlaceholderText = "Anahtar (Kilit)";
            this.textBox_mesajAnahtari.Size = new System.Drawing.Size(217, 23);
            this.textBox_mesajAnahtari.TabIndex = 7;
            this.textBox_mesajAnahtari.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_mesajAnahtari.TextChanged += new System.EventHandler(this.textBox_mesajAnahtari_TextChanged);
            // 
            // checkBox_mesajiSifrele
            // 
            this.checkBox_mesajiSifrele.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.checkBox_mesajiSifrele.Location = new System.Drawing.Point(98, 176);
            this.checkBox_mesajiSifrele.Name = "checkBox_mesajiSifrele";
            this.checkBox_mesajiSifrele.Size = new System.Drawing.Size(232, 44);
            this.checkBox_mesajiSifrele.TabIndex = 6;
            this.checkBox_mesajiSifrele.Text = "Yollanacak Mesaji SPN-16 ile şifrele\r\n(Varsayılan anahtar değeri \'xxxxxxxx\')";
            this.checkBox_mesajiSifrele.UseVisualStyleBackColor = true;
            // 
            // textBox_Console
            // 
            this.textBox_Console.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBox_Console.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.textBox_Console.ForeColor = System.Drawing.SystemColors.Info;
            this.textBox_Console.Location = new System.Drawing.Point(336, 28);
            this.textBox_Console.Name = "textBox_Console";
            this.textBox_Console.Size = new System.Drawing.Size(351, 204);
            this.textBox_Console.TabIndex = 5;
            this.textBox_Console.Text = "";
            // 
            // button_mesajGonder
            // 
            this.button_mesajGonder.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button_mesajGonder.Location = new System.Drawing.Point(98, 226);
            this.button_mesajGonder.Name = "button_mesajGonder";
            this.button_mesajGonder.Size = new System.Drawing.Size(217, 31);
            this.button_mesajGonder.TabIndex = 4;
            this.button_mesajGonder.Text = "Mesaji Gönder";
            this.button_mesajGonder.UseVisualStyleBackColor = true;
            this.button_mesajGonder.Click += new System.EventHandler(this.button_mesajGonder_Click);
            // 
            // button_mesajEkSil
            // 
            this.button_mesajEkSil.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button_mesajEkSil.Location = new System.Drawing.Point(276, 120);
            this.button_mesajEkSil.Name = "button_mesajEkSil";
            this.button_mesajEkSil.Size = new System.Drawing.Size(39, 23);
            this.button_mesajEkSil.TabIndex = 3;
            this.button_mesajEkSil.Text = "Sil";
            this.button_mesajEkSil.UseVisualStyleBackColor = true;
            this.button_mesajEkSil.Click += new System.EventHandler(this.button_mesajEkSil_Click);
            // 
            // textBox_ekliDosya
            // 
            this.textBox_ekliDosya.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBox_ekliDosya.Cursor = System.Windows.Forms.Cursors.Hand;
            this.textBox_ekliDosya.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.textBox_ekliDosya.Location = new System.Drawing.Point(98, 120);
            this.textBox_ekliDosya.Name = "textBox_ekliDosya";
            this.textBox_ekliDosya.PlaceholderText = "Ekli Dosya (...)";
            this.textBox_ekliDosya.ReadOnly = true;
            this.textBox_ekliDosya.Size = new System.Drawing.Size(172, 23);
            this.textBox_ekliDosya.TabIndex = 2;
            this.textBox_ekliDosya.Text = "Ekli Dosya (...)";
            this.textBox_ekliDosya.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_ekliDosya.MouseClick += new System.Windows.Forms.MouseEventHandler(this.textBox_ekliDosya_MouseClick);
            // 
            // textBox_gonderilecekMesaj
            // 
            this.textBox_gonderilecekMesaj.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBox_gonderilecekMesaj.Location = new System.Drawing.Point(98, 57);
            this.textBox_gonderilecekMesaj.Multiline = true;
            this.textBox_gonderilecekMesaj.Name = "textBox_gonderilecekMesaj";
            this.textBox_gonderilecekMesaj.PlaceholderText = "Mesaj İçeriği";
            this.textBox_gonderilecekMesaj.Size = new System.Drawing.Size(217, 57);
            this.textBox_gonderilecekMesaj.TabIndex = 1;
            // 
            // textBox_gonderenAdi
            // 
            this.textBox_gonderenAdi.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBox_gonderenAdi.Location = new System.Drawing.Point(98, 28);
            this.textBox_gonderenAdi.Name = "textBox_gonderenAdi";
            this.textBox_gonderenAdi.PlaceholderText = "Gönderici İmzanız";
            this.textBox_gonderenAdi.Size = new System.Drawing.Size(217, 23);
            this.textBox_gonderenAdi.TabIndex = 0;
            // 
            // label_spnKeyOnizleme
            // 
            this.label_spnKeyOnizleme.AutoSize = true;
            this.label_spnKeyOnizleme.Location = new System.Drawing.Point(410, 184);
            this.label_spnKeyOnizleme.Name = "label_spnKeyOnizleme";
            this.label_spnKeyOnizleme.Size = new System.Drawing.Size(63, 15);
            this.label_spnKeyOnizleme.TabIndex = 8;
            this.label_spnKeyOnizleme.Text = "(xxxxxxxx)";
            // 
            // textBox_dosyaYukleHash
            // 
            this.textBox_dosyaYukleHash.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBox_dosyaYukleHash.Cursor = System.Windows.Forms.Cursors.Hand;
            this.textBox_dosyaYukleHash.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.textBox_dosyaYukleHash.Location = new System.Drawing.Point(227, 76);
            this.textBox_dosyaYukleHash.Name = "textBox_dosyaYukleHash";
            this.textBox_dosyaYukleHash.PlaceholderText = "Ekli Dosya (...)";
            this.textBox_dosyaYukleHash.ReadOnly = true;
            this.textBox_dosyaYukleHash.Size = new System.Drawing.Size(339, 23);
            this.textBox_dosyaYukleHash.TabIndex = 4;
            this.textBox_dosyaYukleHash.Text = "Dosya Ekle (...)";
            this.textBox_dosyaYukleHash.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControl1);
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(816, 489);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage_mesajSifrele.ResumeLayout(false);
            this.tabPage_mesajSifrele.PerformLayout();
            this.panel_SifrelemeYontemi.ResumeLayout(false);
            this.panel_SifrelemeYontemi.PerformLayout();
            this.tabPage_dosyaHashle.ResumeLayout(false);
            this.tabPage_dosyaHashle.PerformLayout();
            this.tabPage_serverOl.ResumeLayout(false);
            this.tabPage_serverOl.PerformLayout();
            this.tabPage_servereBaglan.ResumeLayout(false);
            this.tabPage_servereBaglan.PerformLayout();
            this.tabPage_mesajGonder.ResumeLayout(false);
            this.tabPage_mesajGonder.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_serverStartStop;
        private System.Windows.Forms.TextBox textBox_portum;
        private System.Windows.Forms.TabControl tabControl1;
        public System.Windows.Forms.TabPage tabPage_serverOl;
        private System.Windows.Forms.Label label_serverDurum;
        private System.Windows.Forms.TabPage tabPage_servereBaglan;
        private System.Windows.Forms.Button button_baglan;
        private System.Windows.Forms.TextBox textBox_sunucuPort;
        private System.Windows.Forms.TextBox textBox_sunucuIP;
        private System.Windows.Forms.TabPage tabPage_mesajSifrele;
        private System.Windows.Forms.TabPage tabPage_mesajGonder;
        private System.Windows.Forms.Button button_mesajGonder;
        private System.Windows.Forms.Button button_mesajEkSil;
        private System.Windows.Forms.TextBox textBox_ekliDosya;
        private System.Windows.Forms.TextBox textBox_gonderilecekMesaj;
        private System.Windows.Forms.TextBox textBox_gonderenAdi;
        private System.Windows.Forms.TextBox ek;
        private System.Windows.Forms.Button button_serverStop;
        private System.Windows.Forms.Button button_baglantiKopar;
        private System.Windows.Forms.RichTextBox textBox_Console;
        private System.Windows.Forms.TextBox textBox_sifrelemeAnahtar;
        private System.Windows.Forms.TextBox textBox_sifrelenecekMesaj;
        private System.Windows.Forms.Button button_mesajSifrele;
        private System.Windows.Forms.CheckBox checkBox_mesajiSifrele;
        private System.Windows.Forms.TextBox textBox_mesajAnahtari;
        private System.Windows.Forms.CheckBox checkBox_otomatikCoz;
        private System.Windows.Forms.Button button_mesajCoz;
        private System.Windows.Forms.Panel panel_SifrelemeYontemi;
        private System.Windows.Forms.RadioButton rdButton_sha256;
        private System.Windows.Forms.RadioButton rdButon_spn;
        private System.Windows.Forms.Label label_KeyForSPNOnizleme;
        private System.Windows.Forms.Label label_spnKeyOnizleme;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label_kilitliMesajAdet;
        private System.Windows.Forms.Label label_gelenTopMesaj;
        private System.Windows.Forms.Button button_tumMesajlariYazdir;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage_dosyaHashle;
        private System.Windows.Forms.TextBox textBox_dosyaYukleHsh;
        private System.Windows.Forms.TextBox textBox_dosyaYukleHash;
        private System.Windows.Forms.TextBox textBox_dosyaHash;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox textBox_sifreliMesaj;
    }
}

