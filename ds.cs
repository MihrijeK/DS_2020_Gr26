using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace ds
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args[0].Equals("Beale"))
            {
                  if (args.Length == 4)
                {
                     Beale beale = new Beale();

                     if (args[1].Equals("e"))
                   {
                         string plaintext = args[3];
                         string libri = args[2];
                         if (Regex.Matches(plaintext, @"[a-zA-Z]").Count != 0)
                         {
                            Console.WriteLine(Beale.Enkriptimi(libri, plaintext));
                         }
                         else
                         {
                              Console.WriteLine("Keni dhene komanda jo valide.");
                              Environment.Exit(1);
                         }
                         
                    }
                   else if (args[1].Equals("d"))
                   {
                   var text = args[2];
                   string decrypt = args[3];
                   if (Regex.Matches(decrypt, @"[0-9]").Count != 0)
                   {
                        Beale.Dekriptimi(decrypt, text);
                   }
                   else
                   {
                       Console.WriteLine("Keni dhene komanda jo valide.");
                   }
                 }
               }
                else 
                   {
                    Console.WriteLine("Ju lutem shenoni 4 argumente:args[0]-Beale,args[1]-e/d,args[2]-libri.txt,args[3]-plaintext/ciphertext");
                    Environment.Exit(1);
                   }
            }
            if (args[0].Equals("Playfair"))
            {
              Playfair playfair = new Playfair();
              if (args.Length == 4)
              {
                if (args[1].Equals("e"))
                {
                    string plainText = args[3];
                    Playfair.initPlainText(plainText);
                    string qelesi = args[2];
                    if ((Regex.Matches(plainText, @"[a-zA-Z]").Count != 0) && (Regex.Matches(qelesi, @"[a-zA-Z]").Count != 0))
                  {
                    Playfair.Enkriptimi(Playfair.Krijotabelen(qelesi), Playfair.Krijoplaintekstiin());
                  } 
                   else
                   {
                      Console.WriteLine("Keni dhene komanda jo valide.");
                   }
                }
                    else if (args[1].Equals("d"))
                {
                    string cipherText = args[3];
                    Playfair.initPlainText(cipherText);
                    string qelesi = args[2];

              if ((Regex.Matches(cipherText, @"[a-zA-Z]").Count != 0) && (Regex.Matches(qelesi, @"[a-zA-Z]").Count != 0))
              {
              Playfair.Dekriptimi(Playfair.Krijotabelen(qelesi), Playfair.Krijoplaintekstiin());
              }
              else
              {
                  Console.WriteLine("Keni dhene komanda jo valide.");
                  Environment.Exit(1);
              }
           }             
                Console.ReadKey();
              }
                else
                {
                    Console.WriteLine("Ju lutem shenoni 4 argumente:args[0]-Playfair,args[1]-e/d,args[2]-qelesi,args[3]-plaintext/ciphertext");
                    Environment.Exit(1);
                }
            }
            if (args[0].Equals("morse-code"))
            {
               if (args.Length == 3)
              {    
               Translator morse = new Translator();

                string input = args[2];
                string encode_decode = args[1];
                Code m = new Code(input);
                // Metoda audio() perkrahet vetem ne Windows
                if (encode_decode == "audio")
                {
                    m.Audio(input);
                }
                else
                {
                    Console.WriteLine("{1}", m.GetInput(), m.Perkthe(encode_decode));
            
                }
              }else
              {
                   Console.WriteLine("Ju lutem shenoni 3 argumente:args[0]-morse-code,args[1]-encode/decode,args[2]-tekst/numra/shenja/./-");
                   Environment.Exit(1);
              }
            }
            if (args[0].Equals("create-user"))
                {
                    if (args.Length == 2)
                    {
                        Createuser createe = new Createuser();

                        {
                            string KeyNName = args[1];
                            if (Regex.IsMatch(KeyNName, "^[a-zA-Z0-9_]*$"))
                            {
                                Createuser.Krijo(KeyNName);
                            }
                            else
                            {
                                Console.WriteLine("Keni dhene komanda jo valide");

                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Shenoni 2 argumente:create-user dhe KeyName");
                    }

               }
            if (args[0].Equals("delete-user"))
                {
                    if (args.Length == 2)
                    {
                        Deleteuser deleteuuser = new Deleteuser();
                        string KeyNName = args[1];
                        Deleteuser.Largo(KeyNName);
                    }
                    else
                    {
                        Console.WriteLine("Shenoni 2 argumente:delete-user dhe KeyName");
                    }
                }
            
        }
    }
}   
