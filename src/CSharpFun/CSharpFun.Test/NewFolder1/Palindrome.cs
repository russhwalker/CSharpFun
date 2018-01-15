using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpFun.Test
{
    [TestClass]
    public class Palindrome
    {



        private IEnumerable<string> ParsePalidromes(string input)
        {
            for (int i = 1; i < input.Length; i++)
            {
                for (int j = 0; j <= input.Length - i; j++)
                {
                    var s = input.Substring(j, i);
                    if (s.Length > 1 && s.SequenceEqual(s.Reverse()))
                    {
                        yield return s;
                    }
                }
            }
        }


        private IEnumerable<string> ParsePalidromesLinq(string input)
        {
            var strings =
               from i in Enumerable.Range(0, input.Length)
               from j in Enumerable.Range(0, input.Length - i + 1)
               where j > 1
               select input.Substring(i, j);

            foreach (var s in strings)
            {
                if (s.SequenceEqual(s.Reverse()))
                {
                    yield return s;
                }
            }
        }

        [TestMethod]
        public void ParsePalidromesTest()
        {
            const string input = "aaabccba3fdsa";
            var palidromes = ParsePalidromes(input).ToList();
            Assert.AreEqual(6, palidromes.Count);
        }

        [TestMethod]
        public void ParsePalidromesLinqTest()
        {
            const string input = "aaabccba3fdsa";
            var palidromes = ParsePalidromesLinq(input).ToList();
            Assert.AreEqual(6, palidromes.Count);
        }

    }
}
