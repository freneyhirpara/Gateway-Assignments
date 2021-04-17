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
            // Arrange
            inputString = "Hello World";
            expectedString = "hELLO wORLD";

            // Act
            string outputString = inputString.UpperToLower();

            // Assert
            Assert.Equal(expectedString ,outputString);
        }

        [Fact]
        public void TitleCase()
        {
            // Arrange
            inputString = "hello WORLD";
            expectedString = "Hello World";

            // Act
            string outputString = inputString.TitleCase();

            // Assert
            Assert.Equal(expectedString, outputString);
        }

        [Fact]
        public void Capitalized()
        {
            // Arrange
            inputString = "hello world";
            expectedString = "Hello World";

            // Act
            string outputString = inputString.Capitalized();

            // Assert
            Assert.Equal(expectedString, outputString);
        }

        [Fact]
        public void CheckLowerCase()
        {
            // Arrange
            inputString = "hello world";
            expectedString = "true";

            // Act
            string outputString = inputString.CheckLowerCase();

            // Assert
            Assert.Equal(expectedString, outputString);
        }

        [Fact]
        public void CheckUpperCase()
        {
            // Arrange
            inputString = "HELLO WORLD";
            expectedString = "true";

            // Act
            string outputString = inputString.CheckUpperCase();

            // Assert
            Assert.Equal(expectedString, outputString);
        }

        [Fact]
        public void CheckforInt()
        {
            // Arrange
            inputString = "111";
            expectedString = "true";

            // Act
            string outputString = inputString.CheckforInt();

            // Assert
            Assert.Equal(expectedString, outputString);
        }

        [Fact]
        public void RemoveLastCharacter()
        {
            // Arrange
            inputString = "Hello World";
            expectedString = "Hello Worl";

            // Act
            string outputString = inputString.RemoveLastCharacter();

            // Assert
            Assert.Equal(expectedString, outputString);
        }

        [Fact]
        public void WordCount()
        {
            // Arrange
            inputString = "Hello World";
            expectedString = "11";

            // Act
            string outputString = inputString.WordCount();

            // Assert
            Assert.Equal(expectedString, outputString);
        }


        [Fact]
        public void StringToInt()
        {
            // Arrange
            inputString = "111";
            expectedString = "111";

            // Act
            string outputString = inputString.StringToInt();

            // Assert
            Assert.Equal(expectedString, outputString);
        }
    }
}
