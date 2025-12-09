using lab5.Entities.Carriages;
using lab5.Entities;
using lab5.Entities.Trains;
using static lab5.Entities.Trains.Train;

namespace lab5.Services
{
    public interface IAdminService
    {
        Train GetTrainByNumber(string trainNumber);
        void CreateTrain(string number);
        void CreateTrain(string number, Route route, bool isPassenger);
        void AddCarriageToTrain(string trainNumber, Carriage carriage);
        void RemoveCarriageFromTrain(string trainNumber, int index);
        void SaveSystemState(string filePath);
        void LoadTrainsFromXml(string filePath);
        List<Train> GetAllTrains();
        bool IsTrainOverloaded(string trainNumber);
        void SetTrainState(string trainNumber, TrainState state);
    }
}
