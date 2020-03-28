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

                Beale beale = new Beale();

                if (args[1].Equals("encrypt"))
                {
                    string plaintext = args[3];
                    string libri = args[2];
                    Console.WriteLine(Beale.Enkriptimi(libri, plaintext));
                }

               else if (args[1].Equals("decrypt"))
                {
                    var text = args[2];
                    string decrypt = args[3];
                    Beale.Dekriptimi(decrypt, text);
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
                Translator morse = new Translator();

                string input = args[2];
                string encode_decode = args[1];
                Code c = new Code(input);
                // Metoda audio() perkrahet vetem ne Windows
                if (encode_decode == "audio")
                {
                    c.audio(input);
                }
                else
                {
                    Console.WriteLine("{1}", c.GetInput(), c.Perkthe(encode_decode));
            
                }
            }
        }
    }
}   
