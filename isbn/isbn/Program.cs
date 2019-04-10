using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isbn
{
    class Isbn
    {
        public static bool Validate(string[] str)
        {
            if (str.Length == 10)
            {
                if (isbn10(str) == true) return true;
                else return false;
            }
            else if (str.Length == 13)
            {
                if (isbn13(str) == true) return true;
                else return false;
            }
            else return false;
        }
        public static bool isbn10(string[] str)
        {
            int sumpr = 0;
            for (int i = 0; i <= str.Length - 2; i++)
            {
                //if (str[i] == "-") strk[i] = str.Remove(i, 1);
                sumpr += int.Parse(str[i]) * (str.Length - i);
            }
            if (str[str.Length - 1] == "x" && str[str.Length - 1] == "X") str[str.Length - 1] = "10";

            if ((sumpr + (int.Parse(str[str.Length - 1]))) % 11 == 0) return true;
            else return false;
        }
        public static bool isbn13(string[] str)
        {
            if (str[2] != "8" && str[2] != "9") return false;
            int sumpr = 0;
            string[] strk = new string[str.Length];
            for (int i = 0; i < str.Length - 1; i++)
            {
                //if (str[i] == "-") strk[i] = str.Remove(i, 1);
                strk[i] = str[i];
            }
            strk[str.Length - 1] = "0";
            for (int j = 0; j < str.Length - 1; j++)
            {
                if (j % 2 == 0) sumpr += int.Parse(strk[j]);
                else sumpr += int.Parse(strk[j]) * 3;
            }
            if (int.Parse(str[str.Length - 1]) == (10 - (sumpr % 10)) || int.Parse(str[str.Length - 1]) == 10) return true;
            else return false;
        }

        class Mainer
        {
            static void Main(string[] args)
            {
                Console.WriteLine("Hi");
                Console.WriteLine("");
                Console.WriteLine("test1 isbn 10");
                string[] str10 = {"2","2","6","6","1","1","1","5","6","6"};
                bool ind1 = isbn10(str10);
                if (ind1 == true)
                {
                    Console.WriteLine("True");
                }
                else Console.WriteLine("False");
                Console.WriteLine("");
                Console.WriteLine("test2 isbn 13");
                string[] str13 = { "9", "7", "8", "2", "1", "2", "3", "4", "5", "6", "8", "0", "3" };
                bool ind2 = isbn13(str13);
                if (ind2 == true)
                {
                    Console.WriteLine("True");
                }
                else Console.WriteLine("False");
                Console.WriteLine("");
                Console.WriteLine("test3 Validate10");
                string[] str1 = { "2", "2", "6", "6", "1", "1", "1", "5", "6", "6" };
                bool ind3 = Validate(str1);
                if (ind3 == true)
                {
                    Console.WriteLine("True");
                }
                else Console.WriteLine("False");
                Console.WriteLine("");
                Console.WriteLine("test4 Validate13");
                string[] str2 = { "9", "7", "8", "2", "1", "2", "3", "4", "5", "6", "8", "0", "3" };
                bool ind4 = Validate(str2);
                if (ind4 == true)
                {
                    Console.WriteLine("True");
                }
                else Console.WriteLine("False");
                Console.WriteLine("Press any key to exit.");
                Console.ReadKey();
            }
        }
    }
}