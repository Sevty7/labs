namespace lab5.Entities.PassengerCarriages
{
    public class DiningCarriage : Carriage
    {
        public override double EmptyWeight => 60.0;
        public override double LoadCapacity => 2.0;


        private int _tables = 12;
        public int Tables
        {
            get => _tables; 
            set
            {
                if (value < 0) throw new ArgumentException("Tables < 0");
                _tables = value;
            }
        }

        public DiningCarriage() : base(ComfortLevel.Standard) { }

        public override string ToString()
        {
            return $"{base.ToString()} Tables = {Tables}, LoadCapacity = {LoadCapacity};";
        }
    }
}
