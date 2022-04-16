
namespace RestaurantPOS
{
    partial class Inventory
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.DGVInventory = new Guna.UI2.WinForms.Guna2DataGridView();
            this.ProductGV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UnitGV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QuantityGV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RateGV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            this.txtSearch = new Guna.UI2.WinForms.Guna2TextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVInventory)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.txtSearch);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(992, 73);
            this.panel1.TabIndex = 25;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 25F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(171, 40);
            this.label1.TabIndex = 2;
            this.label1.Text = "Inventory";
            // 
            // DGVInventory
            // 
            this.DGVInventory.AllowUserToAddRows = false;
            this.DGVInventory.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(239)))), ((int)(((byte)(212)))));
            this.DGVInventory.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DGVInventory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGVInventory.BackgroundColor = System.Drawing.Color.White;
            this.DGVInventory.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DGVInventory.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.DGVInventory.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 10F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGVInventory.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DGVInventory.ColumnHeadersHeight = 30;
            this.DGVInventory.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ProductGV,
            this.UnitGV,
            this.QuantityGV,
            this.RateGV});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(244)))), ((int)(((byte)(226)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Century Gothic", 10F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(221)))), ((int)(((byte)(160)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGVInventory.DefaultCellStyle = dataGridViewCellStyle3;
            this.DGVInventory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGVInventory.EnableHeadersVisualStyles = false;
            this.DGVInventory.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(238)))), ((int)(((byte)(208)))));
            this.DGVInventory.Location = new System.Drawing.Point(0, 73);
            this.DGVInventory.Name = "DGVInventory";
            this.DGVInventory.ReadOnly = true;
            this.DGVInventory.RowHeadersVisible = false;
            this.DGVInventory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGVInventory.Size = new System.Drawing.Size(992, 544);
            this.DGVInventory.TabIndex = 26;
            this.DGVInventory.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.Emerald;
            this.DGVInventory.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(239)))), ((int)(((byte)(212)))));
            this.DGVInventory.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.DGVInventory.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.DGVInventory.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.DGVInventory.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.DGVInventory.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.DGVInventory.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(238)))), ((int)(((byte)(208)))));
            this.DGVInventory.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.DGVInventory.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.DGVInventory.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.DGVInventory.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.DGVInventory.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.DGVInventory.ThemeStyle.HeaderStyle.Height = 30;
            this.DGVInventory.ThemeStyle.ReadOnly = true;
            this.DGVInventory.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(244)))), ((int)(((byte)(226)))));
            this.DGVInventory.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.DGVInventory.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.DGVInventory.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.Black;
            this.DGVInventory.ThemeStyle.RowsStyle.Height = 22;
            this.DGVInventory.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(221)))), ((int)(((byte)(160)))));
            this.DGVInventory.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.DGVInventory.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.DGVInventory_DataBindingComplete);
            // 
            // ProductGV
            // 
            this.ProductGV.HeaderText = "Product";
            this.ProductGV.Name = "ProductGV";
            this.ProductGV.ReadOnly = true;
            // 
            // UnitGV
            // 
            this.UnitGV.HeaderText = "Unit";
            this.UnitGV.Name = "UnitGV";
            this.UnitGV.ReadOnly = true;
            // 
            // QuantityGV
            // 
            this.QuantityGV.HeaderText = "Quantity";
            this.QuantityGV.Name = "QuantityGV";
            this.QuantityGV.ReadOnly = true;
            // 
            // RateGV
            // 
            this.RateGV.HeaderText = "Rate";
            this.RateGV.Name = "RateGV";
            this.RateGV.ReadOnly = true;
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Right;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Image = global::RestaurantPOS.Properties.Resources.cancel__2_;
            this.button1.Location = new System.Drawing.Point(947, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(45, 73);
            this.button1.TabIndex = 4;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.AutoRoundedCorners = true;
            this.txtSearch.BorderRadius = 14;
            this.txtSearch.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSearch.DefaultText = "";
            this.txtSearch.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtSearch.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtSearch.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSearch.DisabledState.Parent = this.txtSearch;
            this.txtSearch.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSearch.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSearch.FocusedState.Parent = this.txtSearch;
            this.txtSearch.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSearch.HoverState.Parent = this.txtSearch;
            this.txtSearch.IconLeft = global::RestaurantPOS.Properties.Resources.icons8_search_50px;
            this.txtSearch.IconLeftOffset = new System.Drawing.Point(5, 0);
            this.txtSearch.Location = new System.Drawing.Point(258, 30);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(21, 21, 21, 21);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.PasswordChar = '\0';
            this.txtSearch.PlaceholderText = "Search Products in Stocks";
            this.txtSearch.SelectedText = "";
            this.txtSearch.ShadowDecoration.Parent = this.txtSearch;
            this.txtSearch.Size = new System.Drawing.Size(612, 31);
            this.txtSearch.TabIndex = 0;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // Inventory
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(992, 617);
            this.ControlBox = false;
            this.Controls.Add(this.DGVInventory);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Inventory";
            this.Text = "Inventory";
            this.Load += new System.EventHandler(this.Inventory_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVInventory)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private Guna.UI2.WinForms.Guna2TextBox txtSearch;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2DataGridView DGVInventory;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductGV;
        private System.Windows.Forms.DataGridViewTextBoxColumn UnitGV;
        private System.Windows.Forms.DataGridViewTextBoxColumn QuantityGV;
        private System.Windows.Forms.DataGridViewTextBoxColumn RateGV;
    }
}