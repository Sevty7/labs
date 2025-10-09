namespace lab3
{
    class Punctuation : Token
    {
        public char symbol
        {
            get { return value[0]; }
        }

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
