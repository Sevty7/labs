namespace lab3 
{
    public class Program
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


            Console.WriteLine(text.ConcordanceToString());

            TextSerializer.Serialize(text, "C:\\Users\\maxim\\VSProjects\\labs_c#\\lab3\\text.xml");

        }
    }
}