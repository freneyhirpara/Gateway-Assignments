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
            string inputString = Console.ReadLine();
            string outputValue;

            //Case 1 : convert the given input string to uppercase

            outputValue = inputString.UppertoLower();
            Console.WriteLine("UpperToLower : " + outputValue);

            //Case 2 : convert the given input string to titlecase

            outputValue = inputString.TitleCase();
            Console.WriteLine("TitleCase : " + outputValue);

            //Case 3 : convert the given input string to capitalized

            outputValue = inputString.Capitalized();
            Console.WriteLine("Capitalized : " + outputValue);

            //Case 4 : check the given input string is in lowercase or not

            outputValue = inputString.CheckLowerCase();
            Console.WriteLine("CheckLowerCase : " + outputValue);

            //Case 5 : check the given input string is in uppercase or not

            outputValue = inputString.CheckUpperCase();
            Console.WriteLine("CheckUpperCase : " + outputValue);

            //Case 6 : check the given input string is int or not

            outputValue = inputString.CheckforInt();
            Console.WriteLine("CheckforInt : " + outputValue);

            //Case 7 : remove last character from the given input string

            outputValue = inputString.RemoveLastChar();
            Console.WriteLine("RemoveLastCharacter : " + outputValue);

            //Case 8 : count the number of words in the given input string

            outputValue = inputString.WordCount();
            Console.WriteLine("WordCount : " + outputValue);

            //Case 9 convert the given input string to int type

            outputValue = inputString.StringToInt();
            Console.WriteLine("StringToInt : " + outputValue);
            Console.ReadLine();
        }
    }
}
