namespace AddressBookSystem
{
    using System;

    public class CustomPrint
    {
        private static int tableWidth = 147;
        /// <summary>Prints the dash line.</summary>
        public static void PrintDashLine()
        {
            Console.WriteLine(new string('~', tableWidth + 4).PadLeft(tableWidth + 5, '+').PadRight(tableWidth + 6, '+'));
        }
        /// <summary>Prints the row.</summary>
        /// <param name="columns">The column values of table.</param>
        /// <returns>The row to be print.</returns>
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
        /// <summary>Aligns the text to centre of cell in table.</summary>
        /// <param name="text">The text.</param>
        /// <param name="width">The width.</param>
        /// <returns>the text with center align</returns>
        private static string AlignCentre(string text, int width)
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
        /// <summary>Prints the line in red.</summary>
        /// <param name="s">The string.</param>
        /// <param name="header">if set to <c>true</c> [header].</param>
        /// <param name="footer">if set to <c>true</c> [footer].</param>
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
        /// <summary>Prints the line in magenta.</summary>
        /// <param name="s">The string.</param>
        /// <param name="header">if set to <c>true</c> [header].</param>
        /// <param name="footer">if set to <c>true</c> [footer].</param>
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
