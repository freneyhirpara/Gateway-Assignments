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
            public static string Conversion(this string input, string output)
            {
                string outputString = "";
                int asciiValue = 0;

                if (output.Equals("UpperToLower"))
                {
                    foreach (var ch in input)
                    {
                        asciiValue = (int)ch;

                        if (asciiValue >= 65 && asciiValue <= 90)
                            asciiValue = asciiValue + 32;
                        else if (asciiValue >= 97 && asciiValue <= 122)
                            asciiValue = asciiValue - 32;
                        outputString += (char)asciiValue;
                    }

                    return outputString;
                }
                else if (output.Equals("TitleCase") || output.Equals("Capitalized"))
                {
                    TextInfo text = new CultureInfo("en-us", false).TextInfo;
                    return text.ToTitleCase(input);
                }

                else if (output.Equals("CheckLowerCase"))
                {
                bool status = false;
                foreach (var item in input)
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
                else if (output.Equals("CheckUpperCase"))
                {
                bool status = false;
                foreach (var item in input)
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
                else if (output.Equals("CheckforInt"))
                {
                    try
                    {
                        int x = int.Parse(input);
                        return "true";
                    }
                    catch (Exception)
                    {

                        return "false";
                    }
                }
                else if (output.Equals("RemoveLastCharacter"))
                {
                    return input.Substring(0,input.Length - 1);
                }
                else if (output.Equals("WordCount"))
                {

                    var count = 0;

                    for (var i = 0; i < input.Length; i++)
                    {
                        if (input[i] == ' ' || i == input.Length - 1)
                            count++;
                    }
                    
                    return count.ToString();
                }
                else if (output.Equals("StringToInt"))
                {
                    try
                    {
                        return "" + int.Parse(input);
                    }
                    catch (Exception)
                    {

                        return "null";
                    }
                }
                return "";
            }
        }
    }