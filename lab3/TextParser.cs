using System.Text;

namespace lab3
{
    class TextParser
    {
        public static Text Parse(string text)
        {
            Text resultText = new Text();
            Sentence currentSentence = new Sentence();
            StringBuilder wordBuilder = new StringBuilder();

            for (int i = 0; i < text.Length; i++)
            {
                char c = text[i];

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

            return resultText;
        }
    }
}
