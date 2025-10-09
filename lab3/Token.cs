namespace lab3
{
    public abstract class Token
    {
        public string value { get; protected set; }
        public Token(string value)
        {
            this.value = value;
        }
        public override string ToString() => value;
    }
}
