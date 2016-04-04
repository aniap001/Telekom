using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Zadanie1
{
    public class Funkcje
    {
        public Funkcje()
        {

        }
        //BitArray T;
        BitArray Tstare;
        BitArray Tnowe;

        byte[] BitArrayToByteArray(BitArray bits) // metoda konwertujaca BitArray na byte[]
        {
            byte[] ret = new byte[(bits.Length - 1) / 8 + 1];
            bits.CopyTo(ret, 0);
            return ret;
        }
        static int wiersze = 8, kolumny = 16; // parametry macierzy H

        Boolean[,] H = new Boolean[8, 16] {
                { true, true, true,false,false, true, true, true,  true,false,false,false,false,false,false,false},
                {false, true, true, true, true,false, true, true, false, true,false,false,false,false,false,false},
                { true,false,false, true,false, true,false, true, false,false, true,false,false,false,false,false},
                { true, true, true,false, true,false,false, true, false,false,false, true,false,false,false,false},
                {false, true,false, true,false, true, true,false, false,false,false,false, true,false,false,false},
                { true,false, true,false, true,false, true,false, false,false,false,false,false, true,false,false},
                { true, true,false,false, true, true,false,false, false,false,false,false,false,false, true,false},
                { true, true, true, true,false,false,false,false, false,false,false,false,false,false,false, true}};

        public Byte[] szyfrowanieWiadomosci(Byte[] wiadomoscBajty)
        {
            BitArray bity;
            BitArray T = new BitArray(kolumny);
            byte[] zaszyfrowanaBajty = new byte[wiadomoscBajty.Length * 2];
            byte[] dwaBajty = new byte[2];
            byte[] bajt = new byte[1];
            for (int i = 0; i < wiadomoscBajty.Length; i++)
            {
                bajt[0] = wiadomoscBajty[i];
                //Console.WriteLine(bajt[0]);
                bity = new BitArray(bajt);            //tworzona  tablica BitArray przechowujaca bity przeslanej wiadomosci (polowa tablicy T)

                T = mnozMacierzTH(bity);                           //tworzenie macierzy T (pelna, zawiera bity kontrolne)
                dwaBajty = BitArrayToByteArray(T);
                Array.Copy(dwaBajty, 0, zaszyfrowanaBajty, i * 2, 2);

            }
            return zaszyfrowanaBajty;
        }


        public BitArray mnozMacierzTH(BitArray A)
        {
            //for(int i = 0; i < A.Length; i++)
            //{
            //    Console.Write(A[i]);
            //}
            BitArray T = new BitArray(kolumny);
            for(int i = 0; i < wiersze; i++)               //Wypelnianie macierzy T liczbami a1, a2, ... a8
            {
                T[i] = A[i];
            }
            for(int i =0; i < wiersze; i++)                //Wypelnianie macierzy T liczbami c1, c2, ... c8
            {
                bool ci = H[i, 0] & A[0];
                for(int j = 1; j < A.Length; j++)
                {
                    ci = ci ^ (H[i, j] & A[j]);
                }
                T[8 + i] = ci;
            }
            Tstare = new BitArray(T);
            return T;       //zwracana BitArray T ktora ma 8 bitow wiadomosci i 8 bitow kontrolnych
        }

        public Byte[] odszyfrowanieWiadomosci(Byte[] wiadomoscBajty)
        {
            byte[] zaszyfrowanaBajty = new byte[wiadomoscBajty.Length / 2];
            byte[] dwaBajty = new byte[2];
            byte[] bajt = new byte[1];
            BitArray R; //odebrana wiadomosc zaszyfrowana
            BitArray E;// wektor bledow wiadomosci  = new BitArray(kolumny);
            for (int i = 0; i < wiadomoscBajty.Length; i += 2)
            {
                //tablica dwaBajty przechowuje odebrana wiadomosc
                dwaBajty[0] = wiadomoscBajty[i];
                dwaBajty[1] = wiadomoscBajty[i+1];

                R = new BitArray(dwaBajty);

                //bool czyDobra = sprawdzWiadomosc(R);

                //korekcjaBledow(R);
            }
            return zaszyfrowanaBajty;
        }
    }
}
