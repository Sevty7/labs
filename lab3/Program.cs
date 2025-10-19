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


            Console.WriteLine(text.ToString());
        }
    }
}