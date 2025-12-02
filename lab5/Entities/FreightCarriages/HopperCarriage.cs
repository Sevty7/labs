namespace lab5.Entities.FreightCarriages
{
    public class HopperCarriage : Carriage, IFreightCarriage //Сыпучие грузы
    {
        public override double EmptyWeight => 24.0;
        public override double LoadCapacity => 66.0;

        public override int Passengers => 0;

        private double _currentLoad = 0;
        public double CurrentLoad
        {
            get => _currentLoad;
            set
            {
                if (value < 0) throw new ArgumentException("CurrentLoad < 0");
                _currentLoad = value;
            }
        }

        public double GrainLoad
        {
            get => CurrentLoad;
            set => CurrentLoad = value;
        }
        public HopperCarriage() : base(ComfortLevel.None) { }

        public override bool IsOverloaded() => CurrentLoad > LoadCapacity;

        public override string ToString()
        {
            return $"{base.ToString()} LoadCapacity = {LoadCapacity}t, GrainLoad = {GrainLoad}t;";
        }
    }
}
