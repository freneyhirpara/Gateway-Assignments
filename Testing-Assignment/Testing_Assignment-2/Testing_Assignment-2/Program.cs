using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingAssignment2
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string outputValue;

            //Case 1 : convert the given input string to uppercase
            outputValue = ExtensionMethods.Conversion(input, "UpperToLower");
            Console.WriteLine("UpperToLower : " + outputValue);

            //Case 2 : convert the given input string to titlecase
            outputValue = ExtensionMethods.Conversion(input, "TitleCase");
            Console.WriteLine("TitleCase : " + outputValue);

            //Case 3 : convert the given input string to capitalized
            outputValue = ExtensionMethods.Conversion(input, "Capitalized");
            Console.WriteLine("Capitalized : " + outputValue);

            //Case 4 : check the given input string is in lowercase or not
            outputValue = ExtensionMethods.Conversion(input, "CheckLowerCase");
            Console.WriteLine("CheckLowerCase : " + outputValue);

            //Case 5 : check the given input string is in uppercase or not
            outputValue = ExtensionMethods.Conversion(input, "CheckUpperCase");
            Console.WriteLine("CheckUpperCase : " + outputValue);

            //Case 6 : check the given input string is int or not
            outputValue = ExtensionMethods.Conversion(input, "CheckforInt");
            Console.WriteLine("CheckforInt : " + outputValue);

            //Case 7 : remove last character from the given input string
            outputValue = ExtensionMethods.Conversion(input, "RemoveLastCharacter");
            Console.WriteLine("RemoveLastCharacter : " + outputValue);

            //Case 8 : count the number of words in the given input string
            outputValue = ExtensionMethods.Conversion(input, "WordCount");
            Console.WriteLine("WordCount : " + outputValue);

            //Case 9 convert the given input string to int type
            outputValue = ExtensionMethods.Conversion(input, "StringToInt");
            Console.WriteLine("StringToInt : " + outputValue);
            Console.ReadLine();
        }
    }
}
