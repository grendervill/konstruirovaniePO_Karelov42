using System;
using System.Windows.Forms;
using RealEstateAgency.Services;
using RealEstateAgency.Models;

namespace RealEstateAgency.Forms
{
    public partial class MainForm : Form
    {
        private readonly DatabaseService _dbService;
        private readonly PropertyService _propertyService;
        private readonly ClientService _clientService;
        private readonly DealService _dealService;
        private readonly BookingService _bookingService;
        private readonly RentalService _rentalService;

        public MainForm()
        {
            InitializeComponent();
            _dbService = new DatabaseService();
            _propertyService = new PropertyService(_dbService);
            _clientService = new ClientService(_dbService);
            _dealService = new DealService(_dbService);
            _bookingService = new BookingService(_dbService);
            _rentalService = new RentalService(_dbService);
            LoadData();
        }

        private void LoadData()
        {
            LoadProperties();
            LoadClients();
            LoadDeals();
            LoadBookings();
        }

        private void LoadProperties()
        {
            try
            {
                var properties = _propertyService.GetAllProperties();
                dgvProperties.DataSource = properties;
                lblPropertiesCount.Text = $"Всего объектов: {properties.Count}";
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
                dgvClients.DataSource = clients;
                lblClientsCount.Text = $"Всего клиентов: {clients.Count}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки клиентов: {ex.Message}", "Ошибка", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadDeals()
        {
            try
            {
                var deals = _dealService.GetAllDeals();
                dgvDeals.DataSource = deals;
                lblDealsCount.Text = $"Всего сделок: {deals.Count}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки сделок: {ex.Message}", "Ошибка", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadBookings()
        {
            try
            {
                var bookings = _bookingService.GetAllBookings();
                dgvBookings.DataSource = bookings;
                lblBookingsCount.Text = $"Всего бронирований: {bookings.Count}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки бронирований: {ex.Message}", "Ошибка", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddProperty_Click(object sender, EventArgs e)
        {
            var propertyForm = new PropertyForm(_propertyService);
            if (propertyForm.ShowDialog() == DialogResult.OK)
            {
                LoadProperties();
            }
        }

        private void btnEditProperty_Click(object sender, EventArgs e)
        {
            if (dgvProperties.SelectedRows.Count > 0)
            {
                var selectedProperty = (Property)dgvProperties.SelectedRows[0].DataBoundItem;
                var propertyForm = new PropertyForm(_propertyService, selectedProperty);
                if (propertyForm.ShowDialog() == DialogResult.OK)
                {
                    LoadProperties();
                }
            }
            else
            {
                MessageBox.Show("Выберите объект недвижимости для редактирования", "Предупреждение", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDeleteProperty_Click(object sender, EventArgs e)
        {
            if (dgvProperties.SelectedRows.Count > 0)
            {
                var result = MessageBox.Show("Вы уверены, что хотите удалить выбранный объект недвижимости?", 
                    "Подтверждение удаления", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        var selectedProperty = (Property)dgvProperties.SelectedRows[0].DataBoundItem;
                        _propertyService.DeleteProperty(selectedProperty.Id);
                        LoadProperties();
                        MessageBox.Show("Объект недвижимости успешно удален", "Успех", 
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка удаления объекта недвижимости: {ex.Message}", "Ошибка", 
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Выберите объект недвижимости для удаления", "Предупреждение", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnAddClient_Click(object sender, EventArgs e)
        {
            var clientForm = new ClientForm(_clientService);
            if (clientForm.ShowDialog() == DialogResult.OK)
            {
                LoadClients();
            }
        }

        private void btnEditClient_Click(object sender, EventArgs e)
        {
            if (dgvClients.SelectedRows.Count > 0)
            {
                var selectedClient = (Client)dgvClients.SelectedRows[0].DataBoundItem;
                var clientForm = new ClientForm(_clientService, selectedClient);
                if (clientForm.ShowDialog() == DialogResult.OK)
                {
                    LoadClients();
                }
            }
            else
            {
                MessageBox.Show("Выберите клиента для редактирования", "Предупреждение", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDeleteClient_Click(object sender, EventArgs e)
        {
            if (dgvClients.SelectedRows.Count > 0)
            {
                var result = MessageBox.Show("Вы уверены, что хотите удалить выбранного клиента?", 
                    "Подтверждение удаления", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        var selectedClient = (Client)dgvClients.SelectedRows[0].DataBoundItem;
                        _clientService.DeleteClient(selectedClient.Id);
                        LoadClients();
                        MessageBox.Show("Клиент успешно удален", "Успех", 
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка удаления клиента: {ex.Message}", "Ошибка", 
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Выберите клиента для удаления", "Предупреждение", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnGenerateReport_Click(object sender, EventArgs e)
        {
            var reportForm = new ReportForm(_dealService);
            reportForm.ShowDialog();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnAddBooking_Click(object sender, EventArgs e)
        {
            var bookingForm = new BookingForm(_bookingService, _propertyService, _clientService);
            if (bookingForm.ShowDialog() == DialogResult.OK)
            {
                LoadBookings();
                LoadProperties(); // Обновляем статусы объектов
            }
        }

        private void btnEditBooking_Click(object sender, EventArgs e)
        {
            if (dgvBookings.SelectedRows.Count > 0)
            {
                var selectedBooking = (Booking)dgvBookings.SelectedRows[0].DataBoundItem;
                var bookingForm = new BookingForm(_bookingService, _propertyService, _clientService, selectedBooking);
                if (bookingForm.ShowDialog() == DialogResult.OK)
                {
                    LoadBookings();
                    LoadProperties();
                }
            }
            else
            {
                MessageBox.Show("Выберите бронирование для редактирования", "Предупреждение", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDeleteBooking_Click(object sender, EventArgs e)
        {
            if (dgvBookings.SelectedRows.Count > 0)
            {
                var result = MessageBox.Show("Вы уверены, что хотите удалить выбранное бронирование?", 
                    "Подтверждение удаления", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        var selectedBooking = (Booking)dgvBookings.SelectedRows[0].DataBoundItem;
                        _bookingService.DeleteBooking(selectedBooking.Id);
                        LoadBookings();
                        LoadProperties();
                        MessageBox.Show("Бронирование успешно удалено", "Успех", 
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка удаления бронирования: {ex.Message}", "Ошибка", 
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Выберите бронирование для удаления", "Предупреждение", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCreateRentalDeal_Click(object sender, EventArgs e)
        {
            if (dgvBookings.SelectedRows.Count > 0)
            {
                var selectedBooking = (Booking)dgvBookings.SelectedRows[0].DataBoundItem;
                if (selectedBooking.Status == "active")
                {
                    var rentalDealForm = new RentalDealForm(_rentalService, _propertyService, _clientService, _dealService, selectedBooking);
                    if (rentalDealForm.ShowDialog() == DialogResult.OK)
                    {
                        LoadBookings();
                        LoadDeals();
                        LoadProperties();
                        MessageBox.Show("Сделка аренды успешно создана", "Успех", 
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Нельзя создать сделку из неактивного бронирования", "Предупреждение", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Выберите бронирование для создания сделки", "Предупреждение", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCancelBooking_Click(object sender, EventArgs e)
        {
            if (dgvBookings.SelectedRows.Count > 0)
            {
                var result = MessageBox.Show("Вы уверены, что хотите отменить выбранное бронирование?", 
                    "Подтверждение отмены", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        var selectedBooking = (Booking)dgvBookings.SelectedRows[0].DataBoundItem;
                        selectedBooking.Status = "cancelled";
                        _bookingService.UpdateBooking(selectedBooking);
                        LoadBookings();
                        LoadProperties();
                        MessageBox.Show("Бронирование успешно отменено", "Успех", 
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка отмены бронирования: {ex.Message}", "Ошибка", 
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Выберите бронирование для отмены", "Предупреждение", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Настройка DataGridView для свойств
            dgvProperties.AutoGenerateColumns = false;
            dgvProperties.Columns.Clear();
            dgvProperties.Columns.Add(new DataGridViewTextBoxColumn() { DataPropertyName = "Id", HeaderText = "ID" });
            dgvProperties.Columns.Add(new DataGridViewTextBoxColumn() { DataPropertyName = "PropertyTypeName", HeaderText = "Тип" });
            dgvProperties.Columns.Add(new DataGridViewTextBoxColumn() { DataPropertyName = "StatusName", HeaderText = "Статус" });
            dgvProperties.Columns.Add(new DataGridViewTextBoxColumn() { DataPropertyName = "Address", HeaderText = "Адрес" });
            dgvProperties.Columns.Add(new DataGridViewTextBoxColumn() { DataPropertyName = "City", HeaderText = "Город" });
            dgvProperties.Columns.Add(new DataGridViewTextBoxColumn() { DataPropertyName = "Area", HeaderText = "Площадь" });
            dgvProperties.Columns.Add(new DataGridViewTextBoxColumn() { DataPropertyName = "Price", HeaderText = "Цена" });

            // Настройка DataGridView для клиентов
            dgvClients.AutoGenerateColumns = false;
            dgvClients.Columns.Clear();
            dgvClients.Columns.Add(new DataGridViewTextBoxColumn() { DataPropertyName = "Id", HeaderText = "ID" });
            dgvClients.Columns.Add(new DataGridViewTextBoxColumn() { DataPropertyName = "LastName", HeaderText = "Фамилия" });
            dgvClients.Columns.Add(new DataGridViewTextBoxColumn() { DataPropertyName = "FirstName", HeaderText = "Имя" });
            dgvClients.Columns.Add(new DataGridViewTextBoxColumn() { DataPropertyName = "MiddleName", HeaderText = "Отчество" });
            dgvClients.Columns.Add(new DataGridViewTextBoxColumn() { DataPropertyName = "Phone", HeaderText = "Телефон" });
            dgvClients.Columns.Add(new DataGridViewTextBoxColumn() { DataPropertyName = "Email", HeaderText = "Email" });

            // Настройка DataGridView для сделок
            dgvDeals.AutoGenerateColumns = false;
            dgvDeals.Columns.Clear();
            dgvDeals.Columns.Add(new DataGridViewTextBoxColumn() { DataPropertyName = "Id", HeaderText = "ID" });
            dgvDeals.Columns.Add(new DataGridViewTextBoxColumn() { DataPropertyName = "DealTypeName", HeaderText = "Тип сделки" });
            dgvDeals.Columns.Add(new DataGridViewTextBoxColumn() { DataPropertyName = "PropertyAddress", HeaderText = "Объект" });
            dgvDeals.Columns.Add(new DataGridViewTextBoxColumn() { DataPropertyName = "ClientName", HeaderText = "Клиент" });
            dgvDeals.Columns.Add(new DataGridViewTextBoxColumn() { DataPropertyName = "EmployeeName", HeaderText = "Сотрудник" });
            dgvDeals.Columns.Add(new DataGridViewTextBoxColumn() { DataPropertyName = "DealDate", HeaderText = "Дата" });
            dgvDeals.Columns.Add(new DataGridViewTextBoxColumn() { DataPropertyName = "Amount", HeaderText = "Сумма" });

            // Настройка DataGridView для бронирований
            dgvBookings.AutoGenerateColumns = false;
            dgvBookings.Columns.Clear();
            dgvBookings.Columns.Add(new DataGridViewTextBoxColumn() { DataPropertyName = "Id", HeaderText = "ID" });
            dgvBookings.Columns.Add(new DataGridViewTextBoxColumn() { DataPropertyName = "PropertyAddress", HeaderText = "Объект" });
            dgvBookings.Columns.Add(new DataGridViewTextBoxColumn() { DataPropertyName = "ClientName", HeaderText = "Клиент" });
            dgvBookings.Columns.Add(new DataGridViewTextBoxColumn() { DataPropertyName = "EmployeeName", HeaderText = "Сотрудник" });
            dgvBookings.Columns.Add(new DataGridViewTextBoxColumn() { DataPropertyName = "BookingDate", HeaderText = "Дата брони" });
            dgvBookings.Columns.Add(new DataGridViewTextBoxColumn() { DataPropertyName = "StartDate", HeaderText = "Начало" });
            dgvBookings.Columns.Add(new DataGridViewTextBoxColumn() { DataPropertyName = "EndDate", HeaderText = "Окончание" });
            dgvBookings.Columns.Add(new DataGridViewTextBoxColumn() { DataPropertyName = "Status", HeaderText = "Статус" });
            dgvBookings.Columns.Add(new DataGridViewTextBoxColumn() { DataPropertyName = "Amount", HeaderText = "Сумма" });
        }
    }
}