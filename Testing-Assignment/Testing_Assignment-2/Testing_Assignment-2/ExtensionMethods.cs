using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingAssignment2
{
    public static class ExtensionMethods
    {
        public static string UppertoLower(this string inputString)
        {
            string output = "";
            int ascii = 0;
            foreach (var ch in inputString)
            {
                ascii = (int)ch;
                if (ascii >= 65 && ascii <= 90)
                    ascii += 32;
                else if (ascii >= 97 && ascii <= 122)
                    ascii -= 32;
                output += (char)ascii;
            }
            return output;
        }
    

        public static string TitleCase(this string inputString)
        {
            TextInfo textInfo = new CultureInfo("en-us", false).TextInfo;
            return textInfo.ToTitleCase(inputString);
        }

        public static string Capitalized(this string inputString)
        {
            TextInfo textInfo = new CultureInfo("en-us", false).TextInfo;
            return textInfo.ToTitleCase(inputString);
        }

        public static string CheckLowerCase(this string inputString)
        {
            bool status = false;
            int asciiValue = 0;
            foreach (var item in inputString)
            {
                asciiValue = (int)item;
                if (asciiValue >= 97 && asciiValue <= 122)
                {
                    status = true;
                }
                else
                {
                    status = false;
                    break;
                }

            }
            if (status == true)
            {
                return "true";
            }
            else
            {
                return "false";
            }
        }

        public static string CheckUpperCase(this string inputString)
        {

            bool status = false;
            int asciiValue = 0;
            foreach (var item in inputString)
            {
                asciiValue = (int)item;
                if (asciiValue >= 65 && asciiValue <= 90)
                {
                    status = true;
                }
                else
                {
                    status = false;
                    break;
                }

            }
            if (status == true)
            {
                return "true";
            }
            else
            {
                return "false";
            }
        }

        public static string CheckforInt(this string inputString)
        {
            try
            {
                int x = int.Parse(inputString);
                return "Success";
            }
            catch (Exception)
            {

                return "Failed";
            }
        }

        public static string RemoveLastChar(this string inputString)
        {
            return inputString.Substring(0, inputString.Length - 1);
        }

        public static string WordCount(this string inputString)
        {
            var wordCount = 0;
            for (var i = 0; i < inputString.Length; i++)
                if (inputString[i] == ' ' || i == inputString.Length - 1)
                    wordCount++;
            return wordCount.ToString();
        }

        public static string StringToInt(this string inputString)
        {
            try
            {
                return "" + int.Parse(inputString);
            }
            catch (Exception)
            {

                return "null";
            }
        }
    }
}
