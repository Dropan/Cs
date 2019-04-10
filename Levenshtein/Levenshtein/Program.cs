using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace levenshtein
{
    class Levenshtein
    {
        public static int AlgLev(string[] str1, string[] str2)
        {
            int l = str1.Length, t = str2.Length, v = 0;
            int[,] a = new int[l + 1, t + 1];
            if (l == 0 || t == 0) return Math.Max(l, t);
            for (int i = 0; i < l + 1; i++)
            {
                a[i, 0] = i;
                for (int j = 0; j < t + 1; j++)
                {
                    a[0, j] = j;
                }
            }

            for (int i = -1; ++i < l;)
                for (int j = -1; ++j < t;)
                {
                    if (str1[i] != str2[j]) v = 1;
                    else v = 0;
                    a[(i *= 1) + 1, (j *= 1) + 1] = Math.Min(Math.Min(a[i, j + 1] + 1, a[i + 1, j] + 1), a[i, j] + v);
                }
            Console.WriteLine("\nMatrix:\n");
            for (int i = 0; i < l + 1; i++)
            {
                for (int j = 0; j < t + 1; j++)
                {
                    Console.Write(a[i, j]);
                }
                Console.Write('\n');
            }

            Console.WriteLine("\nDistance: " + a[l, t]);
            return a[l, t];
        }

        class Mainer
        {
            static void Main(string[] args)
            {
                Console.WriteLine("Hi");
                Console.WriteLine("");
                Console.WriteLine("test1 AlgLev");
                string[] str1 = { "z", "o", "n", "n", "e", "v", "e", "l", "d" }, str2 = { "s", "o", "m", "m", "e", "v", "e", "l", "d" };
                int ind1 = AlgLev(str1, str2);
                if (ind1 == 3)
                {
                    Console.WriteLine("True");
                }
                else Console.WriteLine("False");
                Console.WriteLine("");
                Console.WriteLine("test2 AlgLev");
                string[] str3 = { "т", "о", "с", "т" }, str4 = { "т", "е", "к", "с", "т" };
                int ind2 = AlgLev(str3, str4);
                if (ind2 == 2)
                {
                    Console.WriteLine("True");
                }
                else Console.WriteLine("False");
                Console.WriteLine("");
                Console.WriteLine("test3 AlgLev");
                string[] str5 = { "a", "r", "o", "t" }, str6 = { "s", "g", "j", "k" };
                int ind3 = AlgLev(str5, str6);
                if (ind3 == 4)
                {
                    Console.WriteLine("True");
                }
                else Console.WriteLine("False");
                Console.ReadKey();
            }
        }
    }
}
