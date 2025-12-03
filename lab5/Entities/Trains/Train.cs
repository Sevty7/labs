using System.Xml.Serialization;
using lab5.Entities.Carriages;

namespace lab5.Entities.Trains
{
    public abstract class Train
    {
        public List<Carriage> Carriages { get; set; } = new List<Carriage>();
        public string TrainNumber { get; set; }
        public string Route { get; set; }

        public Train() { }

        protected Train(string trainNumber, string route)
        {
            TrainNumber = trainNumber;
            Route = route;
        }

        public abstract bool IsCarriageCompatible(Carriage carriage);

        public virtual void AddCarriage(Carriage carriage) 
        { 
            if (carriage != null) 
                Carriages.Add(carriage); 
        }

        public virtual void RemoveCarriage(int index)
        {
            if (index < 0 || index >= Carriages.Count)
                return;
            Carriages.RemoveAt(index);
        }

        public virtual void RemoveCarriage(Carriage value)
        {
            if (Carriages.Contains(value))
                Carriages.Remove(value);
        }

        public void SaveToXml(string filePath) 
        {
            if (string.IsNullOrWhiteSpace(filePath))
                throw new ArgumentException("File path is null or empty.", nameof(filePath));

            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Train));
                using (StreamWriter sw = new StreamWriter(filePath))
                {
                    serializer.Serialize(sw, this);
                }
            }
            catch (InvalidOperationException e)
            {
                throw new InvalidOperationException("Failed to serialize Train to XML.", e);
            }
        }

        public static Train LoadFromXml(string filePath) 
        {
            if (string.IsNullOrWhiteSpace(filePath))
                throw new ArgumentException("File path is null or empty.", nameof(filePath));

            if (!File.Exists(filePath))
                throw new FileNotFoundException($"File not found: {filePath}", filePath);

            try
            {
                XmlSerializer deSerializer = new XmlSerializer(typeof(Train));
                using (StreamReader sr = new StreamReader(filePath))
                {
                    var obj = deSerializer.Deserialize(sr);
                    if (obj is Train)
                        return (Train)obj;
                    else
                        throw new InvalidDataException("XML file does not contain Train data.");
                }
            }
            catch (InvalidOperationException e)
            {
                throw new InvalidOperationException("Failed to deserialize XML to Train.", e);
            }
        }
    }
}
