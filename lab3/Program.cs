namespace lab3 
{
    class Program
    {
        public static void Main(string[] args)
        {
            string stringText;

            using (StreamReader sr = new StreamReader("C:\\Users\\maxim\\VSProjects\\labs_c#\\lab3\\Text.txt"))
            {
                stringText =  sr.ReadToEnd();
            }

            Text text = TextParser.Parse(stringText);

            Console.WriteLine("Исходный текст:");
            Console.WriteLine(text.ToString());
            Console.WriteLine();

            // 1
            Console.WriteLine("1. Предложения по количеству слов:");
            foreach (var s in text.GetSentencesByWordCountAscending()) Console.WriteLine(s.ToString());
            Console.WriteLine();

            // 2
            Console.WriteLine("2. Предложения по длине:");
            foreach (var s in text.GetSentencesByLengthAscending()) Console.WriteLine(s.ToString());
            Console.WriteLine();

            // 3
            Console.WriteLine("3. Уникальные слова из вопросительных предложений (длина=3):");
            foreach (var w in text.FindUniqueWordsInQuestionsOfLength(3)) Console.WriteLine(w);
            Console.WriteLine();

            // 4
            text.DeleteWordsOfLengthStartingWithConsonant(5);
            Console.WriteLine("4. После удаления слов длины 5 с согласной:");
            Console.WriteLine(text.ToString());
            Console.WriteLine();

            // 5
            text = TextParser.Parse(stringText);
            text.ReplaceWordsOfLength(5, "REPLACED");
            Console.WriteLine("5. После замены слов длины 5:");
            Console.WriteLine(text.ToString());
            Console.WriteLine();

            // 6
            text = TextParser.Parse(stringText);
            text.RemoveStopWords("C:\\Users\\maxim\\VSProjects\\labs_c#\\lab3\\stopwords_en.txt");
            Console.WriteLine("6. После удаления стоп-слов:");
            Console.WriteLine(text.ToString());
        }
    }
}