using lab5.Entities.Carriages;
using lab5.Entities.Trains;

namespace lab5.Services
{
    public class RailwaySystem : IPassengerService, IAdminService
    {
        private List<Train> _trains = new List<Train>();


        //Admin
        public void CreateTrain(string number) 
        { 

        }

        public void AddCarriageToTrain(string trainNumber, Carriage carriage) 
        { 

        }

        public void RemoveCarriageFromTrain(string trainNumber, int index)
        {

        }

        public void SaveSystemState(string path) 
        { 

        }

        public List<Train> GetAllTrains()
        {
            return new List<Train>();
        }

        public bool IsTrainOverloaded(string trainNumber) { return false; }

        //Passenger
        public List<Train> GetAvailableTrains()
        {
            return new List<Train>();
        }

        public void BuyTicket(Train train, int carriageIndex) 
        {
            
        }

        public Dictionary<string, decimal> GetDiningMenu(string trainNumber)
        {
            return new Dictionary<string, decimal>();
        }
    }
}
