using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool A = true;
            bool B = true;

            Console.WriteLine(DeMorgan(A, B));
            Console.ReadLine();
        }
        public static bool Conjunction(bool A, bool B) => A & B;
        public static bool Disjunction(bool A, bool B) => A | B;
        public static bool Inversion(bool A) => !A;
        public static bool Implication(bool A, bool B) => !A | B;
        public static bool ExclusiveOr(bool A, bool B) => A ^ B;
        public static bool DeMorgan(bool A, bool B)
        {
            if ((Inversion(Conjunction(A, B)) == !A & !B))
                return true;
            return false;
        }
    }
}
