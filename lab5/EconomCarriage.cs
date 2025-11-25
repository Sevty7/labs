namespace lab5
{
    public class EconomCarriage : Carriage
    {
        public override string TypeName => "EconomCarriage";
        public override int MaxPassengers => UpperBedsCount + LowerBedsCount;


        private int _upperBedsCount = 0;
        public int UpperBedsCount 
        {
            get => _upperBedsCount;
            set
            {
                if (value < 0) throw new ArgumentException("UpperBedsCount < 0");
                _upperBedsCount = value;
                EnsureCapacity();
            }
        }

        private int _lowerBedsCount = 0;
        public int LowerBedsCount
        {
            get => _lowerBedsCount;
            set
            {
                if (value < 0) throw new ArgumentException("LowerBedsCount < 0");
                _lowerBedsCount = value;
                EnsureCapacity();
            }
        }


        public EconomCarriage() : base(ComfortLevel.Low) { }
        public EconomCarriage(int passengers) : base(passengers, 0, ComfortLevel.Low) { }
        public EconomCarriage(int passengers, int baggage) : base(passengers, baggage, ComfortLevel.Low) { }
        public EconomCarriage(int passengers, int baggage, int upperBedsCount) : base(passengers, baggage, ComfortLevel.Low)
        {
            UpperBedsCount = upperBedsCount;
        }
        public EconomCarriage(int passengers, int baggage, int upperBedsCount, int lowerBedsCount) : base(passengers, baggage, ComfortLevel.Low)
        {
            UpperBedsCount = upperBedsCount;
            LowerBedsCount = lowerBedsCount;
        }
        public EconomCarriage(int passengers, int baggage, int upperBedsCount, int lowerBedsCount, ComfortLevel comfort) : base(passengers, baggage, comfort)
        {
            UpperBedsCount = upperBedsCount;
            LowerBedsCount = lowerBedsCount;
        }
    }
}
