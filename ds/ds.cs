using Playfair;
using ds;
using Beale;
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
                else{
                    Console.WriteLine("Ju lutem shenoni 4 argumente:args[0]-Beale,args[1]-e/d,args[2]-libri.txt,args[3]-plaintext/ciphertext");
                    }
            }
            if (args[0].Equals("Playfair"))
            {
                Playfair playfair = new Playfair();

                if (args[1].Equals("encrypt"))
                {
                    string plainText = args[3];
                    Playfair.initPlainText(plainText);

                    string qelesi = args[2];
                    Playfair.Enkriptimi(Playfair.Krijotabelen(qelesi), Playfair.Krijoplaintekstiin());
                } else if (args[1].Equals("decrypt"))
                {
                    string plainText = args[3];
                    Playfair.initPlainText(plainText);

                    string qelesi = args[2];



                    Playfair.Dekriptimi(Playfair.Krijotabelen(qelesi), Playfair.Krijoplaintekstiin());
                }

                Console.ReadKey();

            }
            if (args[0].Equals("morse-code"))
            {
               Fjalori morse = new Fjalori();

                string input = args[2];
                string encode_decode = args[1];
                Morse m = new Morse(input);
                // Metoda audio() perkrahet vetem ne Windows
                if (encode_decode == "audio")
                {
                    m.audio(input);
                }
                else
                {
                    Console.WriteLine("{1}", m.GetInput(), m.Perkthe(encode_decode));
            
                }
            }
        }
    }
}   
