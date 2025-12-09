namespace lab5.Entities
{
    [Serializable]
    public class Route
    {
        public string StartStation { get; set; }
        public string EndStation { get; set; }
        public double Distance { get; set; }
        public TimeSpan Duration { get; set; }
        public Route() { }
        public Route(string start, string end, double distance, TimeSpan duration)
        {
            StartStation = start;
            EndStation = end;
            Distance = distance;
            Duration = duration;
        }
        public override string ToString()
        {
            return $"{StartStation} -> {EndStation} ({Distance} km, {Duration})";
        }
    }
}