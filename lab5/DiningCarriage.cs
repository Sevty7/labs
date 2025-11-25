namespace lab5
{
    public class DiningCarriage : Carriage
    {
        public override string TypeName => "DiningCarriage";
        public override int MaxPassengers => SeatsCount;


        private int _seatsCount = 0;
        public int SeatsCount
        {
            get => _seatsCount; 
            set
            {
                if (value < 0) throw new ArgumentException("SeatsCount < 0");
                _seatsCount = value;
                EnsureCapacity();
            }
        }

        public bool IsOpen { get; set; } = true;

        public DiningCarriage() : base(ComfortLevel.None) { }
        public DiningCarriage(int passengers) : base(passengers, 0, ComfortLevel.None) { }
        public DiningCarriage(int passengers, int baggage) : base(passengers, baggage, ComfortLevel.None) { }
        public DiningCarriage(int passengers, int baggage, int seatsCount) : base(passengers, baggage, ComfortLevel.None)
        {
            SeatsCount = seatsCount;
        }
        public DiningCarriage(int passengers, int baggage, int seatsCount, bool isOpen) : base(passengers, baggage, ComfortLevel.None)
        {
            SeatsCount = seatsCount;
            IsOpen = isOpen;
        }
        public DiningCarriage(int passengers, int baggage, int seatsCount, bool isOpen, ComfortLevel comfort) : base(passengers, baggage, comfort)
        {
            SeatsCount = seatsCount;
            IsOpen = isOpen;
        }
    }
}
