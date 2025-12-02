namespace lab5.Entities.PassengerCarriages
{
    public class EconomCarriage : Carriage, IPassengerCarriage
    {
        public override double EmptyWeight => 54.0;
        public override double LoadCapacity => 0;
        public int TotalSeats => UpperSeats + LowerSeats;

        public decimal BaseTicketPrice { get; set; } = 5m;


        private int _upperSeats = 18;
        public int UpperSeats 
        {
            get => _upperSeats;
            set
            {
                if (value < 0) throw new ArgumentException("UpperSeats < 0");
                _upperSeats = value;
                ValidatePassengers();
            }
        }

        private int _lowerSeats = 18;
        public int LowerSeats
        {
            get => _lowerSeats;
            set
            {
                if (value < 0) throw new ArgumentException("LowerSeats < 0");
                _lowerSeats = value;
                ValidatePassengers();
            }
        }

        public EconomCarriage() : base(ComfortLevel.Economy) { }

        public int GetAvailableSeats() => TotalSeats - Passengers;

        public decimal CalculateTicketPrice()
        {
            decimal comfortMultiplier = 1.0m + ((int)Comfort * 0.2m);
            return BaseTicketPrice * comfortMultiplier;
        }

        public override string ToString()
        {
            return $"{base.ToString()} TotalSeats = {TotalSeats}, Available = {GetAvailableSeats()};";
        }
    }
}
