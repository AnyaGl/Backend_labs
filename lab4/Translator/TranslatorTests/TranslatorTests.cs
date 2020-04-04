using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace TranslatorTests
{
    [TestClass]
    public class TranslatorTests
    {
        Translator.Translator translator = new Translator.Translator("vocabulary.txt");
        [TestMethod]
        public void ConstructorTest()
        {
            Dictionary<string, string> reqVocabulary = new Dictionary<string, string> { 
                { "cat", "кот" },
                { "ball", "м€ч" },
                { "meat", "м€со" },
                { "big house", "большой дом" },
            };
            
            CollectionAssert.AreEquivalent(reqVocabulary, translator.vocabulary);
        }
        [TestMethod]
        public void GetTranslation_ExistingEnWord_TraslationReturned()
        {
            Assert.AreEqual("кот", translator.GetTranslation("cat"));
            Assert.AreEqual("большой дом", translator.GetTranslation("big house"));
        }
        [TestMethod]
        public void GetTranslation_NonexistingEnWord_NullReturned()
        {
            Assert.AreEqual(null, translator.GetTranslation("asd"));
        }
        [TestMethod]
        public void GetTranslation_ExistingRusWord_TraslationReturned()
        {
            Assert.AreEqual("cat", translator.GetTranslation("кот"));
            Assert.AreEqual("big house", translator.GetTranslation("большой дом"));
        }
        [TestMethod]
        public void GetTranslation_NonexistingRusWord_NullReturned()
        {
            Assert.AreEqual(null, translator.GetTranslation("фыв"));
        }
    }
}
