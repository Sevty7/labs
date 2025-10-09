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

                if (token is Word && i < tokens.Count - 1 && tokens[i + 1] is Word)
                {
                    result.Append(' ');
                }
            }
            return result.ToString();
        }
    }
}
