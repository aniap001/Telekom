using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;


namespace Zadanie1
{
    class Program
    {

        
        static void Main(string[] args)
        {
            int a = 300;

//            BitArray B = new BitArray(Convert.ToByte(a));   //Testy
//            Console.WriteLine(B.Length);
//            for (int i = 0; i < B.Length; i++)
//                Console.WriteLine(B[i]);



            Funkcje funkcje = new Funkcje();

            Console.WriteLine("Wprowadz wiadomosc: ");

            //NADAWANIE WIADOMOSCI
            string mojaWiadomosc = Console.ReadLine();
            Byte[] wiadomoscBajty = System.Text.Encoding.ASCII.GetBytes(mojaWiadomosc);
            File.WriteAllBytes("mojaWiadomosc.txt", funkcje.szyfrowanieWiadomosci(wiadomoscBajty));



            Console.WriteLine("TERAZ MOZNA BEZPIECZNIE ZMODYFIKOWAC WIADOMOSC");
            Console.Read();


            //ODBIERANIE WIADOMOSCI
            Byte[] odebranaWiadomoscBity = File.ReadAllBytes("mojaWiadomosc.txt");
            //zaimplementowac sprawdzanie wiadomosci
            string odebranaWiadomosc = System.Text.Encoding.ASCII.GetString(odebranaWiadomoscBity);
            Console.WriteLine("Odebrana wiadomosc to: " + odebranaWiadomosc);
            Console.Read();
            Console.Read();
            Console.ReadLine();
       




        }
    }
}
