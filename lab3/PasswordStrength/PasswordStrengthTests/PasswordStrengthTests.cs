using Microsoft.VisualStudio.TestTools.UnitTesting;
using PasswordStrength;
namespace PasswordStrengthTests
{
    [TestClass]
    public class PasswordStrengthLibTests
    {
        [TestMethod]
        public void PasswordStrength_Paasword_StrengthReturned()
        {
            Assert.AreEqual(7, PasswordStrengthLib.PasswordStrength("1"));
            Assert.AreEqual(28, PasswordStrengthLib.PasswordStrength("aa1A"));
            Assert.AreEqual(6, PasswordStrengthLib.PasswordStrength("aaa"));
            Assert.AreEqual(72, PasswordStrengthLib.PasswordStrength("Qwerty123"));
        }


        [TestMethod]
        public void IsCorrectPassword_CorrectPassword_TrueReturned()
        {
            Assert.AreEqual(true, PasswordStrengthLib.IsCorrectPassword("Ab1"));
        }
        [TestMethod]
        public void IsCorrectPassword_InvalidPassword_FalseReturned()
        {
            Assert.AreEqual(false, PasswordStrengthLib.IsCorrectPassword("Ab.1"));
        }


        [TestMethod]
        public void StrengthByLength_String_4xLengthReturned()
        {
            Assert.AreEqual(16, PasswordStrengthLib.StrengthByLength("Ag1B"));
        }


        [TestMethod]
        public void StrengthByNumberOfDigits_String_4xNumberOfDigitsReturned()
        {
            Assert.AreEqual(8, PasswordStrengthLib.StrengthByNumberOfDigits("Ag1B2"));
            Assert.AreEqual(0, PasswordStrengthLib.StrengthByNumberOfDigits("qwe"));
        }


        [TestMethod]
        public void StrengthByNumberOfUpperLetters_StringWithUpperLetters_StrengthReturned() //strength = ((len-n)*2)
        {
            Assert.AreEqual(0, PasswordStrengthLib.StrengthByNumberOfUpperLetters("A"));
            Assert.AreEqual(2, PasswordStrengthLib.StrengthByNumberOfUpperLetters("Aa"));
            Assert.AreEqual(6, PasswordStrengthLib.StrengthByNumberOfUpperLetters("Aaaa"));
        }
        [TestMethod]
        public void StrengthByNumberOfUpperLetters_StringWithoutUpperLetters_StrengthReturned() //strength = ((len-n)*2)
        {
            Assert.AreEqual(0, PasswordStrengthLib.StrengthByNumberOfUpperLetters("a"));
            Assert.AreEqual(0, PasswordStrengthLib.StrengthByNumberOfUpperLetters("aaa"));
        }


        [TestMethod]
        public void StrengthByNumberOfLowerLetters_StringWithLowerLetters_StrengthReturned() //strength = ((len-n)*2)
        {
            Assert.AreEqual(0, PasswordStrengthLib.StrengthByNumberOfLowerLetters("a"));
            Assert.AreEqual(2, PasswordStrengthLib.StrengthByNumberOfLowerLetters("Aa"));
            Assert.AreEqual(4, PasswordStrengthLib.StrengthByNumberOfLowerLetters("AAaaa"));
        }
        [TestMethod]
        public void StrengthByNumberOfLowerLetters_StringWithoutLowerLetters_StrengthReturned() //strength = ((len-n)*2)
        {
            Assert.AreEqual(0, PasswordStrengthLib.StrengthByNumberOfLowerLetters("A"));
            Assert.AreEqual(0, PasswordStrengthLib.StrengthByNumberOfLowerLetters("AAA"));
        }


        [TestMethod]
        public void StrengthByOnlyLetters_StringWithOnlyLetters_StrengthReturned() //strength = -len
        {
            Assert.AreEqual(-1, PasswordStrengthLib.StrengthByOnlyLetters("a"));
            Assert.AreEqual(-4, PasswordStrengthLib.StrengthByOnlyLetters("Aaaa"));
        }
        [TestMethod]
        public void StrengthByOnlyLetters_StringWithNotOnlyLetters_StrengthReturned() //strength = 0
        {
            Assert.AreEqual(0, PasswordStrengthLib.StrengthByOnlyLetters("132ab"));
        }


        [TestMethod]
        public void StrengthByOnlyDigits_StringWithOnlyDigits_StrengthReturned() //strength = -len
        {
            Assert.AreEqual(-1, PasswordStrengthLib.StrengthByOnlyDigits("1"));
            Assert.AreEqual(-4, PasswordStrengthLib.StrengthByOnlyDigits("1123"));
        }
        [TestMethod]
        public void StrengthByOnlyDigits_StringWithNotOnlyDigits_StrengthReturned() //strength = 0
        {
            Assert.AreEqual(0, PasswordStrengthLib.StrengthByOnlyDigits("aa12a"));
        }


        [TestMethod]
        public void StrengthByRepeatingChars_StringWithRepeating_StrengthReturned()
        {
            Assert.AreEqual(-3, PasswordStrengthLib.StrengthByRepeatingChars("aa12a"));
            Assert.AreEqual(-7, PasswordStrengthLib.StrengthByRepeatingChars("aa1111a"));
            Assert.AreEqual(0, PasswordStrengthLib.StrengthByRepeatingChars("123a"));
            Assert.AreEqual(0, PasswordStrengthLib.StrengthByRepeatingChars("aA"));
        }
    }
}
