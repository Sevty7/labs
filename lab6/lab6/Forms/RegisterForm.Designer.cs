namespace lab6.Forms
{
    partial class RegisterForm
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
            loginLabel = new Label();
            loginTextBox = new TextBox();
            passwordLabel = new Label();
            passwordTextBox = new TextBox();
            singUpButton = new Button();
            signIpLinkLabel = new LinkLabel();
            lblTitle = new Label();
            SuspendLayout();
            // 
            // loginLabel
            // 
            loginLabel.AutoSize = true;
            loginLabel.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            loginLabel.Location = new Point(90, 114);
            loginLabel.Name = "loginLabel";
            loginLabel.Size = new Size(126, 20);
            loginLabel.TabIndex = 3;
            loginLabel.Text = "Create Username";
            // 
            // loginTextBox
            // 
            loginTextBox.Font = new Font("Segoe UI", 10F);
            loginTextBox.Location = new Point(90, 137);
            loginTextBox.Name = "loginTextBox";
            loginTextBox.PlaceholderText = "Enter username";
            loginTextBox.Size = new Size(250, 30);
            loginTextBox.TabIndex = 1;
            // 
            // passwordLabel
            // 
            passwordLabel.AutoSize = true;
            passwordLabel.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            passwordLabel.Location = new Point(90, 183);
            passwordLabel.Name = "passwordLabel";
            passwordLabel.Size = new Size(121, 20);
            passwordLabel.TabIndex = 5;
            passwordLabel.Text = "Create Password";
            // 
            // passwordTextBox
            // 
            passwordTextBox.Font = new Font("Segoe UI", 10F);
            passwordTextBox.Location = new Point(90, 206);
            passwordTextBox.Name = "passwordTextBox";
            passwordTextBox.PasswordChar = '●';
            passwordTextBox.PlaceholderText = "Enter password";
            passwordTextBox.Size = new Size(250, 30);
            passwordTextBox.TabIndex = 2;
            // 
            // singUpButton
            // 
            singUpButton.BackColor = Color.ForestGreen;
            singUpButton.Cursor = Cursors.Hand;
            singUpButton.FlatStyle = FlatStyle.Flat;
            singUpButton.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            singUpButton.ForeColor = Color.White;
            singUpButton.Location = new Point(90, 260);
            singUpButton.Name = "singUpButton";
            singUpButton.Size = new Size(250, 40);
            singUpButton.TabIndex = 3;
            singUpButton.Text = "Create Account";
            singUpButton.UseVisualStyleBackColor = false;
            singUpButton.Click += singInButton_Click;
            // 
            // signIpLinkLabel
            // 
            signIpLinkLabel.ActiveLinkColor = Color.DarkGreen;
            signIpLinkLabel.AutoSize = true;
            signIpLinkLabel.LinkColor = Color.FromArgb(0, 122, 204);
            signIpLinkLabel.Location = new Point(135, 319);
            signIpLinkLabel.Name = "signIpLinkLabel";
            signIpLinkLabel.Size = new Size(167, 20);
            signIpLinkLabel.TabIndex = 4;
            signIpLinkLabel.TabStop = true;
            signIpLinkLabel.Text = "Have an account? Login";
            signIpLinkLabel.LinkClicked += signIpLinkLabel_LinkClicked;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI Light", 18F);
            lblTitle.ForeColor = Color.FromArgb(64, 64, 64);
            lblTitle.Location = new Point(135, 44);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(167, 41);
            lblTitle.TabIndex = 6;
            lblTitle.Text = "Registration";
            // 
            // RegisterForm
            // 
            AcceptButton = singUpButton;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(432, 403);
            Controls.Add(lblTitle);
            Controls.Add(signIpLinkLabel);
            Controls.Add(singUpButton);
            Controls.Add(passwordTextBox);
            Controls.Add(passwordLabel);
            Controls.Add(loginTextBox);
            Controls.Add(loginLabel);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "RegisterForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Register";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label loginLabel;
        private TextBox loginTextBox;
        private Label passwordLabel;
        private TextBox passwordTextBox;
        private Button singUpButton;
        private LinkLabel signIpLinkLabel;
        private Label lblTitle;
    }
}