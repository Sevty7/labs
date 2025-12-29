    using System.Xml.Serialization;
    using lab6.Entities.Carriages.PassengerCarriages;
    using lab6.Entities.Carriages.FreightCarriages;

    namespace lab6.Entities.Carriages
    {
        [XmlInclude(typeof(CoupeCarriage))]
        [XmlInclude(typeof(EconomCarriage))]
        [XmlInclude(typeof(DiningCarriage))]
        [XmlInclude(typeof(HopperCarriage))]
        [XmlInclude(typeof(TankCarriage))]
        public abstract class Carriage : IComparable<Carriage>
        {
            [XmlIgnore]
            public abstract double EmptyWeight { get; }
            [XmlIgnore]
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

            public int CompareTo(Carriage other)
            {
                if (other == null) return 1;
                return Comfort.CompareTo(other.Comfort);
            }

            public virtual bool IsOverloaded() =>
                this is IPassengerCarriage ticketed ? Passengers > ticketed.TotalSeats :
                this is IFreightCarriage freight ? freight.CurrentLoad > LoadCapacity :
                false;

            public override string ToString()
            {
                return $"Passengers = {Passengers}, Comfort = {Comfort};";
            }
        }
    }
