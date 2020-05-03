using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Security.Cryptography;
using System.IO;
using System.Xml.Serialization;

bool DoesKeyExist(string name)
                {

                    var cspParams = new CspParameters
                    {

                        Flags = CspProviderFlags.UseExistingKey | CspProviderFlags.UseMachineKeyStore,


                        KeyContainerName = name
                    };

                    try
                    {
                        var rsa = new RSACryptoServiceProvider(cspParams);
                    }
                    catch (Exception)
                    {
                        return false;
                    }
                    return true;
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
            
