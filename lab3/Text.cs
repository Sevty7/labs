using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Serialization;

namespace lab3
{
    [XmlRoot("text")]
    public class Text
    {
        [XmlElement("sentence")]
        public List<Sentence> sentences { get; set; } = new List<Sentence>();

        [XmlIgnore]
        public int paragraphsBeforeFirst = 0;
        [XmlIgnore]
        public Dictionary<int, int> paragraphsAfter = new Dictionary<int, int>();

        public Text() { }

        public void AddSentence(Sentence sentence)
        {
            sentences.Add(sentence);
        }

        public override string ToString()
        {
            var result = new StringBuilder();

            for (int i = 0; i < paragraphsBeforeFirst; i++)
                result.Append("\r\n");

            for (int i = 0; i < sentences.Count; i++)
            {
                result.Append(sentences[i].ToString());

                if (paragraphsAfter.ContainsKey(i))
                {
                    for (int k = 0; k < paragraphsAfter[i]; k++)
                        result.Append("\r\n");
                }
                else
                {
                    if (i < sentences.Count - 1)
                        result.Append(' ');
                }
            }

            return result.ToString();
        }


        public List<Sentence> GetSentencesByWordCountAscending()
        {
            return sentences
                 .OrderBy(countWords)
                 .ToList();
        }

        public int countWords(Sentence s)
        {
            int count = 0;
            
            foreach (var token in s.tokens)
            {
                if (token is Word) count++;
            }

            return count;
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
       
        public SortedDictionary<string, (int Count, SortedSet<int> Lines)> BuildConcordance()
        {
            var concordance = new SortedDictionary<string, (int Count, SortedSet<int> Lines)>();
            int lineNumber = 1;
            for (int i = 0; i < sentences.Count; i++)
            {
                if (!paragraphsAfter.ContainsKey(i)) 
                    continue;
                else
                    lineNumber = i;

                foreach (var token in sentences[i].tokens)
                {
                    if (token is Word w)
                    {
                        string word = w.content.Trim().ToLower();

                        if (string.IsNullOrEmpty(word)) continue;

                        if (!concordance.ContainsKey(word))
                            concordance[word] = (0, new SortedSet<int>());

                        var entry = concordance[word];
                        entry.Count++;
                        entry.Lines.Add(lineNumber);

                        concordance[word] = entry;
                    }
                }
            }
            return concordance;
        }

        public string ConcordanceToString()
        {
            var concord = BuildConcordance();
            var sb = new StringBuilder();
            string currentHeader = null;

            foreach (var kv in concord)
            {
                string key = kv.Key;

                if (string.IsNullOrEmpty(key)) continue;

                string header = char.ToUpper(key[0]).ToString();

                if (currentHeader != header)
                {
                    sb.AppendLine(header);
                    currentHeader = header;
                }

                sb.AppendLine($"{key} {kv.Value.Count}: {string.Join(", ", kv.Value.Lines)}");
            }

            return sb.ToString();
        }


    }
}
