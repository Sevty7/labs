using System.Data;
using lab6.Entities.Trains;
using lab6.Services;

namespace lab6.Forms
{
    public partial class PassengerForm : Form
    {

        private RailwaySystem _system;

        public PassengerForm(RailwaySystem system)
        {
            InitializeComponent();
            _system = system;
            SetupUI();
            RefreshTrains();
        }

        private void SetupUI()
        {
            dgvTrains.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTrains.MultiSelect = false;
            dgvTrains.AutoGenerateColumns = false;

            dgvTrains.Columns.Add("Number", "Train Number");
            dgvTrains.Columns.Add("Route", "Route");
            dgvTrains.Columns.Add("State", "State");

            dgvTrains.Columns["Number"].DataPropertyName = "TrainNumber";
            dgvTrains.Columns["Route"].DataPropertyName = "Route";
            dgvTrains.Columns["State"].DataPropertyName = "State";

            cmbCarriageType.Items.Add("Coupe");
            cmbCarriageType.Items.Add("Econom");
            cmbCarriageType.SelectedIndex = 0;

            dgvMenu.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMenu.MultiSelect = false;
            dgvMenu.AutoGenerateColumns = true;
        }

        private void RefreshTrains()
        {
            dgvTrains.Rows.Clear();
            cmbDiningTrains.Items.Clear();

            var trains = _system.GetAvailableTrains();

            foreach (var train in trains)
            {
                dgvTrains.Rows.Add(train.TrainNumber, train.Route.ToString(), train.State);
            }

            var allTrains = _system.GetAllTrains();
            foreach (var train in allTrains)
            {
                if (train is PassengerTrain)
                {
                    cmbDiningTrains.Items.Add(train.TrainNumber);
                }
            }
        }

        private void btnReserve_Click(object sender, EventArgs e)
        {
            if (dgvTrains.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a train.");
                return;
            }

            string trainNumber = dgvTrains.SelectedRows[0].Cells["Number"].Value.ToString();
            string carriageType = cmbCarriageType.Text;

            try
            {
                var train = _system.GetTrainByNumber(trainNumber);
                _system.ReserveTicket(train, carriageType);
                MessageBox.Show($"Ticket reserved successfully for {carriageType} carriage.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Reservation failed: {ex.Message}");
            }
        }

        private void cmbDiningTrains_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbDiningTrains.SelectedItem == null) return;

            string trainNumber = cmbDiningTrains.SelectedItem.ToString();
            var menu = _system.GetDiningMenu(trainNumber);

            dgvMenu.DataSource = menu.Select(x => new { Item = x.Key, Price = x.Value }).ToList();
        }

        private void btnOrderFood_Click(object sender, EventArgs e)
        {
            if (cmbDiningTrains.SelectedItem == null)
            {
                MessageBox.Show("Select a train first.");
                return;
            }
            if (dgvMenu.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select an item from the menu.");
                return;
            }

            string trainNumber = cmbDiningTrains.SelectedItem.ToString();
            string item = dgvMenu.SelectedRows[0].Cells[0].Value.ToString();

            try
            {
                _system.OrderFood(trainNumber, item);
                MessageBox.Show($"Ordered {item} successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Order failed: {ex.Message}");
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshTrains();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
