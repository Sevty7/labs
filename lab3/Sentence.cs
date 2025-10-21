using System.Text;
using System.Xml.Serialization;

namespace lab3
{
    public class Sentence
    {
        [XmlElement("word", Type = typeof(Word))]
        [XmlElement("punctuation", Type = typeof(Punctuation))]
        public List<Token> tokens { get; set; } = new List<Token>();

        public Sentence() { }
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
