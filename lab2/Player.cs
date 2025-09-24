class Player
{
    public string name;
    public int location;

    public Player(string name)
    {
        this.name = name;
        this.location = -1;
    }
    public Player(string name,  int location)
    {
        this.name = name;
        this.location = location;
    }
}