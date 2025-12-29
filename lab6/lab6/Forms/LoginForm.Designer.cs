namespace lab6.Forms
{
    partial class LoginForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            passwordTextBox = new TextBox();
            loginTextBox = new TextBox();
            loginLabel = new Label();
            passwordLabel = new Label();
            signUpLinkLabel = new LinkLabel();
            singInButton = new Button();
            lblTitle = new Label();
            SuspendLayout();
            // 
            // passwordTextBox
            // 
            passwordTextBox.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            passwordTextBox.Location = new Point(90, 206);
            passwordTextBox.Name = "passwordTextBox";
            passwordTextBox.PasswordChar = '●';
            passwordTextBox.PlaceholderText = "Enter password";
            passwordTextBox.Size = new Size(250, 30);
            passwordTextBox.TabIndex = 2;
            // 
            // loginTextBox
            // 
            loginTextBox.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            loginTextBox.Location = new Point(90, 137);
            loginTextBox.Name = "loginTextBox";
            loginTextBox.PlaceholderText = "Enter username";
            loginTextBox.Size = new Size(250, 30);
            loginTextBox.TabIndex = 1;
            // 
            // loginLabel
            // 
            loginLabel.AutoSize = true;
            loginLabel.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            loginLabel.Location = new Point(90, 114);
            loginLabel.Name = "loginLabel";
            loginLabel.Size = new Size(48, 20);
            loginLabel.TabIndex = 2;
            loginLabel.Text = "Login";
            // 
            // passwordLabel
            // 
            passwordLabel.AutoSize = true;
            passwordLabel.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            passwordLabel.Location = new Point(90, 183);
            passwordLabel.Name = "passwordLabel";
            passwordLabel.Size = new Size(73, 20);
            passwordLabel.TabIndex = 3;
            passwordLabel.Text = "Password";
            // 
            // signUpLinkLabel
            // 
            signUpLinkLabel.ActiveLinkColor = Color.Teal;
            signUpLinkLabel.AutoSize = true;
            signUpLinkLabel.LinkColor = Color.FromArgb(0, 122, 204);
            signUpLinkLabel.Location = new Point(141, 319);
            signUpLinkLabel.Name = "signUpLinkLabel";
            signUpLinkLabel.Size = new Size(149, 20);
            signUpLinkLabel.TabIndex = 4;
            signUpLinkLabel.TabStop = true;
            signUpLinkLabel.Text = "No account? Sign Up";
            signUpLinkLabel.LinkClicked += signUpLinkLabel_LinkClicked;
            // 
            // singInButton
            // 
            singInButton.BackColor = Color.FromArgb(0, 122, 204);
            singInButton.Cursor = Cursors.Hand;
            singInButton.FlatStyle = FlatStyle.Flat;
            singInButton.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            singInButton.ForeColor = Color.White;
            singInButton.Location = new Point(90, 260);
            singInButton.Name = "singInButton";
            singInButton.Size = new Size(250, 40);
            singInButton.TabIndex = 3;
            singInButton.Text = "Sign In";
            singInButton.UseVisualStyleBackColor = false;
            singInButton.Click += singInButton_Click;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI Light", 18F, FontStyle.Regular, GraphicsUnit.Point);
            lblTitle.ForeColor = Color.FromArgb(64, 64, 64);
            lblTitle.Location = new Point(116, 45);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(198, 41);
            lblTitle.TabIndex = 5;
            lblTitle.Text = "Railway Login";
            // 
            // LoginForm
            // 
            AcceptButton = singInButton;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(432, 403);
            Controls.Add(lblTitle);
            Controls.Add(singInButton);
            Controls.Add(signUpLinkLabel);
            Controls.Add(passwordLabel);
            Controls.Add(loginLabel);
            Controls.Add(loginTextBox);
            Controls.Add(passwordTextBox);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Authorization";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox passwordTextBox;
        private TextBox loginTextBox;
        private Label loginLabel;
        private Label passwordLabel;
        private LinkLabel signUpLinkLabel;
        private Button singInButton;
        private Label lblTitle;
    }
}