using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SUT = ExampleNextDate;
using FluentAssertions;

namespace NextDateTests
{
    [TestClass]
    public class NextDate_Should
    {
        [DataTestMethod]
        [DataRow(0, 1, 1818, DisplayName = "Month < 1")]
        [DataRow(13, 1, 1818, DisplayName = "Month > 12")]
        [DataRow(1, 0, 1818, DisplayName = "Day < 1")]
        [DataRow(1, 32, 1818, DisplayName = "Day > 31")]
        [DataRow(1, 1, 1817, DisplayName = "Year < 1818")]
        [DataRow(1, 1, 2022, DisplayName = "Year > 2021")]


        public void ReturnInvalidDateException_WhenDayMonthOrYearOutOfRange(int testMonth, int testDay, int testYear)
        {
            // Arrange
            SUT.Date today = new SUT.Date { Day = testDay, Month = testMonth, Year = testYear };

            //Act (well, actually more Arrange)
            Action test = () => { SUT.Date tomorrow = today.NextDate(); };

            //Assert
            test.Should().Throw<SUT.InvalidDateException>();
        }

        [DataTestMethod] //Valid Test Cases from Decision Table
        [DataRow(4, 16, 2001, 4, 15, 2001, DisplayName = "Cases 1 - 3")]
        [DataRow(5, 1, 2001, 4, 30, 2001, DisplayName = "Case 4")]
        [DataRow(1, 16, 2001, 1, 15, 2001, DisplayName = "Case 6-9")]
        [DataRow(2, 1, 2001, 1, 31, 2001, DisplayName = "Case 10")]
        [DataRow(12, 16, 2001, 12, 15, 2001, DisplayName = "Case 11-14")]
        [DataRow(1, 1, 2002, 12, 31, 2001, DisplayName = "Case 15")]
        [DataRow(2, 16, 2002, 2, 15, 2002, DisplayName = "Case 16")]
        [DataRow(2, 29, 2004, 2, 28, 2004, DisplayName = "Case 17")]
        [DataRow(3, 1, 2001, 2, 28, 2001, DisplayName = "Case 18")]
        [DataRow(3, 1, 2004, 2, 29, 2004, DisplayName = "Case 19")]

        public void ReturnValidDate_WhenInputIsValid(int nextMonth, int nextDay, int nextYear, int testMonth, int testDay, int testYear)
        {
            // Arrange
            SUT.Date today = new SUT.Date { Day = testDay, Month = testMonth, Year = testYear };
            SUT.Date expected = new SUT.Date { Day = nextDay, Month = nextMonth, Year = nextYear };

            //Act
            SUT.Date tomorrow = today.NextDate();

            //Assert
            expected.Should().BeEquivalentTo(tomorrow);
        }

        [DataTestMethod] //Invalid Test Cases from Decision Table
        [DataRow(4, 31, 2001, DisplayName = "Case 5")]
        [DataRow(2, 29, 2001, DisplayName = "Case 20")]
        [DataRow(2, 30, 2001, DisplayName = "Case 21,22")]

        public void ReturnInvalidDateException_WhenInputDateIsInvalid(int testMonth, int testDay, int testYear)
        {
            // Arrange
            SUT.Date today = new SUT.Date { Day = testDay, Month = testMonth, Year = testYear };

            //Act (well, actually more Arrange)
            Action test = () => { SUT.Date tomorrow = today.NextDate(); };

            //Assert
            test.Should().Throw<SUT.InvalidDateException>();
        }

    }

    [TestClass]
    public class IsLeapYear_Should
    {
        [DataTestMethod]
        [DataRow(1992)]
        [DataRow(1996)]
        [DataRow(2000)]
        public void ReturnTrue_WhenInputIsLeapYear(int year)
        {
            Assert.IsTrue(SUT.Date.IsLeapYear(year));
        }

        [DataTestMethod]
        [DataRow(1900)]
        [DataRow(1993)]
        public void ReturnFalse_WhenInputIsNotLeapYear(int year)
        {
            Assert.IsFalse(SUT.Date.IsLeapYear(year));
        }

    }
}
