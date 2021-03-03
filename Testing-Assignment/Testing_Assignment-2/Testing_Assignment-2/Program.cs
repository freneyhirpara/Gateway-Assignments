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

            //Case 1
            outputValue = ExtensionMethods.StringConvert(input, "UpperToLower");

            //Case 2
            outputValue = ExtensionMethods.StringConvert(input, "TitleCase");

            //Case 3
            outputValue = ExtensionMethods.StringConvert(input, "Capitalized");

            //Case 4
            outputValue = ExtensionMethods.StringConvert(input, "CheckLowerCase");

            //Case 5
            outputValue = ExtensionMethods.StringConvert(input, "CheckUpperCase");

            //Case 6
            outputValue = ExtensionMethods.StringConvert(input, "CheckforInt");

            //Case 7
            outputValue = ExtensionMethods.StringConvert(input, "RemoveLastCharacter");

            //Case 8
            outputValue = ExtensionMethods.StringConvert(input, "WordCount");

            //Case 9
            outputValue = ExtensionMethods.StringConvert(input, "StringToInt");
        }
    }
}
