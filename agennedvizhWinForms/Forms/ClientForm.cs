using System;
using System.Windows.Forms;
using RealEstateAgency.Models;
using RealEstateAgency.Services;

namespace RealEstateAgency.Forms
{
    public partial class ClientForm : Form
    {
        private readonly ClientService _clientService;
        private Client _client;
        private bool _isNew;

        public ClientForm(ClientService clientService, Client? client = null)
        {
            InitializeComponent();
            _clientService = clientService;
            _client = client ?? new Client();
            _isNew = client == null;
            if (!_isNew)
            {
                PopulateForm();
            }
        }

        private void PopulateForm()
        {
            txtFirstName.Text = _client.FirstName;
            txtLastName.Text = _client.LastName;
            txtMiddleName.Text = _client.MiddleName;
            txtPhone.Text = _client.Phone;
            txtEmail.Text = _client.Email;
            txtPassportSeries.Text = _client.PassportSeries;
            txtPassportNumber.Text = _client.PassportNumber;
            txtRegistrationAddress.Text = _client.RegistrationAddress;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
                return;

            try
            {
                _client.FirstName = txtFirstName.Text.Trim();
                _client.LastName = txtLastName.Text.Trim();
                _client.MiddleName = txtMiddleName.Text.Trim();
                _client.Phone = txtPhone.Text.Trim();
                _client.Email = txtEmail.Text.Trim();
                _client.PassportSeries = txtPassportSeries.Text.Trim();
                _client.PassportNumber = txtPassportNumber.Text.Trim();
                _client.RegistrationAddress = txtRegistrationAddress.Text.Trim();

                if (_isNew)
                {
                    _clientService.AddClient(_client);
                }
                else
                {
                    _clientService.UpdateClient(_client);
                }

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка сохранения клиента: {ex.Message}", "Ошибка", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtFirstName.Text))
            {
                MessageBox.Show("Пожалуйста, введите имя", "Предупреждение", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtFirstName.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtLastName.Text))
            {
                MessageBox.Show("Пожалуйста, введите фамилию", "Предупреждение", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLastName.Focus();
                return false;
            }

            return true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void ClientForm_Load(object sender, EventArgs e)
        {
            // Настройка формы
        }
    }
}