using System.Text;
using System.Text.RegularExpressions;

namespace lab3
{
    public class TextParser
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
                bool inQuotes = false;

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
                            bool IsOpeningQuote(char ch) => ch == '«' || ch == '“' || ch == '"';
                            bool IsClosingQuote(char ch) => ch == '»' || ch == '”' || ch == '"';

                            if (IsOpeningQuote(c) && !inQuotes)
                            {
                                inQuotes = true;
                                currentSentence.tokens.Add(new Punctuation(c));
                                continue;
                            }

                            if (IsClosingQuote(c) && inQuotes)
                            {
                                inQuotes = false;
                                currentSentence.tokens.Add(new Punctuation(c));
                                continue;
                            }

                            if (Punctuation.IsSentenceEnd(c))
                            {
                                if (inQuotes)
                                {
                                    if (i + 1 < s.Length && IsClosingQuote(s[i + 1]))
                                    {
                                        int j = i + 2;
                                        while (j < s.Length && char.IsWhiteSpace(s[j])) j++;

                                        if (j < s.Length && (s[j] == '-' || s[j] == '—'))
                                        {
                                            currentSentence.tokens.Add(new Punctuation(c));
                                            currentSentence.tokens.Add(new Punctuation(s[i + 1]));
                                            inQuotes = false;
                                            i++; 
                                            continue;
                                        }

                                        currentSentence.tokens.Add(new Punctuation(c));
                                        currentSentence.tokens.Add(new Punctuation(s[i + 1]));
                                        inQuotes = false;
                                        i++;
                                        if (currentSentence.tokens.Count > 0)
                                        {
                                            resultText.AddSentence(currentSentence);
                                            currentSentence = new Sentence();
                                        }
                                        continue;
                                    }
                                    else
                                    {
                                        currentSentence.tokens.Add(new Punctuation(c));
                                        continue;
                                    }
                                }
                                else
                                {
                                    currentSentence.tokens.Add(new Punctuation(c));
                                    if (currentSentence.tokens.Count > 0)
                                    {
                                        resultText.AddSentence(currentSentence);
                                        currentSentence = new Sentence();
                                    }
                                    continue;
                                }
                            }

                            currentSentence.tokens.Add(new Punctuation(c));
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
