class Game
{
    public int size;
    public Player cat;
    public Player mouse;
    public static string inputFileName;
    public static string outputFileName;


    public Game()
    {
        cat = new Player("Cat");
        mouse = new Player("Mouse");
    }
    
    public void run()
    {
        using(StreamWriter sw  = new StreamWriter(outputFileName))
        using(StreamReader sr = new StreamReader(inputFileName))
        {
            sw.WriteLine("Cat and Mouse\n\nCat\tMouse\tDistance\n--------------------");

            size = int.Parse(sr.ReadLine().Trim());
            int sizeOfMove;
            while(!sr.EndOfStream && !isCatch())
            {
                string[] commands = sr.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                switch(commands[0])
                {

                    case "M":
                        sizeOfMove = int.Parse(commands[1]);

                        if (!mouse.isInGame()) mouse.distanceTraveled -= sizeOfMove;
                        mouse.distanceTraveled += Math.Abs(sizeOfMove);

                        mouse.location = modSize(sizeOfMove + mouse.location, size);
                        break;

                    case "C":
                        sizeOfMove = int.Parse(commands[1]);

                        if (!cat.isInGame()) cat.distanceTraveled -= sizeOfMove;
                        cat.distanceTraveled += Math.Abs(sizeOfMove);

                        cat.location = modSize(sizeOfMove + cat.location, size);
                        break;

                    case "P":
                        if (getDistance() != 0) sw.WriteLine($"{getCurrentPositions()}\t\t\t{getDistance()}");

                        else sw.WriteLine($"{getCurrentPositions()}");

                        break;

                    default:
                        Console.WriteLine("Incorect data in file");
                        break;
                }

            }
            sw.WriteLine("--------------------\n\n");
            sw.WriteLine("Distance traveled:\tMouse\tCat");
            sw.WriteLine($"\t\t\t\t\t{mouse.distanceTraveled}\t\t{cat.distanceTraveled}\n");

            if (isCatch()) sw.WriteLine($"Mouse caught at: {mouse.location}");
            else sw.WriteLine("Mouse evaded Cat");
        }
    }

    private string getCurrentPositions()
    {
        if (!cat.isInGame()) return $" ??\t {mouse.location}";
        if (!mouse.isInGame()) return $" {cat.location}\t ??";

        return $" {cat.location}\t {mouse.location}";
    }

    private int getDistance()
    {
        if (cat.isInGame() && mouse.isInGame()) return Math.Abs(cat.location - mouse.location);
        return 0;
    }

    private bool isCatch()
    {
        if (cat.isInGame() || mouse.isInGame()) return cat.location == mouse.location;
        return false;
    }

    private int modSize(int x, int size)
    {
        int mod = (x % size + size) % size;
        if (mod == 0) mod = size;

        return mod;
    }
}
