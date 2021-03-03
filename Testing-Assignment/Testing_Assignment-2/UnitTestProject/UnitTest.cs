using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest
    {
        string inputString = "";
        string expectedString = "";
        [TestMethod]
        public void UpperToLower()
        {
            //Arrange
            inputString = "Hello World";
            expectedString = "hELLO wORLD";
            //Act
            string outputString = TestingAssignment2.ExtensionMethods.StringConvert(inputString, "UpperToLower");

            //Assert
            Assert.AreEqual(expectedString ,outputString);
        }

        [TestMethod]
        public void TitleCase()
        {
            //Arrange
            inputString = "hello WORLD";
            expectedString = "Hello World";
            //Act
            string outputString = TestingAssignment2.ExtensionMethods.StringConvert(inputString, "TitleCase");

            //Assert
            Assert.AreEqual(expectedString, outputString);
        }

        [TestMethod]
        public void Capitalized()
        {
            //Arrange
            inputString = "hello world";
            expectedString = "Hello World";
            //Act
            string outputString = TestingAssignment2.ExtensionMethods.StringConvert(inputString, "Capitalized");

            //Assert
            Assert.AreEqual(expectedString, outputString);
        }

        [TestMethod]
        public void CheckLowerCase()
        {
            //Arrange
            inputString = "hello world";
            expectedString = "lowerCase";
            //Act
            string outputString = TestingAssignment2.ExtensionMethods.StringConvert(inputString, "CheckLowerCase");

            //Assert
            Assert.AreEqual(expectedString, outputString);
        }

        [TestMethod]
        public void CheckUpperCase()
        {
            //Arrange
            inputString = "HELLO WORLD";
            expectedString = "uppercase";
            //Act
            string outputString = TestingAssignment2.ExtensionMethods.StringConvert(inputString, "CheckUpperCase");

            //Assert
            Assert.AreEqual(expectedString, outputString);
        }

        [TestMethod]
        public void CheckforInt()
        {
            //Arrange
            inputString = "111";
            expectedString = "true";
            //Act
            string outputString = TestingAssignment2.ExtensionMethods.StringConvert(inputString, "CheckforInt");

            //Assert
            Assert.AreEqual(expectedString, outputString);
        }

        [TestMethod]
        public void RemoveLastCharacter()
        {
            //Arrange
            inputString = "Hello World";
            expectedString = "Hello Worl";
            //Act
            string outputString = TestingAssignment2.ExtensionMethods.StringConvert(inputString, "RemoveLastCharacter");

            //Assert
            Assert.AreEqual(expectedString, outputString);
        }

        [TestMethod]
        public void WordCount()
        {
            //Arrange
            inputString = "Hello World";
            expectedString = "11";
            //Act
            string outputString = TestingAssignment2.ExtensionMethods.StringConvert(inputString, "WordCount");

            //Assert
            Assert.AreEqual(expectedString, outputString);
        }


        [TestMethod]
        public void StringToInt()
        {
            //Arrange
            inputString = "111";
            expectedString = "111";
            //Act
            string outputString = TestingAssignment2.ExtensionMethods.StringConvert(inputString, "StringToInt");

            //Assert
            Assert.AreEqual(expectedString, outputString);
        }
    }
}
