namespace lab5
{
    public class CoupeCarriage : Carriage
    {
        public override string TypeName => "CoupeCarriage";
        public override int MaxPassengers => CoupeCount * SeatsPerCoupe;

        private int _coupeCount = 0;
        public int CoupeCount
        {
            get => _coupeCount; 
            set
            {
                if (value < 0) throw new ArgumentException("CoupeCount < 0");
                _coupeCount = value;
                EnsureCapacity();
            }
        }

        private int _seatsPerCoupe = 0;
        public int SeatsPerCoupe 
        {
            get => _seatsPerCoupe; 
            set
            {
                if (value < 0) throw new ArgumentException("SeatsPerCoupe < 0");
                _seatsPerCoupe = value;
                EnsureCapacity();
            }
        }

        public CoupeCarriage() : base(ComfortLevel.High) { }
        public CoupeCarriage(int passengers) : base(passengers, 0, ComfortLevel.High) { }
        public CoupeCarriage(int passengers, int baggage) : base(passengers, baggage, ComfortLevel.High) { }
        public CoupeCarriage(int passengers, int baggage,int coupeCount) : base(passengers, baggage , ComfortLevel.High)
        {
            CoupeCount = coupeCount;
        }
        public CoupeCarriage(int passengers, int baggage, int coupeCount, int seatsPerCompartment) : base(passengers, baggage, ComfortLevel.High)
        {
            CoupeCount = coupeCount;
            SeatsPerCoupe = seatsPerCompartment;
        }
        public CoupeCarriage(int passengers, int baggage, int coupeCount, int seatsPerCompartment, ComfortLevel comfort)
            : base(passengers, baggage, comfort)
        {
            CoupeCount = coupeCount;
            SeatsPerCoupe = seatsPerCompartment;
        }
    }
}
