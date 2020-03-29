using Microsoft.VisualStudio.TestTools.UnitTesting;
using CheckIdentifier;

namespace CheckIdentifierTests
{
    [TestClass]
    public class CheckIdentifierTests
    {
            [TestMethod]
        public void IsLetter_NotLatinLetter_FalseReturned()
        {
            Assert.AreEqual(false, CheckIdentifierLib.IsLetter('1'));
            Assert.AreEqual(false, CheckIdentifierLib.IsLetter('ò'));
            Assert.AreEqual(false, CheckIdentifierLib.IsLetter('*'));
        }

        [TestMethod]
        public void IsLetter_LatinLetter_TrueReturned()
        {
            Assert.AreEqual(true, CheckIdentifierLib.IsLetter('A'));
            Assert.AreEqual(true, CheckIdentifierLib.IsLetter('z'));
        }

        [TestMethod]
        public void IsCorrectIdentifier_IncorrectIdentifier_FalseRetrened()
        {
            Assert.AreEqual(false, CheckIdentifierLib.IsCorrectIdentifier("C*h"));
            Assert.AreEqual(false, CheckIdentifierLib.IsCorrectIdentifier("1Ch"));
        }

        [TestMethod]
        public void IsCorrectIdentifier_CorrectIdentifier_TrueRetrened()
        {
            Assert.AreEqual(true, CheckIdentifierLib.IsCorrectIdentifier("ch"));
            Assert.AreEqual(true, CheckIdentifierLib.IsCorrectIdentifier("Ch1"));
        }
    }

    [TestClass]
    public class ProgramTests
    {
        [TestMethod]
        public void ParseArgs_InvalidNumberOfArguments_FalseReturned()
        {
            string[] args = { };
            Assert.AreEqual(false, Program.ParseArgs(args));
            args = new[] { "", "" };
            Assert.AreEqual(false, Program.ParseArgs(args));
        }

        [TestMethod]
        public void ParseArgs_OneArgument_TrueReturned()
        {
            string[] args = { "123" };
            Assert.AreEqual(true, Program.ParseArgs(args));
        }
    }
}
