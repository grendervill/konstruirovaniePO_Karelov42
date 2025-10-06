using System;
using System.Windows.Forms;
using RealEstateAgency.Services;

namespace RealEstateAgency.Forms
{
    public partial class ReportForm : Form
    {
        private readonly DealService _dealService;

        public ReportForm(DealService dealService)
        {
            InitializeComponent();
            _dealService = dealService;
            dtpStartDate.Value = DateTime.Now.AddMonths(-1);
            dtpEndDate.Value = DateTime.Now;
        }

        private void btnGenerateDealsReport_Click(object sender, EventArgs e)
        {
            try
            {
                var startDate = dtpStartDate.Value.Date;
                var endDate = dtpEndDate.Value.Date;
                
                // Проверяем, что даты корректны
                if (startDate > endDate)
                {
                    MessageBox.Show("Дата начала не может быть позже даты окончания", "Предупреждение", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var deals = _dealService.GetDealsByPeriod(startDate, endDate);
                
                if (deals.Count == 0)
                {
                    MessageBox.Show($"За период с {startDate:dd.MM.yyyy} по {endDate:dd.MM.yyyy} сделок не найдено", 
                        "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvReport.DataSource = null; // Очищаем таблицу
                    return;
                }

                dgvReport.DataSource = deals;
                
                // Настройка столбцов DataGridView
                SetupDealsReportColumns();
                
                MessageBox.Show($"Найдено {deals.Count} сделок за период с {startDate:dd.MM.yyyy} по {endDate:dd.MM.yyyy}", 
                    "Результат", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка формирования отчета: {ex.Message}", "Ошибка", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGenerateEmployeeStats_Click(object sender, EventArgs e)
        {
            try
            {
                var startDate = dtpStartDate.Value.Date;
                var endDate = dtpEndDate.Value.Date;
                
                // Проверяем, что даты корректны
                if (startDate > endDate)
                {
                    MessageBox.Show("Дата начала не может быть позже даты окончания", "Предупреждение", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var stats = _dealService.GetEmployeeStatistics(startDate, endDate);
                
                if (stats.Count == 0)
                {
                    MessageBox.Show($"За период с {startDate:dd.MM.yyyy} по {endDate:dd.MM.yyyy} статистика не найдена", 
                        "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvReport.DataSource = null; // Очищаем таблицу
                    return;
                }

                dgvReport.DataSource = stats;
                
                // Настройка столбцов DataGridView
                SetupEmployeeStatsColumns();
                
                MessageBox.Show($"Сформирована статистика по {stats.Count} сотрудникам за период с {startDate:dd.MM.yyyy} по {endDate:dd.MM.yyyy}", 
                    "Результат", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка формирования статистики: {ex.Message}", "Ошибка", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetupDealsReportColumns()
        {
            dgvReport.AutoGenerateColumns = false;
            dgvReport.Columns.Clear();
            
            dgvReport.Columns.Add(new DataGridViewTextBoxColumn() { DataPropertyName = "DealId", HeaderText = "ID Сделки", Name = "DealId" });
            dgvReport.Columns.Add(new DataGridViewTextBoxColumn() { DataPropertyName = "DealDate", HeaderText = "Дата", Name = "DealDate" });
            dgvReport.Columns.Add(new DataGridViewTextBoxColumn() { DataPropertyName = "PropertyAddress", HeaderText = "Объект", Name = "PropertyAddress" });
            dgvReport.Columns.Add(new DataGridViewTextBoxColumn() { DataPropertyName = "ClientName", HeaderText = "Клиент", Name = "ClientName" });
            dgvReport.Columns.Add(new DataGridViewTextBoxColumn() { DataPropertyName = "EmployeeName", HeaderText = "Сотрудник", Name = "EmployeeName" });
            dgvReport.Columns.Add(new DataGridViewTextBoxColumn() { DataPropertyName = "DealType", HeaderText = "Тип", Name = "DealType" });
            dgvReport.Columns.Add(new DataGridViewTextBoxColumn() { DataPropertyName = "Amount", HeaderText = "Сумма", Name = "Amount" });
        }

        private void SetupEmployeeStatsColumns()
        {
            dgvReport.AutoGenerateColumns = false;
            dgvReport.Columns.Clear();
            
            dgvReport.Columns.Add(new DataGridViewTextBoxColumn() { DataPropertyName = "EmployeeName", HeaderText = "Сотрудник", Name = "EmployeeName" });
            dgvReport.Columns.Add(new DataGridViewTextBoxColumn() { DataPropertyName = "DealsCount", HeaderText = "Кол-во сделок", Name = "DealsCount" });
            dgvReport.Columns.Add(new DataGridViewTextBoxColumn() { DataPropertyName = "TotalAmount", HeaderText = "Общая сумма", Name = "TotalAmount" });
            dgvReport.Columns.Add(new DataGridViewTextBoxColumn() { DataPropertyName = "AverageAmount", HeaderText = "Средняя сумма", Name = "AverageAmount" });
        }

        private void ReportForm_Load(object sender, EventArgs e)
        {
            // Настройка DataGridView
            dgvReport.AutoGenerateColumns = false;
        }
    }
}