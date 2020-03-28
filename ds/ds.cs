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


