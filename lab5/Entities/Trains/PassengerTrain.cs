using System.Numerics;
using lab5.Entities.Carriages;
using lab5.Entities.Carriages.PassengerCarriages;

namespace lab5.Entities.Trains
{
    public class PassengerTrain : Train
    {
        public int TotalPassengers => Carriages.Sum(c => c.Passengers);
        public decimal TotalRevenue { get; private set; } = 0;

        public PassengerTrain() : base() { }

        public PassengerTrain(string trainNumber, string route) : base(trainNumber, route) { }

        public override bool IsCarriageCompatible(Carriage carriage)
        {
            return carriage is CoupeCarriage ||
                   carriage is EconomCarriage ||
                   carriage is DiningCarriage;
        }

        public override void AddCarriage(Carriage carriage)
        {
            if (!IsCarriageCompatible(carriage)) 
                throw new InvalidOperationException($"Passenger train cannot accept carriage of type {carriage.GetType().Name}. Only passenger types are allowed.");

            base.AddCarriage(carriage);
        }

        public void SortCarriagesByComfort()
        {
            Carriages.Sort();
        }

        public List<Carriage> FindCarriagesByPassengerRange(int min, int max)
        {
            return Carriages.Where(c => c.Passengers >= min && c.Passengers <= max).ToList();
        }

        public void SellTicket(IPassengerCarriage carriage)
        {
            if (carriage.GetAvailableSeats() <= 0)
                throw new InvalidOperationException("No available seats in this carriage.");

            decimal price = carriage.CalculateTicketPrice();

            (carriage as Carriage).Passengers += 1;
            TotalRevenue += price;

            Console.WriteLine($"Ticket sold for {price}. Available seats: {carriage.GetAvailableSeats()}");
        }

        public void ProcessMealOrder(DiningCarriage dining, decimal price)
        {
            if (Carriages.Contains(dining))
            {
                TotalRevenue += price;
                Console.WriteLine("Meal ordered.");
            }
            else
            {
                throw new InvalidOperationException("Dining carriage not in train.");
            }
        }
    }
}