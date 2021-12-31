using System;
using System.Collections.Generic;
using System.IO;

namespace soketmessasing
{
    public class Dosya
    {
        public string filePath { get; set; }
        public string fileName { get; set; }
    }

    [Serializable]
    class Mesaj
    {
        public string gonderen;
        private string SPN_Key;
        public bool isSifreli { get; private set; }
        public bool dosyaEkliMi { get; private set; }
        public string icerik;
        public string fileName { get; private set; }
        public byte[] dosyaByte { get; private set; }
        //Mesaja dosya iliştirme fonksiyonu
        public void DosyaEkle(string filePath, string fileName)
        {
            var fileBytes = File.ReadAllBytes(filePath);
            //Dosyayı sıkıştırıp kaydediyoruz mesaja
            var compressedFileBytes = DosyaDonusumleri.Compress(fileBytes);
            this.dosyaByte = compressedFileBytes;
            this.fileName = fileName;
            dosyaEkliMi = true;
        }
        //Mesaja dosya iliştirme fonksiyonu
        public void DosyaEkle(byte[] FileAsByteArray, string fileName)
        {
            //Dosyayı sıkıştırıp kaydediyoruz mesaja
            var compressedFileBytes = DosyaDonusumleri.Compress(FileAsByteArray);
            this.dosyaByte = compressedFileBytes;
            this.fileName = fileName;
            dosyaEkliMi = true;
        }

        /// <summary>
        /// Mesajdaki verileri verilen anahtar bilgisine göre SPN şifreleme algoritmasıyla şifreler.
        /// </summary>
        /// <param name="key"></param>
        public void Sifrele(string key)
        {
            icerik = SPN_Chiper.SPN_Sifrele(icerik, key)[1];
            gonderen = SPN_Chiper.SPN_Sifrele(gonderen, key)[1];
            fileName = SPN_Chiper.SPN_Sifrele(fileName, key)[1];

            if(dosyaEkliMi)
            {
                List<string> stringArrayFile = new List<string>();
                for (int i = 0; i < dosyaByte.Length;)
                {
                    var dosyaBlock64 = Convert.ToString(dosyaByte[i], 2).PadLeft(8, '0');
                    while (++i % 8 != 0 && i < dosyaByte.Length)
                    {
                        dosyaBlock64 += Convert.ToString(dosyaByte[i], 2).PadLeft(8, '0');
                    }
                    //dosyanın sonuna geldiginde 64bitlik karakter yoksa sonunu null degerle doldur.
                    dosyaBlock64 = dosyaBlock64.PadRight(64, '0');

                    var sifreliBlock64 = SPN_Chiper.SPN_Sifrele(dosyaBlock64, key, true)[1];
                    stringArrayFile.Add(sifreliBlock64);

                }

                List<byte> byteArray = new List<byte>();
                for (int i = 0; i < stringArrayFile.Count; i++)
                {
                    var sifreliBlock64 = stringArrayFile[i];

                    byteArray.Add(Convert.ToByte(sifreliBlock64.Substring(0, 8), 2));
                    byteArray.Add(Convert.ToByte(sifreliBlock64.Substring(8, 8), 2));
                    byteArray.Add(Convert.ToByte(sifreliBlock64.Substring(16, 8), 2));
                    byteArray.Add(Convert.ToByte(sifreliBlock64.Substring(24, 8), 2));
                    byteArray.Add(Convert.ToByte(sifreliBlock64.Substring(32, 8), 2));
                    byteArray.Add(Convert.ToByte(sifreliBlock64.Substring(40, 8), 2));
                    byteArray.Add(Convert.ToByte(sifreliBlock64.Substring(48, 8), 2));
                    byteArray.Add(Convert.ToByte(sifreliBlock64.Substring(56, 8), 2));
                }

                dosyaByte = byteArray.ToArray();
               
            }
            isSifreli = true;
            SPN_Key = SPN_Chiper.SPN_Sifrele(key, key)[1];
        }
    
        /// <summary>
        /// Mesajdaki şifrelenmiş keyi parametre olarak gönderilen key açabilirse key doğrudur. 
        /// Tüm verilerin şifresini kaldırır.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool Desifrele(string key)
        {
            var sifreleyenAnahtar = SPN_Chiper.SPN_Cozumle(SPN_Key, key, true)[0];
            //Eger desifrede kullanilan anahtar sifrelemede kullanilanile ayni ise desifrele.
            if (sifreleyenAnahtar != key)
                return false;

           
            icerik = SPN_Chiper.SPN_Cozumle(icerik, key, true)[0];
            gonderen = SPN_Chiper.SPN_Cozumle(gonderen, key, true)[0];
            fileName = SPN_Chiper.SPN_Cozumle(fileName, key, true)[0];

            icerik = DosyaDonusumleri.RemoveInvalidChars(icerik);
            gonderen = DosyaDonusumleri.RemoveInvalidChars(gonderen);
            fileName = DosyaDonusumleri.RemoveInvalidChars(fileName);

            if (dosyaEkliMi)
            {
                List<string> stringArrayFile = new List<string>();
                for (int i = 0; i < dosyaByte.Length;)
                {
                    var dosyaBlock64 = Convert.ToString(dosyaByte[i], 2).PadLeft(8, '0');
                    while (++i % 8 != 0 && i < dosyaByte.Length)
                    {
                        dosyaBlock64 += Convert.ToString(dosyaByte[i], 2).PadLeft(8, '0');
                    }
                    //dosyanın sonuna geldiginde 64bitlik karakter yoksa sonunu null degerle doldur.
                    dosyaBlock64 = dosyaBlock64.PadRight(64, '0');


                    stringArrayFile.Add(dosyaBlock64);

                }

                List<byte> byteArray = new List<byte>();
                for (int i = 0; i < stringArrayFile.Count; i++)
                {
                    var sifreliBlock64 = SPN_Chiper.SPN_Cozumle(stringArrayFile[i], key, true)[1];

                    byteArray.Add(Convert.ToByte(sifreliBlock64.Substring(0, 8), 2));
                    byteArray.Add(Convert.ToByte(sifreliBlock64.Substring(8, 8), 2));
                    byteArray.Add(Convert.ToByte(sifreliBlock64.Substring(16, 8), 2));
                    byteArray.Add(Convert.ToByte(sifreliBlock64.Substring(24, 8), 2));
                    byteArray.Add(Convert.ToByte(sifreliBlock64.Substring(32, 8), 2));
                    byteArray.Add(Convert.ToByte(sifreliBlock64.Substring(40, 8), 2));
                    byteArray.Add(Convert.ToByte(sifreliBlock64.Substring(48, 8), 2));
                    byteArray.Add(Convert.ToByte(sifreliBlock64.Substring(56, 8), 2));
                }

                dosyaByte =  byteArray.ToArray();
            }

            SPN_Key = null;
            isSifreli = false;
            return true;

        }

        /// <summary>
        /// Dosyayı arzulanan klasöre çıkartır. Tabi eğer mesaj kilitli değilse.
        /// </summary>
        /// <param name="directory"></param>
        /// <returns>Dosyayı dışarı aktarıp aktarmadıgı bilgisi döner.</returns>
        public bool DosyayiDisaAktar(string directory="")
        {

            if (!isSifreli)
            {
                //Dosya sifreli degilse doyayi disari aktariyioruz. ama once decompress ediyoruz.
                var decompressedFileBytes = DosyaDonusumleri.Decompress(this.dosyaByte);
                return DosyaDonusumleri.ByteArrayToFile(decompressedFileBytes, fileName, directory);
            }
            return false;
        }
    }
}
