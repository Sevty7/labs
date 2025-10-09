namespace lab3
{
    class Word : Token
    {
        public string content
        {
            get { return value; }
        }
        public int length
        {
            get { return value.Length; }
        }

        public Word(string content) : base(content)
        {
        }
    }
}
