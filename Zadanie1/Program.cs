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
            //int a = 300;

            //            BitArray B = new BitArray(Convert.ToByte(a));   //Testy
            //            Console.WriteLine(B.Length);
            //            for (int i = 0; i < B.Length; i++)
            //                Console.WriteLine(B[i]);



            Funkcje funkcje = new Funkcje();

            //Console.WriteLine("Wprowadz wiadomosc: ");
            //COS POKOMBINOWALAM ALE Z TEGO CO MOWISZ TO NIE WIEM CZY TO DOBRZE... BO JEDNAK CHYBA W INNY SPOSOB TRZEBA TE BAJTY ZAPISAC DO PLIKU
            //ODEBRANIE WIADOMOSCI Z PLIKU odebrana.txt I UMIESZCZENIE BAJTOW W TABLICY 
            Byte[] wiadomoscBajty = File.ReadAllBytes("mojaWiadomosc.txt");
            byte[] zaszyfrowanaBjaty = funkcje.szyfrowanieWiadomosci(wiadomoscBajty);

            File.WriteAllBytes("wyslana.txt", zaszyfrowanaBjaty);



            Console.WriteLine("TERAZ MOZNA BEZPIECZNIE ZMODYFIKOWAC WIADOMOSC");
            Console.Read();


            //ODBIERANIE WIADOMOSCI
            Byte[] odebranaWiadomoscBity = File.ReadAllBytes("wyslana.txt");
            //zaimplementowac sprawdzanie wiadomosci
            string odebranaWiadomosc = System.Text.Encoding.ASCII.GetString(odebranaWiadomoscBity);
            byte[] odszyfrowanaWiadomosc = funkcje.odszyfrowanieWiadomosci(odebranaWiadomoscBity);
            Console.WriteLine("Odebrana wiadomosc to: " + odebranaWiadomosc);
            Console.Read();
            Console.Read();
            Console.ReadLine();





        }
    }
}
