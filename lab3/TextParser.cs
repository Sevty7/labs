using System.Text;
using System.Text.RegularExpressions;

namespace lab3
{
    class TextParser
    {
        public static Text Parse(string text)
        {
            Text resultText = new Text();
            var splitText = Regex.Split(text, @"(\r\n)");
            int pendingParagraphs = 0;

            foreach (var s in splitText)
            {
                if (s == "\r\n")
                {
                    pendingParagraphs++;
                    continue;
                }

                if (string.IsNullOrWhiteSpace(s))
                    continue;

                if (pendingParagraphs > 0)
                    ApplyPendingParagraphs(resultText, ref pendingParagraphs);

                Sentence currentSentence = new Sentence();
                StringBuilder wordBuilder = new StringBuilder();

                for (int i = 0; i < s.Length; i++)
                {
                    char c = s[i];

                    if (char.IsLetterOrDigit(c))
                    {
                        wordBuilder.Append(c);
                    }
                    else
                    {
                        if (wordBuilder.Length > 0)
                        {
                            currentSentence.tokens.Add(new Word(wordBuilder.ToString()));
                            wordBuilder.Clear();
                        }

                        if (Punctuation.IsPunctuation(c))
                        {
                            currentSentence.tokens.Add(new Punctuation(c));

                            if (Punctuation.IsSentenceEnd(c))
                            {
                                if (currentSentence.tokens.Count > 0)
                                {
                                    resultText.AddSentence(currentSentence);
                                    currentSentence = new Sentence();
                                }
                            }
                        }
                    }
                }

                if (wordBuilder.Length > 0)
                {
                    currentSentence.tokens.Add(new Word(wordBuilder.ToString()));
                }

                if (currentSentence.tokens.Count > 0)
                {
                    resultText.AddSentence(currentSentence);
                }
            }

            if (pendingParagraphs > 0)
            {
                ApplyPendingParagraphs(resultText, ref pendingParagraphs);
            }

            return resultText;
        }
        private static void ApplyPendingParagraphs(Text resultText, ref int pendingParagraphs)
        {
            if (pendingParagraphs <= 0) return;

            if (resultText.sentences.Count == 0)
            {
                resultText.paragraphsBeforeFirst += pendingParagraphs;
            }
            else
            {
                int lastIdx = resultText.sentences.Count - 1;
                if (resultText.paragraphsAfter.ContainsKey(lastIdx))
                    resultText.paragraphsAfter[lastIdx] += pendingParagraphs;
                else
                    resultText.paragraphsAfter[lastIdx] = pendingParagraphs;
            }

            pendingParagraphs = 0;
        }
    }
}
