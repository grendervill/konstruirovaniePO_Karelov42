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
                var deals = _dealService.GetDealsByPeriod(dtpStartDate.Value, dtpEndDate.Value);
                dgvReport.DataSource = deals;
                
                if (deals.Count == 0)
                {
                    MessageBox.Show("За указанный период сделки не найдены", "Информация", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
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
                var stats = _dealService.GetEmployeeStatistics(dtpStartDate.Value, dtpEndDate.Value);
                dgvReport.DataSource = stats;
                
                if (stats.Count == 0)
                {
                    MessageBox.Show("За указанный период статистика не найдена", "Информация", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка формирования статистики: {ex.Message}", "Ошибка", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ReportForm_Load(object sender, EventArgs e)
        {
            // Настройка DataGridView
            dgvReport.AutoGenerateColumns = false;
        }
    }
}