using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace AOC1._1
{
    public class Day4
    {
        public static void Task1()
        {
            string[] lines = System.IO.File.ReadAllLines(@"C:\Remote\AdventOfCoding2020\AOC1.1\Resources\Data4.txt");
            List<string> passports = GetPassports(lines);

            int validCount = 0;
            foreach (var passport in passports)
            {
                if (passport.Contains("hcl:") && passport.Contains("iyr:") && passport.Contains("eyr:") && passport.Contains("ecl:") &&
                    passport.Contains("pid:") && passport.Contains("byr:") && passport.Contains("hgt:"))
                {
                    validCount++;
                }
            }

            Console.WriteLine($"Day 4, task 1: {validCount}");
        }

        public static void Task2()
        {
            string[] lines = System.IO.File.ReadAllLines(@"C:\Remote\AdventOfCoding2020\AOC1.1\Resources\Data4.txt");
            List<string> passports = GetPassports(lines);

            int validCount = 0;
            foreach (var passport in passports)
            {
                var passwordDictionary = GetPassportFieldsDictionary(passport);
                if (!IsBirthCorrect(passwordDictionary))
                {
                    continue;
                }

                if (!IsIssueYearCorrect(passwordDictionary))
                {
                    continue;
                }

                if (!IsExpirationYearCorrect(passwordDictionary))
                {
                    continue;
                }

                if (!IsHeightCorrect(passwordDictionary))
                {
                    continue;
                }

                if (!IsHairColorCorrect(passwordDictionary))
                {
                    continue;
                }

                if (!IsEyeColorCorrect(passwordDictionary))
                {
                    continue;
                }

                if (!IsPassportIdCorrect(passwordDictionary))
                {
                    continue;
                }

                validCount++;
            }

            Console.WriteLine($"Day 4, task 2: {validCount}");
        }

        private static List<string> GetPassports(string[] lines)
        {
            var passports = new List<string>();
            var tempString = "";

            foreach (var line in lines)
            {
                if (line == "")
                {
                    passports.Add(tempString);
                    tempString = "";
                    continue;
                }

                if (tempString != "")
                {
                    tempString += " ";
                }

                tempString += line;
            }
            passports.Add(tempString);
            return passports;
        }

        private static Dictionary<string, string> GetPassportFieldsDictionary(string passport)
        {
            var dictionary = new Dictionary<string, string>();
            var fields = passport.Split(" ");
            foreach (var field in fields)
            {
                var innerFields = field.Split(":");
                dictionary[innerFields[0]] = innerFields[1];
            }
            return dictionary;
        }

        private static bool IsBirthCorrect(Dictionary<string, string> passwordDictionary)
        {
            if (passwordDictionary.ContainsKey("byr"))
            {
                var value = passwordDictionary["byr"];
                var date = int.Parse(value);
                if (date < 1920 || date > 2002)
                {
                    return false;
                }
            }
            else
            {
                return false;
            }

            return true;
        }

        private static bool IsIssueYearCorrect(Dictionary<string, string> passwordDictionary)
        {
            if (passwordDictionary.ContainsKey("iyr"))
            {
                var value = passwordDictionary["iyr"];
                var date = int.Parse(value);
                if (date < 2010 || date > 2020)
                {
                    return false;
                }
            }
            else
            {
                return false;
            }

            return true;
        }

        private static bool IsExpirationYearCorrect(Dictionary<string, string> passwordDictionary)
        {
            if (passwordDictionary.ContainsKey("eyr"))
            {
                var value = passwordDictionary["eyr"];
                var date = int.Parse(value);
                if (date < 2020 || date > 2030)
                {
                    return false;
                }
            }
            else
            {
                return false;
            }

            return true;
        }

        private static bool IsHeightCorrect(Dictionary<string, string> passwordDictionary)
        {
            if (passwordDictionary.ContainsKey("hgt"))
            {
                var value = passwordDictionary["hgt"];
                var match = Regex.Match(value, @"([0-9]+)");
                if (match == null)
                {
                    return false;
                }

                var height = int.Parse(match.Value);
                if (value.Contains("in"))
                {
                    if (height < 59 || height > 76)
                    {
                        return false;
                    }
                }
                else if (value.Contains("cm"))
                {
                    if (height < 150 || height > 193)
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }

            return true;
        }

        private static bool IsHairColorCorrect(Dictionary<string, string> passwordDictionary)
        {
            if (passwordDictionary.ContainsKey("hcl"))
            {
                var value = passwordDictionary["hcl"];
                if (value.Length != 7)
                {
                    return false;
                }

                var match = Regex.Match(value, @"(#{1}[0-9a-f]{6})");
                if (match == null)
                {
                    return false;
                }
            }
            else
            {
                return false;
            }

            return true;
        }

        private static bool IsEyeColorCorrect(Dictionary<string, string> passwordDictionary)
        {
            if (passwordDictionary.ContainsKey("ecl"))
            {
                var value = passwordDictionary["ecl"];
                if (!value.Contains("amb") && !value.Contains("blu") && !value.Contains("brn") && !value.Contains("gry") && 
                    !value.Contains("grn") && !value.Contains("hzl") && !value.Contains("oth"))
                {
                    return false;
                }
            }
            else
            {
                return false;
            }

            return true;
        }

        private static bool IsPassportIdCorrect(Dictionary<string, string> passwordDictionary)
        {
            if (passwordDictionary.ContainsKey("pid"))
            {
                var value = passwordDictionary["pid"];
                if (value.Length != 9)
                {
                    return false;
                }
            }
            else
            {
                return false;
            }

            return true;
        }
    }
}