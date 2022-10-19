
namespace RestaurantPOS
{
    partial class RecentSales
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.DGVSales = new Guna.UI2.WinForms.Guna2DataGridView();
            this.SaleIDGV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SaleInvoiceNoGV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OrderDateGV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OrderTimeGV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SaleGrandTotalGV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SaleActionGV = new System.Windows.Forms.DataGridViewButtonColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVSales)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.OrangeRed;
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(799, 52);
            this.panel1.TabIndex = 27;
            // 
            // button3
            // 
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Image = global::RestaurantPOS.Properties.Resources.cancel__2_;
            this.button3.Location = new System.Drawing.Point(755, 3);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(45, 36);
            this.button3.TabIndex = 5;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 25F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(243, 40);
            this.label1.TabIndex = 2;
            this.label1.Text = "RECENT SALES";
            // 
            // DGVSales
            // 
            this.DGVSales.AllowUserToAddRows = false;
            this.DGVSales.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(205)))), ((int)(((byte)(189)))));
            this.DGVSales.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DGVSales.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGVSales.BackgroundColor = System.Drawing.Color.White;
            this.DGVSales.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DGVSales.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.DGVSales.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(87)))), ((int)(((byte)(34)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGVSales.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DGVSales.ColumnHeadersHeight = 30;
            this.DGVSales.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SaleIDGV,
            this.SaleInvoiceNoGV,
            this.OrderDateGV,
            this.OrderTimeGV,
            this.SaleGrandTotalGV,
            this.SaleActionGV});
            this.DGVSales.ContextMenuStrip = this.contextMenuStrip1;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(221)))), ((int)(((byte)(211)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(143)))), ((int)(((byte)(107)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGVSales.DefaultCellStyle = dataGridViewCellStyle3;
            this.DGVSales.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGVSales.EnableHeadersVisualStyles = false;
            this.DGVSales.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(203)))), ((int)(((byte)(186)))));
            this.DGVSales.Location = new System.Drawing.Point(0, 52);
            this.DGVSales.Name = "DGVSales";
            this.DGVSales.ReadOnly = true;
            this.DGVSales.RowHeadersVisible = false;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.DGVSales.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.DGVSales.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGVSales.Size = new System.Drawing.Size(799, 447);
            this.DGVSales.TabIndex = 28;
            this.DGVSales.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.DeepOrange;
            this.DGVSales.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(205)))), ((int)(((byte)(189)))));
            this.DGVSales.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.DGVSales.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.DGVSales.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.DGVSales.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.DGVSales.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.DGVSales.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(203)))), ((int)(((byte)(186)))));
            this.DGVSales.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(87)))), ((int)(((byte)(34)))));
            this.DGVSales.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.DGVSales.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.DGVSales.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.DGVSales.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.DGVSales.ThemeStyle.HeaderStyle.Height = 30;
            this.DGVSales.ThemeStyle.ReadOnly = true;
            this.DGVSales.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(221)))), ((int)(((byte)(211)))));
            this.DGVSales.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.DGVSales.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.DGVSales.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.Black;
            this.DGVSales.ThemeStyle.RowsStyle.Height = 22;
            this.DGVSales.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(143)))), ((int)(((byte)(107)))));
            this.DGVSales.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.DGVSales.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVSales_CellContentClick);
            // 
            // SaleIDGV
            // 
            this.SaleIDGV.HeaderText = "SaleID";
            this.SaleIDGV.Name = "SaleIDGV";
            this.SaleIDGV.ReadOnly = true;
            this.SaleIDGV.Visible = false;
            // 
            // SaleInvoiceNoGV
            // 
            this.SaleInvoiceNoGV.HeaderText = "Invoice No";
            this.SaleInvoiceNoGV.Name = "SaleInvoiceNoGV";
            this.SaleInvoiceNoGV.ReadOnly = true;
            // 
            // OrderDateGV
            // 
            this.OrderDateGV.HeaderText = "Order Date";
            this.OrderDateGV.Name = "OrderDateGV";
            this.OrderDateGV.ReadOnly = true;
            // 
            // OrderTimeGV
            // 
            this.OrderTimeGV.HeaderText = "Order Time";
            this.OrderTimeGV.Name = "OrderTimeGV";
            this.OrderTimeGV.ReadOnly = true;
            // 
            // SaleGrandTotalGV
            // 
            this.SaleGrandTotalGV.HeaderText = "Total Amount";
            this.SaleGrandTotalGV.Name = "SaleGrandTotalGV";
            this.SaleGrandTotalGV.ReadOnly = true;
            // 
            // SaleActionGV
            // 
            this.SaleActionGV.HeaderText = "Action";
            this.SaleActionGV.Name = "SaleActionGV";
            this.SaleActionGV.ReadOnly = true;
            this.SaleActionGV.Text = "VIEW";
            this.SaleActionGV.ToolTipText = "VIEW";
            this.SaleActionGV.UseColumnTextForButtonValue = true;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteToolStripMenuItem,
            this.editToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(108, 48);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.editToolStripMenuItem.Text = "Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // RecentSales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(799, 499);
            this.ControlBox = false;
            this.Controls.Add(this.DGVSales);
            this.Controls.Add(this.panel1);
            this.Name = "RecentSales";
            this.Text = "Recent Sales";
            this.Load += new System.EventHandler(this.ViewAllOrders_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVSales)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2DataGridView DGVSales;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn SaleIDGV;
        private System.Windows.Forms.DataGridViewTextBoxColumn SaleInvoiceNoGV;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrderDateGV;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrderTimeGV;
        private System.Windows.Forms.DataGridViewTextBoxColumn SaleGrandTotalGV;
        private System.Windows.Forms.DataGridViewButtonColumn SaleActionGV;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
    }
}