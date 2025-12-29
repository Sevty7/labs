using lab6.Entities.Carriages;
using lab6.Entities.Carriages.FreightCarriages;

namespace lab6.Entities.Trains
{
    public class FreightTrain : Train
    {
        public double MaxPullingWeight { get; set; } = 5000.0;

        public FreightTrain() : base() { }

        public FreightTrain(string trainNumber, Route route) : base(trainNumber, route) { }

        public override void AddCarriage(Carriage carriage)
        {
            if (!IsCarriageCompatible(carriage))
                throw new InvalidOperationException($"Freight train cannot accept carriage of type {carriage.GetType().Name}. Only freight types are allowed.");

            if (IsLocomotiveOverloaded())
                throw new InvalidOperationException("Cannot add carriage: Locomotive capacity exceeded.");
           
            base.AddCarriage(carriage);
        }

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