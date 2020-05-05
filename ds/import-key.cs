using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Security.Cryptography;
using System.IO;
using System.Xml.Serialization;
using System.Net;

namespace ds
{
    class Program
    {
        static void Main(String[] args)
        {  string KeyName = args[0];
            string privat = "keys\\" + KeyName + ".xml";
            string publik = "keys\\" + KeyName + ".pub.xml";
            string shtegu = args[1];
            var cs = new CspParameters() { };
            cs.Flags = CspProviderFlags.UseMachineKeyStore;

 if (shtegu.Contains(".xml"))
            {
                if (File.Exists(shtegu))
                {
                    string l = File.ReadAllText(shtegu);
                    if (File.Exists(publik) && File.Exists(privat))
                    {
                        Console.WriteLine("Ky celes ekziston paraprakisht");

                    }

                    else
                    {
                        if (l.Contains("<P>"))
                        {

                            using (StreamReader reader = new StreamReader(shtegu))
                            {
                                string permbajtja = reader.ReadToEnd();

                                using (StreamWriter sw = new StreamWriter(privat))
                                {
                                    sw.Write(permbajtja);
                                    sw.Close();
                                    Console.WriteLine("Celesi privat u ruajt ne fajllin " + privat);
                                }
                                   using (StreamWriter sp = new StreamWriter(publik))
                                {
                                    RSACryptoServiceProvider rsaKey = new RSACryptoServiceProvider();
                                    rsaKey.FromXmlString(permbajtja);
                                    sp.Write(rsaKey.ToXmlString(false));
                                    Console.WriteLine("Celesi publik u ruajt ne fajllin " + publik);
                                }
                            }

                        }
                        else
                        {
                            using (StreamReader reader = new StreamReader(shtegu))
                            {

                                using (StreamWriter sw = new StreamWriter(publik))
                                {
                                    string permbajtja = reader.ReadToEnd();
                                    sw.Write(permbajtja);
                                    sw.Close();
                                }
                            }

                            Console.WriteLine("Celesi publik u ruajt ne fajllin " + publik);
                        } 
                    }
                }
                else
                {
                    Console.WriteLine("Fajlli nuk ekziston");
                }
            }
                
       else if ((shtegu.Contains("https://")) || (shtegu.Contains("http://")))
            {
                if (File.Exists(publik))
                {
                    Console.WriteLine("Ky celes ekziston paraprakisht");

                }
                else
                {
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(shtegu);
                    using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                    {
                        using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                        {
                            string html = reader.ReadToEnd();
                            StreamWriter pu = new StreamWriter(publik);
                            pu.Write(html);
                            pu.Close();
                        }
                    }

                    Console.WriteLine("Celesi publik u ruajt ne fajllin " + publik);
                }
            }
          }

    }
}
