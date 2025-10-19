using System.Text;

namespace lab3
{
    class Sentence
    {
        public List<Token> tokens { get; private set; } = new List<Token>();

        public override string ToString()
        {
            var result = new StringBuilder();

            for (int i = 0; i < tokens.Count; i++)
            {
                var token = tokens[i];
                result.Append(token.ToString());

                if (i < tokens.Count - 1 && tokens[i + 1] is Word)
                {
                    if (token is Word)
                    {
                        result.Append(' ');
                    }

                    else if (token is Punctuation p && Punctuation.IsPunctuation(p.symbol))
                    {
                        if (p.symbol != '(' && p.symbol != '"' && p.symbol != '\'')
                        {
                            result.Append(' ');
                        }
                    }
                }
            }
            return result.ToString();
        }
    }
}
