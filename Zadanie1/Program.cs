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

            //Console.WriteLine("Wprowadz wiadomosc: ");
            //COS POKOMBINOWALAM ALE Z TEGO CO MOWISZ TO NIE WIEM CZY TO DOBRZE... BO JEDNAK CHYBA W INNY SPOSOB TRZEBA TE BAJTY ZAPISAC DO PLIKU
            //ODEBRANIE WIADOMOSCI Z PLIKU odebrana.txt I UMIESZCZENIE BAJTOW W TABLICY 
            System.IO.StreamReader file = new System.IO.StreamReader(@"odebrana.txt");
            string mojaWiadomosc = file.ReadLine();
            Byte[] wiadomoscBajty = System.Text.Encoding.ASCII.GetBytes(mojaWiadomosc);


            //petla do operowania na wszystkich bajtach przeslanej wiadomosci
            BitArray jedenBajt;
            for (int i = 0; i < wiadomoscBajty.Length; i++)
            {
                jedenBajt = new BitArray(wiadomoscBajty[i]);
                Console.WriteLine(wiadomoscBajty[i]);
            }
            File.WriteAllBytes("wyslana.txt", funkcje.szyfrowanieWiadomosci(wiadomoscBajty));



            Console.WriteLine("TERAZ MOZNA BEZPIECZNIE ZMODYFIKOWAC WIADOMOSC");
            Console.Read();


            //ODBIERANIE WIADOMOSCI
            Byte[] odebranaWiadomoscBity = File.ReadAllBytes("wyslana.txt");
            //zaimplementowac sprawdzanie wiadomosci
            string odebranaWiadomosc = System.Text.Encoding.ASCII.GetString(odebranaWiadomoscBity);
            Console.WriteLine("Odebrana wiadomosc to: " + odebranaWiadomosc);
            Console.Read();
            Console.Read();
            Console.ReadLine();





        }
    }
}
