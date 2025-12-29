using lab6.Services;

namespace lab6.Forms
{
    public partial class RegisterForm : Form
    {
        private AuthService _authService;
        public RegisterForm(AuthService authService)
        {
            InitializeComponent();
            _authService = authService;
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

            if (_authService.Register(login, password))
            {
                MessageBox.Show("Successful registration");
                this.Close();
                return;
            }
            MessageBox.Show("This user already exists");
        }

        private void signIpLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }
    }
}
