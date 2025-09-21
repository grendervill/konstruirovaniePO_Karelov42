namespace RealEstateAgency.Forms
{
    partial class ReportForm
    {
        private System.ComponentModel.IContainer components = null;
        private DateTimePicker dtpStartDate;
        private DateTimePicker dtpEndDate;
        private Button btnGenerateDealsReport;
        private Button btnGenerateEmployeeStats;
        private DataGridView dgvReport;
        private Label label1;
        private Label label2;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dtpStartDate = new DateTimePicker();
            this.dtpEndDate = new DateTimePicker();
            this.btnGenerateDealsReport = new Button();
            this.btnGenerateEmployeeStats = new Button();
            this.dgvReport = new DataGridView();
            this.label1 = new Label();
            this.label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReport)).BeginInit();
            this.SuspendLayout();
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.Location = new System.Drawing.Point(80, 12);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(200, 23);
            this.dtpStartDate.TabIndex = 0;
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.Location = new System.Drawing.Point(320, 12);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(200, 23);
            this.dtpEndDate.TabIndex = 1;
            // 
            // btnGenerateDealsReport
            // 
            this.btnGenerateDealsReport.Location = new System.Drawing.Point(540, 12);
            this.btnGenerateDealsReport.Name = "btnGenerateDealsReport";
            this.btnGenerateDealsReport.Size = new System.Drawing.Size(150, 30);
            this.btnGenerateDealsReport.TabIndex = 2;
            this.btnGenerateDealsReport.Text = "Отчет по сделкам";
            this.btnGenerateDealsReport.UseVisualStyleBackColor = true;
            this.btnGenerateDealsReport.Click += new System.EventHandler(this.btnGenerateDealsReport_Click);
            // 
            // btnGenerateEmployeeStats
            // 
            this.btnGenerateEmployeeStats.Location = new System.Drawing.Point(700, 12);
            this.btnGenerateEmployeeStats.Name = "btnGenerateEmployeeStats";
            this.btnGenerateEmployeeStats.Size = new System.Drawing.Size(180, 30);
            this.btnGenerateEmployeeStats.TabIndex = 3;
            this.btnGenerateEmployeeStats.Text = "Статистика сотрудников";
            this.btnGenerateEmployeeStats.UseVisualStyleBackColor = true;
            this.btnGenerateEmployeeStats.Click += new System.EventHandler(this.btnGenerateEmployeeStats_Click);
            // 
            // dgvReport
            // 
            this.dgvReport.AllowUserToAddRows = false;
            this.dgvReport.AllowUserToDeleteRows = false;
            this.dgvReport.Anchor = ((AnchorStyles)((((AnchorStyles.Top | AnchorStyles.Bottom) 
            | AnchorStyles.Left) 
            | AnchorStyles.Right)));
            this.dgvReport.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReport.Location = new System.Drawing.Point(12, 50);
            this.dgvReport.Name = "dgvReport";
            this.dgvReport.ReadOnly = true;
            this.dgvReport.RowTemplate.Height = 25;
            this.dgvReport.Size = new System.Drawing.Size(960, 500);
            this.dgvReport.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "Период с:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(290, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(22, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "по:";
            // 
            // ReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvReport);
            this.Controls.Add(this.btnGenerateEmployeeStats);
            this.Controls.Add(this.btnGenerateDealsReport);
            this.Controls.Add(this.dtpEndDate);
            this.Controls.Add(this.dtpStartDate);
            this.Name = "ReportForm";
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Отчеты";
            this.Load += new System.EventHandler(this.ReportForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvReport)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}