using lab5.Entities.Carriages;
using lab5.Entities.Carriages.PassengerCarriages;

namespace lab5.Entities.Trains
{
    public class PassengerTrain : Train
    {
        public decimal TotalRevenue { get; private set; } = 0;

        public PassengerTrain() : base() { }

        public PassengerTrain(string trainNumber, string route) : base(trainNumber, route) { }

        public override bool IsCarriageCompatible(Carriage carriage)
        {
            return carriage is CoupeCarriage ||
                   carriage is EconomCarriage ||
                   carriage is DiningCarriage;
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