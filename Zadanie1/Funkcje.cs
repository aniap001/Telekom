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
        public Funkcje(int m1, int n1) // na razie nie uzywane
        {


        }
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
            for (int i = 0; i < wiadomoscBajty.Length; i++)
            {
                bity = new BitArray(wiadomoscBajty[i]);            //tworzona  tablica BitArray przechowujaca bity przeslanej wiadomosci (polowa tablicy T)

                T = mnozMacierzTH(bity);                           //tworzenie macierzy T (pelna, zawiera bity kontrolne)
                dwaBajty = BitArrayToByteArray(T);
                Array.Copy(dwaBajty, 0, zaszyfrowanaBajty, i * 2, 2);

            }
            return zaszyfrowanaBajty;
        }


        public BitArray mnozMacierzTH(BitArray T)
        {
            BitArray mWynikowa = T;

            for (int i = 0; i < wiersze; i++)
            {
                Boolean wartosc = false;
                for (int j = 0; j < kolumny; j++)
                {
                    wartosc = T[i] ^ H[i, j];       //dodawanie logiczne
                    mWynikowa[i] = wartosc ^ mWynikowa[i];
                }
            }

            for (int i = wiersze, j = 0; i < kolumny; j++, i++)
            {
                T[i] = mWynikowa[j];
            }
            return mWynikowa;       //zwracana BitArray T ktora ma 8 bitow wiadomosci i 8 bitow kontrolnych
        }
        //-------------------------------------------------------------------------------

    }
}
