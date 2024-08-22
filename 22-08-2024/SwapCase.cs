using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwapCaseProgram
{
    internal class Program
    {
        enum ConversionResult
        {
            Upper,
            Lower
        }
        static ConversionResult SwapCase(string str , out string result)
        {
            if (Char.IsUpper(str[0]))
            {
                result = str.ToLower();
                return ConversionResult.Lower;
            }
            else
            {
                result = str.ToUpper();
                return ConversionResult.Upper;
            }
        }
        static void Main(string[] args)
        {
            switch(SwapCase("Helloo" , out string result))
            {
                case ConversionResult.Upper:
                    Console.WriteLine($"the result after swapping is {result} and is converted to uppercase");
                    break;
                case ConversionResult.Lower:
                    Console.WriteLine($"the result after swapping is {result} and is converted to lower case");
                    break;

            }
        }
    }
}
