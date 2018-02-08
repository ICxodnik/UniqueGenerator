using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace UniqueGenerator.Models
{
    public class TextGenerator
    {
        const string pattern = @"([\{\[][^\}\]|]+(?:\|[^\}\]|]+)+[\}\]])";
        protected IList<object> parts;
        protected Random random = new Random(Environment.TickCount);

        public TextGenerator(String text)
        {
            RegexOptions regOptions = RegexOptions.IgnoreCase | RegexOptions.CultureInvariant | RegexOptions.IgnorePatternWhitespace;

            var strings = Regex.Split(text, pattern, regOptions);

            this.parts = strings.Select<String, Object>(str =>
            {
                var first = str[0];
                switch (first)
                {
                    case '{':
                        {
                            var options = str.Substring(1, str.Length - 2).Split('|');
                            return new SampleInterpolator(options);
                        }
                    case '[':
                        {
                            var options = str.Substring(1, str.Length - 2).Split('|');
                            return new PickInterpolator(options);
                        }
                    default:
                        return str;
                }
            }).ToList();
        }

        public string Generate()
        {
            return String.Join("", this.parts);
        }

        public IEnumerable<string> Generate(int n)
        {
            for (int i = 0; i < n; i++)
            {
                yield return Generate();
            }
        }

    }
}