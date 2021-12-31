using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;
namespace soketmessasing
{
    class SocketClient
    {
        /// <summary>
        /// Bagli olunan serverin ip portunu dondurur.
        /// </summary>
        /// <returns></returns>
        public EndPoint GetRemoteEndPoint()
        {
            if (server != null)
            {
                return server.RemoteEndPoint;
            }
            else 
                return null;
        }

        public bool _isConnect = false;
        private Socket server = null;
        public List<Mesaj> gelenMesajlar = new List<Mesaj>();
       
        /// <summary>
        /// İp adresi ve port bilgisi verilen sunucuya baglanma istegi gonderir. Baglanma gerceklesirse true doner.
        /// </summary>
        /// <param name="ipAdresi"></param>
        /// <param name="port"></param>
        /// <returns>Baglantinin gerceklesip gerceklesmedigi bilgisi.</returns>
        public bool ConnectToServer(IPAddress ipAdresi, int port = 11000)
        {
            server = new Socket(ipAdresi.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                if (!_isConnect)
                {
                    server.Connect(ipAdresi, port);
                    _isConnect = true;
                    Thread th_listenServ = new Thread(DinleServer);
                    th_listenServ.Start();
                    return true;
                }
                else
                {
                    MessageBox.Show(
                       "Zaten bir servere bağlısınız.", "Bağlantı Kurulamadı",
                       MessageBoxButtons.OK,
                       MessageBoxIcon.Warning);
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message, "Bağlantı Kurulamadı",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
            return false;

        }

        /// <summary>
        /// Clientin Serverla olan baglantisni kopartir.
        /// </summary>
        public void DisconnectFromServer()
        {
            
            try
            {
                if (server != null)
                {
                    server.Dispose();
                    server = null;
                    _isConnect = false;
                }
                else
                    MessageBox.Show(
                       "Zaten bir servere bagli degilsiniz.", "Bağlantı Kesilemedi",
                       MessageBoxButtons.OK,
                       MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message, "Bağlantı Kesilemedi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }

        }

        private bool IsServerDisconnect()
        {
            try
            {

                if (server.Poll(100, SelectMode.SelectRead))
                {
                    if (!server.Connected)
                        return true;
                    // Something bad has happened, shut down
                    else
                        return false;
                    // There is data waiting to be read"
                }
            }
            catch (Exception) { }
            return false;

        }

        /// <summary>
        /// Bagli sunucuya bir mesaj gonderir.
        /// </summary>
        /// <param name="mesaj"></param>
        /// <returns></returns>
        public bool SendMessage(Mesaj mesaj)
        {
            
            if(server != null && !IsServerDisconnect())
            {
                server.SendTimeout = 1000;
                var yollanacakBytes = Serializator.ToByteArray<Mesaj>(mesaj);
                var gidenByte = server.Send(yollanacakBytes);
                
                return yollanacakBytes.Length == gidenByte;
           
            }
           

            return false;
        }

        /// <summary>
        /// Sunucudan gelen mesajlari donusturup gelenMesajlar icerisine atar. 
        /// Sürekli sunucuyu dinler
        /// </summary>
        public void DinleServer()
        {
            int gelenByte = 0;
            byte[] buffer = new byte[1024];

            while (_isConnect)
            {
                List<byte> okunanBytes = new List<byte>();
                while (server.Available > 0)
                {
                
                    //clientten okunan byte sayısı
                    gelenByte = server.Receive(buffer, 0, buffer.Length, SocketFlags.None);

                    //gelen mesajin okunan bytlarini kaydediyoruz.
                    okunanBytes.AddRange(buffer.Take(gelenByte));
                }

                //okuma bittiginde bir mesaj okunduysa donusturup gelen mesajlar listesine atiyoruz
                if (okunanBytes.Count > 0)
                {
                   
                    var alinanMesaj = Serializator.FromByteArray<Mesaj>(okunanBytes.ToArray());
  

                    gelenMesajlar.Add(alinanMesaj);
                    if (alinanMesaj.dosyaEkliMi)
                        alinanMesaj.DosyayiDisaAktar("transferedFiles/");

                }

                Thread.Sleep(1000);
            }
        }
   

    }
}
