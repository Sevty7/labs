namespace lab6.Forms
{
    partial class AdminForm
    {

        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            panelSidebar = new Panel();
            btnLogout = new Button();
            btnLoad = new Button();
            btnSave = new Button();
            panelHeader = new Panel();
            lblTitle = new Label();
            panelContent = new Panel();
            dgvCarriages = new DataGridView();
            lblCarriages = new Label();
            dgvTrains = new DataGridView();
            lblTrains = new Label();
            panelControls = new Panel();
            grpCarriages = new GroupBox();
            btnSearch = new Button();
            numMaxPass = new NumericUpDown();
            label8 = new Label();
            numMinPass = new NumericUpDown();
            label7 = new Label();
            btnSort = new Button();
            btnRemoveCarriage = new Button();
            numCarriageIndex = new NumericUpDown();
            label6 = new Label();
            btnAddCarriage = new Button();
            cmbCarriageType = new ComboBox();
            grpActions = new GroupBox();
            btnCheckOverload = new Button();
            btnSetState = new Button();
            cmbState = new ComboBox();
            grpCreate = new GroupBox();
            btnCreateTrain = new Button();
            rbFreight = new RadioButton();
            rbPassenger = new RadioButton();
            txtDuration = new TextBox();
            label5 = new Label();
            numDistance = new NumericUpDown();
            label4 = new Label();
            txtEnd = new TextBox();
            label3 = new Label();
            txtStart = new TextBox();
            label2 = new Label();
            txtNumber = new TextBox();
            label1 = new Label();
            panelSidebar.SuspendLayout();
            panelHeader.SuspendLayout();
            panelContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCarriages).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvTrains).BeginInit();
            panelControls.SuspendLayout();
            grpCarriages.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numMaxPass).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numMinPass).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numCarriageIndex).BeginInit();
            grpActions.SuspendLayout();
            grpCreate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numDistance).BeginInit();
            SuspendLayout();
            // 
            // panelSidebar
            // 
            panelSidebar.BackColor = Color.FromArgb(33, 37, 41);
            panelSidebar.Controls.Add(btnLogout);
            panelSidebar.Controls.Add(btnLoad);
            panelSidebar.Controls.Add(btnSave);
            panelSidebar.Dock = DockStyle.Left;
            panelSidebar.Location = new Point(0, 0);
            panelSidebar.Name = "panelSidebar";
            panelSidebar.Size = new Size(200, 703);
            panelSidebar.TabIndex = 0;
            // 
            // btnLogout
            // 
            btnLogout.BackColor = Color.Crimson;
            btnLogout.Dock = DockStyle.Bottom;
            btnLogout.FlatAppearance.BorderSize = 0;
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            btnLogout.ForeColor = Color.White;
            btnLogout.Location = new Point(0, 643);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(200, 60);
            btnLogout.TabIndex = 2;
            btnLogout.Text = "Logout";
            btnLogout.UseVisualStyleBackColor = false;
            btnLogout.Click += btnLogout_Click;
            // 
            // btnLoad
            // 
            btnLoad.BackColor = Color.FromArgb(52, 58, 64);
            btnLoad.Dock = DockStyle.Top;
            btnLoad.FlatAppearance.BorderSize = 0;
            btnLoad.FlatStyle = FlatStyle.Flat;
            btnLoad.Font = new Font("Segoe UI", 10F);
            btnLoad.ForeColor = Color.White;
            btnLoad.Location = new Point(0, 60);
            btnLoad.Name = "btnLoad";
            btnLoad.Size = new Size(200, 60);
            btnLoad.TabIndex = 1;
            btnLoad.Text = "Load XML";
            btnLoad.UseVisualStyleBackColor = false;
            btnLoad.Click += btnLoad_Click;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(52, 58, 64);
            btnSave.Dock = DockStyle.Top;
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Segoe UI", 10F);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(0, 0);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(200, 60);
            btnSave.TabIndex = 0;
            btnSave.Text = "Save XML";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.White;
            panelHeader.Controls.Add(lblTitle);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(200, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(982, 60);
            panelHeader.TabIndex = 1;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI Light", 18F);
            lblTitle.Location = new Point(20, 9);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(245, 41);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Admin Dashboard";
            // 
            // panelContent
            // 
            panelContent.BackColor = Color.FromArgb(248, 249, 250);
            panelContent.Controls.Add(dgvCarriages);
            panelContent.Controls.Add(lblCarriages);
            panelContent.Controls.Add(dgvTrains);
            panelContent.Controls.Add(lblTrains);
            panelContent.Dock = DockStyle.Fill;
            panelContent.Location = new Point(200, 60);
            panelContent.Name = "panelContent";
            panelContent.Padding = new Padding(20);
            panelContent.Size = new Size(652, 643);
            panelContent.TabIndex = 2;
            // 
            // dgvCarriages
            // 
            dgvCarriages.AllowUserToAddRows = false;
            dgvCarriages.AllowUserToDeleteRows = false;
            dgvCarriages.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvCarriages.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCarriages.BackgroundColor = Color.White;
            dgvCarriages.BorderStyle = BorderStyle.None;
            dgvCarriages.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvCarriages.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(0, 122, 204);
            dataGridViewCellStyle1.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(0, 122, 204);
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvCarriages.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvCarriages.ColumnHeadersHeight = 40;
            dgvCarriages.EnableHeadersVisualStyles = false;
            dgvCarriages.Location = new Point(20, 473);
            dgvCarriages.MultiSelect = false;
            dgvCarriages.Name = "dgvCarriages";
            dgvCarriages.ReadOnly = true;
            dgvCarriages.RowHeadersVisible = false;
            dgvCarriages.RowHeadersWidth = 51;
            dataGridViewCellStyle2.BackColor = Color.White;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(229, 241, 251);
            dataGridViewCellStyle2.SelectionForeColor = Color.Black;
            dgvCarriages.RowsDefaultCellStyle = dataGridViewCellStyle2;
            dgvCarriages.RowTemplate.Height = 35;
            dgvCarriages.ScrollBars = ScrollBars.Both;
            dgvCarriages.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCarriages.Size = new Size(612, 150);
            dgvCarriages.TabIndex = 3;
            // 
            // lblCarriages
            // 
            lblCarriages.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblCarriages.AutoSize = true;
            lblCarriages.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            lblCarriages.ForeColor = Color.FromArgb(64, 64, 64);
            lblCarriages.Location = new Point(20, 445);
            lblCarriages.Name = "lblCarriages";
            lblCarriages.Size = new Size(166, 25);
            lblCarriages.TabIndex = 2;
            lblCarriages.Text = "Train Composition";
            // 
            // dgvTrains
            // 
            dgvTrains.AllowUserToAddRows = false;
            dgvTrains.AllowUserToDeleteRows = false;
            dgvTrains.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvTrains.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTrains.BackgroundColor = Color.White;
            dgvTrains.BorderStyle = BorderStyle.None;
            dgvTrains.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvTrains.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.FromArgb(0, 122, 204);
            dataGridViewCellStyle3.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = Color.White;
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(0, 122, 204);
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dgvTrains.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgvTrains.ColumnHeadersHeight = 40;
            dgvTrains.EnableHeadersVisualStyles = false;
            dgvTrains.Location = new Point(20, 52);
            dgvTrains.MultiSelect = false;
            dgvTrains.Name = "dgvTrains";
            dgvTrains.ReadOnly = true;
            dgvTrains.RowHeadersVisible = false;
            dgvTrains.RowHeadersWidth = 51;
            dataGridViewCellStyle4.BackColor = Color.White;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle4.ForeColor = Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(229, 241, 251);
            dataGridViewCellStyle4.SelectionForeColor = Color.Black;
            dgvTrains.RowsDefaultCellStyle = dataGridViewCellStyle4;
            dgvTrains.RowTemplate.Height = 35;
            dgvTrains.ScrollBars = ScrollBars.Both;
            dgvTrains.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTrains.Size = new Size(612, 380);
            dgvTrains.TabIndex = 1;
            // 
            // lblTrains
            // 
            lblTrains.AutoSize = true;
            lblTrains.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            lblTrains.ForeColor = Color.FromArgb(64, 64, 64);
            lblTrains.Location = new Point(20, 24);
            lblTrains.Name = "lblTrains";
            lblTrains.Size = new Size(122, 25);
            lblTrains.TabIndex = 0;
            lblTrains.Text = "Active Trains";
            // 
            // panelControls
            // 
            panelControls.BackColor = Color.White;
            panelControls.BorderStyle = BorderStyle.FixedSingle;
            panelControls.Controls.Add(grpCarriages);
            panelControls.Controls.Add(grpActions);
            panelControls.Controls.Add(grpCreate);
            panelControls.Dock = DockStyle.Right;
            panelControls.Location = new Point(852, 60);
            panelControls.Name = "panelControls";
            panelControls.Padding = new Padding(10);
            panelControls.Size = new Size(330, 643);
            panelControls.TabIndex = 3;
            // 
            // grpCarriages
            // 
            grpCarriages.Controls.Add(btnSearch);
            grpCarriages.Controls.Add(numMaxPass);
            grpCarriages.Controls.Add(label8);
            grpCarriages.Controls.Add(numMinPass);
            grpCarriages.Controls.Add(label7);
            grpCarriages.Controls.Add(btnSort);
            grpCarriages.Controls.Add(btnRemoveCarriage);
            grpCarriages.Controls.Add(numCarriageIndex);
            grpCarriages.Controls.Add(label6);
            grpCarriages.Controls.Add(btnAddCarriage);
            grpCarriages.Controls.Add(cmbCarriageType);
            grpCarriages.Dock = DockStyle.Top;
            grpCarriages.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            grpCarriages.Location = new Point(10, 396);
            grpCarriages.Name = "grpCarriages";
            grpCarriages.Size = new Size(308, 237);
            grpCarriages.TabIndex = 2;
            grpCarriages.TabStop = false;
            grpCarriages.Text = "Manage Carriages";
            // 
            // btnSearch
            // 
            btnSearch.BackColor = Color.Gray;
            btnSearch.FlatAppearance.BorderSize = 0;
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.Font = new Font("Segoe UI", 9F);
            btnSearch.ForeColor = Color.White;
            btnSearch.Location = new Point(6, 187);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(296, 30);
            btnSearch.TabIndex = 10;
            btnSearch.Text = "Search by Passengers";
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += btnSearch_Click;
            // 
            // numMaxPass
            // 
            numMaxPass.Location = new Point(190, 154);
            numMaxPass.Name = "numMaxPass";
            numMaxPass.Size = new Size(60, 27);
            numMaxPass.TabIndex = 9;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 9F);
            label8.Location = new Point(148, 156);
            label8.Name = "label8";
            label8.Size = new Size(37, 20);
            label8.TabIndex = 8;
            label8.Text = "Max";
            // 
            // numMinPass
            // 
            numMinPass.Location = new Point(82, 154);
            numMinPass.Name = "numMinPass";
            numMinPass.Size = new Size(60, 27);
            numMinPass.TabIndex = 7;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 9F);
            label7.Location = new Point(6, 156);
            label7.Name = "label7";
            label7.Size = new Size(70, 20);
            label7.TabIndex = 6;
            label7.Text = "Pass Min:";
            // 
            // btnSort
            // 
            btnSort.BackColor = Color.Gray;
            btnSort.FlatAppearance.BorderSize = 0;
            btnSort.FlatStyle = FlatStyle.Flat;
            btnSort.Font = new Font("Segoe UI", 9F);
            btnSort.ForeColor = Color.White;
            btnSort.Location = new Point(6, 110);
            btnSort.Name = "btnSort";
            btnSort.Size = new Size(296, 30);
            btnSort.TabIndex = 5;
            btnSort.Text = "Sort by Comfort";
            btnSort.UseVisualStyleBackColor = false;
            btnSort.Click += btnSort_Click;
            // 
            // btnRemoveCarriage
            // 
            btnRemoveCarriage.BackColor = Color.Crimson;
            btnRemoveCarriage.FlatAppearance.BorderSize = 0;
            btnRemoveCarriage.FlatStyle = FlatStyle.Flat;
            btnRemoveCarriage.Font = new Font("Segoe UI", 9F);
            btnRemoveCarriage.ForeColor = Color.White;
            btnRemoveCarriage.Location = new Point(216, 70);
            btnRemoveCarriage.Name = "btnRemoveCarriage";
            btnRemoveCarriage.Size = new Size(86, 30);
            btnRemoveCarriage.TabIndex = 4;
            btnRemoveCarriage.Text = "Remove";
            btnRemoveCarriage.UseVisualStyleBackColor = false;
            btnRemoveCarriage.Click += btnRemoveCarriage_Click;
            // 
            // numCarriageIndex
            // 
            numCarriageIndex.Location = new Point(125, 73);
            numCarriageIndex.Name = "numCarriageIndex";
            numCarriageIndex.Size = new Size(85, 27);
            numCarriageIndex.TabIndex = 3;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9F);
            label6.Location = new Point(6, 75);
            label6.Name = "label6";
            label6.Size = new Size(107, 20);
            label6.TabIndex = 2;
            label6.Text = "Remove Index:";
            // 
            // btnAddCarriage
            // 
            btnAddCarriage.BackColor = Color.SeaGreen;
            btnAddCarriage.FlatAppearance.BorderSize = 0;
            btnAddCarriage.FlatStyle = FlatStyle.Flat;
            btnAddCarriage.Font = new Font("Segoe UI", 9F);
            btnAddCarriage.ForeColor = Color.White;
            btnAddCarriage.Location = new Point(216, 30);
            btnAddCarriage.Name = "btnAddCarriage";
            btnAddCarriage.Size = new Size(86, 30);
            btnAddCarriage.TabIndex = 1;
            btnAddCarriage.Text = "Add";
            btnAddCarriage.UseVisualStyleBackColor = false;
            btnAddCarriage.Click += btnAddCarriage_Click;
            // 
            // cmbCarriageType
            // 
            cmbCarriageType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCarriageType.Font = new Font("Segoe UI", 9F);
            cmbCarriageType.FormattingEnabled = true;
            cmbCarriageType.Location = new Point(6, 31);
            cmbCarriageType.Name = "cmbCarriageType";
            cmbCarriageType.Size = new Size(204, 28);
            cmbCarriageType.TabIndex = 0;
            // 
            // grpActions
            // 
            grpActions.Controls.Add(btnCheckOverload);
            grpActions.Controls.Add(btnSetState);
            grpActions.Controls.Add(cmbState);
            grpActions.Dock = DockStyle.Top;
            grpActions.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            grpActions.Location = new Point(10, 276);
            grpActions.Name = "grpActions";
            grpActions.Size = new Size(308, 120);
            grpActions.TabIndex = 1;
            grpActions.TabStop = false;
            grpActions.Text = "Train Status & Actions";
            // 
            // btnCheckOverload
            // 
            btnCheckOverload.BackColor = Color.Orange;
            btnCheckOverload.FlatAppearance.BorderSize = 0;
            btnCheckOverload.FlatStyle = FlatStyle.Flat;
            btnCheckOverload.Font = new Font("Segoe UI", 9F);
            btnCheckOverload.ForeColor = Color.White;
            btnCheckOverload.Location = new Point(6, 75);
            btnCheckOverload.Name = "btnCheckOverload";
            btnCheckOverload.Size = new Size(296, 30);
            btnCheckOverload.TabIndex = 2;
            btnCheckOverload.Text = "Check Overload";
            btnCheckOverload.UseVisualStyleBackColor = false;
            btnCheckOverload.Click += btnCheckOverload_Click;
            // 
            // btnSetState
            // 
            btnSetState.BackColor = Color.FromArgb(0, 122, 204);
            btnSetState.FlatAppearance.BorderSize = 0;
            btnSetState.FlatStyle = FlatStyle.Flat;
            btnSetState.Font = new Font("Segoe UI", 9F);
            btnSetState.ForeColor = Color.White;
            btnSetState.Location = new Point(216, 35);
            btnSetState.Name = "btnSetState";
            btnSetState.Size = new Size(86, 30);
            btnSetState.TabIndex = 1;
            btnSetState.Text = "Set State";
            btnSetState.UseVisualStyleBackColor = false;
            btnSetState.Click += btnSetState_Click;
            // 
            // cmbState
            // 
            cmbState.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbState.Font = new Font("Segoe UI", 9F);
            cmbState.FormattingEnabled = true;
            cmbState.Location = new Point(6, 36);
            cmbState.Name = "cmbState";
            cmbState.Size = new Size(204, 28);
            cmbState.TabIndex = 0;
            // 
            // grpCreate
            // 
            grpCreate.Controls.Add(btnCreateTrain);
            grpCreate.Controls.Add(rbFreight);
            grpCreate.Controls.Add(rbPassenger);
            grpCreate.Controls.Add(txtDuration);
            grpCreate.Controls.Add(label5);
            grpCreate.Controls.Add(numDistance);
            grpCreate.Controls.Add(label4);
            grpCreate.Controls.Add(txtEnd);
            grpCreate.Controls.Add(label3);
            grpCreate.Controls.Add(txtStart);
            grpCreate.Controls.Add(label2);
            grpCreate.Controls.Add(txtNumber);
            grpCreate.Controls.Add(label1);
            grpCreate.Dock = DockStyle.Top;
            grpCreate.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            grpCreate.Location = new Point(10, 10);
            grpCreate.Name = "grpCreate";
            grpCreate.Size = new Size(308, 266);
            grpCreate.TabIndex = 0;
            grpCreate.TabStop = false;
            grpCreate.Text = "Create New Train";
            // 
            // btnCreateTrain
            // 
            btnCreateTrain.BackColor = Color.SeaGreen;
            btnCreateTrain.FlatAppearance.BorderSize = 0;
            btnCreateTrain.FlatStyle = FlatStyle.Flat;
            btnCreateTrain.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnCreateTrain.ForeColor = Color.White;
            btnCreateTrain.Location = new Point(6, 220);
            btnCreateTrain.Name = "btnCreateTrain";
            btnCreateTrain.Size = new Size(296, 35);
            btnCreateTrain.TabIndex = 12;
            btnCreateTrain.Text = "Create Train";
            btnCreateTrain.UseVisualStyleBackColor = false;
            btnCreateTrain.Click += btnCreateTrain_Click;
            // 
            // rbFreight
            // 
            rbFreight.AutoSize = true;
            rbFreight.Font = new Font("Segoe UI", 9F);
            rbFreight.Location = new Point(125, 190);
            rbFreight.Name = "rbFreight";
            rbFreight.Size = new Size(76, 24);
            rbFreight.TabIndex = 11;
            rbFreight.Text = "Freight";
            rbFreight.UseVisualStyleBackColor = true;
            // 
            // rbPassenger
            // 
            rbPassenger.AutoSize = true;
            rbPassenger.Checked = true;
            rbPassenger.Font = new Font("Segoe UI", 9F);
            rbPassenger.Location = new Point(16, 190);
            rbPassenger.Name = "rbPassenger";
            rbPassenger.Size = new Size(95, 24);
            rbPassenger.TabIndex = 10;
            rbPassenger.TabStop = true;
            rbPassenger.Text = "Passenger";
            rbPassenger.UseVisualStyleBackColor = true;
            // 
            // txtDuration
            // 
            txtDuration.Font = new Font("Segoe UI", 9F);
            txtDuration.Location = new Point(90, 152);
            txtDuration.Name = "txtDuration";
            txtDuration.PlaceholderText = "hh:mm";
            txtDuration.Size = new Size(212, 27);
            txtDuration.TabIndex = 9;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9F);
            label5.Location = new Point(6, 155);
            label5.Name = "label5";
            label5.Size = new Size(70, 20);
            label5.TabIndex = 8;
            label5.Text = "Duration:";
            // 
            // numDistance
            // 
            numDistance.Font = new Font("Segoe UI", 9F);
            numDistance.Location = new Point(90, 119);
            numDistance.Maximum = new decimal(new int[] { 20000, 0, 0, 0 });
            numDistance.Name = "numDistance";
            numDistance.Size = new Size(212, 27);
            numDistance.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F);
            label4.Location = new Point(6, 121);
            label4.Name = "label4";
            label4.Size = new Size(69, 20);
            label4.TabIndex = 6;
            label4.Text = "Distance:";
            // 
            // txtEnd
            // 
            txtEnd.Font = new Font("Segoe UI", 9F);
            txtEnd.Location = new Point(90, 86);
            txtEnd.Name = "txtEnd";
            txtEnd.Size = new Size(212, 27);
            txtEnd.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F);
            label3.Location = new Point(6, 89);
            label3.Name = "label3";
            label3.Size = new Size(37, 20);
            label3.TabIndex = 4;
            label3.Text = "End:";
            // 
            // txtStart
            // 
            txtStart.Font = new Font("Segoe UI", 9F);
            txtStart.Location = new Point(90, 53);
            txtStart.Name = "txtStart";
            txtStart.Size = new Size(212, 27);
            txtStart.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F);
            label2.Location = new Point(6, 56);
            label2.Name = "label2";
            label2.Size = new Size(43, 20);
            label2.TabIndex = 2;
            label2.Text = "Start:";
            // 
            // txtNumber
            // 
            txtNumber.Font = new Font("Segoe UI", 9F);
            txtNumber.Location = new Point(90, 20);
            txtNumber.Name = "txtNumber";
            txtNumber.Size = new Size(212, 27);
            txtNumber.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F);
            label1.Location = new Point(6, 23);
            label1.Name = "label1";
            label1.Size = new Size(66, 20);
            label1.TabIndex = 0;
            label1.Text = "Number:";
            // 
            // AdminForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1182, 703);
            Controls.Add(panelControls);
            Controls.Add(panelContent);
            Controls.Add(panelHeader);
            Controls.Add(panelSidebar);
            MinimumSize = new Size(1200, 750);
            Name = "AdminForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Railway Admin System";
            panelSidebar.ResumeLayout(false);
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelContent.ResumeLayout(false);
            panelContent.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCarriages).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvTrains).EndInit();
            panelControls.ResumeLayout(false);
            grpCarriages.ResumeLayout(false);
            grpCarriages.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numMaxPass).EndInit();
            ((System.ComponentModel.ISupportInitialize)numMinPass).EndInit();
            ((System.ComponentModel.ISupportInitialize)numCarriageIndex).EndInit();
            grpActions.ResumeLayout(false);
            grpCreate.ResumeLayout(false);
            grpCreate.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numDistance).EndInit();
            ResumeLayout(false);
        }

        private Panel panelSidebar;
        private Button btnSave;
        private Button btnLoad;
        private Button btnLogout;
        private Panel panelHeader;
        private Label lblTitle;
        private Panel panelContent;
        private DataGridView dgvTrains;
        private Label lblTrains;
        private DataGridView dgvCarriages;
        private Label lblCarriages;
        private Panel panelControls;
        private GroupBox grpCreate;
        private TextBox txtNumber;
        private Label label1;
        private TextBox txtDuration;
        private Label label5;
        private NumericUpDown numDistance;
        private Label label4;
        private TextBox txtEnd;
        private Label label3;
        private TextBox txtStart;
        private Label label2;
        private Button btnCreateTrain;
        private RadioButton rbFreight;
        private RadioButton rbPassenger;
        private GroupBox grpActions;
        private ComboBox cmbState;
        private Button btnSetState;
        private Button btnCheckOverload;
        private GroupBox grpCarriages;
        private ComboBox cmbCarriageType;
        private Button btnAddCarriage;
        private Button btnRemoveCarriage;
        private NumericUpDown numCarriageIndex;
        private Label label6;
        private Button btnSort;
        private Button btnSearch;
        private NumericUpDown numMaxPass;
        private Label label8;
        private NumericUpDown numMinPass;
        private Label label7;
    }
}