using System;
using System.Windows.Forms;
using RealEstateAgency.Models;
using RealEstateAgency.Services;

namespace RealEstateAgency.Forms
{
    public partial class EmployeeForm : Form
    {
        private readonly EmployeeService _employeeService;
        private Employee _employee;
        private bool _isNew;

        public EmployeeForm(EmployeeService employeeService, Employee? employee = null)
        {
            InitializeComponent();
            _employeeService = employeeService;
            _employee = employee ?? new Employee();
            _isNew = employee == null;
            if (!_isNew)
            {
                PopulateForm();
            }
        }

        private void PopulateForm()
        {
            txtFirstName.Text = _employee.FirstName;
            txtLastName.Text = _employee.LastName;
            txtMiddleName.Text = _employee.MiddleName;
            txtPosition.Text = _employee.Position;
            txtPhone.Text = _employee.Phone;
            txtEmail.Text = _employee.Email;
            dtpHireDate.Value = _employee.HireDate ?? DateTime.Now;
            txtSalary.Text = _employee.Salary?.ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
                return;

            try
            {
                _employee.FirstName = txtFirstName.Text.Trim();
                _employee.LastName = txtLastName.Text.Trim();
                _employee.MiddleName = txtMiddleName.Text.Trim();
                _employee.Position = txtPosition.Text.Trim();
                _employee.Phone = txtPhone.Text.Trim();
                _employee.Email = txtEmail.Text.Trim();
                _employee.HireDate = dtpHireDate.Value;
                _employee.Salary = string.IsNullOrWhiteSpace(txtSalary.Text) ? null : Convert.ToDecimal(txtSalary.Text);

                if (_isNew)
                {
                    _employeeService.AddEmployee(_employee);
                }
                else
                {
                    _employeeService.UpdateEmployee(_employee);
                }

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка сохранения сотрудника: {ex.Message}", "Ошибка", 
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

            if (string.IsNullOrWhiteSpace(txtPosition.Text))
            {
                MessageBox.Show("Пожалуйста, введите должность", "Предупреждение", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPosition.Focus();
                return false;
            }

            if (!string.IsNullOrWhiteSpace(txtSalary.Text) && !decimal.TryParse(txtSalary.Text, out _))
            {
                MessageBox.Show("Пожалуйста, введите корректное значение зарплаты", "Предупреждение", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSalary.Focus();
                return false;
            }

            return true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void EmployeeForm_Load(object sender, EventArgs e)
        {
            // Настройка формы
        }
    }
}