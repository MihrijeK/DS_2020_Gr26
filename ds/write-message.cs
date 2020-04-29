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
        {
            if (args[0].Equals("mire"))
            {
                //Me lexu qelsin Public te marresit qe e shkrujam
                string PubKey = File.ReadAllText(@"C://Users//ThinkPad T440//source//repos//DES1//create-user//bin//Debug//keys//mire.pb.xml");
                //Nese jepet edhe argumenti file 
                string strXmlParameters = objRSA.ToXmlString(true);
                StreamWriter sw = new StreamWriter("exportedKeys.xml");
                sw.Write(strXmlParameters);
                sw.Close();
                Console.WriteLine("Mesazhi i enkriptuar u rujt ne fajllin :" + "exportedKeys.xml");
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
        public static string Encrypt(string plaintext, string key)
        {
            byte[] bytePlaintext = Encoding.UTF8.GetBytes(plaintext);
            DESCryptoServiceProvider objDES = new DESCryptoServiceProvider();
            if (key.Length > 8 || key.Length < 8)
                return "Celesi i dhene nuk eshte adekuat !";
            objDES.Key = Encoding.UTF8.GetBytes(key);
            objDES.Padding = PaddingMode.None;
            objDES.Mode = CipherMode.CBC;
            //objDES.IV = Encoding.UTF8.GetBytes("11112222");
            objDES.GenerateIV();
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, objDES.CreateEncryptor(), CryptoStreamMode.Write);
            cs.Write(bytePlaintext, 0, bytePlaintext.Length);
            cs.Close();
            byte[] byteCiphertext = ms.ToArray();
            return Convert.ToBase64String(byteCiphertext);
    }
        
     
        
}
