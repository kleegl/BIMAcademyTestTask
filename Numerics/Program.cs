using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Numerics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int>() { 0,1,2,3,4,5,6,5,4,3,2};
            //CreateArray(ref list);
            List<int> listBase = list.ToList();
            ShowList(list);
    #region HandlesFunc
            //Console.WriteLine("\nmin value = " + MinValue(list) + "\n");
            //Console.WriteLine("max value = " + MaxValue(list) + "\n");

            //Console.Write("from more to less: ");
            //ShowList(SortUp(list));
            //Console.WriteLine();

            //Console.Write("from less to more: ");
            //ShowList(SortDown(list));
            //Console.WriteLine();

            //Console.WriteLine(FirstIndex(listBase));
            //Console.WriteLine(LastIndex(listBase));
            //ShowList(AllIndexes(listBase));
            //ShowList(MultipleM(listBase));
    #endregion
            #region LinQFunc
            ShowList(AllIndexesLinQ(listBase));
            //ShowList(MultipleMLinQ(listBase));
            #endregion
            Console.ReadLine();
        }
#region HandlesFunc
        public static void CreateArray(ref List<int> list)
        {
            var randomValue = new Random();
            int length = randomValue.Next(4, 10);
            for (int i = 0; i < length; i++)
            {
                list.Add(randomValue.Next(0,20));
            }
        }
        public static void ShowList(List<int> list)
        {
            foreach(var i in list)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
        }
        public static int MinValue(List<int> list)
        {
            int min = Int32.MaxValue;
            for (int i = 0; i < list.Count; i++)
            {
                if(list[i] < min)
                    min = list[i];
            }
            return min;
        }
        public static int MaxValue(List<int> list)
        {
            int max = Int32.MinValue;
            for (int i = 0; i < list.Count; i++)
            {
                if (max < list[i])
                    max = list[i];
            }
            return max;
        }
        //from more to less
        public static List<int> SortUp(List<int> list)
        {
            int temp = 0;
            for (int i = 0; i < list.Count; i++)
            {
                for (int j = 0; j < list.Count; j++)
                {
                    if(list[i] > list[j])
                    {
                        temp = list[i];
                        list[i] = list[j];
                        list[j] = temp;
                    }
                }
            }
            return list;
        }
        //from less to more
        public static List<int> SortDown(List<int> list)
        {
            int temp = 0;
            for (int i = 0; i < list.Count; i++)
            {
                for (int j = 0; j < list.Count; j++)
                {
                    if(list[i] < list[j])
                    {
                        temp = list[i];
                        list[i] = list[j];
                        list[j] = temp;
                    }
                }
            }
            return list;
        }
        public static int FirstIndex(List<int> list)
        {
            Console.WriteLine("Enter number for search first index: ");
            int num = 0;
            int index = -1;
            try
            {
                num = Int32.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("You entered not number!");
            }
            for (int i = 0; i < list.Count; i++)
            {
                if(list[i] == num)
                {
                    index = i;
                    break;
                }
            }
            return index;
        }
        public static int LastIndex(List<int> list)
        {
            Console.WriteLine("Enter number for search last index: ");
            int num = 0;
            int index = -1;
            try
            {
                num = Int32.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("You entered not number!");
            }
            for (int i = 0; i < list.Count; i++)
            {
                if(num == list[i])
                {
                    index = i;
                }
            }
            return index;
        }
        public static List<int> AllIndexes(List<int> list)
        {
            Console.WriteLine("Enter number for search all indexes: ");
            int num = 0;
            try
            {
                num = Int32.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("You entered not number!");
            }
            List<int> indexes = new List<int>();
            for (int i = 0;i < list.Count; i++)
            {
                if(list[i] == num)
                    indexes.Add(i);
            }
            return indexes;
        }
        public static List<int> MultipleM(List<int> list)
        {
            Console.WriteLine("Enter m for search all numbers's multiples m: ");
            int m = 0;
            try
            {
                m = Int32.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("You entered not number!");
            }
            List<int> indexes = new List<int>();
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] % m == 0 && list[i] != 0)
                    indexes.Add(list[i]);
            }
            return indexes;
        }
#endregion
#region LinQFunc
        public static int MinLinq(List<int> list) => list.Min(x => x);
        public static int MaxLinQ(List<int> list) => list.Min(x => x);
        public static List<int> SortUpLinQ(List<int> list) => list.OrderByDescending(x => x).ToList();
        public static List<int> SortDownLinQ(List<int> list) => list.OrderBy(x => x).ToList();
        public static int FirstIndexLinQ(List<int> list)
        {
            int num = Int32.Parse(Console.ReadLine());
            int index = list.FindIndex(n => n==num);
            return index;
        }
        public static int LastIndexLinQ(List<int> list)
        {
            int num = Int32.Parse(Console.ReadLine());
            int index = list.FindLastIndex(n => n == num);
            return index;
        }
        public static List<int> AllIndexesLinQ(List<int> list)
        {
            Console.WriteLine("Enter number for search: ");
            int num = 0;
            try
            {
                num = Int32.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("Error");
            }

            var result = list.Where(n => n == num);

            return result.ToList();
        }
        //rework
        public static List<int> MultipleMLinQ(List<int> list)
        {
            Console.WriteLine("Enter m for search all numbers's multiples m: ");
            int num = 0;            
            try
            {
                num = Int32.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("You entered not number!");
            }


            //var result = list.Where(n => n % num == 0 && n != 0).ToList();
            return result;
        }
#endregion
    }
}
