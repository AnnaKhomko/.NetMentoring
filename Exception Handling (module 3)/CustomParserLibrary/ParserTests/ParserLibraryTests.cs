using CustomParserLibrary;
using NUnit.Framework;
using System;

namespace ParserLibraryTests
{
    [TestFixture]
    public class ParserLibraryTests
    {
        public CustomParser parser;

        [SetUp]
        public void Init()
        {
            parser = new CustomParser();
        }

        [Test]
        [TestCase("12")]
        [TestCase("-12")]
        [TestCase("145")]
        [TestCase("+145")]
        [TestCase("0")]
        [TestCase("2147483647")]
        [TestCase("-2147483648")]
        public void ParseToInt_EnteredDataIsCorrect_ParsingCompleteSuccessfully(string str)
        {
            int actualResult;
            parser.ParseToInt(str, out actualResult);
            Assert.AreEqual(int.Parse(str), actualResult, "Parser works unexpected for correct int numbers.");
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void ParseToInt_NullArgumentEntered_ExpectedExceptionThrows(string str)
        {
            int actualResult;
            Assert.Throws<ArgumentNullException>(() => parser.ParseToInt(str, out actualResult));
        }

        [Test]
        [TestCase("dgdghgh")]
        [TestCase("-2//b")]
        public void ParseToInt_StringTypeEntered_ExpectedExceptionThrows(string str)
        {
            int actualResult;
            Assert.Throws<FormatException>(() => parser.ParseToInt(str, out actualResult));
        }

        [Test]
        [TestCase("3.54")]
        [TestCase("-3.52")]
        public void ParseToInt_FloatTypeEntered_ExpectedExceptionThrows(string str)
        {
            int actualResult;
            Assert.Throws<FormatException>(() => parser.ParseToInt(str, out actualResult));
        }

        [Test]
        [TestCase("21474836476")]
        [TestCase("-21474836488")]
        public void ParseToInt_LongTypeEntered_ExpectedExceptionThrows(string str)
        {
            int actualResult;
            Assert.Throws<FormatException>(() => parser.ParseToInt(str, out actualResult));
        }
    }
}
