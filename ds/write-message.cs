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
           

            }
        }

        public static string Encrypt(string key)
        {
            byte[] bytePlaintexti = Encoding.UTF8.GetBytes(key);
            byte[] byteCiphertexti = objRSA.Encrypt(bytePlaintexti, true);

            return Convert.ToBase64String(byteCiphertexti);
        }
    }
}
