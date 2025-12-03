namespace lab5.Entities.Carriages.FreightCarriages
{
    public class TankCarriage : Carriage, IFreightCarriage //Жидкости
    {
        public override double EmptyWeight => 22.0;
        public override double LoadCapacity => 70.0;
        public override int Passengers => 0;

        private double _currentLoad = 0;
        public double CurrentLoad
        {
            get => _currentLoad;
            set
            {
                if (value < 0) throw new ArgumentException("CurrentLoad < 0");
                _currentLoad = value;
                IsOverloaded();
            }
        }
        public double OilVolume
        {
            get => CurrentLoad;
            set => CurrentLoad = value;
        }

        public TankCarriage() : base(ComfortLevel.None) { }

        public override bool IsOverloaded() => OilVolume > LoadCapacity;

        public override string ToString()
        {
            return $"{base.ToString()} LoadCapacity = {LoadCapacity}t, OilVolume = {OilVolume}t;";
        }
    }
}
