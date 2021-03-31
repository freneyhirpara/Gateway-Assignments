using System;
using Xunit;

namespace UnitTestProject
{
    public class UnitTest
    {
        string inputString = "";
        string expectedString = "";

        [Fact]
        public void UpperToLower()
        {
            //Arrange
            inputString = "Hello World";
            expectedString = "hELLO wORLD";

            //Act
            string outputString = TestingAssignment2.ExtensionMethods.Conversion(inputString, "UpperToLower");

            //Assert
            Assert.Equal(expectedString ,outputString);
        }

        [Fact]
        public void TitleCase()
        {
            //Arrange
            inputString = "hello WORLD";
            expectedString = "Hello World";

            //Act
            string outputString = TestingAssignment2.ExtensionMethods.Conversion(inputString, "TitleCase");

            //Assert
            Assert.Equal(expectedString, outputString);
        }

        [Fact]
        public void Capitalized()
        {
            //Arrange
            inputString = "hello world";
            expectedString = "Hello World";

            //Act
            string outputString = TestingAssignment2.ExtensionMethods.Conversion(inputString, "Capitalized");

            //Assert
            Assert.Equal(expectedString, outputString);
        }

        [Fact]
        public void CheckLowerCase()
        {
            //Arrange
            inputString = "hello world";
            expectedString = "lowerCase";

            //Act
            string outputString = TestingAssignment2.ExtensionMethods.Conversion(inputString, "CheckLowerCase");

            //Assert
            Assert.Equal(expectedString, outputString);
        }

        [Fact]
        public void CheckUpperCase()
        {
            //Arrange
            inputString = "HELLO WORLD";
            expectedString = "uppercase";

            //Act
            string outputString = TestingAssignment2.ExtensionMethods.Conversion(inputString, "CheckUpperCase");

            //Assert
            Assert.Equal(expectedString, outputString);
        }

        [Fact]
        public void CheckforInt()
        {
            //Arrange
            inputString = "111";
            expectedString = "true";

            //Act
            string outputString = TestingAssignment2.ExtensionMethods.Conversion(inputString, "CheckforInt");

            //Assert
            Assert.Equal(expectedString, outputString);
        }

        [Fact]
        public void RemoveLastCharacter()
        {
            //Arrange
            inputString = "Hello World";
            expectedString = "Hello Worl";

            //Act
            string outputString = TestingAssignment2.ExtensionMethods.Conversion(inputString, "RemoveLastCharacter");

            //Assert
            Assert.Equal(expectedString, outputString);
        }

        [Fact]
        public void WordCount()
        {
            //Arrange
            inputString = "Hello World";
            expectedString = "11";

            //Act
            string outputString = TestingAssignment2.ExtensionMethods.Conversion(inputString, "WordCount");

            //Assert
            Assert.Equal(expectedString, outputString);
        }


        [Fact]
        public void StringToInt()
        {
            //Arrange
            inputString = "111";
            expectedString = "111";

            //Act
            string outputString = TestingAssignment2.ExtensionMethods.Conversion(inputString, "StringToInt");

            //Assert
            Assert.Equal(expectedString, outputString);
        }
    }
}
