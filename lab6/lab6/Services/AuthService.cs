namespace lab6.Services
{
    public class AuthService
    {
        private readonly string _filePath = "C:\\Users\\maxim\\VSProjects\\labs_c#\\lab6\\lab6\\passengers.txt";
        private Dictionary<string, string> _accounts = new Dictionary<string, string>();

        public AuthService()
        {
            LoadAccounts();
        }

        private void LoadAccounts()
        {
            if (!File.Exists(_filePath)) return;

            var lines = File.ReadAllLines(_filePath);
            foreach (var line in lines)
            {
                var parts = line.Split(':');
                if (parts.Length == 2 && !_accounts.ContainsKey(parts[0]))
                {
                    _accounts.Add(parts[0].Trim(), parts[1].Trim());
                }
            }
        }

        public bool Register(string username, string password)
        {
            if (_accounts.ContainsKey(username)) return false;

            _accounts.Add(username, password);
            File.AppendAllText(_filePath, $"{username}:{password}\n");
            return true;
        }

        public bool LoginPassenger(string username, string password)
        {
            if (_accounts.ContainsKey(username))
            {
                string storedPass = _accounts[username];

                if (storedPass == password)
                    return true;   
            }
            return false;
        }

        public bool LoginAdmin(string username, string password)
        {
            return username == "admin" && password == "admin123";
        }
    }
}