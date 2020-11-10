using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBookSystem
{
    public class CustomPrint
    {
        private static int tableWidth = 147;
        public static void PrintDashLine()
        {
            Console.WriteLine(new string('-', tableWidth + 4).PadLeft(tableWidth + 5, '+').PadRight(tableWidth + 6, '+'));
        }
        public static string PrintRow(params string[] columns)
        {
            int width = (tableWidth - columns.Length) / columns.Length;
            string row = "|";

            foreach (string column in columns)
            {
                row += AlignCentre(column, width+1) + "|";
            }

            return row;
        }
        public static string AlignCentre(string text, int width)
        {
            text = text.Length > width ? text.Substring(0, width - 3) + "..." : text;

            if (string.IsNullOrEmpty(text))
            {
                return new string(' ', width);
            }
            else
            {
                return text.PadRight(width - (width - text.Length) / 2).PadLeft(width);
            }
        }
        //For printing headers and results in red
        public static void PrintInRed(string s, bool header = true, bool footer = false)
        {
            if (header)
                Console.WriteLine("-----------------------------------------");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(s);
            Console.ResetColor();
            if (footer)
                Console.WriteLine("-----------------------------------------");
        }
        //For printing Errors in Magenta
        public static void PrintInMagenta(string s, bool header = true, bool footer = false)
        {
            if (header)
                Console.WriteLine("-----------------------------------------");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(s);
            Console.ResetColor();
            if (footer)
                Console.WriteLine("-----------------------------------------");
        }
    }
}
