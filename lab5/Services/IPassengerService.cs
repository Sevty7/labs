using lab5.Entities.Trains;
using lab5.Entities.Carriages.PassengerCarriages;

namespace lab5.Services
{
    public interface IPassengerService
    {
        List<Train> GetAvailableTrains();
        void BuyTicket(Train train, int carriageIndex);
        Dictionary<string, decimal> GetDiningMenu(string trainNumber);
    }
}
