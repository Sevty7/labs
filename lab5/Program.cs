using lab5.Services;

namespace lab5
{
    public class Program
    {
        public static void Main(string[] args)
        {
            RailwaySystem service = new RailwaySystem();

            while (true)
            {
                Console.WriteLine("1. Enter as a passenger ");
                Console.WriteLine("2. Enter as a admin");
                Console.WriteLine("0. Quit");

                string key = Console.ReadLine();

                if (key == "1")
                {
                    IPassengerService passengerService = service;
                }
                else if (key == "2")
                {
                    IAdminService adminService = service;
                }
                else if (key == "0") break;
            }
        }
    }
}
