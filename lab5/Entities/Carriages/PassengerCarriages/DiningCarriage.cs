using System.Xml.Serialization;

namespace lab5.Entities.Carriages.PassengerCarriages
{
    public class DiningCarriage : Carriage
    {

        [XmlIgnore]
        public Dictionary<string, decimal> Menu { get; set; } = new Dictionary<string, decimal>
        {
            { "Borsch", 5m },
            { "Tea", 1m },
            { "Cutlet with Puree", 3m }
        };

        [XmlElement("Menu")]
        public List<MenuItem> MenuItems
        {
            get => Menu.Select(kv => new MenuItem { Key = kv.Key, Value = kv.Value }).ToList();
            set => Menu = value.ToDictionary(i => i.Key, i => i.Value);
        }


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

        public class MenuItem
        {
            [XmlAttribute]
            public string Key { get; set; } = "";
            [XmlAttribute]
            public decimal Value { get; set; }
        }
    }
}