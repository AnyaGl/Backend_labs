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
                { "cat", "���" },
                { "ball", "���" },
                { "meat", "����" },
                { "big house", "������� ���" },
            };
            
            CollectionAssert.AreEquivalent(reqVocabulary, translator.vocabulary);
        }
        [TestMethod]
        public void GetTranslation_ExistingEnWord_TraslationReturned()
        {
            Assert.AreEqual("���", translator.GetTranslation("cat"));
            Assert.AreEqual("������� ���", translator.GetTranslation("big house"));
        }
    }
}
