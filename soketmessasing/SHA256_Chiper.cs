using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace soketmessasing
{
    class SHA256_Chiper
    {
      
        /// <summary>
        /// Parametre olarak gonderilen string veriyi SHA-256 algoritmasina gore hashleyerek geri dondurur.
        /// </summary>
        /// <param name="randomString">Hashlenecek herhangi bir string veri.</param>
        /// <returns>Paremetre olarak aldığı string verinin hash halini döndürür.</returns>
        public static string StringToHash(string randomString)
        {
            var crypt = new SHA256Managed();
            var hash = new StringBuilder();
            byte[] crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(randomString));
            foreach (byte theByte in crypto)
            {
                hash.Append(theByte.ToString("x2"));
            }
            return hash.ToString();
        }

        /// <summary>
        /// Parametre olarak aldıgı byteArrayi hashler.
        /// </summary>
        /// <param name="fileBytes"></param>
        /// <returns>hashlenmis byte array verisini dondurur.</returns>
        public static string FileToHash(byte[] fileBytes)
        {
            using (SHA256 mySHA256 = SHA256.Create())
            {
                // Compute the hash of the fileStream.
                byte[] hashValue = mySHA256.ComputeHash(fileBytes);
                // Write the name and hash value of the file to the console.

                return ByteArrayToString(hashValue);
             
            }
        }

        // Display the byte array in a readable format.
        private static string ByteArrayToString(byte[] array)
        {
            var hash = "";
            for (int i = 0; i < array.Length; i++)
            {
                hash += array[i].ToString("x2");
            }
            return hash;
        }


    }
}
