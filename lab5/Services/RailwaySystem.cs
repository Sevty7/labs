using System.Xml.Serialization;
using lab5.Entities;
using lab5.Entities.Carriages;
using lab5.Entities.Carriages.PassengerCarriages;
using lab5.Entities.Trains;
using static lab5.Entities.Trains.Train;

namespace lab5.Services
{
    [XmlRoot("RailwaySystem")]
    [XmlInclude(typeof(PassengerTrain))]
    [XmlInclude(typeof(FreightTrain))]
    [XmlInclude(typeof(Route))]
    public class RailwaySystem : IPassengerService, IAdminService
    {
        [XmlArray("Trains")]
        [XmlArrayItem("PassengerTrain", typeof(PassengerTrain))]
        [XmlArrayItem("FreightTrain", typeof(FreightTrain))]
        public List<Train> Trains { get; set; } = new List<Train>();

        public RailwaySystem() { }

        //Admin
        public Train GetTrainByNumber(string trainNumber)
        {
            var train = Trains.Find(t => t.TrainNumber == trainNumber);
            if (train == null)
            {
                throw new KeyNotFoundException($"Train with number {trainNumber} not found.");
            }
            return train;
        }

        public void CreateTrain(string number, Route route, bool isPassenger)
        {
            if (Trains.Any(t => t.TrainNumber == number))
            {
                throw new InvalidOperationException($"Train with number {number} already exists.");
            }
            Train newTrain = isPassenger
                ? new PassengerTrain(number, route)
                : new FreightTrain(number, route);
            Trains.Add(newTrain);
        }
        public void CreateTrain(string number)
        {
            CreateTrain(number, new Route("DefaultStart", "DefaultEnd", 0, TimeSpan.Zero), true);
        }

        public void AddCarriageToTrain(string trainNumber, Carriage carriage)
        {
            var train = GetTrainByNumber(trainNumber);
            train.AddCarriage(carriage);
        }

        public void RemoveCarriageFromTrain(string trainNumber, int index)
        {
            var train = GetTrainByNumber(trainNumber);
            train.RemoveCarriage(index);
        }

        public void SaveSystemState(string filePath) 
        {
            if (string.IsNullOrWhiteSpace(filePath))
                throw new ArgumentException("File path is null or empty.", nameof(filePath));

            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(RailwaySystem));
                using (StreamWriter sw = new StreamWriter(filePath))
                {
                    serializer.Serialize(sw, this);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
                if (e.InnerException != null)
                {
                    Console.WriteLine($"Inner Error: {e.InnerException.Message}");
                }
                throw new InvalidOperationException("Failed to serialize...", e);
            }
        }

        public void LoadTrainsFromXml(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
                throw new ArgumentException("File path is null or empty.", nameof(filePath));

            if (!File.Exists(filePath))
                throw new FileNotFoundException($"File not found: {filePath}", filePath);

            try
            {
                XmlSerializer deSerializer = new XmlSerializer(typeof(RailwaySystem));
                using (StreamReader sr = new StreamReader(filePath))
                {
                    var obj = deSerializer.Deserialize(sr);
                    if (obj is RailwaySystem loadedSystem)
                        this.Trains = loadedSystem.Trains;
                    else
                        throw new InvalidDataException("XML file does not contain RailwaySystem data.");
                }
            }
            catch (InvalidOperationException e)
            {
                throw new InvalidOperationException("Failed to deserialize XML to RailwaySystem.", e);
            }
        }


        public List<Train> GetAllTrains()
        {
            return new List<Train>(Trains);
        }

        public bool IsTrainOverloaded(string trainNumber)
        {
            var train = GetTrainByNumber(trainNumber);
            if (train is FreightTrain freight)
                return freight.IsLocomotiveOverloaded();
            return train.Carriages.Any(c => c.IsOverloaded());
        }

        public void SetTrainState(string trainNumber, TrainState state)
        {
            var train = GetTrainByNumber(trainNumber);
            train.State = state;
        }

        public void SortTrainCarriagesByComfort(string trainNumber)
        {
            var train = GetTrainByNumber(trainNumber);
            if (!(train is PassengerTrain pt))
            {
                throw new InvalidOperationException("Sorting by comfort is only possible for passenger trains.");
            }
            pt.SortCarriagesByComfort();
        }

        public List<Carriage> FindCarriagesByPassengerRange(string trainNumber, int min, int max)
        {
            var train = GetTrainByNumber(trainNumber);
            if (!(train is PassengerTrain pt))
            {
                throw new InvalidOperationException("Searching by passenger range is only possible for passenger trains.");
            }

            return pt.FindCarriagesByPassengerRange(min, max);
        }


        //Passenger
        public List<Train> GetAvailableTrains()
        {
            return Trains.Where(t => t is PassengerTrain && t.State == TrainState.Ready).ToList();
        }

        public void ReserveTicket(Train train, string carriageType)
        {
            if (!Trains.Contains(train))
                throw new InvalidOperationException("Train not found.");

            if (!(train is PassengerTrain pt))
            {
                throw new InvalidOperationException("Train must be a PassengerTrain for ticket reservation.");
            }

            IPassengerCarriage targetCarriage = null;

            string normalizedType = carriageType.ToLower();

            foreach (var carriage in train.Carriages)
            {
                if (carriage is CoupeCarriage && normalizedType == "coupe")
                {
                    targetCarriage = (IPassengerCarriage)carriage;
                    break;
                }
                else if (carriage is EconomCarriage && normalizedType == "econom")
                {
                    targetCarriage = (IPassengerCarriage)carriage;
                    break;
                }
            }

            if (targetCarriage == null)
            {
                throw new InvalidOperationException($"Carriage type '{carriageType}' not found or is not a valid passenger carriage.");
            }

            pt.ReserveSeat(targetCarriage);
        }

        public Dictionary<string, decimal> GetDiningMenu(string trainNumber)
        {
            var train = GetTrainByNumber(trainNumber);
            var dining = train.Carriages.OfType<DiningCarriage>().FirstOrDefault();
            if (dining != null)
            {
                return dining.Menu;
            }
            return new Dictionary<string, decimal>();
        }

        public void OrderFood(string trainNumber, string item)
        {
            var train = GetTrainByNumber(trainNumber);

            var dining = train.Carriages.OfType<DiningCarriage>().FirstOrDefault();
            if (dining == null || !dining.Menu.TryGetValue(item, out decimal price))
                throw new InvalidOperationException("Item not available or no dining carriage.");

            if (train.State != TrainState.InTransit)
                throw new InvalidOperationException("Can only order food when the train is in transit.");

            if (train is PassengerTrain pt)
                pt.ProcessMealOrder(dining, price);
            else
                throw new InvalidOperationException("Food orders only available on passenger trains.");
        }
    }
}
