using System.Text;

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
        public List<string> FindUniqueWordsInQuestionsOfLength(int length)//!
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

        public void DeleteWordsOfLengthStartingWithConsonant(int length)//regex
        {
            foreach (var s in sentences)
            {
                for (int i = s.tokens.Count - 1; i >= 0; i--)
                {
                    if (s.tokens[i] is Word w)
                    {
                        if (w.length == length && StartsWithConsonant(w.content))
                            s.tokens.RemoveAt(i);
                    }
                }
            }
        }

        private bool StartsWithConsonant(string word)
        {
            if (string.IsNullOrEmpty(word)) return false;
            char c = word[0];
            if (!char.IsLetter(c)) return false;

            string latinVowels = "aeiouAEIOU";
            string cyrVowels = "аеёиоуыэюяАЕЁИОУЫЭЮЯ";

            return latinVowels.IndexOf(c) < 0 && cyrVowels.IndexOf(c) < 0;
        }

        public void ReplaceWordsInSentence(int sentenceIndex, int targetLength, string replacement)
        {
            if (sentenceIndex < 0 || sentenceIndex >= sentences.Count) return;
            var s = sentences[sentenceIndex];

            for (int i = 0; i < s.tokens.Count; i++)
            {
                if (s.tokens[i] is Word w && w.length == targetLength)
                {
                    s.tokens[i] = new Word(replacement);
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
