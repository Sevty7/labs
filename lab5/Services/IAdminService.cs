using lab5.Entities.Carriages;
using lab5.Entities.Trains;

namespace lab5.Services
{
    public interface IAdminService
    {
        void CreateTrain(string number);
        void AddCarriageToTrain(string trainNumber, Carriage carriage);
        void RemoveCarriageFromTrain(string trainNumber, int index);
        void SaveSystemState(string path);
        List<Train> GetAllTrains();
        bool IsTrainOverloaded(string trainNumber);
    }
}
