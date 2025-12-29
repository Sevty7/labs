using lab6.Entities;
using lab6.Entities.Carriages;
using lab6.Entities.Carriages.FreightCarriages;
using lab6.Entities.Carriages.PassengerCarriages;
using lab6.Entities.Trains;
using lab6.Services;
using static lab6.Entities.Trains.Train;

namespace lab6.Forms
{
    public partial class AdminForm : Form
    {
        private RailwaySystem _system;
        public AdminForm(RailwaySystem system)
        {
            InitializeComponent();
            _system = system;
            SetupUI();
            RefreshTrainList();
        }

        private void SetupUI()
        {
            dgvTrains.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTrains.MultiSelect = false;
            dgvTrains.AutoGenerateColumns = false;

            dgvTrains.Columns.Add("Number", "Number");
            dgvTrains.Columns.Add("Type", "Type");
            dgvTrains.Columns.Add("Route", "Route");
            dgvTrains.Columns.Add("State", "State");
            dgvTrains.Columns.Add("Count", "Carriages");

            dgvCarriages.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCarriages.MultiSelect = false;
            dgvCarriages.AutoGenerateColumns = false;

            dgvCarriages.Columns.Add("Index", "Index");
            dgvCarriages.Columns.Add("Type", "Type");
            dgvCarriages.Columns.Add("Load", "Load/Pass");
            dgvCarriages.Columns.Add("Comfort", "Comfort");

            dgvTrains.SelectionChanged += DgvTrains_SelectionChanged;

            cmbState.DataSource = Enum.GetValues(typeof(TrainState));

            cmbCarriageType.Items.AddRange(new string[] {
                "Coupe", "Econom", "Dining", "Hopper", "Tank"
            });
            cmbCarriageType.SelectedIndex = 0;
        }

        private void DgvTrains_SelectionChanged(object sender, EventArgs e)
        {
            RefreshCarriageList();
        }

        private void RefreshTrainList()
        {
            dgvTrains.Rows.Clear();
            var trains = _system.GetAllTrains();
            foreach (var train in trains)
            {
                string type = train is PassengerTrain ? "Passenger" : "Freight";
                dgvTrains.Rows.Add(
                    train.TrainNumber,
                    type,
                    train.Route.ToString(),
                    train.State,
                    train.Carriages.Count
                );
            }
            RefreshCarriageList();
        }

        private void RefreshCarriageList()
        {
            dgvCarriages.Rows.Clear();
            string number = GetSelectedTrainNumber();
            if (number == null) return;

            try
            {
                var train = _system.GetTrainByNumber(number);
                int index = 0;
                foreach (var c in train.Carriages)
                {
                    string loadInfo = "0";
                    if (c is IPassengerCarriage pc)
                        loadInfo = $"{c.Passengers} / {pc.TotalSeats} seats";
                    else if (c is DiningCarriage dc)
                        loadInfo = $"{dc.Tables} tables";
                    else if (c is IFreightCarriage fc)
                        loadInfo = $"{fc.CurrentLoad} / {c.LoadCapacity} tons";

                    dgvCarriages.Rows.Add(index++, c.GetType().Name, loadInfo, c.Comfort);
                }
            }
            catch { }
        }

        private string GetSelectedTrainNumber()
        {
            if (dgvTrains.SelectedRows.Count == 0) return null;
            return dgvTrains.SelectedRows[0].Cells["Number"].Value.ToString();
        }

        private void btnCreateTrain_Click(object sender, EventArgs e)
        {
            try
            {
                string number = txtNumber.Text;
                string start = txtStart.Text;
                string end = txtEnd.Text;
                double dist = (double)numDistance.Value;

                if (!TimeSpan.TryParse(txtDuration.Text, out TimeSpan duration))
                {
                    MessageBox.Show("Invalid duration format (use hh:mm)");
                    return;
                }

                Route route = new Route(start, end, dist, duration);
                bool isPassenger = rbPassenger.Checked;

                _system.CreateTrain(number, route, isPassenger);
                RefreshTrainList();
                MessageBox.Show("Train created successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void btnAddCarriage_Click(object sender, EventArgs e)
        {
            string number = GetSelectedTrainNumber();
            if (number == null)
            {
                MessageBox.Show("Select a train first");
                return;
            }

            string type = cmbCarriageType.SelectedItem.ToString();
            Carriage carriage = null;

            switch (type)
            {
                case "Coupe": carriage = new CoupeCarriage(); break;
                case "Econom": carriage = new EconomCarriage(); break;
                case "Dining": carriage = new DiningCarriage(); break;
                case "Hopper": carriage = new HopperCarriage(); break;
                case "Tank": carriage = new TankCarriage(); break;
            }

            try
            {
                _system.AddCarriageToTrain(number, carriage);
                RefreshTrainList();
                MessageBox.Show("Carriage added");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void btnRemoveCarriage_Click(object sender, EventArgs e)
        {
            string number = GetSelectedTrainNumber();
            if (number == null)
            {
                MessageBox.Show("Select a train first");
                return;
            }

            int index = (int)numCarriageIndex.Value;
            try
            {
                _system.RemoveCarriageFromTrain(number, index);
                RefreshTrainList();
                MessageBox.Show("Carriage removed");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void btnSetState_Click(object sender, EventArgs e)
        {
            string number = GetSelectedTrainNumber();
            if (number == null)
            {
                MessageBox.Show("Select a train first");
                return;
            }

            TrainState state = (TrainState)cmbState.SelectedItem;
            _system.SetTrainState(number, state);
            RefreshTrainList();
        }

        private void btnCheckOverload_Click(object sender, EventArgs e)
        {
            string number = GetSelectedTrainNumber();
            if (number == null)
            {
                MessageBox.Show("Select a train first");
                return;
            }

            bool isOverloaded = _system.IsTrainOverloaded(number);
            MessageBox.Show($"Is Train Overloaded: {isOverloaded}");
        }

        private void btnSort_Click(object sender, EventArgs e)
        {
            string number = GetSelectedTrainNumber();
            if (number == null)
            {
                MessageBox.Show("Select a train first");
                return;
            }

            try
            {
                _system.SortTrainCarriagesByComfort(number);
                RefreshTrainList();
                MessageBox.Show("Carriages sorted by comfort.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string number = GetSelectedTrainNumber();
            if (number == null)
            {
                MessageBox.Show("Select a train first");
                return;
            }

            int min = (int)numMinPass.Value;
            int max = (int)numMaxPass.Value;

            try
            {
                var result = _system.FindCarriagesByPassengerRange(number, min, max);
                string msg = $"Found {result.Count} carriages:\n";
                foreach (var c in result)
                {
                    msg += $"- {c.GetType().Name}, Pass: {c.Passengers}\n";
                }
                MessageBox.Show(msg);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "XML files|*.xml";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    _system.SaveSystemState(sfd.FileName);
                    MessageBox.Show("Saved successfully");
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "XML files|*.xml";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    _system.LoadTrainsFromXml(ofd.FileName);
                    RefreshTrainList();
                    MessageBox.Show("Loaded successfully");
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}