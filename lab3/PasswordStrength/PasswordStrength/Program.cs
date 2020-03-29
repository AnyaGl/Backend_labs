using System;
using System.Collections.Generic;

namespace PasswordStrength
{
    public class PasswordStrengthLib
    {
        public static bool IsLowerLetter(char ch)
        {
            return ch >= 'a' && ch <= 'z';
        }
        public static bool IsUpperLetter(char ch)
        {
            return ch >= 'A' && ch <= 'Z';
        }
        public static bool IsCorrectPassword(string password)
        {
            foreach (char ch in password)
            {
                if (!IsLowerLetter(ch) && !IsUpperLetter(ch) && !char.IsDigit(ch))
                {
                    return false;
                }
            }
            return true;
        }
        public static int StrengthByLength(string password)
        {
            return 4 * password.Length;
        }
        public static int StrengthByNumberOfDigits(string password)
        {
            int countDigit = 0;
            foreach (char ch in password)
            {
                if (char.IsDigit(ch))
                {
                    countDigit += 1;
                }
            }
            return 4 * countDigit;
        }
        public static int StrengthByNumberOfUpperLetters(string password)
        {
            int countUpperLetters = 0;

            foreach (char ch in password)
            {
                if (IsUpperLetter(ch))
                {
                    countUpperLetters += 1;
                }
            }

            if (countUpperLetters != 0)
            {
                return 2 * (password.Length - countUpperLetters);
            }
            return 0;
        }
        public static int StrengthByNumberOfLowerLetters(string password)
        {
            int countLowerLetters = 0;

            foreach (char ch in password)
            {
                if (IsLowerLetter(ch))
                {
                    countLowerLetters += 1;
                }
            }

            if (countLowerLetters != 0)
            {
                return 2 * (password.Length - countLowerLetters);
            }
            return 0;
        }
        public static int StrengthByOnlyLetters(string password)
        {
            int countLetters = 0;
            foreach (char ch in password)
            {
                if (IsLowerLetter(ch) || IsUpperLetter(ch))
                {
                    countLetters += 1;
                }
            }
            if (countLetters == password.Length)
            {
                return -countLetters;
            }
            return 0;
        }
        public static int StrengthByOnlyDigits(string password)
        {
            int countDigits = 0;
            foreach (char ch in password)
            {
                if (char.IsDigit(ch))
                {
                    countDigits += 1;
                }
            }
            if (countDigits == password.Length)
            {
                return -countDigits;
            }
            return 0;
        }
        public static int StrengthByRepeatingChars(string password)
        {
            int strength = 0;
            Dictionary<char, int> numberOfChar = new Dictionary<char, int>();
            foreach (char ch in password)
            {
                if (!numberOfChar.ContainsKey(ch))
                {
                    numberOfChar.Add(ch, 1);
                }
                else
                {
                    numberOfChar[ch] += 1;
                }
            }
            foreach (var elem in numberOfChar)
            {
                if (elem.Value != 1)
                {
                    strength -= elem.Value;
                }
            }
            return strength;
        }
        public static int? PasswordStrength(string password)
        {            
            if (!IsCorrectPassword(password))
            {
                Console.WriteLine("Password must consist of latin letters and numbers");
                return null;
            }

            int strength = 0;
            strength += StrengthByLength(password);
            strength += StrengthByNumberOfDigits(password);
            strength += StrengthByNumberOfLowerLetters(password);
            strength += StrengthByNumberOfUpperLetters(password);
            strength += StrengthByOnlyDigits(password);
            strength += StrengthByOnlyLetters(password);
            strength += StrengthByRepeatingChars(password);

            return strength;
        }
    }
    class Program
    {
        static int Main(string[] args)
        {
            if (args.Length != 1)
            {
                Console.WriteLine("Invalid number of arguments\n" +
                                  "Usage: PasswordStrength.exe <password>");
                return 1;
            }
            string password = args[0];
            int? strength = PasswordStrengthLib.PasswordStrength(password);
            if (strength == null)
            {
                return 1;
            }
            Console.WriteLine(strength);
            return 0;
        }
    }
}
