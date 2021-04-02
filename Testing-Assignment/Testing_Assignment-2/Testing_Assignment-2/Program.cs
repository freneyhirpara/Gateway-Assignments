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
            
            outputValue = input.Conversion("UpperToLower");
            Console.WriteLine("UpperToLower : " + outputValue);

            //Case 2 : convert the given input string to titlecase
            
            outputValue = input.Conversion("TitleCase");
            Console.WriteLine("TitleCase : " + outputValue);

            //Case 3 : convert the given input string to capitalized
            
            outputValue = input.Conversion( "Capitalized");
            Console.WriteLine("Capitalized : " + outputValue);

            //Case 4 : check the given input string is in lowercase or not
            
            outputValue = input.Conversion( "CheckLowerCase");
            Console.WriteLine("CheckLowerCase : " + outputValue);

            //Case 5 : check the given input string is in uppercase or not
            
            outputValue = input.Conversion("CheckUpperCase");
            Console.WriteLine("CheckUpperCase : " + outputValue);

            //Case 6 : check the given input string is int or not
            
            outputValue = input.Conversion("CheckforInt");
            Console.WriteLine("CheckforInt : " + outputValue);

            //Case 7 : remove last character from the given input string
            
            outputValue = input.Conversion("RemoveLastCharacter");
            Console.WriteLine("RemoveLastCharacter : " + outputValue);

            //Case 8 : count the number of words in the given input string
            
            outputValue = input.Conversion( "WordCount");
            Console.WriteLine("WordCount : " + outputValue);

            //Case 9 convert the given input string to int type
            
            outputValue = input.Conversion( "StringToInt");
            Console.WriteLine("StringToInt : " + outputValue);
            Console.ReadLine();
        }
    }
}
