using lab5.Entities;
using lab5.Entities.Carriages;
using lab5.Entities.Carriages.FreightCarriages;
using lab5.Entities.Carriages.PassengerCarriages;
using lab5.Services;
using static lab5.Entities.Trains.Train;

namespace lab5
{
    public class Program
    {
        private static Dictionary<string, string> passengerAccounts = new Dictionary<string, string>();
        private const string AccountsFilePath = "C:\\Users\\maxim\\VSProjects\\labs_c#\\lab5\\passengers.txt";

        public static void Main(string[] args)
        {
            LoadPassengerAccountsFromFile();

            RailwaySystem service = new RailwaySystem();

            while (true)
            {
                Console.WriteLine("====================================");
                Console.WriteLine(" Main Menu ");
                Console.WriteLine("====================================");
                Console.WriteLine("1. Enter as a passenger");
                Console.WriteLine("2. Enter as an admin");
                Console.WriteLine("0. Quit");
                Console.Write("Choose an option: ");

                string key = Console.ReadLine();
                Console.WriteLine();

                if (key == "0")
                {
                    Console.WriteLine("Exiting the system... Goodbye!");
                    break;
                }

                if (key == "1")
                {
                    Console.WriteLine("Passenger mode selected.");
                    if (PassengerAuth())
                    {
                        Console.WriteLine("Entering Passenger Menu...");
                        PassengerMenu(service);
                    }
                    else
                    {
                        Console.WriteLine("Returning to main menu...");
                    }
                }
                else if (key == "2")
                {
                    Console.WriteLine("Admin mode selected.");
                    if (AdminAuth())
                    {
                        Console.WriteLine("Access granted. Entering Admin Menu...");
                        AdminMenu(service);
                    }
                    else
                    {
                        Console.WriteLine("Access denied. Returning to main menu...");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid option. Please choose 0, 1, or 2.");
                }
            }
        }

        private static bool AdminAuth()
        {
            Console.WriteLine("=== Admin Login ===");
            Console.Write("Username: ");
            string username = Console.ReadLine();
            Console.Write("Password: ");
            string password = Console.ReadLine();

            if (username == "admin" && password == "admin123")
            {
                Console.WriteLine("Admin authenticated successfully.");
                return true;
            }

            Console.WriteLine("Incorrect username or password.");
            return false;
        }

        private static bool PassengerAuth()
        {
            Console.WriteLine("=== Passenger Authentication ===");
            Console.WriteLine("1. Register");
            Console.WriteLine("2. Login");
            Console.WriteLine("0. Back");
            Console.Write("Choose an option: ");

            string choice = Console.ReadLine();
            Console.WriteLine();

            if (choice == "0")
            {
                Console.WriteLine("Returning back...");
                return false;
            }

            Console.Write("Username: ");
            string username = Console.ReadLine();
            Console.Write("Password: ");
            string password = Console.ReadLine();

            if (choice == "1")
            {
                if (passengerAccounts.ContainsKey(username))
                {
                    Console.WriteLine("Username already exists.");
                    return false;
                }

                // Add to dictionary and append to file
                passengerAccounts.Add(username, password);
                try
                {
                    AppendAccountToFile(username, password);
                    Console.WriteLine("Registration successful and saved.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Registration saved in memory but failed to write file: {ex.Message}");
                }

                return true;
            }
            else if (choice == "2")
            {
                if (passengerAccounts.TryGetValue(username, out string storedPass) && storedPass == password)
                {
                    Console.WriteLine("Login successful.");
                    return true;
                }

                Console.WriteLine("Invalid credentials.");
                return false;
            }

            Console.WriteLine("Invalid option.");
            return false;
        }

        private static void PassengerMenu(IPassengerService service)
        {
            while (true)
            {
                Console.WriteLine("\n===== Passenger Menu =====");
                Console.WriteLine("1. View available trains");
                Console.WriteLine("2. Reserve ticket");
                Console.WriteLine("3. View dining menu");
                Console.WriteLine("4. Order food");
                Console.WriteLine("0. Back");
                Console.Write("Choose an option: ");

                string key = Console.ReadLine();
                Console.WriteLine();

                if (key == "0")
                {
                    Console.WriteLine("Returning to main menu...");
                    break;
                }

                try
                {
                    if (key == "1")
                    {
                        Console.WriteLine("Fetching list of available trains...");
                        var trains = service.GetAvailableTrains();

                        if (trains.Count == 0)
                        {
                            Console.WriteLine("No available trains.");
                        }
                        else
                        {
                            foreach (var train in trains)
                                Console.WriteLine(train.ToString());
                        }
                    }
                    else if (key == "2")
                    {
                        Console.Write("Enter train number: ");
                        string trainNum = Console.ReadLine();

                        var train = service.GetAvailableTrains()
                            .FirstOrDefault(t => t.TrainNumber == trainNum);

                        if (train == null)
                        {
                            Console.WriteLine("Train not found or not available.");
                            continue;
                        }

                        Console.Write("Enter carriage type (coupe/econom): ");
                        string type = Console.ReadLine();

                        try
                        {
                            service.ReserveTicket(train, type);
                            Console.WriteLine($"Ticket reserved successfully in a {type} carriage.");
                        }
                        catch (InvalidOperationException ex)
                        {
                            Console.WriteLine($"Reservation failed: {ex.Message}");
                        }
                    }

                    else if (key == "3")
                    {
                        Console.Write("Enter train number: ");
                        string trainNum = Console.ReadLine();

                        Console.WriteLine("Loading dining menu...");
                        var menu = service.GetDiningMenu(trainNum);

                        if (menu.Count == 0)
                        {
                            Console.WriteLine("No dining menu available.");
                        }
                        else
                        {
                            foreach (var item in menu)
                                Console.WriteLine($"{item.Key}: {item.Value}");
                        }
                    }
                    else if (key == "4")
                    {
                        Console.Write("Enter train number: ");
                        string trainNum = Console.ReadLine();
                        Console.Write("Enter item name: ");
                        string item = Console.ReadLine();

                        service.OrderFood(trainNum, item);
                        Console.WriteLine("Food ordered successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Invalid option.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }

        private static void AdminMenu(IAdminService service)
        {
            while (true)
            {
                Console.WriteLine("\n===== Admin Menu =====");
                Console.WriteLine("1. Create train");
                Console.WriteLine("2. Add carriage to train");
                Console.WriteLine("3. Remove carriage from train");
                Console.WriteLine("4. View all trains");
                Console.WriteLine("5. Check if train is overloaded");
                Console.WriteLine("6. Set train state");
                Console.WriteLine("7. Save system state");
                Console.WriteLine("8. Load system state");
                Console.WriteLine("9. Sort train carriages by comfort");
                Console.WriteLine("10. Find carriages by passenger range");
                Console.WriteLine("0. Back");
                Console.Write("Choose an option: ");

                string key = Console.ReadLine();
                Console.WriteLine();

                if (key == "0")
                {
                    Console.WriteLine("Returning to main menu...");
                    break;
                }

                try
                {
                    if (key == "1")
                    {
                        Console.WriteLine("=== Create Train ===");

                        Console.Write("Enter train number: ");
                        string number = Console.ReadLine();

                        Console.Write("Enter start station: ");
                        string start = Console.ReadLine();

                        Console.Write("Enter end station: ");
                        string end = Console.ReadLine();

                        Console.Write("Enter distance (km): ");
                        double distance = double.Parse(Console.ReadLine());

                        Console.Write("Enter duration (hh:mm): ");
                        TimeSpan duration = TimeSpan.Parse(Console.ReadLine());

                        Route route = new Route(start, end, distance, duration);

                        Console.Write("Is passenger train? (y/n): ");
                        bool isPassenger = Console.ReadLine().ToLower() == "y";

                        service.CreateTrain(number, route, isPassenger);

                        Console.WriteLine("Train created successfully.");
                    }
                    else if (key == "2")
                    {
                        Console.Write("Enter train number: ");
                        string trainNum = Console.ReadLine();

                        Console.Write("Enter carriage type (coupe, econom, dining, hopper, tank): ");
                        string type = Console.ReadLine().ToLower();

                        Carriage carriage = type switch
                        {
                            "coupe" => new CoupeCarriage(),
                            "econom" => new EconomCarriage(),
                            "dining" => new DiningCarriage(),
                            "hopper" => new HopperCarriage(),
                            "tank" => new TankCarriage(),
                            _ => null
                        };

                        if (carriage == null)
                        {
                            Console.WriteLine("Invalid carriage type.");
                        }
                        else
                        {
                            service.AddCarriageToTrain(trainNum, carriage);
                            Console.WriteLine("Carriage added.");
                        }
                    }
                    else if (key == "3")
                    {
                        Console.Write("Enter train number: ");
                        string trainNum = Console.ReadLine();

                        Console.Write("Enter carriage index: ");
                        if (int.TryParse(Console.ReadLine(), out int index))
                        {
                            service.RemoveCarriageFromTrain(trainNum, index);
                            Console.WriteLine("Carriage removed.");
                        }
                        else
                        {
                            Console.WriteLine("Invalid index.");
                        }
                    }
                    else if (key == "4")
                    {
                        Console.WriteLine("Listing all trains...");
                        var trains = service.GetAllTrains();

                        if (trains.Count == 0)
                        {
                            Console.WriteLine("No trains found.");
                        }
                        else
                        {
                            foreach (var train in trains)
                                Console.WriteLine(train.ToString());
                        }
                    }
                    else if (key == "5")
                    {
                        Console.Write("Enter train number: ");
                        string trainNum = Console.ReadLine();

                        bool overloaded = service.IsTrainOverloaded(trainNum);
                        Console.WriteLine($"Overloaded: {overloaded}");
                    }
                    else if (key == "6")
                    {
                        Console.Write("Enter train number: ");
                        string trainNum = Console.ReadLine();

                        Console.WriteLine("States: 0-Ready, 1-InTransit, 2-Arrived, 3-Maintenance, 4-Cancelled");
                        Console.Write("Choose state: ");

                        if (int.TryParse(Console.ReadLine(), out int stateInt) &&
                            Enum.IsDefined(typeof(TrainState), stateInt))
                        {
                            service.SetTrainState(trainNum, (TrainState)stateInt);
                            Console.WriteLine("State updated.");
                        }
                        else
                        {
                            Console.WriteLine("Invalid state number.");
                        }
                    }
                    else if (key == "7")
                    {
                        Console.Write("Enter file path to save: ");
                        string path = Console.ReadLine();

                        service.SaveSystemState(path);
                        Console.WriteLine("State saved.");
                    }
                    else if (key == "8")
                    {
                        Console.Write("Enter file path to load: ");
                        string path = Console.ReadLine();

                        service.LoadTrainsFromXml(path);
                        Console.WriteLine("System state loaded.");
                    }
                    else if (key == "9")
                    {
                        Console.Write("Enter train number to sort carriages: ");
                        string trainNum = Console.ReadLine();

                        service.SortTrainCarriagesByComfort(trainNum);
                        Console.WriteLine($"Carriages for train {trainNum} sorted by comfort level.");
                        Console.WriteLine(service.GetTrainByNumber(trainNum).ToString());
                    }
                    else if (key == "10")
                    {
                        Console.Write("Enter train number to search carriages: ");
                        string trainNum = Console.ReadLine();

                        Console.Write("Enter minimum number of passengers: ");
                        if (!int.TryParse(Console.ReadLine(), out int min))
                        {
                            Console.WriteLine("Invalid minimum value.");
                            continue;
                        }

                        Console.Write("Enter maximum number of passengers: ");
                        if (!int.TryParse(Console.ReadLine(), out int max))
                        {
                            Console.WriteLine("Invalid maximum value.");
                            continue;
                        }

                        var foundCarriages = service.FindCarriagesByPassengerRange(trainNum, min, max);

                        if (foundCarriages.Count == 0)
                        {
                            Console.WriteLine($"No carriages found in train {trainNum} with passenger count between {min} and {max}.");
                        }
                        else
                        {
                            Console.WriteLine($"Found {foundCarriages.Count} carriages:");
                            foreach (var carriage in foundCarriages)
                            {
                                Console.WriteLine($"- Type: {carriage.GetType().Name}, Current Passengers: {carriage.Passengers}");
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid option.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }



        private static void LoadPassengerAccountsFromFile()
        {
            try
            {
                if (!File.Exists(AccountsFilePath))
                {
                    File.WriteAllText(AccountsFilePath, string.Empty);
                    return;
                }

                var lines = File.ReadAllLines(AccountsFilePath);
                foreach (var raw in lines)
                {
                    if (string.IsNullOrWhiteSpace(raw)) continue;
                    if (raw.StartsWith("#")) continue; //comments

                    int sepIndex = raw.IndexOf(':');
                    if (sepIndex <= 0) continue;

                    string username = raw.Substring(0, sepIndex).Trim();
                    string password = raw.Substring(sepIndex + 1).Trim();

                    if (!passengerAccounts.ContainsKey(username))
                        passengerAccounts.Add(username, password);
                }

                Console.WriteLine($"Loaded {passengerAccounts.Count} passenger accounts from file.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to load passenger accounts: {ex.Message}");
            }
        }

        private static void AppendAccountToFile(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(AccountsFilePath))
                throw new ArgumentException("Accounts file path is null or empty.", nameof(AccountsFilePath));

            if (string.IsNullOrWhiteSpace(username))
                throw new ArgumentException("Username is null or empty.", nameof(username));

            if (password == null)
                throw new ArgumentException("Password is null.", nameof(password));

            try
            {
                using (var sw = new StreamWriter(AccountsFilePath, append: true))
                {
                    sw.WriteLine($"{username}:{password}");
                }
            }
            catch (Exception e)
            {
                throw new IOException("Failed to append account to file.", e);
            }
        }

    }
}
