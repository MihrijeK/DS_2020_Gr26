using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Configuration;
using System.Security.Permissions;

namespace write_mesage
{
    class Program
    {
        static RSACryptoServiceProvider objRSA = new RSACryptoServiceProvider();
        static void Main(string[] args)
        {   //Qelesi i DES me rng
            RNGCryptoServiceProvider rngCsp = new RNGCryptoServiceProvider();
            byte[] byteArray = new byte[8];
            rngCsp.GetBytes(byteArray);
            
            try{
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
            //Enkriptimi i qelesit te DES me RSA
            public static string Encrypti(string key)
            {
                byte[] bytePlaintexti = Encoding.UTF8.GetBytes(key);
                byte[] byteCiphertexti = objRSA.Encrypt(bytePlaintexti, true);
                return Convert.ToBase64String(byteCiphertexti);
            }
            //Enkriptimi i Mesazhit me DES
            public static byte[] EncriptimiIMesazhit(string mesazhi, byte[] Key, byte[] IV)
        {
            try
            {
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
    catch(FileNotFoundException e){
            Console.WriteLine("Gabim: Celesi publik"+this.emri+" nuk ekziston.");
    }
     
        
}
