using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Task_1
{
    class Trix
    {
        private readonly string symb = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789+-;*&^%$#@!";

        private static readonly object loke = new object();

        private readonly Random rand;

        private readonly int thend = 40;

        public Trix(int lol, bool ssecond)
        {
            Loll = lol;
            Ssecond = ssecond;
            rand = new Random((int)DateTime.Now.Ticks);
        }

        public int Loll { get; set; }

        public int lengtht { get; set; }

        public char Symbol => symb.ToCharArray()[rand.Next(0, 47)];

        public bool Ssecond { get; set; }

        public void Move()
        {
            int mlenth;

            while (true)
            {
                mlenth = rand.Next(3, 6);

                Thread.Sleep(0);

                for (var i = 0; i < thend; i++)
                {
                    lock (loke)
                    {
                        Console.CursorTop = 0;
                        Console.ForegroundColor = ConsoleColor.Black;

                        pisat(' ', i);

                        if (lengtht < mlenth)
                        {
                            lengtht++;
                        }
                        else if (lengtht == mlenth)
                        {
                            mlenth = 0;
                        }

                        if (Ssecond && i < 20 && i > lengtht + 2 && (rand.Next(1, 5) == 3))
                        {
                            new Thread((new Trix(Loll, false)).Move).Start();
                            Ssecond = false;
                        }

                        if ((thend - 1) - i < lengtht)
                            lengtht--;
                        

                        Console.CursorTop = i - lengtht + 1;
                        Console.ForegroundColor = ConsoleColor.DarkGreen;

                        pisat(Symbol, lengtht - 2);

                        ChangeColor(2, ConsoleColor.Green);
                        ChangeColor(1, ConsoleColor.White);

                        Thread.Sleep(0);
                    }
                }
            }
        }

        private void pisat(char x, int length)
        {
            for (var j = 0; j < length; j++)
            {
                Console.CursorLeft = Loll;
                Console.WriteLine(x);
            }
        }

        private void ChangeColor(int value, ConsoleColor color)
        {
            if (lengtht >= value)
            {
                Console.ForegroundColor = color;
                Console.CursorLeft = Loll;
                Console.WriteLine(Symbol);
            }
        }
    } 
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(80, 40);

            Trix newtrix;

            for (var i = 0; i < 30; i++)
            {
                newtrix = new Trix(i * 2, true);
                new Thread(newtrix.Move).Start();
            }

            Console.ReadLine();
        }
    }
}