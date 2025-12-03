namespace lab5.Entities.Carriages.PassengerCarriages
{
    public interface IPassengerCarriage
    {
        int TotalSeats { get; }
        decimal BaseTicketPrice { get; }
        int GetAvailableSeats();
        decimal CalculateTicketPrice();
    }
}
