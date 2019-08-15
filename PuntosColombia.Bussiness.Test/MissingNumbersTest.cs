using Microsoft.VisualStudio.TestTools.UnitTesting;
using PuntosColombia.Bussiness;
using System;
using System.Collections.Generic;

namespace PuntosColombia.Bussiness.Test
{
    [TestClass]
    public class MissingNumbersTest
    {
        [TestMethod]
        public void TestSearchMissingNumbers1()
        {
            //Arrange
            var n = 10;
            var m = 13;
            List<int> arr = new List<int> { 203, 204, 205, 206, 207, 208, 203, 204, 205, 206 };
            List<int> brr = new List<int> { 203, 204, 204, 205, 206, 207, 205, 208, 203, 206, 205, 206, 204 };
            string expectedResult = "204 205 206";

            MissingNumbers search = new MissingNumbers();

            //Act
            var result = search.SearchMissingNumbers(n, m, arr, brr);

            //Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void TestSearchMissingNumbers2()
        {
            //Arrange
            var n = 4;
            var m = 4;
            List<int> arr = new List<int> { 301, 303, 304, 305 };
            List<int> brr = new List<int> { 301, 302, 303, 304 };
            string expectedResult = "301";

            MissingNumbers search = new MissingNumbers();

            //Act
            var result = search.SearchMissingNumbers(n, m, arr, brr);

            //Assert
            Assert.AreNotSame(expectedResult, result);
        }

        [TestMethod]
        public void TestSearchMissingNumbers3()
        {
            //Arrange
            var n = 4;
            var m = 5;
            List<int> arr = new List<int> { 301, 303, 304, 305 };
            List<int> brr = new List<int> { 301, 302, 303, 304, 404 };
            string expectedResult = "Error_Max_Min the maximum value of list B minus the minimum value is greater than 100";

            MissingNumbers search = new MissingNumbers();

            //Act
            var result = search.SearchMissingNumbers(n, m, arr, brr);

            //Assert
            Assert.AreSame(expectedResult, result);
        }

        [TestMethod]
        public void TestSearchMissingNumbers4()
        {
            //Arrange
            var n = 4;
            var m = 5;
            List<int> arr = new List<int> { 301, 303, 304, 305 };
            List<int> brr = new List<int> { 301, 23302, 10303, 304, 305 };
            string expectedResult = "Error_brr some List B items are greater than 10000";

            MissingNumbers search = new MissingNumbers();

            //Act
            var result = search.SearchMissingNumbers(n, m, arr, brr);

            //Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void TestSearchMissingNumbers5()
        {
            //Arrange
            var n = 6;
            var m = 5;
            List<int> arr = new List<int> { 301, 303, 304, 305, 306, 307 };
            List<int> brr = new List<int> { 301, 302, 303, 304, 305 };
            string expectedResult = "Error_n>m Quantity List A  is greater than Quantity List B";

            MissingNumbers search = new MissingNumbers();

            //Act
            var result = search.SearchMissingNumbers(n, m, arr, brr);

            //Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void TestSearchMissingNumbers6()
        {
            //Arrange
            var n = 200000;
            var m = 300000;
            List<int> arr = new List<int> { 301, 303, 304, 305, 306, 307 };
            List<int> brr = new List<int> { 301, 302, 303, 304, 305 };
            string expectedResult = "Error_n Quantity List A is out of range";

            MissingNumbers search = new MissingNumbers();

            //Act
            var result = search.SearchMissingNumbers(n, m, arr, brr);

            //Assert
            Assert.AreEqual(expectedResult, result);
        }
    }
}
