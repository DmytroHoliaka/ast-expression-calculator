using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public static class Printer
    {
        public static void Print(List<Token>? tokens)
        {
            Console.WriteLine("Tokens: ");

            if (tokens is null)
            {
                Console.WriteLine("[null]");
                return;
            }

            int count = tokens.Count;
            Console.Write("[");

            for (int i = 0; i < count; ++i)
            {
                Console.Write(tokens[i]);

                if (i < count - 1)
                {
                    Console.Write(", ");
                }
            }

            Console.WriteLine("]");
        }
    }
}
