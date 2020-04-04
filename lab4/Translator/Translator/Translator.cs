using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Text;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Translator
{
    public class Translator 
    {
        public Dictionary<string, string> vocabulary;
        public Translator(string path)
        {
            this.vocabulary = InitVocabulary(path);
        }
        
        Dictionary<string, string> InitVocabulary(string vocabularyFileName)
        {
            Dictionary<string, string> vocabulary = new Dictionary<string, string> { };
            using (StreamReader input = new StreamReader(vocabularyFileName, encoding: Encoding.UTF8))
            {
                string line;
                while ((line = input.ReadLine()) != null)
                {
                    string[] words = line.Split('~');
                    vocabulary.Add(words[0], words[1]);
                }
            }
            return vocabulary;
        }
        bool IsEnWord(string word)
        {
            foreach (char ch in word)
            {
                if ((ch > 'z' || ch < 'a') && ch != ' ')
                {
                    return false;
                }
            }
            return true;
        }
        public string GetTranslation(string word)
        {
            word = word.ToLower();
            if (IsEnWord(word))
            {
                return TranslateEnWord(word);
            }
            return TranslateRusWord(word);            
        }
        string TranslateEnWord(string word)
        {
            try
            {
                return vocabulary[word];
            }
            catch
            {
                return null;
            }
        }
        string TranslateRusWord(string word)
        {
            return vocabulary.Where(x => x.Value == word).FirstOrDefault().Key;
        }


    }
}
