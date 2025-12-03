namespace lab5.Entities.Carriages.PassengerCarriages
{
    public class CoupeCarriage : Carriage, IPassengerCarriage
    {
        public override double EmptyWeight => 58.0;
        public override double LoadCapacity => 0;
        public int TotalSeats => CoupeCount * SeatsPerCoupe;
        public decimal BaseTicketPrice { get; set; } = 10m;

        private int _coupeCount = 9;
        public int CoupeCount
        {
            get => _coupeCount; 
            set
            {
                if (value < 0) throw new ArgumentException("CoupeCount < 0");
                _coupeCount = value;
                ValidatePassengers();
            }
        }

        private int _seatsPerCoupe = 4;
        public int SeatsPerCoupe 
        {
            get => _seatsPerCoupe; 
            set
            {
                if (value < 0) throw new ArgumentException("SeatsPerCoupe < 0");
                _seatsPerCoupe = value;
                ValidatePassengers();
            }
        }
        public int GetAvailableSeats() => TotalSeats - Passengers;

        public decimal CalculateTicketPrice()
        {
            decimal comfortMultiplier = 1.0m + ((int)Comfort * 0.2m);
            return BaseTicketPrice * comfortMultiplier;
        }

        public CoupeCarriage() : base(ComfortLevel.High) { }

        public override string ToString()
        {
            return $"{base.ToString()} TotalSeats = {TotalSeats}, Available = {GetAvailableSeats()};";
        }
    }
}
