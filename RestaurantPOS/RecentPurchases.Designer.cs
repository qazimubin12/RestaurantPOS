
namespace RestaurantPOS
{
    partial class RecentPurchases
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
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.DGVRecentPurchases = new Guna.UI2.WinForms.Guna2DataGridView();
            this.PurchaseIDGV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InvoiceNoGV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PurchaseDateGV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GrandTotalGV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ActionGV = new System.Windows.Forms.DataGridViewButtonColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVRecentPurchases)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.OrangeRed;
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 73);
            this.panel1.TabIndex = 29;
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Right;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Image = global::RestaurantPOS.Properties.Resources.cancel__2_;
            this.button1.Location = new System.Drawing.Point(755, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(45, 73);
            this.button1.TabIndex = 4;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 25F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(309, 40);
            this.label1.TabIndex = 2;
            this.label1.Text = "Recent Purchases";
            // 
            // DGVRecentPurchases
            // 
            this.DGVRecentPurchases.AllowUserToAddRows = false;
            this.DGVRecentPurchases.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(205)))), ((int)(((byte)(189)))));
            this.DGVRecentPurchases.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DGVRecentPurchases.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGVRecentPurchases.BackgroundColor = System.Drawing.Color.White;
            this.DGVRecentPurchases.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DGVRecentPurchases.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.DGVRecentPurchases.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(87)))), ((int)(((byte)(34)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGVRecentPurchases.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DGVRecentPurchases.ColumnHeadersHeight = 40;
            this.DGVRecentPurchases.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PurchaseIDGV,
            this.InvoiceNoGV,
            this.PurchaseDateGV,
            this.GrandTotalGV,
            this.ActionGV});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(221)))), ((int)(((byte)(211)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(143)))), ((int)(((byte)(107)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGVRecentPurchases.DefaultCellStyle = dataGridViewCellStyle3;
            this.DGVRecentPurchases.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGVRecentPurchases.EnableHeadersVisualStyles = false;
            this.DGVRecentPurchases.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(203)))), ((int)(((byte)(186)))));
            this.DGVRecentPurchases.Location = new System.Drawing.Point(0, 0);
            this.DGVRecentPurchases.Name = "DGVRecentPurchases";
            this.DGVRecentPurchases.ReadOnly = true;
            this.DGVRecentPurchases.RowHeadersVisible = false;
            this.DGVRecentPurchases.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGVRecentPurchases.Size = new System.Drawing.Size(800, 377);
            this.DGVRecentPurchases.TabIndex = 30;
            this.DGVRecentPurchases.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.DeepOrange;
            this.DGVRecentPurchases.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(205)))), ((int)(((byte)(189)))));
            this.DGVRecentPurchases.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.DGVRecentPurchases.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.DGVRecentPurchases.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.DGVRecentPurchases.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.DGVRecentPurchases.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.DGVRecentPurchases.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(203)))), ((int)(((byte)(186)))));
            this.DGVRecentPurchases.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(87)))), ((int)(((byte)(34)))));
            this.DGVRecentPurchases.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.DGVRecentPurchases.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.DGVRecentPurchases.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.DGVRecentPurchases.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.DGVRecentPurchases.ThemeStyle.HeaderStyle.Height = 40;
            this.DGVRecentPurchases.ThemeStyle.ReadOnly = true;
            this.DGVRecentPurchases.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(221)))), ((int)(((byte)(211)))));
            this.DGVRecentPurchases.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.DGVRecentPurchases.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.DGVRecentPurchases.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.Black;
            this.DGVRecentPurchases.ThemeStyle.RowsStyle.Height = 22;
            this.DGVRecentPurchases.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(143)))), ((int)(((byte)(107)))));
            this.DGVRecentPurchases.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.DGVRecentPurchases.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVRecentPurchases_CellClick);
            // 
            // PurchaseIDGV
            // 
            this.PurchaseIDGV.HeaderText = "PurchaseID";
            this.PurchaseIDGV.Name = "PurchaseIDGV";
            this.PurchaseIDGV.ReadOnly = true;
            this.PurchaseIDGV.Visible = false;
            // 
            // InvoiceNoGV
            // 
            this.InvoiceNoGV.HeaderText = "Invoice No";
            this.InvoiceNoGV.Name = "InvoiceNoGV";
            this.InvoiceNoGV.ReadOnly = true;
            // 
            // PurchaseDateGV
            // 
            this.PurchaseDateGV.HeaderText = "Purchase Date";
            this.PurchaseDateGV.Name = "PurchaseDateGV";
            this.PurchaseDateGV.ReadOnly = true;
            // 
            // GrandTotalGV
            // 
            this.GrandTotalGV.HeaderText = "Grand Total";
            this.GrandTotalGV.Name = "GrandTotalGV";
            this.GrandTotalGV.ReadOnly = true;
            // 
            // ActionGV
            // 
            this.ActionGV.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ActionGV.HeaderText = "ACTION";
            this.ActionGV.Name = "ActionGV";
            this.ActionGV.ReadOnly = true;
            this.ActionGV.Text = "EDIT";
            this.ActionGV.ToolTipText = "EDIT";
            this.ActionGV.UseColumnTextForButtonValue = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.DGVRecentPurchases);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 73);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(800, 377);
            this.panel2.TabIndex = 31;
            // 
            // RecentPurchases
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.ControlBox = false;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "RecentPurchases";
            this.Text = "RecentPurchases";
            this.Load += new System.EventHandler(this.RecentPurchases_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVRecentPurchases)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2DataGridView DGVRecentPurchases;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridViewTextBoxColumn PurchaseIDGV;
        private System.Windows.Forms.DataGridViewTextBoxColumn InvoiceNoGV;
        private System.Windows.Forms.DataGridViewTextBoxColumn PurchaseDateGV;
        private System.Windows.Forms.DataGridViewTextBoxColumn GrandTotalGV;
        private System.Windows.Forms.DataGridViewButtonColumn ActionGV;
    }
}