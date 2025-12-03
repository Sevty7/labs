using lab5.Entities.Carriages;
using lab5.Entities.Carriages.FreightCarriages;

namespace lab5.Entities.Trains
{
    public class FreightTrain : Train
    {
        public double MaxPullingWeight { get; set; } = 5000.0;

        public FreightTrain() : base() { }

        public FreightTrain(string trainNumber, string route) : base(trainNumber, route) { }

        public override bool IsCarriageCompatible(Carriage carriage)
        {
            return carriage is HopperCarriage ||
                   carriage is TankCarriage;
        }

        public bool IsLocomotiveOverloaded()
        {
            double totalWeight = Carriages.Sum(c => c.EmptyWeight + c.LoadCapacity);
            return totalWeight > MaxPullingWeight;
        }
    }
}