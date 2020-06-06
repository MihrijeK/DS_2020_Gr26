using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography;
using System.Text.RegularExpressions;


namespace ds
{
    class Createuser
    {
            string pass = "";
            string pass1 = "";
            Console.Write("Enter password:");
             do
            {
             ConsoleKeyInfo key = Console.ReadKey(true);
           
        //krjimi i nje funksioni qe shperben per krijimin e celesave
       public static void Krijo(string KeyName)
        {
           //Folderi ku duam ta ruajm celesin
             string KeyPath = "C://keys";
             if (!(Directory.Exists(KeyPath)))

                Directory.CreateDirectory(KeyPath);
            
           //kontrollojm se a ekziston ky celes paraprakisht
             bool DoesKeyExist(string name)
              {
               //krijimi i CspParametrave
                  var cspParams = new CspParameters
                  {
                    Flags = CspProviderFlags.UseExistingKey | CspProviderFlags.UseMachineKeyStore,
                    KeyContainerName = name
                  };
               
                // e inicializojm nje instance te RSACryptoServiceProvider() klases me parametra te specifikuar
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
            
            //nese ky celes ekziston me pare shfaq kete mesazh
             //nese ky celes ekziston me pare shfaq kete mesazh
            if (DoesKeyExist(KeyName))
            {
                Console.WriteLine("Gabim:Shfrytezuesi " + KeyName + " ekziston paraprakisht");
            }

            //nese ky celes nuk ekziston me pare:
            if (!DoesKeyExist(KeyName))
            {




                DatabaseConnection DB = new DatabaseConnection();
                string pass = "";
                string pass1 = "";
                Console.Write("Enter password:");
                do
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    // Backspace Should Not Work
                    if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
                    {
                        pass += key.KeyChar;
                        Console.Write("*");
                    }
                    else
                    {
                        if (key.Key == ConsoleKey.Backspace && pass.Length > 0)
                        {
                            pass = pass.Substring(0, (pass.Length - 1));
                            Console.Write("\b \b");
                        }
                        else if (key.Key == ConsoleKey.Enter)
                        {
                            break;
                        }
                    }
                } while (true);
                string password = new System.Net.NetworkCredential(string.Empty, pass).Password;

                var hasNumber = new Regex(@"[0-9]+");
                var hasSymbols = new Regex(@"[!@#$%^&*()_+=\[{\]};:<>|./?,-]");
                bool validimi()
                {

                    if (password.Length < 6)
                    {
                        Console.WriteLine("\nShkruane nje password me te gjate se 6 karaktere .");
                        return false;
                    }

                    if (!hasNumber.IsMatch(password) && (!hasSymbols.IsMatch(password)))
                    {
                        Console.WriteLine("\nPassword-i duhet te permbaj se paku nje numer ose nje karakter !");
                        return false;
                    }
                    if (hasNumber.IsMatch(password) && (!hasSymbols.IsMatch(password)))
                    {
                        return true;
                    }
                    if (!hasNumber.IsMatch(password) && (hasSymbols.IsMatch(password)))
                    {
                        return true;
                    }
                    return true;
                }
                if (validimi())
                {
                    Console.Write("\nConfirm Password:");
                    do
                    {

                        ConsoleKeyInfo keyy = Console.ReadKey(true);
                        // Backspace Should Not Work
                        if (keyy.Key != ConsoleKey.Backspace && keyy.Key != ConsoleKey.Enter)
                        {
                            pass1 += keyy.KeyChar;
                            Console.Write("*");
                        }
                        else
                        {
                            if (keyy.Key == ConsoleKey.Backspace && pass1.Length > 0)
                            {
                                pass = pass.Substring(0, (pass1.Length - 1));
                                Console.Write("\b \b");
                            }
                            else if (keyy.Key == ConsoleKey.Enter)
                            {
                                break;
                            }
                        }
                    } while (true);


                    if (pass != pass1)
                    {
                        Console.WriteLine("\nPassword-at nuk perputhen !");
                    }
               
                var cp = new CspParameters();
                cp.KeyContainerName = KeyName;
                cp.Flags = CspProviderFlags.NoPrompt | CspProviderFlags.UseArchivableKey
                | CspProviderFlags.UseMachineKeyStore;
                RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(cp);
             try
             {
                //perdorimi i FileStream Class per te krijuar nje instance te re te kesaj klase me nje path specifik  
                //dhe krijimi i atij file
                var fs = new FileStream(
                String.Concat(KeyPath, "\\", KeyName, ".xml"), FileMode.Create);
                     
                //Perdorimi i StreamWriter per shkrim ne Fajllin e caktuar perkatesisht ne fajllin e krijuar (fs)
                 using (StreamWriter sw = new StreamWriter(fs))
                 {
                      //Krijon dhe kthen nje XML string permbajtje te celesit privat 
                     sw.WriteLine(rsa.ToXmlString(true));
                 }
                   
                 Console.WriteLine("Eshte krijuar celesi privat " + String.Concat("keys//", KeyName, ".xml"));
             }
             catch
             {
                 Console.WriteLine("Eshte shfaqur nje problem gjate krijimit te celesit privat");
             }

             //Kontrollojme permes try and catch nese ka ndonje gabim
            try
             {
                //Krijimi i fajllit me extension .xml ne varesi nga pathi dhe emri
                    var fs = new FileStream(
                        String.Concat(KeyPath, "\\", KeyName, ".pub", ".xml"), FileMode.Create);
               //Permes objektit sw(StreamWriter) shkruajm ne fajllin fs
                    using (StreamWriter sw = new StreamWriter(fs))
                    {     
                         //Krijon dhe kthen nje XML string permbajtje te celesit publik
                            sw.WriteLine(rsa.ToXmlString(false));
                    }
                    
                    Console.WriteLine("Eshte krijuar celesi publik " + String.Concat("keys//", KeyName, ".pub", ".xml"));
            }
           catch
           {
            Console.WriteLine("Eshte shfaqur nje problem gjate krijimit te celesit public");
           }
          }
        }
    }
}


