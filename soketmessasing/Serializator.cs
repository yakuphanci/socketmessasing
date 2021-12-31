using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace soketmessasing
{
    public class Serializator
    {
        //
        //
        /// <summary>
        /// Nesneyi Byte array olarak serialize eder.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static byte[] ToByteArray<T>(T obj)
        {

            //Deger nullsa null döndür.
            if (obj == null)
                return null;
            BinaryFormatter bf = new BinaryFormatter();
            using (MemoryStream ms = new MemoryStream())
            {
                bf.Serialize(ms, obj);
                return ms.ToArray();
            }
        }

        //
        //
        /// <summary>
        /// byte array olan veriyi geri istenen türe deserialize eder.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <returns></returns>
        public static T FromByteArray<T>(byte[] data)
        {
            if (data == null)
                return default(T);
            BinaryFormatter bf = new BinaryFormatter();
            using (MemoryStream ms = new MemoryStream(data))
            {
                object obj = bf.Deserialize(ms);
                
                return (T)obj;
            }
        }

        
    }
}
