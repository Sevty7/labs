namespace lab3 {
    class Program
    {
        public static void Main(string[] args)
        {
            Text text = new Text();
            Sentence sentence = new Sentence();

            sentence.tokens.Add(new Word("Hello"));
            sentence.tokens.Add(new Punctuation(','));
            sentence.tokens.Add(new Word(" World"));
            sentence.tokens.Add(new Punctuation('!'));

            text.AddSentence(sentence);
            Console.WriteLine(text.ToString());
        }
    }
}