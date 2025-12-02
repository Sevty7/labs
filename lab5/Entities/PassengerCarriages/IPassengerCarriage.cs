namespace lab5.Entities.PassengerCarriages
{
    public interface IPassengerCarriage
    {
        int TotalSeats { get; }
        decimal BaseTicketPrice { get; }
        int GetAvailableSeats();
        decimal CalculateTicketPrice();
    }
}
