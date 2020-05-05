using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography;


namespace deleteuser
{
    class deleteuser
    {
        static void Main(string[] args)
        {
            //argumenti i pare emri i celesit
            string KeyName = args[0];
            //path ku do te ruhet celesi
            string KeyPath = "C://keys";
            if (args.Length == 1)
             {
              
              string publik = String.Concat(KeyPath, "\\", KeyName, ".pub", ".xml");
              string privat = String.Concat(KeyPath, "\\", KeyName, ".xml");
                //funksioni qe sherben per te shiquar se a ekziston paraprakisht celesi
              bool DoesKeyExist(string name)
                {
                   //krijimi i CspParameters
                    var cspParams = new CspParameters
                    {

                        Flags = CspProviderFlags.UseExistingKey | CspProviderFlags.UseMachineKeyStore,


                        KeyContainerName = name
                    };

                    try
                    {
                        //krijimi i nje instance te re te RSACryptoServiceProvider() qe merr si paramater cspParams qe i krijuam 
                        //me pare
                        var rsa = new RSACryptoServiceProvider(cspParams);



                    }
                    catch (Exception)
                    {
                        return false;
                    }
                    return true;

                }
                //nese ekziston ai celes
               if (DoesKeyExist(KeyName))
                {
                     
                   //nese ekzistojn Path te dhene
                    if (File.Exists(Path.Combine(KeyPath, privat)) && File.Exists(Path.Combine(KeyPath, publik)))
                    {
                        var cp = new CspParameters
                        {
                            KeyContainerName = KeyName,
                            Flags = CspProviderFlags.UseExistingKey | CspProviderFlags.UseMachineKeyStore,
                        };


                    
                        var rsa = new RSACryptoServiceProvider(cp)
                        {
                            //fshij permbajtjen e atij celesi
                            PersistKeyInCsp = false
                        };
                        rsa.Clear();
                        //fshij edhe file qe e permbajn celesin me emrin e dhene
                        File.Delete(Path.Combine(KeyPath, privat));
                        File.Delete(Path.Combine(KeyPath, publik));
                        //paraqit mesazhet e caktuara
                        Console.WriteLine("Eshte larguar celesi privat " + String.Concat("keys/", KeyName, ".xml"));
                        Console.WriteLine("Eshte larguar celesi publik " + String.Concat("keys/", KeyName, ".pub", ".xml"));
                    }
                   
                    //nese ekziston vetem celesi publik
                     else if (File.Exists(Path.Combine(KeyPath, publik)))
                    {
                        

                        var cp = new CspParameters
                        {
                            KeyContainerName = KeyName,
                            Flags = CspProviderFlags.UseExistingKey | CspProviderFlags.UseMachineKeyStore,
                        };


                        
                        var rsa = new RSACryptoServiceProvider(cp)
                        {
                           //ateher fshije permbajtjen e atij celesi 
                            PersistKeyInCsp = false
                        };
                        rsa.Clear();
                         //fshije edhe file qe e permban ate celes
                        File.Delete(Path.Combine(KeyPath, publik));
                        Console.WriteLine("Eshte larguar celesi publik " + String.Concat("keys/", KeyName, ".pub", ".xml"));

                    }

                }
                //nese celesi nuk ekziston paraqite kete mesazh
                 else if (!DoesKeyExist(KeyName))
                {
                    Console.WriteLine("Celesi " + KeyName + " nuk ekziston.");
                }
            }
            else
            { 
                
                //nese shenon argumente me shume se sa qe duhet
                  Console.WriteLine("Shenoni vetem  1 argument:KeyName");
               
            }
        }
    }
}
