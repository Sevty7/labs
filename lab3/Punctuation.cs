using System.Xml.Serialization;

namespace lab3
{
    [XmlType("punctuation")]
    public class Punctuation : Token
    {
        public char symbol
        {
            get { return value[0]; }
        }
            
        public Punctuation() : base() { }

        public Punctuation(char symbol) : base(symbol.ToString())
        {
        }
        public static bool IsSentenceEnd(char c)
        {
            return c == '.' || c == '!' || c == '?';
        }

        public static bool IsPunctuation(char c)
        {
            return ".,!?;:-()\"'".Contains(c);
        }
    }
}
