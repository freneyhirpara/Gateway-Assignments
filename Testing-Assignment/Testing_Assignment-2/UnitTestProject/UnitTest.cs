using System;
using TestingAssignment2;
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
            string outputString = inputString.UppertoLower();

            // Assert
            Assert.Equal(expectedString, outputString);
        }

        [Fact]
        public void TitleCase()
        {
            // Arrange
            inputString = "hello";
            expectedString = "Hello";

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
        public void CheckLowerCaseSuccess()
        {
            // Arrange
            inputString = "hello";
            expectedString = "true";

            // Act
            string outputString = inputString.CheckLowerCase();

            // Assert
            Assert.Equal(expectedString, outputString);
        }

        [Fact]
        public void CheckLowerCaseFail()
        {
            // Arrange
            inputString = "hELLO";
            expectedString = "false";

            // Act
            string outputString = inputString.CheckLowerCase();

            // Assert
            Assert.Equal(expectedString, outputString);
        }

        [Fact]
        public void CheckUpperCaseSuccess()
        {
            // Arrange
            inputString = "HELLO";
            expectedString = "true";

            // Act
            string outputString = inputString.CheckUpperCase();

            // Assert
            Assert.Equal(expectedString, outputString);
        }

        [Fact]
        public void CheckUpperCaseFail()
        {
            // Arrange
            inputString = "Hello";
            expectedString = "false";

            // Act
            string outputString = inputString.CheckUpperCase();

            // Assert
            Assert.Equal(expectedString, outputString);
        }

        [Fact]
        public void CheckforIntSuccess()
        {
            // Arrange
            inputString = "111";
            expectedString = "Success";

            // Act
            string outputString = inputString.CheckforInt();

            // Assert
            Assert.Equal(expectedString, outputString);
        }

        [Fact]
        public void CheckforIntFail()
        {
            // Arrange
            inputString = "hello";
            expectedString = "Failed";

            // Act
            string outputString = inputString.CheckforInt();

            // Assert
            Assert.Equal(expectedString, outputString);
        }

        [Fact]
        public void RemoveLastChar()
        {
            // Arrange
            inputString = "Hello World";
            expectedString = "Hello Worl";

            // Act
            string outputString = inputString.RemoveLastChar();

            // Assert
            Assert.Equal(expectedString, outputString);
        }

        [Fact]
        public void WordCount()
        {
            // Arrange
            inputString = "Hello World";
            expectedString = "2";

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
