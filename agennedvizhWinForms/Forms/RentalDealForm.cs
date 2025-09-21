using System;
using System.Windows.Forms;
using RealEstateAgency.Models;
using RealEstateAgency.Services;

namespace RealEstateAgency.Forms
{
    public partial class RentalDealForm : Form
    {
        private readonly RentalService _rentalService;
        private readonly PropertyService _propertyService;
        private readonly ClientService _clientService;
        private readonly DealService _dealService;
        private Booking _booking;

        public RentalDealForm(RentalService rentalService, PropertyService propertyService, 
                             ClientService clientService, DealService dealService, Booking booking)
        {
            InitializeComponent();
            _rentalService = rentalService;
            _propertyService = propertyService;
            _clientService = clientService;
            _dealService = dealService;
            _booking = booking;
            PopulateForm();
        }

        private void PopulateForm()
        {
            txtProperty.Text = _booking.PropertyAddress;
            txtClient.Text = _booking.ClientName;
            txtEmployee.Text = _booking.EmployeeName;
            dtpStartDate.Value = _booking.StartDate;
            dtpEndDate.Value = _booking.EndDate ?? DateTime.Now.AddMonths(1);
            chkIndefinite.Checked = _booking.EndDate == null;
            txtAmount.Text = _booking.Amount?.ToString();
            txtNotes.Text = _booking.Notes;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
                return;

            try
            {
                var deal = new Deal
                {
                    DealTypeId = 2, // Аренда (предполагаем, что ID = 2)
                    PropertyId = _booking.PropertyId,
                    ClientId = _booking.ClientId,
                    EmployeeId = _booking.EmployeeId,
                    DealDate = DateTime.Now,
                    Amount = string.IsNullOrWhiteSpace(txtAmount.Text) ? 0 : Convert.ToDecimal(txtAmount.Text),
                    Commission = string.IsNullOrWhiteSpace(txtAmount.Text) ? null : Convert.ToDecimal(txtAmount.Text) * 0.03m,
                    ContractNumber = GenerateContractNumber(),
                    Notes = txtNotes.Text.Trim()
                };

                var startDate = dtpStartDate.Value;
                var endDate = chkIndefinite.Checked ? (DateTime?)null : dtpEndDate.Value;

                _rentalService.CreateRentalDeal(deal, startDate, endDate);

                // Обновить статус бронирования
                _booking.Status = "completed";
                var bookingService = new BookingService(new DatabaseService());
                bookingService.UpdateBooking(_booking);

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка создания сделки аренды: {ex.Message}", "Ошибка", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GenerateContractNumber()
        {
            return $"RNT-{DateTime.Now:yyyyMMdd}-{new Random().Next(1000, 9999)}";
        }

        private bool ValidateInput()
        {
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

        private void RentalDealForm_Load(object sender, EventArgs e)
        {
            dtpEndDate.Enabled = !chkIndefinite.Checked;
        }
    }
}