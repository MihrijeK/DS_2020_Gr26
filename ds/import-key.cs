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
        {
            string KeyPath = args[1];
            string KeyName = args[0];
            string p1 = string.Concat(KeyName, ".xml");
            string priv = string.Concat("key\\", p1);
            string p2 = string.Concat(KeyName, ".pub.xml");
            string pub = string.Concat("key\\", p2);
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
                
 if (args[1].Contains("https://"))
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(args[1]);
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                    {
                        string html = reader.ReadToEnd();
                        StreamWriter pu = new StreamWriter(pub);
                        pu.Write(html);
                        pu.Close();
                    }
                }

                Console.ReadLine();
                Console.WriteLine("Celesi publik u ruajt ne fajllin " + pub);
            }
            
