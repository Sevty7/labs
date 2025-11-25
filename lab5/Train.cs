using System.Xml.Serialization;

namespace lab5
{
    public class Train
    {
        public List<Carriage> Carriages { get; set; } = new List<Carriage>();
        public int TotalPassengers => Carriages.Sum(c => c.Passengers);
        public Train() { }

        public void AddCarriage(Carriage carriage) 
        { 
            if (carriage != null) 
                Carriages.Add(carriage); 
        }

        public void RemoveCarriage(int index)
        {
            if (index < 0 || index >= Carriages.Count)
                return;
            Carriages.RemoveAt(index);
        }

        public void RemoveCarriage(Carriage value)
        {
            if (Carriages.Contains(value))
                Carriages.Remove(value);
        }

        public int CalculateTotalPassengers() => Carriages.Sum(c => c.Passengers);

        public List<Carriage> FindCarriagesByPassengerRange(int min, int max) => Carriages.Where(c => c.Passengers >= min && c.Passengers <= max).ToList();

        public void SortCarriagesByComfort() { Carriages.Sort(); }
        public void SortCarriagesByPassengers() { Carriages.Sort(Carriage.ComparePassengers); }
        public void SortCarriagesByBaggage() { Carriages.Sort(Carriage.CompareByBaggage); }


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
