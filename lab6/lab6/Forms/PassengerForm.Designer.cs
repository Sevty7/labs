namespace lab6.Forms
{
    partial class PassengerForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            panelHeader = new Panel();
            btnRefresh = new Button();
            btnLogout = new Button();
            lblTitle = new Label();
            tabControl1 = new TabControl();
            tabPageTickets = new TabPage();
            panelTicketRight = new Panel();
            grpReserve = new GroupBox();
            btnReserve = new Button();
            label1 = new Label();
            cmbCarriageType = new ComboBox();
            dgvTrains = new DataGridView();
            tabPageDining = new TabPage();
            panelFoodRight = new Panel();
            grpOrder = new GroupBox();
            label2 = new Label();
            cmbDiningTrains = new ComboBox();
            btnOrderFood = new Button();
            dgvMenu = new DataGridView();
            panelHeader.SuspendLayout();
            tabControl1.SuspendLayout();
            tabPageTickets.SuspendLayout();
            panelTicketRight.SuspendLayout();
            grpReserve.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTrains).BeginInit();
            tabPageDining.SuspendLayout();
            panelFoodRight.SuspendLayout();
            grpOrder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMenu).BeginInit();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.FromArgb(0, 122, 204);
            panelHeader.Controls.Add(btnRefresh);
            panelHeader.Controls.Add(btnLogout);
            panelHeader.Controls.Add(lblTitle);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(1000, 70);
            panelHeader.TabIndex = 0;
            // 
            // btnRefresh
            // 
            btnRefresh.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnRefresh.BackColor = Color.White;
            btnRefresh.FlatAppearance.BorderSize = 0;
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnRefresh.ForeColor = Color.FromArgb(0, 122, 204);
            btnRefresh.Location = new Point(782, 18);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(100, 35);
            btnRefresh.TabIndex = 2;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = false;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // btnLogout
            // 
            btnLogout.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnLogout.BackColor = Color.Crimson;
            btnLogout.FlatAppearance.BorderSize = 0;
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnLogout.ForeColor = Color.White;
            btnLogout.Location = new Point(888, 18);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(100, 35);
            btnLogout.TabIndex = 1;
            btnLogout.Text = "Logout";
            btnLogout.UseVisualStyleBackColor = false;
            btnLogout.Click += btnLogout_Click;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI Semibold", 16F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(20, 16);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(247, 37);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Passenger Services";
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPageTickets);
            tabControl1.Controls.Add(tabPageDining);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Font = new Font("Segoe UI", 10F);
            tabControl1.ItemSize = new Size(150, 40);
            tabControl1.Location = new Point(0, 70);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1000, 530);
            tabControl1.SizeMode = TabSizeMode.Fixed;
            tabControl1.TabIndex = 1;
            // 
            // tabPageTickets
            // 
            tabPageTickets.Controls.Add(panelTicketRight);
            tabPageTickets.Controls.Add(dgvTrains);
            tabPageTickets.Location = new Point(4, 44);
            tabPageTickets.Name = "tabPageTickets";
            tabPageTickets.Padding = new Padding(20);
            tabPageTickets.Size = new Size(992, 482);
            tabPageTickets.TabIndex = 0;
            tabPageTickets.Text = "Book Tickets";
            tabPageTickets.UseVisualStyleBackColor = true;
            // 
            // panelTicketRight
            // 
            panelTicketRight.Controls.Add(grpReserve);
            panelTicketRight.Dock = DockStyle.Right;
            panelTicketRight.Location = new Point(672, 20);
            panelTicketRight.Name = "panelTicketRight";
            panelTicketRight.Padding = new Padding(20, 0, 0, 0);
            panelTicketRight.Size = new Size(300, 442);
            panelTicketRight.TabIndex = 1;
            // 
            // grpReserve
            // 
            grpReserve.Controls.Add(btnReserve);
            grpReserve.Controls.Add(label1);
            grpReserve.Controls.Add(cmbCarriageType);
            grpReserve.Dock = DockStyle.Top;
            grpReserve.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            grpReserve.Location = new Point(20, 0);
            grpReserve.Name = "grpReserve";
            grpReserve.Size = new Size(280, 200);
            grpReserve.TabIndex = 0;
            grpReserve.TabStop = false;
            grpReserve.Text = "Reservation";
            // 
            // btnReserve
            // 
            btnReserve.BackColor = Color.SeaGreen;
            btnReserve.FlatAppearance.BorderSize = 0;
            btnReserve.FlatStyle = FlatStyle.Flat;
            btnReserve.ForeColor = Color.White;
            btnReserve.Location = new Point(20, 120);
            btnReserve.Name = "btnReserve";
            btnReserve.Size = new Size(240, 45);
            btnReserve.TabIndex = 2;
            btnReserve.Text = "Reserve Ticket";
            btnReserve.UseVisualStyleBackColor = false;
            btnReserve.Click += btnReserve_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F);
            label1.Location = new Point(20, 40);
            label1.Name = "label1";
            label1.Size = new Size(144, 20);
            label1.TabIndex = 1;
            label1.Text = "Select Carriage Type";
            // 
            // cmbCarriageType
            // 
            cmbCarriageType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCarriageType.Font = new Font("Segoe UI", 10F);
            cmbCarriageType.FormattingEnabled = true;
            cmbCarriageType.Location = new Point(20, 65);
            cmbCarriageType.Name = "cmbCarriageType";
            cmbCarriageType.Size = new Size(240, 31);
            cmbCarriageType.TabIndex = 0;
            // 
            // dgvTrains
            // 
            dgvTrains.AllowUserToAddRows = false;
            dgvTrains.AllowUserToDeleteRows = false;
            dgvTrains.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTrains.BackgroundColor = Color.White;
            dgvTrains.BorderStyle = BorderStyle.None;
            dgvTrains.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvTrains.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(0, 122, 204);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 10F);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(0, 122, 204);
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvTrains.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvTrains.ColumnHeadersHeight = 40;
            dgvTrains.Dock = DockStyle.Left;
            dgvTrains.EnableHeadersVisualStyles = false;
            dgvTrains.Location = new Point(20, 20);
            dgvTrains.MultiSelect = false;
            dgvTrains.Name = "dgvTrains";
            dgvTrains.ReadOnly = true;
            dgvTrains.RowHeadersVisible = false;
            dgvTrains.RowHeadersWidth = 51;
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(229, 241, 251);
            dataGridViewCellStyle2.SelectionForeColor = Color.Black;
            dgvTrains.RowsDefaultCellStyle = dataGridViewCellStyle2;
            dgvTrains.RowTemplate.Height = 35;
            dgvTrains.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTrains.Size = new Size(640, 442);
            dgvTrains.TabIndex = 0;
            // 
            // tabPageDining
            // 
            tabPageDining.Controls.Add(panelFoodRight);
            tabPageDining.Controls.Add(dgvMenu);
            tabPageDining.Location = new Point(4, 44);
            tabPageDining.Name = "tabPageDining";
            tabPageDining.Padding = new Padding(20);
            tabPageDining.Size = new Size(992, 482);
            tabPageDining.TabIndex = 1;
            tabPageDining.Text = "Dining Car";
            tabPageDining.UseVisualStyleBackColor = true;
            // 
            // panelFoodRight
            // 
            panelFoodRight.Controls.Add(grpOrder);
            panelFoodRight.Dock = DockStyle.Right;
            panelFoodRight.Location = new Point(672, 20);
            panelFoodRight.Name = "panelFoodRight";
            panelFoodRight.Padding = new Padding(20, 0, 0, 0);
            panelFoodRight.Size = new Size(300, 442);
            panelFoodRight.TabIndex = 1;
            // 
            // grpOrder
            // 
            grpOrder.Controls.Add(label2);
            grpOrder.Controls.Add(cmbDiningTrains);
            grpOrder.Controls.Add(btnOrderFood);
            grpOrder.Dock = DockStyle.Top;
            grpOrder.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            grpOrder.Location = new Point(20, 0);
            grpOrder.Name = "grpOrder";
            grpOrder.Size = new Size(280, 200);
            grpOrder.TabIndex = 0;
            grpOrder.TabStop = false;
            grpOrder.Text = "Order Food";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F);
            label2.Location = new Point(20, 40);
            label2.Name = "label2";
            label2.Size = new Size(143, 20);
            label2.TabIndex = 2;
            label2.Text = "Select Train (Dining)";
            // 
            // cmbDiningTrains
            // 
            cmbDiningTrains.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDiningTrains.Font = new Font("Segoe UI", 10F);
            cmbDiningTrains.FormattingEnabled = true;
            cmbDiningTrains.Location = new Point(20, 65);
            cmbDiningTrains.Name = "cmbDiningTrains";
            cmbDiningTrains.Size = new Size(240, 31);
            cmbDiningTrains.TabIndex = 1;
            cmbDiningTrains.SelectedIndexChanged += cmbDiningTrains_SelectedIndexChanged;
            // 
            // btnOrderFood
            // 
            btnOrderFood.BackColor = Color.Orange;
            btnOrderFood.FlatAppearance.BorderSize = 0;
            btnOrderFood.FlatStyle = FlatStyle.Flat;
            btnOrderFood.ForeColor = Color.White;
            btnOrderFood.Location = new Point(20, 120);
            btnOrderFood.Name = "btnOrderFood";
            btnOrderFood.Size = new Size(240, 45);
            btnOrderFood.TabIndex = 0;
            btnOrderFood.Text = "Order Selected Item";
            btnOrderFood.UseVisualStyleBackColor = false;
            btnOrderFood.Click += btnOrderFood_Click;
            // 
            // dgvMenu
            // 
            dgvMenu.AllowUserToAddRows = false;
            dgvMenu.AllowUserToDeleteRows = false;
            dgvMenu.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvMenu.BackgroundColor = Color.White;
            dgvMenu.BorderStyle = BorderStyle.None;
            dgvMenu.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvMenu.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.Orange;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 10F);
            dataGridViewCellStyle3.ForeColor = Color.White;
            dataGridViewCellStyle3.SelectionBackColor = Color.Orange;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dgvMenu.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgvMenu.ColumnHeadersHeight = 40;
            dgvMenu.Dock = DockStyle.Left;
            dgvMenu.EnableHeadersVisualStyles = false;
            dgvMenu.Location = new Point(20, 20);
            dgvMenu.MultiSelect = false;
            dgvMenu.Name = "dgvMenu";
            dgvMenu.ReadOnly = true;
            dgvMenu.RowHeadersVisible = false;
            dgvMenu.RowHeadersWidth = 51;
            dataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(255, 248, 225);
            dataGridViewCellStyle4.SelectionForeColor = Color.Black;
            dgvMenu.RowsDefaultCellStyle = dataGridViewCellStyle4;
            dgvMenu.RowTemplate.Height = 35;
            dgvMenu.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMenu.Size = new Size(640, 442);
            dgvMenu.TabIndex = 0;
            // 
            // PassengerForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1000, 600);
            Controls.Add(tabControl1);
            Controls.Add(panelHeader);
            MinimumSize = new Size(1000, 600);
            Name = "PassengerForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Passenger Dashboard";
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            tabControl1.ResumeLayout(false);
            tabPageTickets.ResumeLayout(false);
            panelTicketRight.ResumeLayout(false);
            grpReserve.ResumeLayout(false);
            grpReserve.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTrains).EndInit();
            tabPageDining.ResumeLayout(false);
            panelFoodRight.ResumeLayout(false);
            grpOrder.ResumeLayout(false);
            grpOrder.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMenu).EndInit();
            ResumeLayout(false);
        }

        private Panel panelHeader;
        private Label lblTitle;
        private Button btnLogout;
        private TabControl tabControl1;
        private TabPage tabPageTickets;
        private TabPage tabPageDining;
        private DataGridView dgvTrains;
        private Panel panelTicketRight;
        private GroupBox grpReserve;
        private ComboBox cmbCarriageType;
        private Label label1;
        private Button btnReserve;
        private DataGridView dgvMenu;
        private Panel panelFoodRight;
        private GroupBox grpOrder;
        private Button btnOrderFood;
        private ComboBox cmbDiningTrains;
        private Label label2;
        private Button btnRefresh;
    }
}