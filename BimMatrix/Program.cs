//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace BimMatrix
//{
//    internal class Program
//    {
//        static void Main(string[] args)
//        {
//            Console.Write("Enter your word: ");
//            string message = Console.ReadLine();
//            Console.WriteLine(message);
//            Console.Clear();

//            while(true)
//                Fall(message);
//        }

//        public static void Fall(string message)
//        {
//            Console.ForegroundColor = ConsoleColor.DarkGreen;
//            Console.WindowLeft = Console.WindowTop = 0;
//            Console.WindowHeight = Console.BufferHeight = Console.LargestWindowHeight;
//            Console.WindowWidth = Console.BufferWidth = Console.LargestWindowWidth;
//            Console.CursorVisible = false;

//            int width;
//            int height;
//            int[] y;

//            Init(out width, out height, out y);

//            for (int x = 0; x < width; x++)
//            {
//                Random random = new Random();
//                Console.ForegroundColor = ConsoleColor.Green;
//                Console.SetCursorPosition(x, y[x]);
//                Console.ForegroundColor = ConsoleColor.DarkGreen;

//                Console.Write(message[random.Next(message.Length)]);

//                int temp = y[x];
//                Console.SetCursorPosition(x, inScreenYPosition(temp, height));
//                Console.Write(message[random.Next(message.Length)]);

//                int temp1 = y[x];
//                Console.SetCursorPosition(x, inScreenYPosition(temp1, height));
//                Console.Write(' ');

//                y[x] = y[x] + 1;
//            }
//        }

//        public static void Init(out int width, out int height, out int[] y)
//        {
//            height = Console.WindowHeight;
//            width = Console.WindowWidth - 1;

//            y = new int[width];

//            Console.Clear();
//            for (int x = 0; x < width; ++x)
//            {
//                Random rand = new Random();
//                y[x] = rand.Next(height);
//            }
//        }

//        public static int inScreenYPosition(int yPosition, int height)
//        {
//            if (yPosition < 0)
//                return yPosition + height;
//            else if (yPosition < height)
//                return yPosition;
//            else
//                return 0;
//        }
//    }
//}