using System;
using System.IO;
using System.Security.Cryptography;
using System.Net;

namespace ds
{
  public  class import
    {
        public static void Import(string Keyname,string shtegu)
        {

            string privat = "C:\\keys\\" + Keyname + ".xml";
            string publik = "C:\\keys\\" + Keyname + ".pub.xml";
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
                      //Nëse çelësi që po importohet është privat, atëherë automatikisht do ta gjenerohet edhe pjesa publike dhe do te ruhen të dyt në
                       //direktoriumin e çelësave.
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
                        {//Perndryshe nese permbajtja eshte vetme me Modulus dhe Exponent atehere ruhet vetem qelesi publik.
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
           
        else if (!(File.Exists(shtegu)))
            {
                Console.Write("Gabim: Fajlli i dhene nuk eshte celes valid.");
            }
            else
            {
                Console.Write("Gabim: Fajlli i dhene nuk eshte celes valid.");
            }
        }
  }
}
