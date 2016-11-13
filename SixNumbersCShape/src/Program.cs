using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SixNumbersCShape.src
{
    class Program
    {
        const uint inputMax = 6;
        static void Main(string[] args)
        {
            List<int> inputnums = new List<int>();
            int ans = 0;
            string buf = String.Empty;
            int num = 0;
            for(int i = 1; i <= Program.inputMax; i++)
            {
                while (true)
                {
                    Console.Write("数字を入力してください({0}/{1}):", i, Program.inputMax);
                    buf = Console.ReadLine();
                    if(int.TryParse(buf, out num))
                    {
                        if (num > 0)
                        {
                            inputnums.Add(num);
                            break;
                        }
                    }
                    Console.WriteLine("自然数を入力してください");
                }
            }
            while (true)
            {
                Console.Write("{0}つの数字を四則演算して導き出す数字を入力してください:", Program.inputMax);
                buf = Console.ReadLine();
                if(int.TryParse(buf, out ans))
                {
                    if (ans > 0) break;
                }
                Console.WriteLine("自然数を入力してください");
            }
            SixNumbers six = new src.SixNumbers(inputnums, ans);
           
        }// Main
    }
}
