using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Security.Cryptography;
using System.IO;
using System.Xml.Serialization;
namespace ds
{
    class exportkey
    {
        public static void Eksporti(string KeyName, string PP, string exportfolder)
        {

            if (PP == "public")
            {
                 string pub = "C:\\keys\\" + KeyName + ".pub.xml";
                if (File.Exists(pub))
                {
                    using (StreamReader reader = new StreamReader(pub))
                    {
                        string html = reader.ReadToEnd();

                        RSACryptoServiceProvider objRSAa = new RSACryptoServiceProvider();
                       using (StreamWriter sp = new StreamWriter(Path.Combine(exportfolder)))
                        {
                           RSACryptoServiceProvider rsaKey = new RSACryptoServiceProvider();
                            rsaKey.FromXmlString(html);
                            sp.Write(rsaKey.ToXmlString(false));
                         }
                        Console.WriteLine("Celesi publik u ruajt ne fajllin " + exportfolder + ".");
                    }
                }
                else
                {
                    Console.WriteLine("Gabim: Celesi public " + KeyName + " nuk ekziston.");

                }
               
            }

          
