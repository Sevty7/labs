using System.Xml.Serialization;

namespace lab5
{
    [XmlInclude(typeof(CoupeCarriage))]
    [XmlInclude(typeof(EconomCarriage))]
    [XmlInclude(typeof(DiningCarriage))]
    public abstract class Carriage : IComparable<Carriage>
    {
        public abstract string TypeName { get; }

        public abstract int MaxPassengers { get; }

        private int _passengers = 0;
        public int Passengers 
        {   
            get => _passengers; 

            set 
            {
                if (value < 0) throw new ArgumentException("Passengers < 0");
                _passengers = value;
                EnsureCapacity();
            } 
        }

        private int _baggage = 0;
        public int Baggage 
        {
            get { return _baggage; }

            set
            {
                if (value < 0) throw new ArgumentException("Baggage < 0");
                _baggage = value;
            } 
        }
        public ComfortLevel Comfort { get; set; }
        public enum ComfortLevel
        {
            None = 0,
            VeryLow = 1,
            Low = 2,
            Medium = 3,
            High = 4,
            VeryHigh = 5
        }

        public Carriage() 
        {
            Comfort = ComfortLevel.None;
        }
        protected Carriage(ComfortLevel comfort)
        {
            Comfort = comfort;
        }
        protected Carriage(int passengers)
        {
            Passengers = passengers;
            Comfort = ComfortLevel.None;
        }
        protected Carriage(int passengers, int baggage)
        {
            Passengers = passengers;
            Baggage = baggage;
            Comfort = ComfortLevel.None;
        }

        protected Carriage(int passengers, int baggage, ComfortLevel comfort)
        {
            Passengers = passengers;
            Baggage = baggage;
            Comfort = comfort;
        }

        public override string ToString()
        {
            return $"Passengers = {Passengers}, Baggage = {Baggage}, Comfort = {Comfort};";
        }

        public int CompareTo(Carriage other)
        {
            if (other == null) return 1;
            return Comfort.CompareTo(other.Comfort);
        }

        public static int ComparePassengers(Carriage x, Carriage y)
        {
            if (x == null && y == null) return 0;
            if (x == null) return -1;
            if (y == null) return 1;

            return x.Passengers.CompareTo(y.Passengers);
        }

        public static int CompareByBaggage(Carriage x, Carriage y)
        {
            if (x == null && y == null) return 0;
            if (x == null) return -1;
            if (y == null) return 1;

            return x.Baggage.CompareTo(y.Baggage);
        }

        protected virtual void EnsureCapacity()
        {
            if (MaxPassengers <= 0) return;

            if (Passengers > MaxPassengers)
                throw new ArgumentException($"Passengers ({Passengers}) > MaxPassengers ({MaxPassengers}).");
        }
    }
}
