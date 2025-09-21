namespace RealEstateAgency.Forms
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private TabControl tabControl1;
        private TabPage tabPageProperties;
        private TabPage tabPageClients;
        private TabPage tabPageDeals;
        private TabPage tabPageBookings;
        private DataGridView dgvProperties;
        private Button btnAddProperty;
        private Button btnEditProperty;
        private Button btnDeleteProperty;
        private DataGridView dgvClients;
        private Button btnAddClient;
        private Button btnEditClient;
        private Button btnDeleteClient;
        private DataGridView dgvDeals;
        private Button btnGenerateReport;
        private Button btnRefresh;
        private Label lblPropertiesCount;
        private Label lblClientsCount;
        private Label lblDealsCount;
        private DataGridView dgvBookings;
        private Button btnAddBooking;
        private Button btnEditBooking;
        private Button btnDeleteBooking;
        private Button btnCreateRentalDeal;
        private Button btnCancelBooking;
        private Label lblBookingsCount;

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
            this.tabControl1 = new TabControl();
            this.tabPageProperties = new TabPage();
            this.lblPropertiesCount = new Label();
            this.btnDeleteProperty = new Button();
            this.btnEditProperty = new Button();
            this.btnAddProperty = new Button();
            this.dgvProperties = new DataGridView();
            this.tabPageClients = new TabPage();
            this.lblClientsCount = new Label();
            this.btnDeleteClient = new Button();
            this.btnEditClient = new Button();
            this.btnAddClient = new Button();
            this.dgvClients = new DataGridView();
            this.tabPageDeals = new TabPage();
            this.lblDealsCount = new Label();
            this.btnGenerateReport = new Button();
            this.dgvDeals = new DataGridView();
            this.tabPageBookings = new TabPage();
            this.lblBookingsCount = new Label();
            this.btnCancelBooking = new Button();
            this.btnCreateRentalDeal = new Button();
            this.btnDeleteBooking = new Button();
            this.btnEditBooking = new Button();
            this.btnAddBooking = new Button();
            this.dgvBookings = new DataGridView();
            this.btnRefresh = new Button();
            this.tabControl1.SuspendLayout();
            this.tabPageProperties.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProperties)).BeginInit();
            this.tabPageClients.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClients)).BeginInit();
            this.tabPageDeals.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDeals)).BeginInit();
            this.tabPageBookings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBookings)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageProperties);
            this.tabControl1.Controls.Add(this.tabPageClients);
            this.tabControl1.Controls.Add(this.tabPageDeals);
            this.tabControl1.Controls.Add(this.tabPageBookings);
            this.tabControl1.Dock = DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1000, 600);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPageProperties
            // 
            this.tabPageProperties.Controls.Add(this.lblPropertiesCount);
            this.tabPageProperties.Controls.Add(this.btnDeleteProperty);
            this.tabPageProperties.Controls.Add(this.btnEditProperty);
            this.tabPageProperties.Controls.Add(this.btnAddProperty);
            this.tabPageProperties.Controls.Add(this.dgvProperties);
            this.tabPageProperties.Location = new System.Drawing.Point(4, 24);
            this.tabPageProperties.Name = "tabPageProperties";
            this.tabPageProperties.Padding = new Padding(3);
            this.tabPageProperties.Size = new System.Drawing.Size(992, 572);
            this.tabPageProperties.TabIndex = 0;
            this.tabPageProperties.Text = "Объекты недвижимости";
            this.tabPageProperties.UseVisualStyleBackColor = true;
            // 
            // lblPropertiesCount
            // 
            this.lblPropertiesCount.AutoSize = true;
            this.lblPropertiesCount.Location = new System.Drawing.Point(6, 547);
            this.lblPropertiesCount.Name = "lblPropertiesCount";
            this.lblPropertiesCount.Size = new System.Drawing.Size(109, 15);
            this.lblPropertiesCount.TabIndex = 4;
            this.lblPropertiesCount.Text = "Всего объектов: 0";
            // 
            // btnDeleteProperty
            // 
            this.btnDeleteProperty.Location = new System.Drawing.Point(246, 6);
            this.btnDeleteProperty.Name = "btnDeleteProperty";
            this.btnDeleteProperty.Size = new System.Drawing.Size(114, 30);
            this.btnDeleteProperty.TabIndex = 3;
            this.btnDeleteProperty.Text = "Удалить";
            this.btnDeleteProperty.UseVisualStyleBackColor = true;
            this.btnDeleteProperty.Click += new System.EventHandler(this.btnDeleteProperty_Click);
            // 
            // btnEditProperty
            // 
            this.btnEditProperty.Location = new System.Drawing.Point(126, 6);
            this.btnEditProperty.Name = "btnEditProperty";
            this.btnEditProperty.Size = new System.Drawing.Size(114, 30);
            this.btnEditProperty.TabIndex = 2;
            this.btnEditProperty.Text = "Редактировать";
            this.btnEditProperty.UseVisualStyleBackColor = true;
            this.btnEditProperty.Click += new System.EventHandler(this.btnEditProperty_Click);
            // 
            // btnAddProperty
            // 
            this.btnAddProperty.Location = new System.Drawing.Point(6, 6);
            this.btnAddProperty.Name = "btnAddProperty";
            this.btnAddProperty.Size = new System.Drawing.Size(114, 30);
            this.btnAddProperty.TabIndex = 1;
            this.btnAddProperty.Text = "Добавить";
            this.btnAddProperty.UseVisualStyleBackColor = true;
            this.btnAddProperty.Click += new System.EventHandler(this.btnAddProperty_Click);
            // 
            // dgvProperties
            // 
            this.dgvProperties.AllowUserToAddRows = false;
            this.dgvProperties.AllowUserToDeleteRows = false;
            this.dgvProperties.Anchor = ((AnchorStyles)((((AnchorStyles.Top | AnchorStyles.Bottom) 
            | AnchorStyles.Left) 
            | AnchorStyles.Right)));
            this.dgvProperties.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProperties.Location = new System.Drawing.Point(6, 42);
            this.dgvProperties.Name = "dgvProperties";
            this.dgvProperties.ReadOnly = true;
            this.dgvProperties.RowTemplate.Height = 25;
            this.dgvProperties.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvProperties.Size = new System.Drawing.Size(980, 502);
            this.dgvProperties.TabIndex = 0;
            // 
            // tabPageClients
            // 
            this.tabPageClients.Controls.Add(this.lblClientsCount);
            this.tabPageClients.Controls.Add(this.btnDeleteClient);
            this.tabPageClients.Controls.Add(this.btnEditClient);
            this.tabPageClients.Controls.Add(this.btnAddClient);
            this.tabPageClients.Controls.Add(this.dgvClients);
            this.tabPageClients.Location = new System.Drawing.Point(4, 24);
            this.tabPageClients.Name = "tabPageClients";
            this.tabPageClients.Padding = new Padding(3);
            this.tabPageClients.Size = new System.Drawing.Size(992, 572);
            this.tabPageClients.TabIndex = 1;
            this.tabPageClients.Text = "Клиенты";
            this.tabPageClients.UseVisualStyleBackColor = true;
            // 
            // lblClientsCount
            // 
            this.lblClientsCount.AutoSize = true;
            this.lblClientsCount.Location = new System.Drawing.Point(6, 547);
            this.lblClientsCount.Name = "lblClientsCount";
            this.lblClientsCount.Size = new System.Drawing.Size(97, 15);
            this.lblClientsCount.TabIndex = 8;
            this.lblClientsCount.Text = "Всего клиентов: 0";
            // 
            // btnDeleteClient
            // 
            this.btnDeleteClient.Location = new System.Drawing.Point(246, 6);
            this.btnDeleteClient.Name = "btnDeleteClient";
            this.btnDeleteClient.Size = new System.Drawing.Size(114, 30);
            this.btnDeleteClient.TabIndex = 7;
            this.btnDeleteClient.Text = "Удалить";
            this.btnDeleteClient.UseVisualStyleBackColor = true;
            this.btnDeleteClient.Click += new System.EventHandler(this.btnDeleteClient_Click);
            // 
            // btnEditClient
            // 
            this.btnEditClient.Location = new System.Drawing.Point(126, 6);
            this.btnEditClient.Name = "btnEditClient";
            this.btnEditClient.Size = new System.Drawing.Size(114, 30);
            this.btnEditClient.TabIndex = 6;
            this.btnEditClient.Text = "Редактировать";
            this.btnEditClient.UseVisualStyleBackColor = true;
            this.btnEditClient.Click += new System.EventHandler(this.btnEditClient_Click);
            // 
            // btnAddClient
            // 
            this.btnAddClient.Location = new System.Drawing.Point(6, 6);
            this.btnAddClient.Name = "btnAddClient";
            this.btnAddClient.Size = new System.Drawing.Size(114, 30);
            this.btnAddClient.TabIndex = 5;
            this.btnAddClient.Text = "Добавить";
            this.btnAddClient.UseVisualStyleBackColor = true;
            this.btnAddClient.Click += new System.EventHandler(this.btnAddClient_Click);
            // 
            // dgvClients
            // 
            this.dgvClients.AllowUserToAddRows = false;
            this.dgvClients.AllowUserToDeleteRows = false;
            this.dgvClients.Anchor = ((AnchorStyles)((((AnchorStyles.Top | AnchorStyles.Bottom) 
            | AnchorStyles.Left) 
            | AnchorStyles.Right)));
            this.dgvClients.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvClients.Location = new System.Drawing.Point(6, 42);
            this.dgvClients.Name = "dgvClients";
            this.dgvClients.ReadOnly = true;
            this.dgvClients.RowTemplate.Height = 25;
            this.dgvClients.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvClients.Size = new System.Drawing.Size(980, 502);
            this.dgvClients.TabIndex = 4;
            // 
            // tabPageDeals
            // 
            this.tabPageDeals.Controls.Add(this.lblDealsCount);
            this.tabPageDeals.Controls.Add(this.btnGenerateReport);
            this.tabPageDeals.Controls.Add(this.dgvDeals);
            this.tabPageDeals.Location = new System.Drawing.Point(4, 24);
            this.tabPageDeals.Name = "tabPageDeals";
            this.tabPageDeals.Padding = new Padding(3);
            this.tabPageDeals.Size = new System.Drawing.Size(992, 572);
            this.tabPageDeals.TabIndex = 2;
            this.tabPageDeals.Text = "Сделки";
            this.tabPageDeals.UseVisualStyleBackColor = true;
            // 
            // lblDealsCount
            // 
            this.lblDealsCount.AutoSize = true;
            this.lblDealsCount.Location = new System.Drawing.Point(6, 547);
            this.lblDealsCount.Name = "lblDealsCount";
            this.lblDealsCount.Size = new System.Drawing.Size(85, 15);
            this.lblDealsCount.TabIndex = 2;
            this.lblDealsCount.Text = "Всего сделок: 0";
            // 
            // btnGenerateReport
            // 
            this.btnGenerateReport.Location = new System.Drawing.Point(6, 6);
            this.btnGenerateReport.Name = "btnGenerateReport";
            this.btnGenerateReport.Size = new System.Drawing.Size(150, 30);
            this.btnGenerateReport.TabIndex = 1;
            this.btnGenerateReport.Text = "Сформировать отчет";
            this.btnGenerateReport.UseVisualStyleBackColor = true;
            this.btnGenerateReport.Click += new System.EventHandler(this.btnGenerateReport_Click);
            // 
            // dgvDeals
            // 
            this.dgvDeals.AllowUserToAddRows = false;
            this.dgvDeals.AllowUserToDeleteRows = false;
            this.dgvDeals.Anchor = ((AnchorStyles)((((AnchorStyles.Top | AnchorStyles.Bottom) 
            | AnchorStyles.Left) 
            | AnchorStyles.Right)));
            this.dgvDeals.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDeals.Location = new System.Drawing.Point(6, 42);
            this.dgvDeals.Name = "dgvDeals";
            this.dgvDeals.ReadOnly = true;
            this.dgvDeals.RowTemplate.Height = 25;
            this.dgvDeals.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvDeals.Size = new System.Drawing.Size(980, 502);
            this.dgvDeals.TabIndex = 0;
            // 
            // tabPageBookings
            // 
            this.tabPageBookings.Controls.Add(this.lblBookingsCount);
            this.tabPageBookings.Controls.Add(this.btnCancelBooking);
            this.tabPageBookings.Controls.Add(this.btnCreateRentalDeal);
            this.tabPageBookings.Controls.Add(this.btnDeleteBooking);
            this.tabPageBookings.Controls.Add(this.btnEditBooking);
            this.tabPageBookings.Controls.Add(this.btnAddBooking);
            this.tabPageBookings.Controls.Add(this.dgvBookings);
            this.tabPageBookings.Location = new System.Drawing.Point(4, 24);
            this.tabPageBookings.Name = "tabPageBookings";
            this.tabPageBookings.Padding = new Padding(3);
            this.tabPageBookings.Size = new System.Drawing.Size(992, 572);
            this.tabPageBookings.TabIndex = 3;
            this.tabPageBookings.Text = "Бронирования";
            this.tabPageBookings.UseVisualStyleBackColor = true;
            // 
            // lblBookingsCount
            // 
            this.lblBookingsCount.AutoSize = true;
            this.lblBookingsCount.Location = new System.Drawing.Point(6, 547);
            this.lblBookingsCount.Name = "lblBookingsCount";
            this.lblBookingsCount.Size = new System.Drawing.Size(139, 15);
            this.lblBookingsCount.TabIndex = 6;
            this.lblBookingsCount.Text = "Всего бронирований: 0";
            // 
            // btnCancelBooking
            // 
            this.btnCancelBooking.Location = new System.Drawing.Point(486, 6);
            this.btnCancelBooking.Name = "btnCancelBooking";
            this.btnCancelBooking.Size = new System.Drawing.Size(114, 30);
            this.btnCancelBooking.TabIndex = 5;
            this.btnCancelBooking.Text = "Отменить";
            this.btnCancelBooking.UseVisualStyleBackColor = true;
            this.btnCancelBooking.Click += new System.EventHandler(this.btnCancelBooking_Click);
            // 
            // btnCreateRentalDeal
            // 
            this.btnCreateRentalDeal.Location = new System.Drawing.Point(366, 6);
            this.btnCreateRentalDeal.Name = "btnCreateRentalDeal";
            this.btnCreateRentalDeal.Size = new System.Drawing.Size(114, 30);
            this.btnCreateRentalDeal.TabIndex = 4;
            this.btnCreateRentalDeal.Text = "Создать сделку";
            this.btnCreateRentalDeal.UseVisualStyleBackColor = true;
            this.btnCreateRentalDeal.Click += new System.EventHandler(this.btnCreateRentalDeal_Click);
            // 
            // btnDeleteBooking
            // 
            this.btnDeleteBooking.Location = new System.Drawing.Point(246, 6);
            this.btnDeleteBooking.Name = "btnDeleteBooking";
            this.btnDeleteBooking.Size = new System.Drawing.Size(114, 30);
            this.btnDeleteBooking.TabIndex = 3;
            this.btnDeleteBooking.Text = "Удалить";
            this.btnDeleteBooking.UseVisualStyleBackColor = true;
            this.btnDeleteBooking.Click += new System.EventHandler(this.btnDeleteBooking_Click);
            // 
            // btnEditBooking
            // 
            this.btnEditBooking.Location = new System.Drawing.Point(126, 6);
            this.btnEditBooking.Name = "btnEditBooking";
            this.btnEditBooking.Size = new System.Drawing.Size(114, 30);
            this.btnEditBooking.TabIndex = 2;
            this.btnEditBooking.Text = "Редактировать";
            this.btnEditBooking.UseVisualStyleBackColor = true;
            this.btnEditBooking.Click += new System.EventHandler(this.btnEditBooking_Click);
            // 
            // btnAddBooking
            // 
            this.btnAddBooking.Location = new System.Drawing.Point(6, 6);
            this.btnAddBooking.Name = "btnAddBooking";
            this.btnAddBooking.Size = new System.Drawing.Size(114, 30);
            this.btnAddBooking.TabIndex = 1;
            this.btnAddBooking.Text = "Добавить";
            this.btnAddBooking.UseVisualStyleBackColor = true;
            this.btnAddBooking.Click += new System.EventHandler(this.btnAddBooking_Click);
            // 
            // dgvBookings
            // 
            this.dgvBookings.AllowUserToAddRows = false;
            this.dgvBookings.AllowUserToDeleteRows = false;
            this.dgvBookings.Anchor = ((AnchorStyles)((((AnchorStyles.Top | AnchorStyles.Bottom) 
            | AnchorStyles.Left) 
            | AnchorStyles.Right)));
            this.dgvBookings.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBookings.Location = new System.Drawing.Point(6, 42);
            this.dgvBookings.Name = "dgvBookings";
            this.dgvBookings.ReadOnly = true;
            this.dgvBookings.RowTemplate.Height = 25;
            this.dgvBookings.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvBookings.Size = new System.Drawing.Size(980, 502);
            this.dgvBookings.TabIndex = 0;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((AnchorStyles)((AnchorStyles.Top | AnchorStyles.Right)));
            this.btnRefresh.Location = new System.Drawing.Point(884, 12);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(104, 30);
            this.btnRefresh.TabIndex = 1;
            this.btnRefresh.Text = "Обновить";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 600);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.tabControl1);
            this.Name = "MainForm";
            this.Text = "Агентство недвижимости";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPageProperties.ResumeLayout(false);
            this.tabPageProperties.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProperties)).EndInit();
            this.tabPageClients.ResumeLayout(false);
            this.tabPageClients.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClients)).EndInit();
            this.tabPageDeals.ResumeLayout(false);
            this.tabPageDeals.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDeals)).EndInit();
            this.tabPageBookings.ResumeLayout(false);
            this.tabPageBookings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBookings)).EndInit();
            this.ResumeLayout(false);

        }
    }
}