using System;
using System.IO;
using System.IO.Compression;

namespace soketmessasing
{
    class DosyaDonusumleri
    {
        //
        //
        /// <summary>
        /// dosya adındaki geçersiz karakterleri siler.
        /// </summary>
        /// <param name="filename">geçersiz karakter içerebilen dosyaadı</param>
        /// <returns>geçersiz karakterlerden arınmış dosyaadını geri döndürür</returns>
        public static string RemoveInvalidChars(string filename)
        {
            return string.Concat(filename.Split(Path.GetInvalidFileNameChars()));
        }

        //
        //

        /// <summary>
        /// Byte Array olarak tutulan bir dosyayı tekrardan fiziksel diske dosya olarak kaydeder.
        /// </summary>
        /// <param name="byteArray">Dosyanın tutuldugu byte array</param>
        /// <param name="fileName">dosyanın ismi</param>
        /// <param name="directory">dosyanın kaydedileceği dizin.</param>
        /// <returns>Dosyanın kaydedildiği bilgisi eğer dosya kaydolursa true kaydolmazsa false.</returns>
        public static bool ByteArrayToFile(byte[] byteArray, string fileName, string directory = "" )
        {
            int i = 0;

            fileName = RemoveInvalidChars(fileName);

            if (!Directory.Exists(directory) && directory != "")
                Directory.CreateDirectory(directory);

            if (File.Exists(directory + fileName))
            {
                var newName = "";
                while (File.Exists(directory + (newName = fileName.Split(".")[0] + " (" + (++i) + ")." + fileName.Split(".")[1]))) ;
                fileName = newName;
            }
            try
            {
               
                using (var fs = new FileStream(directory + fileName, FileMode.Create, FileAccess.Write))
                {
                    fs.Write(byteArray, 0, byteArray.Length);
                    return true;
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, " Islem gerceklestirilirken bir hata oldu!", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning);
                return false;
            }
        }

        #region Compress Decompress Functions
        //
        //
        /// <summary>
        /// byte array olarak verilen veriyi sıkıştırır.
        /// </summary>
        /// <param name="data">sıkıştırılacak veri</param>
        /// <returns>sıkıştırılmış veriyi tekrar byte array olarak geri döndürür</returns>
        public static byte[] Compress(byte[] data)
        {
            MemoryStream output = new MemoryStream();
            using (DeflateStream dstream = new DeflateStream(output, CompressionLevel.Optimal))
            {
                dstream.Write(data, 0, data.Length);
            }
            return output.ToArray();
        }
        //
        //
        //
        /// <summary>
        /// byte array olarak sıkıtırılmıs veriyi geri genişlet. 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static byte[] Decompress(byte[] data)
        {
            MemoryStream input = new MemoryStream(data);
            MemoryStream output = new MemoryStream();
            using (DeflateStream dstream = new DeflateStream(input, CompressionMode.Decompress))
            {
                dstream.CopyTo(output);
            }
            return output.ToArray();
        }

        #endregion

    }
}
