using System;

namespace lab06_ver4
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] MassiveOne = { 1, 2, 3, 4, 5 }; int[] MassiveTwo = { 2, 3 };
            OneRankMas(MassiveOne, MassiveTwo);

            int[] MassiveTwo2 = { 1, 2, 4 };
            OneRankMas(MassiveOne, MassiveTwo2);

            int[] MassiveTwo3 = { 2, 6 };
            OneRankMas(MassiveOne, MassiveTwo3);

            int[,] MassiveOne2 = { { 1, 2, 3 }, { 3, 4, 5 }, { 7, 8, 9 } }; int[,] MassiveTwo4 = { { 3, 4, 5 }, { 7, 8, 9 } };
            TwoRankMas(MassiveOne2, MassiveTwo4);

            int[,] MassiveTwo5 = { { 3, 4, 5 } };
            TwoRankMas(MassiveOne2, MassiveTwo5);

            int[,] MassiveTwo6 = { { 3, 4, 5 }, { 6, 7, 8 } };
            TwoRankMas(MassiveOne2, MassiveTwo6);

        }
        public static void OneorTwo(int MasRankOne, int MasRankTwo)
        {

        }

        public static void OneRankMas(int [] MassiveOne, int [] MassiveTwo)
        {

            int KolOne = MassiveOne.Length;
            int KolTwo = MassiveTwo.Length;

            int[] MassivePeremen = new int[KolTwo];
            int T = KolTwo;
            int conr = 0;

            for (int i = 0; i < KolOne; i++)
            {
                if (i == T - 1)
                {
                    i = i - (KolTwo - 1);

                    for (int n = 0; n < KolTwo; n++)
                    {
                        MassivePeremen[n] = MassiveOne[i];
                        i += 1;
                    }

                    TorF(MassivePeremen, MassiveTwo, KolTwo, i, KolOne, ref conr);

                    i--;
                    T++;
                }
            }
        }
        public static void TorF(int[] MassivePeremen, int[] MassiveTwo, int KolTwo, int i, int KolOne, ref int conr)
        {
            int result = 0;

            for (int n = 0; n < KolTwo; n++)
            {
                if (MassivePeremen[n] == MassiveTwo[n])
                    result++;
            }

            if (result == KolTwo)
                conr++;

            if (i == KolOne)
            {
                if (conr > 0)
                    Console.WriteLine(true);
                else
                    Console.WriteLine(false);
            }

        }
        public static void TwoRankMas(int [,] MassiveOne, int [,] MassiveTwo)
        {
            int KolStrokOne = MassiveOne.GetUpperBound(1) + 1;
            int KolStrokTwo = MassiveTwo.GetUpperBound(1) + 1;

            int KolOne = MassiveOne.Length;
            int KolTwo = MassiveTwo.Length;

            int T = KolTwo;

            int raznostOne = KolOne / KolStrokOne;
            int raznostTwo = KolTwo / KolStrokTwo;


            int[] MassivePeremenOne = new int[KolStrokOne];
            int[] MassivePeremenTwo = new int[KolStrokTwo];

            int count = 0;

            for (int i = 0; i < raznostOne; i++)
            {
                for (int n = 0; n < KolStrokOne; n++)
                {
                    MassivePeremenOne[n] = MassiveOne[i, n];
                }

                SecondMassive(MassivePeremenTwo, MassiveTwo, KolStrokTwo, raznostTwo, raznostOne, MassivePeremenOne, KolStrokOne, i, ref count);

            }
        }

        public static void SecondMassive(int[] MassivePeremenTwo, int[,] MassiveTwo, int KolStrokTwo, int raznostTwo, int raznostOne, int[] MassivePeremenOne, int KolStrokOne, int gh, ref int count)
        {
            for (int i = 0; i < raznostTwo; i++)
            {

                for (int n = 0; n < KolStrokTwo; n++)
                    MassivePeremenTwo[n] = MassiveTwo[i, n];
                
                TorFDouble(KolStrokOne, KolStrokTwo, MassivePeremenOne, MassivePeremenTwo, i, raznostOne, raznostTwo, gh, ref count);

            }
        }
        public static void TorFDouble(int KolStrokOne, int KolStrokTwo, int[] MassivePeremenOne, int[] MassivePeremenTwo, int i, int raznostOne, int raznostTwo, int gh, ref int count)
        {
            int result = 0;

            for (int o = 0; o < MassivePeremenOne.Length; o++)
            {
                if (MassivePeremenOne[o] == MassivePeremenTwo[o])
                    result++;

            }

            if (result == MassivePeremenOne.Length)
                count++;

            if (raznostTwo - 1 == i && gh == raznostOne - 1)
            {
                if (count == raznostTwo)
                    Console.WriteLine(true);
                else
                    Console.WriteLine(false);
            }

        }
    }
    
}
