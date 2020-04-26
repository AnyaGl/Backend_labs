using Microsoft.VisualStudio.TestTools.UnitTesting;
using RemoveExtraBlanks;

namespace RemoveExtraBlanksTests
{
    [TestClass]
    public class RemoveExtraBlanksLibTests
    {
        [TestMethod]
        public void RemoveExtraBlanks_EmptyString_EmptyStringReturned()
        {
            Assert.AreEqual("", RemoveExtraBlanksLib.RemoveExtraBlanks(""));
        }
        [TestMethod]
        public void RemoveExtraBlanks_StringWithExtraSpaces_StringWithoutExtraSpacesReturned()
        {
            string str = "   привет    мир        ";
            string resultStr = "привет мир";
            Assert.AreEqual(resultStr, RemoveExtraBlanksLib.RemoveExtraBlanks(str));
        }
        [TestMethod]
        public void RemoveExtraBlanks_StringWithExtraTabs_StringWithoutExtraTabsReturned()
        {
            string str = "\t\tпривет\t\t\tмир\t";
            string resultStr = "привет\tмир";
            Assert.AreEqual(resultStr, RemoveExtraBlanksLib.RemoveExtraBlanks(str));
        }
        [TestMethod]
        public void RemoveExtraBlanks_StringWithExtraBlanks_StringWithoutExtraBlanksReturned()
        {
            string str = "\t \tпривет\t   \t мир   \t!   ";
            string resultStr = "привет\tмир !";
            Assert.AreEqual(resultStr, RemoveExtraBlanksLib.RemoveExtraBlanks(str));
        }
        [TestMethod]
        public void RemoveExtraBlanks_StringWithoutExtraBlanks_SameStringReturned()
        {
            string str = "привет мир";
            string resultStr = "привет мир";
            Assert.AreEqual(resultStr, RemoveExtraBlanksLib.RemoveExtraBlanks(str));
        }
    }
    [TestClass]
    public class ProgramTests
    {
        [TestMethod]
        public void CopyFileWithRemoveExtraBlanks_NonExistInputFile_FalseReturned()
        {
            Assert.AreEqual(false, Program.CopyFileWithRemoveExtraBlanks("nonExist.txt", "output.txt"));
        }
        [TestMethod]
        public void CopyFileWithRemoveExtraBlanks_NonExistOutputFile_FalseReturned()
        {
            Assert.AreEqual(false, Program.CopyFileWithRemoveExtraBlanks("../../../../RemoveExtraBlanks/bin/Debug/netcoreapp3.1/input.txt", "l:/output.txt"));
        }
    }
}

