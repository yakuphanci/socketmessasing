using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace soketmessasing
{
    class SPN_Chiper
    {

        //
        //
        /// <summary>
        /// String değeri İkilik tabanda tekrar stringe çevirir. her karakteri 8 bitlik bloklara yazar.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string StringToBinary_ASCII(string data)
        {
            if (data == null || data == "")
            {

                return "";
            }

            char[] turkishChars = { 'ş', 'ğ', 'ü', 'ç', 'ö', 'İ', 'ı' };
            char[] englishChars = { 's', 'g', 'u', 'c', 'o', 'I', 'i' };

            for (int i = 0; i < turkishChars.Length; i++)
            {

                data = data.Replace(turkishChars[i], englishChars[i]);
            }

            StringBuilder sb = new StringBuilder();

            foreach (char c in data.ToCharArray())
            {
                sb.Append(Convert.ToString(c, 2).PadLeft(8, '0'));
            }
            return sb.ToString();
        }
        
        //
        //
        /// <summary>
        /// 8 bitlik bloklara yazılmış her karakteri birleştirir ve normal bir metne dönüşütürür.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string BinaryToString_ASCII(string data)
        {
            List<Byte> byteList = new List<Byte>();
            for (int i = 0; i < data.Length; i += 8)
            {
                byteList.Add(Convert.ToByte(data.Substring(i, 8), 2));
            }
            return Encoding.ASCII.GetString(byteList.ToArray());
        }

        #region Karistirma, XOR fonksiyonlari (SPN icin)
        //
        //
        /// <summary>
        /// verilen ikilik tabandaki veriyi karıştırır.
        /// </summary>
        /// <param name="textBin"></param>
        /// <returns>Karıştırılmış veriyi döndüerür</returns>
        static String Substition(string textBin)
        {
            byte[] pIndis = { 2, 8, 12, 5, 9, 0, 14, 4, 11, 1, 15, 6, 3, 10, 7, 13 };
            String pTextBin = "";
            for (int i = 0; i < textBin.Length; i++)
            {
                pTextBin += (textBin[pIndis[i]]);
            }
            return pTextBin;
        }

        //
        //
        /// <summary>
        /// Karıştırılmış veriyi tekrar aynı düzende tersine karıştırır. 
        /// Nasıl bozduysa öyle toparlar.
        /// </summary>
        /// <param name="textBin"></param>
        /// <returns>Düzenlenmi şveriyi döndürür</returns>
        static String ReSubstition(string textBin)
        {
            byte[] rpIndis = { 5, 9, 0, 12, 7, 3, 11, 14, 1, 4, 13, 8, 2, 15, 6, 10 };
            String rpTextBin = "";
            for (int i = 0; i < textBin.Length; i++)
            {
                rpTextBin += (textBin[rpIndis[i]]);
            }
            return rpTextBin;
        }


        //
        //
        /// <summary>
        /// İki tane ikilik sistemdeki veriyi birbiri ile xor kapısına sokar sonucu dondurur.
        /// </summary>
        /// <param name="bin1"></param>
        /// <param name="bin2"></param>
        /// <returns>XOR'lanmış veriyi döndürür.</returns>
        static String XOR_bin(string bin1, string bin2)
        {
            int a = Convert.ToInt32(bin1, 2) ^ Convert.ToInt32(bin2, 2);
            return (Convert.ToString(a, 2).PadLeft(16, '0'));
        }
        #endregion

        //
        //
        /// <summary>
        /// Verilen metni, belirlenen 8 karakterli bir anahtarla şifreler.
        /// </summary>
        /// <param name="value"> Şifrelenecek Metin</param>
        /// <param name="key">Şifrelemede kullanılacak 8 karakterli anahtar.</param>
        /// <returns>Bir string array döner 0. string BinsifreliMetin, 1. string SifreliMetin</returns>
        public static string[] SPN_Sifrele(string value, string key, bool isBin = false)
        {
            //value veya key nullsa hiç işlem yapma direk null döndür.
            if (value == null || key == null)
                return new string[] { null, null };

            //veriyi 8bitlik bloklar halinde yaz.
            String binMetin = StringToBinary_ASCII(value);
            //Ama zaten 8bitlik bloklar halinde geldiyse veriyi oldugu gibi kullan.
            if (isBin)
                binMetin = value;

            //anahtar verisini 8bitlik bloklar haline getir.
            String binKey = StringToBinary_ASCII(key);
            String binSifreliMetin = String.Empty;

            //8bitlik bloklar halinde yazılmış veri 16'nın katı degilse yani iki karakterin katı değilse sonuna boş değer ekle.
            while (binMetin.Length % 16 != 0)
            {
                //ŞAYET 16'NIN KATI DEGILSE MESAJ UZUNLUGU SAGINA 0 EKLE (ÇÖZÜME ETKİ ETMEZ).
                binMetin = binMetin.PadRight(binMetin.Length + 1, '0');
            }


            //Key'i bölümle
            String[] xKey = new String[4];
            xKey[0] = binKey.Substring(0, 16);
            xKey[1] = binKey.Substring(16, 16);
            xKey[2] = binKey.Substring(32, 16);
            xKey[3] = binKey.Substring(48, 16);

            //iki karakter iki karakter birbiri ile karıştır
            for (int i = 0; i < binMetin.Length; i += 16)
            {
                String xor_text = XOR_bin(binMetin.Substring(i, 16), xKey[0]);
                String subsText = Substition(xor_text);

                xor_text = XOR_bin(subsText, xKey[1]);
                subsText = Substition(xor_text);

                xor_text = XOR_bin(subsText, xKey[2]);
                xor_text = XOR_bin(xor_text, xKey[3]);
                binSifreliMetin += xor_text;

            }
            //geri döndür.
            string[] _returns = { BinaryToString_ASCII(binSifreliMetin), binSifreliMetin };
            return _returns;
        }

        //
        //
        /// <summary>
        /// Verilen metni, belirlenen 8 karakterli bir anahtarla şifreler.
        /// </summary>
        /// <param name="value"> Çözümlenecek Metin</param>
        /// <param name="key">Çözümlemede kullanılacak 8 karakterli anahtar.(Şifrelemede kullanılan anahtarın aynısı olmalı.)</param>
        /// <returns>Bir string array döner 0. string BinçözümlenmişMetin, 1. string ÇözümlenmişMetin</returns>
        public static string[] SPN_Cozumle(string value, string key, bool isBin = false)
        {
            //null gelirse işlem yapmadan null döndür.
            if (value == null || key == null )
                return new string[] { "", "" };

            //8 bitlik bloklar haline getir.
            String binSifreliMetin = StringToBinary_ASCII(value);
            //zaten öyleyse orjinal halini kullan.
            if (isBin)
                binSifreliMetin = value;

            //veriyi 8bitlerden olusan iki blogun katı haline tamamla.
            while (binSifreliMetin.Length % 16 != 0)
            {
                //ŞAYET 16'NIN KATI DEGILSE MESAJ UZUNLUGU SAGINA 0 EKLE (ÇÖZÜME ETKİ ETMEZ).
                binSifreliMetin = binSifreliMetin.PadRight(binSifreliMetin.Length + 1, '0');
            }

            //anahtari 8bitlik bloklar halinde yaz.
            String binKey = StringToBinary_ASCII(key);
            String cozumlenmisMetinBin = String.Empty;

            //Key'i bölümle
            String[] xKey = new String[4];
            xKey[0] = binKey.Substring(0, 16);
            xKey[1] = binKey.Substring(16, 16);
            xKey[2] = binKey.Substring(32, 16);
            xKey[3] = binKey.Substring(48, 16);

            for (int i = 0; i < binSifreliMetin.Length; i += 16)
            {
                String reXor = XOR_bin(binSifreliMetin.Substring(i, 16), xKey[3]);
                reXor = XOR_bin(reXor, xKey[2]);

                String reSubsText = ReSubstition(reXor);

                reXor = XOR_bin(reSubsText, xKey[1]);
                reSubsText = ReSubstition(reXor);

                reXor = XOR_bin(reSubsText, xKey[0]);
                cozumlenmisMetinBin += reXor;

            }

       
        //
        //
            string[] _returns = { BinaryToString_ASCII(cozumlenmisMetinBin), cozumlenmisMetinBin };
            return _returns;
        }

  
    }

}
