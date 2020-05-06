using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography;

namespace ds
{
  public class read_write
   {
        static DESCryptoServiceProvider DESalg = new DESCryptoServiceProvider();
        static RSACryptoServiceProvider RSA = new RSACryptoServiceProvider();
       
            
      //Enkriptimi i Mesazhit me DES me celsin e gjeneruar me ane te RNGCryptoServiceProvider dhe me IV e instances DES te gjenerar rastesisht
      public static byte[] EnkriptimiIMesazhit(string mesazhi, byte[] Key, byte[] IV)
      {
            try
            {
                DESalg.Mode = CipherMode.CBC;
                // Krijimi i nje  MemoryStream.
                MemoryStream mStream = new MemoryStream();

                // Krijimi i CryptoStream duke perdorur MemoryStream,
                // celesin  dhe  initialization vector (IV).
                CryptoStream cStream = new CryptoStream(mStream,
                    new DESCryptoServiceProvider().CreateEncryptor(Key, IV),
                    CryptoStreamMode.Write);

                //Konverton stringun ne nje byte array.
                byte[] toEncrypt = new ASCIIEncoding().GetBytes(mesazhi);

                // Write the byte array to the crypto stream and flush it.
                cStream.Write(toEncrypt, 0, toEncrypt.Length);
                cStream.FlushFinalBlock();

                // Get an array of bytes from the
                // MemoryStream that holds the
                // encrypted data.
                byte[] ret = mStream.ToArray();

                //Mbylli streams.
                cStream.Close();
                mStream.Close();

                // Return the encrypted buffer.
                return ret;
            }
            catch (CryptographicException e)
            {
                Console.WriteLine("A Cryptographic error occurred: {0}", e.Message);
                return null;
            }
      }
     //Dekriptimi i Mesazhit me qelsin e dekriptuar nga objekti i RSA 
     public static string DekriptimiIMesazhit(byte[] Data, byte[] Key, byte[] IV)
     {
            try
            {
                // Krijo nje MemoryStream duke perdorur
                // array of encrypted data.
                DESalg.Mode = CipherMode.CBC;
                MemoryStream msDecrypt = new MemoryStream(Data);

                // Create a CryptoStream using the MemoryStream
                // and the passed key and initialization vector (IV).
                CryptoStream csDecrypt = new CryptoStream(msDecrypt,
                    new DESCryptoServiceProvider().CreateDecryptor(Key, IV),
                    CryptoStreamMode.Read);

                // Create buffer to hold the decrypted data.
                byte[] fromEncrypt = new byte[Data.Length];

                // Read the decrypted data out of the crypto stream
                // and place it into the temporary buffer.
                csDecrypt.Read(fromEncrypt, 0, fromEncrypt.Length);

                //Convert the buffer into a string and return it.
                return new ASCIIEncoding().GetString(fromEncrypt);
            }
            catch (CryptographicException e)
            {
                Console.WriteLine("A Cryptographic error occurred: {0}", e.Message);
                return null;
            }
       }
       //Enkriptimi i qelsit te DES-it me qelsin publik te merrsit
      public static byte[] RSAEncrypt(byte[] DataToEncrypt, string pathi)
      {
            try
            {
                byte[] encryptedData;
             //  Inicializon një objekt RSA nga informacioni kryesor .
                using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
                {
                    string strXmlParameters = "";
                    StreamReader sr = new StreamReader(pathi);
                    strXmlParameters = sr.ReadToEnd();
                    sr.Close();
                    //Importon informacionet e celesit RSA.
                  //nese  nevojiten vetem informacionet e celesit publik
                   
                    RSA.FromXmlString(strXmlParameters);
                    //Encrypt the passed byte array and specify OAEP padding(true) 
                    encryptedData = RSA.Encrypt(DataToEncrypt, true);
                }
                return encryptedData;
            }
            //Catch and display a CryptographicException  
            //to the console.
            catch (CryptographicException e)
            {
                Console.WriteLine(e.Message);

                return null;
            }
        //Dekriptimi i te dhenave perkatesisht i qelsit qe e marrim me ane te funskionit ConvertFromBase64String 
          //Duke perdorur qelsin privat te emrit qe e ka marr nga Consola. 
        public static byte[] RSADecrypt(byte[] DataToDecrypt, string pathi)
        {
            try
            {
                byte[] decryptedData;
                //Create a new instance of RSACryptoServiceProvider.
                using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
                {
                    string strXmlParameters = "";
                    StreamReader sr = new StreamReader(pathi);
                    strXmlParameters = sr.ReadToEnd();
                    sr.Close();

                    RSA.FromXmlString(strXmlParameters);
                    //Importo  RSA Key informacionet. Duhet
                    //te permbaj dhe informacione te private key.
                    // RSA.ImportParameters(RSAKeyInfo);

                    //Decrypt the passed byte array and specify OAEP padding.  
                    //OAEP padding is only available on Microsoft Windows XP or
                    //later.  
                    decryptedData = RSA.Decrypt(DataToDecrypt, true);
                }
                return decryptedData;
            }
            //Catch and display a CryptographicException  
            //to the console.
            catch (CryptographicException e)
            {
                Console.WriteLine(e.ToString());

                return null;
            }
        }
          
    }
        
}
