using System;
using NUnit.Framework;

namespace _09.DateTime.Now.AddDays.Tests
{
    [TestFixture]
    public class DateTimeTests
    {
        private IDateTime sut;

        [SetUp]
        public void InitializeDateTime()
        {
            this.sut = new MyDateTime();
        }

        [Test]
        public void Test_ShoudReturnCurrentData()
        {
           var expectedData = System.DateTime.Now.Date;

            Assert.AreEqual(expectedData, this.sut.Now().Date);
        }

        [Test]
        public void AddingADayToTheLastOneOfAMonthShouldResultInTheFirstDayOfTheNextMonth()
        {
            var testDate = new System.DateTime(2000, 10, 31);
            var expectedDate = new System.DateTime(2000, 11, 1);

            testDate = testDate.AddDays(1);

            Assert.AreEqual(expectedDate, testDate);
        }


    }
}
