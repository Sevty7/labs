using lab6.Entities.Trains;

namespace lab6.Services
{
    public interface IPassengerService
    {
        List<Train> GetAvailableTrains();
        void ReserveTicket(Train train, string carriageType);
        Dictionary<string, decimal> GetDiningMenu(string trainNumber);
        void OrderFood(string trainNumber, string item);
    }
}
