using Playfair;
using ds;
using Beale;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds
{
    class Program
    {
        static void Main(string[] args)
        {


            if (args[0].Equals("Beale"))
            {

                Bealee beale = new Bealee();

                if (args[1].Equals("e"))
                {
                    string plaintext = args[3];
                    string libri = args[2];
                    Console.WriteLine(Bealee.Enkriptimi(libri, plaintext));
                }

else if (args[1].Equals("d"))
                {
                    var text = args[2];
                    string decrypt = args[3];
                    Bealee.Dekriptimi(decrypt, text);
                }
            }
            if (args[0].Equals("Playfair"))
            {
                Playfaiir playfair = new Playfaiir();

                if (args[1].Equals("e"))
                {
                    string plainText = args[3];
                    Playfaiir.initPlainText(plainText);

                    string qelesi = args[2];
                    Playfaiir.Enkriptimi(Playfaiir.Krijotabelen(qelesi), Playfaiir.Krijoplaintekstiin());
                } else if (args[1].Equals("d"))
                {
                    string plainText = args[3];
                    Playfaiir.initPlainText(plainText);

                    string qelesi = args[2];



                    Playfaiir.Dekriptimi(Playfaiir.Krijotabelen(qelesi), Playfaiir.Krijoplaintekstiin());
                }

                Console.ReadKey();

            }
