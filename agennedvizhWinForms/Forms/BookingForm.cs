using System;
using System.Windows.Forms;
using RealEstateAgency.Models;
using RealEstateAgency.Services;

namespace RealEstateAgency.Forms
{
    public partial class BookingForm : Form
    {
        private readonly BookingService _bookingService;
        private readonly PropertyService _propertyService;
        private readonly ClientService _clientService;
        private Booking _booking;
        private bool _isNew;

        public BookingForm(BookingService bookingService, PropertyService propertyService, ClientService clientService, Booking? booking = null)
        {
            InitializeComponent();
            _bookingService = bookingService;
            _propertyService = propertyService;
            _clientService = clientService;
            _booking = booking ?? new Booking();
            _isNew = booking == null;
            
            LoadProperties();
            LoadClients();
            LoadEmployees();
            
            if (!_isNew)
            {
                PopulateForm();
            }
            else
            {
                dtpBookingDate.Value = DateTime.Now;
                dtpStartDate.Value = DateTime.Now;
            }
        }

        private void LoadProperties()
        {
            try
            {
                var availableProperties = _bookingService.GetAvailableProperties(DateTime.Now);
                cmbProperty.DataSource = availableProperties;
                cmbProperty.DisplayMember = "Address";
                cmbProperty.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки объектов недвижимости: {ex.Message}", "Ошибка", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadClients()
        {
            try
            {
                var clients = _clientService.GetAllClients();
                cmbClient.DataSource = clients;
                cmbClient.DisplayMember = "FullName";
                cmbClient.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки клиентов: {ex.Message}", "Ошибка", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadEmployees()
        {
            try
            {
                var dbService = new DatabaseService();
                var query = "SELECT id, CONCAT(last_name, ' ', first_name, ' ', COALESCE(middle_name, '')) as fullname FROM employees ORDER BY last_name";
                var employees = dbService.ExecuteQueryDisconnected(query);
                cmbEmployee.DataSource = employees;
                cmbEmployee.DisplayMember = "fullname";
                cmbEmployee.ValueMember = "id";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки сотрудников: {ex.Message}", "Ошибка", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PopulateForm()
        {
            dtpBookingDate.Value = _booking.BookingDate;
            dtpStartDate.Value = _booking.StartDate;
            dtpEndDate.Value = _booking.EndDate ?? DateTime.Now.AddMonths(1);
            chkIndefinite.Checked = _booking.EndDate == null;
            txtAmount.Text = _booking.Amount?.ToString();
            txtNotes.Text = _booking.Notes;
            
            // Установка выбранных значений
            if (cmbProperty.Items.Count > 0)
            {
                for (int i = 0; i < cmbProperty.Items.Count; i++)
                {
                    var item = (Property)cmbProperty.Items[i];
                    if (item.Id == _booking.PropertyId)
                    {
                        cmbProperty.SelectedIndex = i;
                        break;
                    }
                }
            }
            
            if (cmbClient.Items.Count > 0)
            {
                for (int i = 0; i < cmbClient.Items.Count; i++)
                {
                    var item = (Client)cmbClient.Items[i];
                    if (item.Id == _booking.ClientId)
                    {
                        cmbClient.SelectedIndex = i;
                        break;
                    }
                }
            }
            
            if (cmbEmployee.Items.Count > 0)
            {
                for (int i = 0; i < cmbEmployee.Items.Count; i++)
                {
                    var row = ((System.Data.DataRowView)cmbEmployee.Items[i]).Row;
                    if (Convert.ToInt32(row["id"]) == _booking.EmployeeId)
                    {
                        cmbEmployee.SelectedIndex = i;
                        break;
                    }
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
                return;

            try
            {
                _booking.PropertyId = cmbProperty.SelectedItem != null ? 
                    Convert.ToInt32(((Property)cmbProperty.SelectedItem).Id) : 0;
                _booking.ClientId = cmbClient.SelectedItem != null ? 
                    Convert.ToInt32(((Client)cmbClient.SelectedItem).Id) : 0;
                _booking.EmployeeId = cmbEmployee.SelectedItem != null ? 
                    Convert.ToInt32(((System.Data.DataRowView)cmbEmployee.SelectedItem)["id"]) : 0;
                _booking.BookingDate = dtpBookingDate.Value;
                _booking.StartDate = dtpStartDate.Value;
                _booking.EndDate = chkIndefinite.Checked ? null : dtpEndDate.Value;
                _booking.Amount = string.IsNullOrWhiteSpace(txtAmount.Text) ? null : Convert.ToDecimal(txtAmount.Text);
                _booking.Notes = txtNotes.Text.Trim();
                _booking.Status = "active";

                if (_isNew)
                {
                    _bookingService.AddBooking(_booking);
                }
                else
                {
                    _bookingService.UpdateBooking(_booking);
                }

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка сохранения бронирования: {ex.Message}", "Ошибка", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateInput()
        {
            if (cmbProperty.SelectedIndex == -1)
            {
                MessageBox.Show("Пожалуйста, выберите объект недвижимости", "Предупреждение", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbProperty.Focus();
                return false;
            }

            if (cmbClient.SelectedIndex == -1)
            {
                MessageBox.Show("Пожалуйста, выберите клиента", "Предупреждение", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbClient.Focus();
                return false;
            }

            if (cmbEmployee.SelectedIndex == -1)
            {
                MessageBox.Show("Пожалуйста, выберите сотрудника", "Предупреждение", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbEmployee.Focus();
                return false;
            }

            if (dtpStartDate.Value > dtpEndDate.Value && !chkIndefinite.Checked)
            {
                MessageBox.Show("Дата начала не может быть позже даты окончания", "Предупреждение", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpStartDate.Focus();
                return false;
            }

            if (!string.IsNullOrWhiteSpace(txtAmount.Text) && !decimal.TryParse(txtAmount.Text, out _))
            {
                MessageBox.Show("Пожалуйста, введите корректное значение суммы", "Предупреждение", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAmount.Focus();
                return false;
            }

            return true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void chkIndefinite_CheckedChanged(object sender, EventArgs e)
        {
            dtpEndDate.Enabled = !chkIndefinite.Checked;
        }

        private void BookingForm_Load(object sender, EventArgs e)
        {
            dtpEndDate.Enabled = !chkIndefinite.Checked;
        }
    }
}