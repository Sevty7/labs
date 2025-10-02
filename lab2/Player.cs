class Player
{
    public string name;
    public int location;
    public int distanceTraveled;

    public Player(string name)
    {
        this.name = name;
        this.location = 0;
    }

    public bool isInGame()
    {
        if (this.location == 0) return false;
        return true;
    }
}