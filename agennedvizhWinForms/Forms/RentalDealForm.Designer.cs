namespace RealEstateAgency.Forms
{
    partial class RentalDealForm
    {
        private System.ComponentModel.IContainer components = null;
        private TextBox txtProperty;
        private TextBox txtClient;
        private TextBox txtEmployee;
        private DateTimePicker dtpStartDate;
        private DateTimePicker dtpEndDate;
        private CheckBox chkIndefinite;
        private TextBox txtAmount;
        private TextBox txtNotes;
        private Button btnSave;
        private Button btnCancel;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;

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
            this.label1 = new Label();
            this.txtProperty = new TextBox();
            this.label2 = new Label();
            this.txtClient = new TextBox();
            this.label3 = new Label();
            this.txtEmployee = new TextBox();
            this.label4 = new Label();
            this.dtpStartDate = new DateTimePicker();
            this.label5 = new Label();
            this.dtpEndDate = new DateTimePicker();
            this.chkIndefinite = new CheckBox();
            this.label6 = new Label();
            this.txtAmount = new TextBox();
            this.label7 = new Label();
            this.txtNotes = new TextBox();
            this.btnSave = new Button();
            this.btnCancel = new Button();
            this.label8 = new Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Объект недвижимости:";
            // 
            // txtProperty
            // 
            this.txtProperty.Location = new System.Drawing.Point(150, 12);
            this.txtProperty.Name = "txtProperty";
            this.txtProperty.ReadOnly = true;
            this.txtProperty.Size = new System.Drawing.Size(300, 23);
            this.txtProperty.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Клиент:";
            // 
            // txtClient
            // 
            this.txtClient.Location = new System.Drawing.Point(150, 41);
            this.txtClient.Name = "txtClient";
            this.txtClient.ReadOnly = true;
            this.txtClient.Size = new System.Drawing.Size(300, 23);
            this.txtClient.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Сотрудник:";
            // 
            // txtEmployee
            // 
            this.txtEmployee.Location = new System.Drawing.Point(150, 70);
            this.txtEmployee.Name = "txtEmployee";
            this.txtEmployee.ReadOnly = true;
            this.txtEmployee.Size = new System.Drawing.Size(300, 23);
            this.txtEmployee.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 102);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 15);
            this.label4.TabIndex = 6;
            this.label4.Text = "Дата начала:";
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.Location = new System.Drawing.Point(150, 99);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(200, 23);
            this.dtpStartDate.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 131);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 15);
            this.label5.TabIndex = 8;
            this.label5.Text = "Дата оконч.:";
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.Location = new System.Drawing.Point(150, 128);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(200, 23);
            this.dtpEndDate.TabIndex = 9;
            // 
            // chkIndefinite
            // 
            this.chkIndefinite.AutoSize = true;
            this.chkIndefinite.Location = new System.Drawing.Point(360, 130);
            this.chkIndefinite.Name = "chkIndefinite";
            this.chkIndefinite.Size = new System.Drawing.Size(90, 19);
            this.chkIndefinite.TabIndex = 10;
            this.chkIndefinite.Text = "Бессрочно";
            this.chkIndefinite.UseVisualStyleBackColor = true;
            this.chkIndefinite.CheckedChanged += new System.EventHandler(this.chkIndefinite_CheckedChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 160);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 15);
            this.label6.TabIndex = 11;
            this.label6.Text = "Сумма:";
            // 
            // txtAmount
            // 
            this.txtAmount.Location = new System.Drawing.Point(150, 157);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(200, 23);
            this.txtAmount.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 189);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(88, 15);
            this.label7.TabIndex = 13;
            this.label7.Text = "Примечания:";
            // 
            // txtNotes
            // 
            this.txtNotes.Location = new System.Drawing.Point(150, 186);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.ScrollBars = ScrollBars.Vertical;
            this.txtNotes.Size = new System.Drawing.Size(300, 80);
            this.txtNotes.TabIndex = 14;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(150, 280);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 30);
            this.btnSave.TabIndex = 15;
            this.btnSave.Text = "Создать сделку";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(350, 280);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 30);
            this.btnCancel.TabIndex = 16;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label8.Location = new System.Drawing.Point(12, 260);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(320, 15);
            this.label8.TabIndex = 17;
            this.label8.Text = "Создание сделки автоматически завершит бронирование";
            // 
            // RentalDealForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(474, 321);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtNotes);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.chkIndefinite);
            this.Controls.Add(this.dtpEndDate);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dtpStartDate);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtEmployee);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtClient);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtProperty);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RentalDealForm";
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Создание сделки аренды";
            this.Load += new System.EventHandler(this.RentalDealForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}