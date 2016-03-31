using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Zadanie1
{
    class Funkcje
    {
        public Funkcje()
        {

        }
        public Funkcje(int m1, int n1) // na razie nie uzywane
        {
            

        }
        static int wiersze = 8, kolumny = 16; // tymczasowe parametry macierzy H

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
            BitArray jedenBajt;
            for(int i = 0; i < wiadomoscBajty.Length; i++)
            {
                jedenBajt = new BitArray(wiadomoscBajty[i]);
            }


            //zaimplementowac "szyfrowanie"

       //     wiadomoscBity.CopyTo(wiadomoscBajty, 0);
            return wiadomoscBajty;
        }


        //  dodane 31-03 ->jak przeczytasz to skasuj - zebys wiedzial co pozmieniane ;)
        BitArray mnozMacierzTH(BitArray T)
        {
            BitArray mWynikowa = T;
            
            for (int i = 0; i<wiersze; i++)
            {
                Boolean wartosc = false;
                for (int j=0; j < kolumny; j++)
                {
                    wartosc = T[i] ^ H[i, j];       //dodawanie logiczne
                    mWynikowa[i] = wartosc ^ mWynikowa[i];
                }
            }

            for(int i=wiersze, j=0; i<kolumny; j++, i++)
            {
                T[i] = mWynikowa[j];
            }
            return mWynikowa;       //zwracana BitArray T ktora ma 8 bitow wiadomosci i 8 bitow kontrolnych
        }
        //-------------------------------------------------------------------------------

    }
}
