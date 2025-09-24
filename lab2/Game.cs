class Game
{
    public int size;
    public Player cat;
    public Player mouse;

    public Game(int size)
    {
        this.size = size;
        cat = new Player("Cat");
        mouse = new Player("Mouse");
    }
    
    public void run()
    {
        Console.WriteLine(getCurrentPositions());
        Console.WriteLine(getDistance());
        Console.WriteLine(isCatch());
    }

    private string getCurrentPositions()
    {
        return $"Позиция кота: {cat.location}\nПозиция мыши: {mouse.location}";
    }

    private int getDistance()
    {
        return Math.Abs(cat.location - mouse.location);
    }

    private bool isCatch()
    {
        return cat.location == mouse.location;
    }
}
