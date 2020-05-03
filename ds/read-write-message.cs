using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography;

namespace read_write_mesage
{
    class Program
    {
        static RSACryptoServiceProvider objRSA = new RSACryptoServiceProvider();
        static void Main(string[] args)
        {   //Qelesi i DES me rng
            RNGCryptoServiceProvider rngCsp = new RNGCryptoServiceProvider();
            byte[] byteArray = new byte[8];
            rngCsp.GetBytes(byteArray);
            
          
                    //Me lexu qelsin Public te marresit qe e shkrujam
                string PubKey = File.ReadAllText(@"C://Users//ThinkPad T440//source//repos//DES1//create-user//bin//Debug//keys//mire.pb.xml");
                
                //Per emrin
                byte[] name = Encoding.UTF8.GetBytes(args[1]);
                //Ketu emrin po e kthejm ne base64
                string part1 = Convert.ToBase64String(name);
                //Per qelsin dhe IV
                DESCryptoServiceProvider objDes = new DESCryptoServiceProvider(); //Des instanca objDES
                  //IV e gjeneruar random 8 bytes
                objDes.GenerateIV();
                string part2 = Convert.ToBase64String(objDes.IV);
                 //Qelesi i gjeneruar random 8 bytes
                objDes.GenerateKey();
                 //Qelesi i konvertuar ne Base64
                string keyStr = Convert.ToBase64String(objDes.Key);

                string plaintexti=args[2];
                string mesazhiiEnkriptuar=Encrypt(plaintexti,keyStr);
                byte[] mesazhi=Encoding.UTF8.GetBytes(mesazhiiEnkriptuar);
                string part3=Convert.ToBase64String(mesazhi);

                Console.WriteLine(part1 + "." + part2+ "." + part3);
                if(args[]!=0)
                {
                    Console.WriteLine(Encrypt(args[1]));

                    string strXmlParameters = objRSA.ToXmlString(true);
                    StreamWriter sw = new StreamWriter("exportedKeys.xml");
                    sw.Write(strXmlParameters);
                    sw.Close();
                    Console.WriteLine("Mesazhi i enkriptuar u ruajt ne fajllin :"+"exportedKeys.xml");

                }
                try
                    {
                        {
                            string Pathi = args[3];
                            var fs = new FileStream(
                                String.Concat(Pathi,".txt"), FileMode.Create);


                            using (StreamWriter sw = new StreamWriter(fs))
                            {

                                sw.WriteLine();
                            }
                        }
                        Console.WriteLine("Mesazhi i enkriptuar u ruajt ne fajllin " + String.Concat(Pathi,".txt"));
                    }
                 catch
                    {
                        Console.WriteLine("Eshte shfaqur nje problem gjate krijimit te fajllit");
                    }
                }
            }
            
      //Enkriptimi i Mesazhit me DES me celsin e gjeneruar me ane te RNGCryptoServiceProvider dhe me IV e instances DES te gjenerar rastesisht
      public static byte[] EnkriptimiIMesazhit(string mesazhi, byte[] Key, byte[] IV)
      {
            try
            {
                DESalg.Mode = CipherMode.CBC;
                // Create a MemoryStream.
                MemoryStream mStream = new MemoryStream();

                // Create a CryptoStream using the MemoryStream
                // and the passed key and initialization vector (IV).
                CryptoStream cStream = new CryptoStream(mStream,
                    new DESCryptoServiceProvider().CreateEncryptor(Key, IV),
                    CryptoStreamMode.Write);

                // Convert the passed string to a byte array.
                byte[] toEncrypt = new ASCIIEncoding().GetBytes(mesazhi);

                // Write the byte array to the crypto stream and flush it.
                cStream.Write(toEncrypt, 0, toEncrypt.Length);
                cStream.FlushFinalBlock();

                // Get an array of bytes from the
                // MemoryStream that holds the
                // encrypted data.
                byte[] ret = mStream.ToArray();

                // Close the streams.
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
                // Create a new MemoryStream using the passed
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
                //Create a new instance of RSACryptoServiceProvider.
                using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
                {
                    string strXmlParameters = "";
                    StreamReader sr = new StreamReader(pathi);
                    strXmlParameters = sr.ReadToEnd();
                    sr.Close();
                    
                    //Import the RSA Key information. This only needs
                    //toinclude the public key information.
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
      }
        
}
