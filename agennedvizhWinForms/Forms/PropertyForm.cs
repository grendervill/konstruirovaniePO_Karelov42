using System;
using System.Windows.Forms;
using RealEstateAgency.Models;
using RealEstateAgency.Services;

namespace RealEstateAgency.Forms
{
    public partial class PropertyForm : Form
    {
        private readonly PropertyService _propertyService;
        private Property _property;
        private bool _isNew;

        public PropertyForm(PropertyService propertyService, Property? property = null)
        {
            InitializeComponent();
            _propertyService = propertyService;
            _property = property ?? new Property();
            _isNew = property == null;
            LoadPropertyTypes();
            LoadPropertyStatuses();
            if (!_isNew)
            {
                PopulateForm();
            }
        }

        private void LoadPropertyTypes()
        {
            try
            {
                var dbService = new DatabaseService();
                var query = "SELECT id, name FROM property_types ORDER BY name";
                var types = dbService.ExecuteQueryDisconnected(query);
                cmbPropertyType.DataSource = types;
                cmbPropertyType.DisplayMember = "name";
                cmbPropertyType.ValueMember = "id";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки типов недвижимости: {ex.Message}", "Ошибка", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadPropertyStatuses()
        {
            try
            {
                var dbService = new DatabaseService();
                var query = "SELECT id, name FROM property_statuses ORDER BY name";
                var statuses = dbService.ExecuteQueryDisconnected(query);
                cmbStatus.DataSource = statuses;
                cmbStatus.DisplayMember = "name";
                cmbStatus.ValueMember = "id";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки статусов: {ex.Message}", "Ошибка", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PopulateForm()
        {
            txtAddress.Text = _property.Address;
            txtCity.Text = _property.City;
            txtArea.Text = _property.Area?.ToString();
            txtRooms.Text = _property.Rooms?.ToString();
            txtFloor.Text = _property.Floor?.ToString();
            txtTotalFloors.Text = _property.TotalFloors?.ToString();
            txtPrice.Text = _property.Price?.ToString();
            txtDescription.Text = _property.Description;
            
            if (cmbPropertyType.Items.Count > 0 && _property.PropertyTypeId > 0)
            {
                for (int i = 0; i < cmbPropertyType.Items.Count; i++)
                {
                    var row = ((System.Data.DataRowView)cmbPropertyType.Items[i]).Row;
                    if (Convert.ToInt32(row["id"]) == _property.PropertyTypeId)
                    {
                        cmbPropertyType.SelectedIndex = i;
                        break;
                    }
                }
            }
            
            if (cmbStatus.Items.Count > 0 && _property.StatusId > 0)
            {
                for (int i = 0; i < cmbStatus.Items.Count; i++)
                {
                    var row = ((System.Data.DataRowView)cmbStatus.Items[i]).Row;
                    if (Convert.ToInt32(row["id"]) == _property.StatusId)
                    {
                        cmbStatus.SelectedIndex = i;
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
                _property.Address = txtAddress.Text.Trim();
                _property.City = txtCity.Text.Trim();
                _property.PropertyTypeId = cmbPropertyType.SelectedItem != null ? 
                    Convert.ToInt32(((System.Data.DataRowView)cmbPropertyType.SelectedItem)["id"]) : 1;
                _property.StatusId = cmbStatus.SelectedItem != null ? 
                    Convert.ToInt32(((System.Data.DataRowView)cmbStatus.SelectedItem)["id"]) : 1;
                _property.Area = string.IsNullOrWhiteSpace(txtArea.Text) ? null : Convert.ToDecimal(txtArea.Text);
                _property.Rooms = string.IsNullOrWhiteSpace(txtRooms.Text) ? null : Convert.ToInt32(txtRooms.Text);
                _property.Floor = string.IsNullOrWhiteSpace(txtFloor.Text) ? null : Convert.ToInt32(txtFloor.Text);
                _property.TotalFloors = string.IsNullOrWhiteSpace(txtTotalFloors.Text) ? null : Convert.ToInt32(txtTotalFloors.Text);
                _property.Price = string.IsNullOrWhiteSpace(txtPrice.Text) ? null : Convert.ToDecimal(txtPrice.Text);
                _property.Description = txtDescription.Text.Trim();

                if (_isNew)
                {
                    _propertyService.AddProperty(_property);
                }
                else
                {
                    _propertyService.UpdateProperty(_property);
                }

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка сохранения объекта недвижимости: {ex.Message}", "Ошибка", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtAddress.Text))
            {
                MessageBox.Show("Пожалуйста, введите адрес", "Предупреждение", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAddress.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtCity.Text))
            {
                MessageBox.Show("Пожалуйста, введите город", "Предупреждение", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCity.Focus();
                return false;
            }

            if (cmbPropertyType.SelectedIndex == -1)
            {
                MessageBox.Show("Пожалуйста, выберите тип недвижимости", "Предупреждение", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbPropertyType.Focus();
                return false;
            }

            if (cmbStatus.SelectedIndex == -1)
            {
                MessageBox.Show("Пожалуйста, выберите статус", "Предупреждение", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbStatus.Focus();
                return false;
            }

            if (!string.IsNullOrWhiteSpace(txtArea.Text) && !decimal.TryParse(txtArea.Text, out _))
            {
                MessageBox.Show("Пожалуйста, введите корректное значение площади", "Предупреждение", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtArea.Focus();
                return false;
            }

            if (!string.IsNullOrWhiteSpace(txtPrice.Text) && !decimal.TryParse(txtPrice.Text, out _))
            {
                MessageBox.Show("Пожалуйста, введите корректное значение цены", "Предупреждение", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPrice.Focus();
                return false;
            }

            return true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void PropertyForm_Load(object sender, EventArgs e)
        {
            // Настройка формы
        }
    }
}