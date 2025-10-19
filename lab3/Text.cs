using System.Text;
using System.Text.RegularExpressions;

namespace lab3
{
    class Text
    {
        public List<Sentence> sentences { get; private set; } = new List<Sentence>();

        public void AddSentence(Sentence sentence)
        {
            sentences.Add(sentence);
        }

        public override string ToString()
        {
            var result = new StringBuilder();
            foreach (var sentence in sentences)
            {
                if (result.Length > 0)
                    result.Append(' ');
                result.Append(sentence.ToString());
            }
            return result.ToString();
        }

        public List<Sentence> GetSentencesByWordCountAscending()
        {
            return sentences
                 .OrderBy(s => s.tokens.Count(t => t is Word))
                 .ToList();
        }

        public List<Sentence> GetSentencesByLengthAscending()
        {
            return sentences
                .OrderBy(s => s.ToString().Length)
                .ToList();
        }

        public List<string> FindUniqueWordsInQuestionsOfLength(int length)
        {
            var unique = new List<string>();

            foreach (var s in sentences)
            {
                if (s.tokens.Count == 0) continue;

                var last = s.tokens[s.tokens.Count - 1];
                if (!(last is Punctuation p) || p.symbol != '?') continue;

                foreach (var t in s.tokens)
                {
                    if (t is Word w && w.length == length)
                    {
                        bool exists = false;
                        foreach (var u in unique)
                        {
                            if (string.Equals(u, w.content, StringComparison.OrdinalIgnoreCase))
                            {
                                exists = true;
                                break;
                            }
                        }
                        if (!exists)
                            unique.Add(w.content);
                    }
                }
            }

            return unique;
        }

        public void DeleteWordsOfLengthStartingWithConsonant(int length)
        {
            string letters = "[A-Za-zА-Яа-яЁё]";
            string consonants = "[^AEIOUaeiouАЕЁИОУЫЭЮЯаеёиоуыэюя]";

            string pattern = $"^{consonants}{letters}{{{length - 1}}}$";
            
            Regex rgx = new Regex(pattern);

            foreach (var s in sentences)
            {
                for (int i = s.tokens.Count - 1; i >= 0; i--)
                {
                    if (s.tokens[i] is Word w)
                    {
                        if (rgx.IsMatch(w.content))
                        {
                            s.tokens.RemoveAt(i);
                        }
                    }
                }
            }
        }

        public void ReplaceWordsOfLength(int targetLength, string replacement)
        {
            foreach (var s in sentences)
            {
                for (int i = 0; i < s.tokens.Count; i++)
                {
                    if (s.tokens[i] is Word w && w.length == targetLength)
                    {
                        s.tokens[i] = new Word(replacement);
                    }
                }
            }
        }

        public void RemoveStopWords(string stopwordFilePath)
        {
            var stopList = new List<string>();

            using (var reader = new StreamReader(stopwordFilePath))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine().Trim();

                    if (line.Length > 0) stopList.Add(line.ToLower());
                }
            }

            foreach (var s in sentences)
            {
                for (int i = s.tokens.Count - 1; i >= 0; i--)
                {
                    if (s.tokens[i] is Word w)
                    {
                        var word = w.content.Trim().ToLower();
                        if (stopList.Contains(word)) s.tokens.RemoveAt(i);
                    }
                }
            }
        }
    }
}
