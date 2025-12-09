using System.Xml.Serialization;
using lab5.Entities.Carriages;
using lab5.Entities.Carriages.PassengerCarriages;
using lab5.Entities.Carriages.FreightCarriages;


namespace lab5.Entities.Trains
{
    [XmlInclude(typeof(PassengerTrain))]
    [XmlInclude(typeof(FreightTrain))]
    [XmlInclude(typeof(CoupeCarriage))]
    [XmlInclude(typeof(EconomCarriage))]
    [XmlInclude(typeof(DiningCarriage))]
    [XmlInclude(typeof(HopperCarriage))]
    [XmlInclude(typeof(TankCarriage))]
    public abstract class Train
    {
        [XmlArray("Carriages")]
        [XmlArrayItem(typeof(CoupeCarriage))]
        [XmlArrayItem(typeof(EconomCarriage))]
        [XmlArrayItem(typeof(DiningCarriage))]
        [XmlArrayItem(typeof(HopperCarriage))]
        [XmlArrayItem(typeof(TankCarriage))]
        public List<Carriage> Carriages { get; set; } = new List<Carriage>();
        public string TrainNumber { get; set; }

        public enum TrainState { Ready, InTransit, Arrived, Maintenance, Cancelled }
        public TrainState State { get; set; } = TrainState.Ready;

        public Route Route { get; set; }
        public Train() { }

        protected Train(string trainNumber, Route route)
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

        public override string ToString()
        {
            return $"Train {TrainNumber}, State: {State}, Route: {Route}, Carriages: {Carriages.Count}";
        }
    }
}
