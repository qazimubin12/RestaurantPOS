
namespace RestaurantPOS
{
    partial class PaymentWindow
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtGrandTotal = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtPaying = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtBalance = new Guna.UI2.WinForms.Guna2TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnFinalize = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtChange = new Guna.UI2.WinForms.Guna2TextBox();
            this.cboPaymentMethod = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(639, 52);
            this.panel1.TabIndex = 26;
            // 
            // button3
            // 
            this.button3.Dock = System.Windows.Forms.DockStyle.Right;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Image = global::RestaurantPOS.Properties.Resources.cancel__2_;
            this.button3.Location = new System.Drawing.Point(594, 0);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(45, 52);
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
            this.label1.Size = new System.Drawing.Size(170, 40);
            this.label1.TabIndex = 2;
            this.label1.Text = "PAYMENT";
            // 
            // txtGrandTotal
            // 
            this.txtGrandTotal.AutoRoundedCorners = true;
            this.txtGrandTotal.BorderRadius = 18;
            this.txtGrandTotal.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.txtGrandTotal.DefaultText = "0";
            this.txtGrandTotal.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtGrandTotal.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtGrandTotal.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtGrandTotal.DisabledState.Parent = this.txtGrandTotal;
            this.txtGrandTotal.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtGrandTotal.Enabled = false;
            this.txtGrandTotal.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtGrandTotal.FocusedState.Parent = this.txtGrandTotal;
            this.txtGrandTotal.Font = new System.Drawing.Font("Century Gothic", 20F);
            this.txtGrandTotal.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtGrandTotal.HoverState.Parent = this.txtGrandTotal;
            this.txtGrandTotal.Location = new System.Drawing.Point(18, 99);
            this.txtGrandTotal.Margin = new System.Windows.Forms.Padding(9, 8, 9, 8);
            this.txtGrandTotal.Name = "txtGrandTotal";
            this.txtGrandTotal.PasswordChar = '\0';
            this.txtGrandTotal.PlaceholderText = "";
            this.txtGrandTotal.SelectedText = "";
            this.txtGrandTotal.SelectionStart = 1;
            this.txtGrandTotal.ShadowDecoration.Parent = this.txtGrandTotal;
            this.txtGrandTotal.Size = new System.Drawing.Size(398, 39);
            this.txtGrandTotal.TabIndex = 34;
            // 
            // txtPaying
            // 
            this.txtPaying.AutoRoundedCorners = true;
            this.txtPaying.BorderRadius = 18;
            this.txtPaying.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPaying.DefaultText = "0";
            this.txtPaying.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtPaying.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtPaying.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtPaying.DisabledState.Parent = this.txtPaying;
            this.txtPaying.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtPaying.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtPaying.FocusedState.Parent = this.txtPaying;
            this.txtPaying.Font = new System.Drawing.Font("Century Gothic", 20F);
            this.txtPaying.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtPaying.HoverState.Parent = this.txtPaying;
            this.txtPaying.Location = new System.Drawing.Point(18, 182);
            this.txtPaying.Margin = new System.Windows.Forms.Padding(9, 8, 9, 8);
            this.txtPaying.Name = "txtPaying";
            this.txtPaying.PasswordChar = '\0';
            this.txtPaying.PlaceholderText = "";
            this.txtPaying.SelectedText = "";
            this.txtPaying.SelectionStart = 1;
            this.txtPaying.ShadowDecoration.Parent = this.txtPaying;
            this.txtPaying.Size = new System.Drawing.Size(398, 39);
            this.txtPaying.TabIndex = 0;
            this.txtPaying.TextChanged += new System.EventHandler(this.txtPaying_TextChanged);
            // 
            // txtBalance
            // 
            this.txtBalance.AutoRoundedCorners = true;
            this.txtBalance.BorderRadius = 18;
            this.txtBalance.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.txtBalance.DefaultText = "0";
            this.txtBalance.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtBalance.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtBalance.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtBalance.DisabledState.Parent = this.txtBalance;
            this.txtBalance.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtBalance.Enabled = false;
            this.txtBalance.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtBalance.FocusedState.Parent = this.txtBalance;
            this.txtBalance.Font = new System.Drawing.Font("Century Gothic", 20F);
            this.txtBalance.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtBalance.HoverState.Parent = this.txtBalance;
            this.txtBalance.Location = new System.Drawing.Point(18, 265);
            this.txtBalance.Margin = new System.Windows.Forms.Padding(9, 8, 9, 8);
            this.txtBalance.Name = "txtBalance";
            this.txtBalance.PasswordChar = '\0';
            this.txtBalance.PlaceholderText = "";
            this.txtBalance.SelectedText = "";
            this.txtBalance.SelectionStart = 1;
            this.txtBalance.ShadowDecoration.Parent = this.txtBalance;
            this.txtBalance.Size = new System.Drawing.Size(398, 39);
            this.txtBalance.TabIndex = 34;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.SeaGreen;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(16, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(147, 28);
            this.label2.TabIndex = 2;
            this.label2.Text = "Grand Total";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.SeaGreen;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(18, 146);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 28);
            this.label3.TabIndex = 2;
            this.label3.Text = "Paying";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.SeaGreen;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(16, 229);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(108, 28);
            this.label4.TabIndex = 2;
            this.label4.Text = "Balance";
            // 
            // btnFinalize
            // 
            this.btnFinalize.BackColor = System.Drawing.Color.SeaGreen;
            this.btnFinalize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFinalize.Font = new System.Drawing.Font("Century Gothic", 15F);
            this.btnFinalize.ForeColor = System.Drawing.Color.White;
            this.btnFinalize.Location = new System.Drawing.Point(18, 411);
            this.btnFinalize.Name = "btnFinalize";
            this.btnFinalize.Size = new System.Drawing.Size(393, 77);
            this.btnFinalize.TabIndex = 35;
            this.btnFinalize.Text = "&FINALIZE";
            this.btnFinalize.UseVisualStyleBackColor = false;
            this.btnFinalize.Click += new System.EventHandler(this.btnFinalize_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.SeaGreen;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(16, 312);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(106, 28);
            this.label5.TabIndex = 2;
            this.label5.Text = "Change";
            // 
            // txtChange
            // 
            this.txtChange.AutoRoundedCorners = true;
            this.txtChange.BorderRadius = 18;
            this.txtChange.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.txtChange.DefaultText = "0";
            this.txtChange.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtChange.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtChange.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtChange.DisabledState.Parent = this.txtChange;
            this.txtChange.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtChange.Enabled = false;
            this.txtChange.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtChange.FocusedState.Parent = this.txtChange;
            this.txtChange.Font = new System.Drawing.Font("Century Gothic", 20F);
            this.txtChange.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtChange.HoverState.Parent = this.txtChange;
            this.txtChange.Location = new System.Drawing.Point(18, 348);
            this.txtChange.Margin = new System.Windows.Forms.Padding(9, 8, 9, 8);
            this.txtChange.Name = "txtChange";
            this.txtChange.PasswordChar = '\0';
            this.txtChange.PlaceholderText = "";
            this.txtChange.SelectedText = "";
            this.txtChange.SelectionStart = 1;
            this.txtChange.ShadowDecoration.Parent = this.txtChange;
            this.txtChange.Size = new System.Drawing.Size(398, 39);
            this.txtChange.TabIndex = 34;
            // 
            // cboPaymentMethod
            // 
            this.cboPaymentMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPaymentMethod.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboPaymentMethod.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.cboPaymentMethod.FormattingEnabled = true;
            this.cboPaymentMethod.Items.AddRange(new object[] {
            "Cash",
            "Card"});
            this.cboPaymentMethod.Location = new System.Drawing.Point(448, 99);
            this.cboPaymentMethod.Name = "cboPaymentMethod";
            this.cboPaymentMethod.Size = new System.Drawing.Size(179, 33);
            this.cboPaymentMethod.TabIndex = 36;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.SeaGreen;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(443, 68);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(108, 28);
            this.label6.TabIndex = 2;
            this.label6.Text = "Method:";
            // 
            // PaymentWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(639, 500);
            this.ControlBox = false;
            this.Controls.Add(this.cboPaymentMethod);
            this.Controls.Add(this.btnFinalize);
            this.Controls.Add(this.txtChange);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtBalance);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtPaying);
            this.Controls.Add(this.txtGrandTotal);
            this.Controls.Add(this.panel1);
            this.Name = "PaymentWindow";
            this.Text = "PaymentWindow";
            this.Load += new System.EventHandler(this.PaymentWindow_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnFinalize;
        public Guna.UI2.WinForms.Guna2TextBox txtGrandTotal;
        public Guna.UI2.WinForms.Guna2TextBox txtBalance;
        public Guna.UI2.WinForms.Guna2TextBox txtPaying;
        private System.Windows.Forms.Label label5;
        public Guna.UI2.WinForms.Guna2TextBox txtChange;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.ComboBox cboPaymentMethod;
    }
}