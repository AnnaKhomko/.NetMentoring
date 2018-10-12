using System;
using NUnit;
using NUnit.Framework;
using ParserForInt;

namespace UnitTestForParser
{
    [TestFixture]
    public class UnitTests 
    {
        public Logic logic;


        [SetUp]
        public void Init()
        {
            logic = new Logic();
        }

        [Test]
        [TestCase("12")]
        [TestCase("-12")]
        [TestCase("145")]
        [TestCase("+145")]
        [TestCase("0")]
        [TestCase("2147483647")]
        [TestCase("-2147483648")]
        public void TestSuccessfulParseIntoInteger(string str)
        {
            Assert.AreEqual(int.Parse(str), logic.DetermeType(str));
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void TestArgumentExceptionExpected(string str)
        {

            Assert.Throws<ArgumentException>(() => logic.DetermeType(str));

        }

        [Test]
        [TestCase("dgdghgh")]
        [TestCase("-2//b")]
        public void TestCheckingStrings(string str)
        {

            Assert.Throws<TypeIsStringException>(() => logic.DetermeType(str));

        }

        [Test]
        [TestCase("3.5")]
        [TestCase("-3.5")]
        public void TestCheckingDouble(string str)
        {

            Assert.Throws<TypeIsFloatException>(() => logic.DetermeType(str));

        }

        [Test]
        [TestCase("21474836476")]
        [TestCase("-21474836488")]
        public void TestCheckingMaxValue(string str)
        {

            Assert.Throws<OverflowException>(() => logic.DetermeType(str));

        }
    }
   
}
