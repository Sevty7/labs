using lab6.Services;

namespace lab6.Forms
{
    public partial class LoginForm : Form
    {

        private AuthService _authService = new AuthService();
        private RailwaySystem _railwaySystem = new RailwaySystem();

        public LoginForm()
        {
            InitializeComponent();
        }

        private void singInButton_Click(object sender, EventArgs e)
        {
            string login = loginTextBox.Text;
            string password = passwordTextBox.Text;

            if (string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Enter login or password!");
                return; 
            }

            if (_authService.LoginAdmin(login, password))
            {
                AdminForm adminForm = new AdminForm(_railwaySystem);

                this.Hide();
                adminForm.ShowDialog();
                this.Show();
                return;
            }

            if (_authService.LoginPassenger(login, password))
            {
                PassengerForm passengerForm = new PassengerForm(_railwaySystem);
                this.Hide();
                passengerForm.ShowDialog();
                this.Show();
                return;
            }

            MessageBox.Show("Invalid login or password");
        }

        private void signUpLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RegisterForm registerForm = new RegisterForm(_authService);

            this.Hide();

            registerForm.ShowDialog();

            this.Show();
        }
    }
}
