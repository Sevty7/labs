class Program
{
    static public void Main(string[] args)
    {
        Game.inputFileName = "C:\\Users\\maxim\\VSProjects\\labs_c#\\lab2\\1.ChaseData.txt";
        Game.outputFileName = "C:\\Users\\maxim\\VSProjects\\labs_c#\\lab2\\1.PursuitLog.txt";

        Game game = new Game();
        game.run();
    }
}