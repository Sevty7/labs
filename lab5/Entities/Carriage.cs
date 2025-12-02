using System.Xml.Serialization;
using lab5.Entities.PassengerCarriages;

namespace lab5.Entities
{
    [XmlInclude(typeof(PassengerCarriages.CoupeCarriage))]
    [XmlInclude(typeof(PassengerCarriages.EconomCarriage))]
    [XmlInclude(typeof(PassengerCarriages.DiningCarriage))]
    [XmlInclude(typeof(FreightCarriages.HopperCarriage))]
    [XmlInclude(typeof(FreightCarriages.TankCarriage))]
    public abstract class Carriage : IComparable<Carriage>
    {
        public abstract double EmptyWeight { get; }
        public abstract double LoadCapacity { get; }

        private int _passengers = 0;
        public virtual int Passengers 
        {   
            get => _passengers; 
            set 
            {
                if (value < 0) throw new ArgumentException("Passengers < 0");
                if (this is IPassengerCarriage ticketed && value > ticketed.TotalSeats)
                    throw new ArgumentException($"Cannot seat {value} passengers. Only {ticketed.TotalSeats} seats available.");

                _passengers = value;
            } 
        }
        public enum ComfortLevel { None = 0, Economy = 1, Standard = 2, High = 3, Luxury = 4 }
        public ComfortLevel Comfort { get; set; } = ComfortLevel.None;

        public Carriage() { }

        public Carriage(ComfortLevel comfort)
        {
            Comfort = comfort;
        }

        protected void ValidatePassengers()
        {
            if (this is PassengerCarriages.IPassengerCarriage ticketed && Passengers > ticketed.TotalSeats)
                throw new InvalidOperationException(
                    $"Current passengers ({Passengers}) exceed new total seats ({ticketed.TotalSeats}).");
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

        public virtual bool IsOverloaded() =>
            this is PassengerCarriages.IPassengerCarriage ticketed ? Passengers > ticketed.TotalSeats :
            this is FreightCarriages.IFreightCarriage freight ? freight.CurrentLoad > LoadCapacity :
            false;

        public override string ToString()
        {
            return $"Passengers = {Passengers}, Comfort = {Comfort};";
        }
    }
}
