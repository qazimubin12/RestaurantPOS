
namespace RestaurantPOS
{
    partial class POS
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblLoggedInUser = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblStoreAddress = new System.Windows.Forms.Label();
            this.lblID = new System.Windows.Forms.Label();
            this.lblStore = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.guna2GroupBox1 = new Guna.UI2.WinForms.Guna2GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dtInvoiceDate = new System.Windows.Forms.DateTimePicker();
            this.label13 = new System.Windows.Forms.Label();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.txtInvoiceNo = new Guna.UI2.WinForms.Guna2TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.txtSearhBarcode = new Guna.UI2.WinForms.Guna2TextBox();
            this.cboProducts = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.DGVSaleCart = new Guna.UI2.WinForms.Guna2DataGridView();
            this.ProductIDGV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductGV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SalePriceGV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QuantityGV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalOfProductGV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ActionAddGV = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ActionRemoveGV = new System.Windows.Forms.DataGridViewButtonColumn();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnRecentSales = new System.Windows.Forms.Button();
            this.txtGrandTotal = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnFinalize = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.txtDiscount = new Guna.UI2.WinForms.Guna2TextBox();
            this.GBWalking = new Guna.UI2.WinForms.Guna2GroupBox();
            this.txtWChange = new Guna.UI2.WinForms.Guna2TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtWPaying = new Guna.UI2.WinForms.Guna2TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.btnWindowClose = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.guna2GroupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVSaleCart)).BeginInit();
            this.panel4.SuspendLayout();
            this.GBWalking.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.OrangeRed;
            this.panel1.Controls.Add(this.btnWindowClose);
            this.panel1.Controls.Add(this.lblLoggedInUser);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Controls.Add(this.lblStoreAddress);
            this.panel1.Controls.Add(this.lblID);
            this.panel1.Controls.Add(this.lblStore);
            this.panel1.Controls.Add(this.label16);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1370, 73);
            this.panel1.TabIndex = 1;
            // 
            // lblLoggedInUser
            // 
            this.lblLoggedInUser.AutoSize = true;
            this.lblLoggedInUser.BackColor = System.Drawing.Color.Transparent;
            this.lblLoggedInUser.Font = new System.Drawing.Font("Century Gothic", 11F);
            this.lblLoggedInUser.ForeColor = System.Drawing.Color.White;
            this.lblLoggedInUser.Location = new System.Drawing.Point(528, 8);
            this.lblLoggedInUser.Name = "lblLoggedInUser";
            this.lblLoggedInUser.Size = new System.Drawing.Size(88, 20);
            this.lblLoggedInUser.TabIndex = 8;
            this.lblLoggedInUser.Text = "Logged In:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 11F);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(437, 7);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 20);
            this.label4.TabIndex = 9;
            this.label4.Text = "Logged In:";
            // 
            // btnClose
            // 
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Image = global::RestaurantPOS.Properties.Resources.cancel__2_;
            this.btnClose.Location = new System.Drawing.Point(1325, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(45, 36);
            this.btnClose.TabIndex = 0;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblStoreAddress
            // 
            this.lblStoreAddress.AutoSize = true;
            this.lblStoreAddress.Font = new System.Drawing.Font("Century Gothic", 25F, System.Drawing.FontStyle.Bold);
            this.lblStoreAddress.ForeColor = System.Drawing.Color.White;
            this.lblStoreAddress.Location = new System.Drawing.Point(557, 21);
            this.lblStoreAddress.Name = "lblStoreAddress";
            this.lblStoreAddress.Size = new System.Drawing.Size(0, 40);
            this.lblStoreAddress.TabIndex = 2;
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Font = new System.Drawing.Font("Century Gothic", 25F, System.Drawing.FontStyle.Bold);
            this.lblID.ForeColor = System.Drawing.Color.White;
            this.lblID.Location = new System.Drawing.Point(1040, 9);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(51, 40);
            this.lblID.TabIndex = 2;
            this.lblID.Text = "ID";
            this.lblID.TextChanged += new System.EventHandler(this.lblID_TextChanged);
            this.lblID.Click += new System.EventHandler(this.lblID_Click);
            // 
            // lblStore
            // 
            this.lblStore.AutoSize = true;
            this.lblStore.Font = new System.Drawing.Font("Century Gothic", 25F, System.Drawing.FontStyle.Bold);
            this.lblStore.ForeColor = System.Drawing.Color.White;
            this.lblStore.Location = new System.Drawing.Point(824, 18);
            this.lblStore.Name = "lblStore";
            this.lblStore.Size = new System.Drawing.Size(61, 40);
            this.lblStore.TabIndex = 2;
            this.lblStore.Text = "cc";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Century Gothic", 25F, System.Drawing.FontStyle.Bold);
            this.label16.ForeColor = System.Drawing.Color.White;
            this.label16.Location = new System.Drawing.Point(718, 18);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(110, 40);
            this.label16.TabIndex = 2;
            this.label16.Text = "Store:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 25F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(218, 40);
            this.label1.TabIndex = 2;
            this.label1.Text = "Point of Sale";
            // 
            // guna2GroupBox1
            // 
            this.guna2GroupBox1.Controls.Add(this.panel2);
            this.guna2GroupBox1.CustomBorderColor = System.Drawing.Color.OrangeRed;
            this.guna2GroupBox1.CustomBorderThickness = new System.Windows.Forms.Padding(0, 30, 0, 0);
            this.guna2GroupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.guna2GroupBox1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2GroupBox1.ForeColor = System.Drawing.Color.White;
            this.guna2GroupBox1.Location = new System.Drawing.Point(0, 73);
            this.guna2GroupBox1.Name = "guna2GroupBox1";
            this.guna2GroupBox1.ShadowDecoration.Parent = this.guna2GroupBox1;
            this.guna2GroupBox1.Size = new System.Drawing.Size(1370, 85);
            this.guna2GroupBox1.TabIndex = 0;
            this.guna2GroupBox1.Text = "SEARCH PRODUCT";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dtInvoiceDate);
            this.panel2.Controls.Add(this.label13);
            this.panel2.Controls.Add(this.btnGenerate);
            this.panel2.Controls.Add(this.txtInvoiceNo);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.btnAdd);
            this.panel2.Controls.Add(this.txtSearhBarcode);
            this.panel2.Controls.Add(this.cboProducts);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.panel2.ForeColor = System.Drawing.Color.Black;
            this.panel2.Location = new System.Drawing.Point(0, 28);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1370, 57);
            this.panel2.TabIndex = 0;
            // 
            // dtInvoiceDate
            // 
            this.dtInvoiceDate.CustomFormat = "dd/MM/yyyy";
            this.dtInvoiceDate.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.dtInvoiceDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtInvoiceDate.Location = new System.Drawing.Point(863, 18);
            this.dtInvoiceDate.Name = "dtInvoiceDate";
            this.dtInvoiceDate.Size = new System.Drawing.Size(138, 24);
            this.dtInvoiceDate.TabIndex = 14;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.label13.ForeColor = System.Drawing.Color.Black;
            this.label13.Location = new System.Drawing.Point(810, 21);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(47, 19);
            this.label13.TabIndex = 13;
            this.label13.Text = "Date:";
            // 
            // btnGenerate
            // 
            this.btnGenerate.BackColor = System.Drawing.Color.OrangeRed;
            this.btnGenerate.FlatAppearance.BorderColor = System.Drawing.Color.OrangeRed;
            this.btnGenerate.FlatAppearance.BorderSize = 2;
            this.btnGenerate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerate.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.btnGenerate.ForeColor = System.Drawing.Color.White;
            this.btnGenerate.Location = new System.Drawing.Point(1260, 14);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(92, 32);
            this.btnGenerate.TabIndex = 12;
            this.btnGenerate.Text = "&GENERATE";
            this.btnGenerate.UseVisualStyleBackColor = false;
            this.btnGenerate.Visible = false;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // txtInvoiceNo
            // 
            this.txtInvoiceNo.AutoRoundedCorners = true;
            this.txtInvoiceNo.BorderRadius = 11;
            this.txtInvoiceNo.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtInvoiceNo.DefaultText = "";
            this.txtInvoiceNo.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtInvoiceNo.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtInvoiceNo.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtInvoiceNo.DisabledState.Parent = this.txtInvoiceNo;
            this.txtInvoiceNo.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtInvoiceNo.Enabled = false;
            this.txtInvoiceNo.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtInvoiceNo.FocusedState.Parent = this.txtInvoiceNo;
            this.txtInvoiceNo.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInvoiceNo.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtInvoiceNo.HoverState.Parent = this.txtInvoiceNo;
            this.txtInvoiceNo.Location = new System.Drawing.Point(1114, 18);
            this.txtInvoiceNo.Margin = new System.Windows.Forms.Padding(4);
            this.txtInvoiceNo.Name = "txtInvoiceNo";
            this.txtInvoiceNo.PasswordChar = '\0';
            this.txtInvoiceNo.PlaceholderText = "";
            this.txtInvoiceNo.SelectedText = "";
            this.txtInvoiceNo.ShadowDecoration.Parent = this.txtInvoiceNo;
            this.txtInvoiceNo.Size = new System.Drawing.Size(139, 25);
            this.txtInvoiceNo.TabIndex = 11;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(1021, 21);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(86, 19);
            this.label11.TabIndex = 10;
            this.label11.Text = "Invoice No:";
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.OrangeRed;
            this.btnAdd.FlatAppearance.BorderColor = System.Drawing.Color.OrangeRed;
            this.btnAdd.FlatAppearance.BorderSize = 2;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(723, 14);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(81, 32);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "&ADD";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Visible = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtSearhBarcode
            // 
            this.txtSearhBarcode.AutoRoundedCorners = true;
            this.txtSearhBarcode.BorderRadius = 13;
            this.txtSearhBarcode.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSearhBarcode.DefaultText = "";
            this.txtSearhBarcode.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtSearhBarcode.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtSearhBarcode.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSearhBarcode.DisabledState.Parent = this.txtSearhBarcode;
            this.txtSearhBarcode.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSearhBarcode.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSearhBarcode.FocusedState.Parent = this.txtSearhBarcode;
            this.txtSearhBarcode.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSearhBarcode.HoverState.Parent = this.txtSearhBarcode;
            this.txtSearhBarcode.IconLeft = global::RestaurantPOS.Properties.Resources.icons8_search_50px;
            this.txtSearhBarcode.IconLeftOffset = new System.Drawing.Point(5, 0);
            this.txtSearhBarcode.Location = new System.Drawing.Point(372, 15);
            this.txtSearhBarcode.Margin = new System.Windows.Forms.Padding(87, 78, 87, 78);
            this.txtSearhBarcode.Name = "txtSearhBarcode";
            this.txtSearhBarcode.PasswordChar = '\0';
            this.txtSearhBarcode.PlaceholderText = "Enter Barcode";
            this.txtSearhBarcode.SelectedText = "";
            this.txtSearhBarcode.ShadowDecoration.Parent = this.txtSearhBarcode;
            this.txtSearhBarcode.Size = new System.Drawing.Size(339, 28);
            this.txtSearhBarcode.TabIndex = 0;
            this.txtSearhBarcode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearhBarcode_KeyDown);
            // 
            // cboProducts
            // 
            this.cboProducts.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboProducts.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboProducts.FormattingEnabled = true;
            this.cboProducts.Location = new System.Drawing.Point(83, 18);
            this.cboProducts.Name = "cboProducts";
            this.cboProducts.Size = new System.Drawing.Size(242, 25);
            this.cboProducts.TabIndex = 1;
            this.cboProducts.SelectedIndexChanged += new System.EventHandler(this.cboProducts_SelectedIndexChanged);
            this.cboProducts.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cboProducts_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(331, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 19);
            this.label3.TabIndex = 0;
            this.label3.Text = "OR";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 19);
            this.label2.TabIndex = 0;
            this.label2.Text = "Search:";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.DGVSaleCart);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.panel3.Location = new System.Drawing.Point(0, 158);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(804, 445);
            this.panel3.TabIndex = 26;
            // 
            // DGVSaleCart
            // 
            this.DGVSaleCart.AllowUserToAddRows = false;
            this.DGVSaleCart.AllowUserToDeleteRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(205)))), ((int)(((byte)(189)))));
            this.DGVSaleCart.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.DGVSaleCart.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGVSaleCart.BackgroundColor = System.Drawing.Color.White;
            this.DGVSaleCart.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DGVSaleCart.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.DGVSaleCart.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(87)))), ((int)(((byte)(34)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Century Gothic", 10F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGVSaleCart.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.DGVSaleCart.ColumnHeadersHeight = 30;
            this.DGVSaleCart.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ProductIDGV,
            this.ProductGV,
            this.SalePriceGV,
            this.QuantityGV,
            this.TotalOfProductGV,
            this.ActionAddGV,
            this.ActionRemoveGV});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(221)))), ((int)(((byte)(211)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Century Gothic", 10F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(143)))), ((int)(((byte)(107)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGVSaleCart.DefaultCellStyle = dataGridViewCellStyle6;
            this.DGVSaleCart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGVSaleCart.EnableHeadersVisualStyles = false;
            this.DGVSaleCart.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(203)))), ((int)(((byte)(186)))));
            this.DGVSaleCart.Location = new System.Drawing.Point(0, 0);
            this.DGVSaleCart.Name = "DGVSaleCart";
            this.DGVSaleCart.ReadOnly = true;
            this.DGVSaleCart.RowHeadersVisible = false;
            this.DGVSaleCart.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGVSaleCart.Size = new System.Drawing.Size(804, 445);
            this.DGVSaleCart.TabIndex = 0;
            this.DGVSaleCart.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.DeepOrange;
            this.DGVSaleCart.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(205)))), ((int)(((byte)(189)))));
            this.DGVSaleCart.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.DGVSaleCart.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.DGVSaleCart.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.DGVSaleCart.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.DGVSaleCart.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.DGVSaleCart.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(203)))), ((int)(((byte)(186)))));
            this.DGVSaleCart.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(87)))), ((int)(((byte)(34)))));
            this.DGVSaleCart.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.DGVSaleCart.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.DGVSaleCart.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.DGVSaleCart.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.DGVSaleCart.ThemeStyle.HeaderStyle.Height = 30;
            this.DGVSaleCart.ThemeStyle.ReadOnly = true;
            this.DGVSaleCart.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(221)))), ((int)(((byte)(211)))));
            this.DGVSaleCart.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.DGVSaleCart.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.DGVSaleCart.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.Black;
            this.DGVSaleCart.ThemeStyle.RowsStyle.Height = 22;
            this.DGVSaleCart.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(143)))), ((int)(((byte)(107)))));
            this.DGVSaleCart.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.DGVSaleCart.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVSaleCart_CellClick);
            // 
            // ProductIDGV
            // 
            this.ProductIDGV.HeaderText = "ProductID";
            this.ProductIDGV.Name = "ProductIDGV";
            this.ProductIDGV.ReadOnly = true;
            this.ProductIDGV.Visible = false;
            // 
            // ProductGV
            // 
            this.ProductGV.HeaderText = "Product";
            this.ProductGV.Name = "ProductGV";
            this.ProductGV.ReadOnly = true;
            // 
            // SalePriceGV
            // 
            this.SalePriceGV.HeaderText = "Price";
            this.SalePriceGV.Name = "SalePriceGV";
            this.SalePriceGV.ReadOnly = true;
            // 
            // QuantityGV
            // 
            this.QuantityGV.HeaderText = "Qty";
            this.QuantityGV.Name = "QuantityGV";
            this.QuantityGV.ReadOnly = true;
            // 
            // TotalOfProductGV
            // 
            this.TotalOfProductGV.HeaderText = "Total";
            this.TotalOfProductGV.Name = "TotalOfProductGV";
            this.TotalOfProductGV.ReadOnly = true;
            // 
            // ActionAddGV
            // 
            this.ActionAddGV.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ActionAddGV.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ActionAddGV.HeaderText = "";
            this.ActionAddGV.Name = "ActionAddGV";
            this.ActionAddGV.ReadOnly = true;
            this.ActionAddGV.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ActionAddGV.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ActionAddGV.Text = "ADD";
            this.ActionAddGV.UseColumnTextForButtonValue = true;
            // 
            // ActionRemoveGV
            // 
            this.ActionRemoveGV.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ActionRemoveGV.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ActionRemoveGV.HeaderText = "";
            this.ActionRemoveGV.Name = "ActionRemoveGV";
            this.ActionRemoveGV.ReadOnly = true;
            this.ActionRemoveGV.Text = "REMOVE";
            this.ActionRemoveGV.UseColumnTextForButtonValue = true;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.button2);
            this.panel4.Controls.Add(this.btnRecentSales);
            this.panel4.Controls.Add(this.txtGrandTotal);
            this.panel4.Controls.Add(this.btnFinalize);
            this.panel4.Controls.Add(this.label6);
            this.panel4.Controls.Add(this.label15);
            this.panel4.Controls.Add(this.txtDiscount);
            this.panel4.Controls.Add(this.GBWalking);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.panel4.Location = new System.Drawing.Point(804, 158);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(566, 445);
            this.panel4.TabIndex = 27;
            // 
            // btnRecentSales
            // 
            this.btnRecentSales.BackColor = System.Drawing.Color.OrangeRed;
            this.btnRecentSales.FlatAppearance.BorderColor = System.Drawing.Color.OrangeRed;
            this.btnRecentSales.FlatAppearance.BorderSize = 2;
            this.btnRecentSales.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRecentSales.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.btnRecentSales.ForeColor = System.Drawing.Color.White;
            this.btnRecentSales.Location = new System.Drawing.Point(422, 20);
            this.btnRecentSales.Name = "btnRecentSales";
            this.btnRecentSales.Size = new System.Drawing.Size(132, 44);
            this.btnRecentSales.TabIndex = 14;
            this.btnRecentSales.Text = "&RECENT SALES";
            this.btnRecentSales.UseVisualStyleBackColor = false;
            this.btnRecentSales.Click += new System.EventHandler(this.btnRecentSales_Click);
            // 
            // txtGrandTotal
            // 
            this.txtGrandTotal.AutoRoundedCorners = true;
            this.txtGrandTotal.BackColor = System.Drawing.Color.White;
            this.txtGrandTotal.BorderRadius = 11;
            this.txtGrandTotal.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtGrandTotal.DefaultText = "";
            this.txtGrandTotal.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtGrandTotal.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtGrandTotal.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtGrandTotal.DisabledState.Parent = this.txtGrandTotal;
            this.txtGrandTotal.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtGrandTotal.Enabled = false;
            this.txtGrandTotal.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtGrandTotal.FocusedState.Parent = this.txtGrandTotal;
            this.txtGrandTotal.ForeColor = System.Drawing.Color.Black;
            this.txtGrandTotal.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtGrandTotal.HoverState.Parent = this.txtGrandTotal;
            this.txtGrandTotal.IconLeftOffset = new System.Drawing.Point(5, 0);
            this.txtGrandTotal.Location = new System.Drawing.Point(140, 39);
            this.txtGrandTotal.Margin = new System.Windows.Forms.Padding(276, 228, 276, 228);
            this.txtGrandTotal.Name = "txtGrandTotal";
            this.txtGrandTotal.PasswordChar = '\0';
            this.txtGrandTotal.PlaceholderText = "";
            this.txtGrandTotal.SelectedText = "";
            this.txtGrandTotal.ShadowDecoration.Parent = this.txtGrandTotal;
            this.txtGrandTotal.Size = new System.Drawing.Size(189, 25);
            this.txtGrandTotal.TabIndex = 13;
            this.txtGrandTotal.TextChanged += new System.EventHandler(this.txtGrandTotal_TextChanged);
            // 
            // btnFinalize
            // 
            this.btnFinalize.BackColor = System.Drawing.Color.OrangeRed;
            this.btnFinalize.FlatAppearance.BorderColor = System.Drawing.Color.OrangeRed;
            this.btnFinalize.FlatAppearance.BorderSize = 2;
            this.btnFinalize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFinalize.Font = new System.Drawing.Font("Century Gothic", 23F);
            this.btnFinalize.ForeColor = System.Drawing.Color.White;
            this.btnFinalize.Location = new System.Drawing.Point(10, 362);
            this.btnFinalize.Name = "btnFinalize";
            this.btnFinalize.Size = new System.Drawing.Size(373, 54);
            this.btnFinalize.TabIndex = 10;
            this.btnFinalize.Text = "&FINALIZE";
            this.btnFinalize.UseVisualStyleBackColor = false;
            this.btnFinalize.Click += new System.EventHandler(this.btnFinalize_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(136, 14);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(90, 19);
            this.label6.TabIndex = 7;
            this.label6.Text = "Grand Total";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.White;
            this.label15.ForeColor = System.Drawing.Color.Black;
            this.label15.Location = new System.Drawing.Point(19, 14);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(68, 19);
            this.label15.TabIndex = 7;
            this.label15.Text = "Discount";
            // 
            // txtDiscount
            // 
            this.txtDiscount.AutoRoundedCorners = true;
            this.txtDiscount.BackColor = System.Drawing.Color.White;
            this.txtDiscount.BorderRadius = 11;
            this.txtDiscount.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtDiscount.DefaultText = "";
            this.txtDiscount.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtDiscount.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtDiscount.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtDiscount.DisabledState.Parent = this.txtDiscount;
            this.txtDiscount.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtDiscount.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtDiscount.FocusedState.Parent = this.txtDiscount;
            this.txtDiscount.ForeColor = System.Drawing.Color.Black;
            this.txtDiscount.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtDiscount.HoverState.Parent = this.txtDiscount;
            this.txtDiscount.IconLeftOffset = new System.Drawing.Point(5, 0);
            this.txtDiscount.Location = new System.Drawing.Point(17, 39);
            this.txtDiscount.Margin = new System.Windows.Forms.Padding(207, 174, 207, 174);
            this.txtDiscount.Name = "txtDiscount";
            this.txtDiscount.PasswordChar = '\0';
            this.txtDiscount.PlaceholderText = "";
            this.txtDiscount.SelectedText = "";
            this.txtDiscount.ShadowDecoration.Parent = this.txtDiscount;
            this.txtDiscount.Size = new System.Drawing.Size(119, 25);
            this.txtDiscount.TabIndex = 10;
            this.txtDiscount.TextChanged += new System.EventHandler(this.txtDiscount_TextChanged);
            // 
            // GBWalking
            // 
            this.GBWalking.Controls.Add(this.txtWChange);
            this.GBWalking.Controls.Add(this.label12);
            this.GBWalking.Controls.Add(this.txtWPaying);
            this.GBWalking.Controls.Add(this.label14);
            this.GBWalking.CustomBorderColor = System.Drawing.Color.OrangeRed;
            this.GBWalking.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.GBWalking.ForeColor = System.Drawing.Color.White;
            this.GBWalking.Location = new System.Drawing.Point(10, 126);
            this.GBWalking.Name = "GBWalking";
            this.GBWalking.ShadowDecoration.Parent = this.GBWalking;
            this.GBWalking.Size = new System.Drawing.Size(544, 116);
            this.GBWalking.TabIndex = 12;
            this.GBWalking.Text = "PAYMENTS";
            // 
            // txtWChange
            // 
            this.txtWChange.AutoRoundedCorners = true;
            this.txtWChange.BackColor = System.Drawing.Color.White;
            this.txtWChange.BorderRadius = 16;
            this.txtWChange.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtWChange.DefaultText = "";
            this.txtWChange.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtWChange.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtWChange.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtWChange.DisabledState.Parent = this.txtWChange;
            this.txtWChange.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtWChange.Enabled = false;
            this.txtWChange.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtWChange.FocusedState.Parent = this.txtWChange;
            this.txtWChange.ForeColor = System.Drawing.Color.Black;
            this.txtWChange.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtWChange.HoverState.Parent = this.txtWChange;
            this.txtWChange.IconLeftOffset = new System.Drawing.Point(5, 0);
            this.txtWChange.Location = new System.Drawing.Point(161, 65);
            this.txtWChange.Margin = new System.Windows.Forms.Padding(207, 174, 207, 174);
            this.txtWChange.Name = "txtWChange";
            this.txtWChange.PasswordChar = '\0';
            this.txtWChange.PlaceholderText = "";
            this.txtWChange.SelectedText = "";
            this.txtWChange.ShadowDecoration.Parent = this.txtWChange;
            this.txtWChange.Size = new System.Drawing.Size(116, 35);
            this.txtWChange.TabIndex = 10;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.White;
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(3, 45);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(56, 19);
            this.label12.TabIndex = 7;
            this.label12.Text = "Paying";
            // 
            // txtWPaying
            // 
            this.txtWPaying.AutoRoundedCorners = true;
            this.txtWPaying.BackColor = System.Drawing.Color.White;
            this.txtWPaying.BorderRadius = 16;
            this.txtWPaying.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtWPaying.DefaultText = "";
            this.txtWPaying.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtWPaying.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtWPaying.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtWPaying.DisabledState.Parent = this.txtWPaying;
            this.txtWPaying.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtWPaying.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtWPaying.FocusedState.Parent = this.txtWPaying;
            this.txtWPaying.ForeColor = System.Drawing.Color.Black;
            this.txtWPaying.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtWPaying.HoverState.Parent = this.txtWPaying;
            this.txtWPaying.IconLeftOffset = new System.Drawing.Point(5, 0);
            this.txtWPaying.Location = new System.Drawing.Point(7, 65);
            this.txtWPaying.Margin = new System.Windows.Forms.Padding(155, 133, 155, 133);
            this.txtWPaying.Name = "txtWPaying";
            this.txtWPaying.PasswordChar = '\0';
            this.txtWPaying.PlaceholderText = "";
            this.txtWPaying.SelectedText = "";
            this.txtWPaying.ShadowDecoration.Parent = this.txtWPaying;
            this.txtWPaying.Size = new System.Drawing.Size(133, 35);
            this.txtWPaying.TabIndex = 10;
            this.txtWPaying.TextChanged += new System.EventHandler(this.txtWPaying_TextChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.White;
            this.label14.ForeColor = System.Drawing.Color.Black;
            this.label14.Location = new System.Drawing.Point(157, 45);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(66, 19);
            this.label14.TabIndex = 7;
            this.label14.Text = "Change";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.OrangeRed;
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.OrangeRed;
            this.button2.FlatAppearance.BorderSize = 2;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(422, 248);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(132, 38);
            this.button2.TabIndex = 15;
            this.button2.Text = "&START NEW";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnWindowClose
            // 
            this.btnWindowClose.FlatAppearance.BorderSize = 0;
            this.btnWindowClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnWindowClose.Image = global::RestaurantPOS.Properties.Resources.cancel__2_;
            this.btnWindowClose.Location = new System.Drawing.Point(1325, 0);
            this.btnWindowClose.Name = "btnWindowClose";
            this.btnWindowClose.Size = new System.Drawing.Size(45, 36);
            this.btnWindowClose.TabIndex = 10;
            this.btnWindowClose.UseVisualStyleBackColor = true;
            this.btnWindowClose.Visible = false;
            this.btnWindowClose.Click += new System.EventHandler(this.btnWindowClose_Click);
            // 
            // POS
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1370, 603);
            this.ControlBox = false;
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.guna2GroupBox1);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "POS";
            this.Text = "POS";
            this.Load += new System.EventHandler(this.POS_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.guna2GroupBox1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGVSaleCart)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.GBWalking.ResumeLayout(false);
            this.GBWalking.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2GroupBox guna2GroupBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private Guna.UI2.WinForms.Guna2DataGridView DGVSaleCart;
        public System.Windows.Forms.ComboBox cboProducts;
        public Guna.UI2.WinForms.Guna2TextBox txtSearhBarcode;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label label6;
        private Guna.UI2.WinForms.Guna2GroupBox GBWalking;
        public Guna.UI2.WinForms.Guna2TextBox txtWChange;
        private System.Windows.Forms.Label label12;
        public Guna.UI2.WinForms.Guna2TextBox txtWPaying;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button btnFinalize;
        private System.Windows.Forms.Button btnGenerate;
        private Guna.UI2.WinForms.Guna2TextBox txtInvoiceNo;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DateTimePicker dtInvoiceDate;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label15;
        public Guna.UI2.WinForms.Guna2TextBox txtDiscount;
        private System.Windows.Forms.Label lblStore;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label lblStoreAddress;
        public Guna.UI2.WinForms.Guna2TextBox txtGrandTotal;
        public System.Windows.Forms.Label lblLoggedInUser;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductIDGV;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductGV;
        private System.Windows.Forms.DataGridViewTextBoxColumn SalePriceGV;
        private System.Windows.Forms.DataGridViewTextBoxColumn QuantityGV;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalOfProductGV;
        private System.Windows.Forms.DataGridViewButtonColumn ActionAddGV;
        private System.Windows.Forms.DataGridViewButtonColumn ActionRemoveGV;
        private System.Windows.Forms.Button btnRecentSales;
        public System.Windows.Forms.Label lblID;
        private System.Windows.Forms.Button button2;
        public System.Windows.Forms.Button btnClose;
        public System.Windows.Forms.Button btnWindowClose;
    }
}