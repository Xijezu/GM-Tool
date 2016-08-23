namespace GM_Tool_V5 {
    partial class frmDatabase {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDatabase));
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_Window_Minimize = new System.Windows.Forms.Button();
            this.btn_Window_Resize = new System.Windows.Forms.Button();
            this.btn_Window_Close = new System.Windows.Forms.Button();
            this.btnGenerateList = new GM_Tool_V5.XButton();
            this.cbSelectedList = new GM_Tool_V5.XComboBox();
            this.xPanel1 = new GM_Tool_V5.XPanel();
            this.tbDbUsername = new GM_Tool_V5.XTextBox();
            this.cbSavePassword = new System.Windows.Forms.CheckBox();
            this.tbDbPassword = new GM_Tool_V5.XTextBox();
            this.tbDbDatabase = new GM_Tool_V5.XTextBox();
            this.tbDbAddress = new GM_Tool_V5.XTextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.xPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btn_Window_Minimize);
            this.panel1.Controls.Add(this.btn_Window_Resize);
            this.panel1.Controls.Add(this.btn_Window_Close);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(278, 27);
            this.panel1.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(25, 25);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.label1.Location = new System.Drawing.Point(37, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "Xijezu\'s GM-Tool V5.2";
            // 
            // btn_Window_Minimize
            // 
            this.btn_Window_Minimize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Window_Minimize.BackColor = System.Drawing.Color.Transparent;
            this.btn_Window_Minimize.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_Window_Minimize.Enabled = false;
            this.btn_Window_Minimize.FlatAppearance.BorderSize = 0;
            this.btn_Window_Minimize.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btn_Window_Minimize.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.btn_Window_Minimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Window_Minimize.Image = global::GM_Tool_V5.Properties.Resources.Minimize3;
            this.btn_Window_Minimize.Location = new System.Drawing.Point(202, 0);
            this.btn_Window_Minimize.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Window_Minimize.Name = "btn_Window_Minimize";
            this.btn_Window_Minimize.Size = new System.Drawing.Size(25, 25);
            this.btn_Window_Minimize.TabIndex = 3;
            this.btn_Window_Minimize.UseVisualStyleBackColor = false;
            this.btn_Window_Minimize.Click += new System.EventHandler(this.btn_Window_Close_Click);
            // 
            // btn_Window_Resize
            // 
            this.btn_Window_Resize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Window_Resize.BackColor = System.Drawing.Color.Transparent;
            this.btn_Window_Resize.BackgroundImage = global::GM_Tool_V5.Properties.Resources.Resize3;
            this.btn_Window_Resize.Enabled = false;
            this.btn_Window_Resize.FlatAppearance.BorderSize = 0;
            this.btn_Window_Resize.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btn_Window_Resize.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.btn_Window_Resize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Window_Resize.Location = new System.Drawing.Point(227, 0);
            this.btn_Window_Resize.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Window_Resize.Name = "btn_Window_Resize";
            this.btn_Window_Resize.Size = new System.Drawing.Size(25, 25);
            this.btn_Window_Resize.TabIndex = 2;
            this.btn_Window_Resize.UseVisualStyleBackColor = false;
            // 
            // btn_Window_Close
            // 
            this.btn_Window_Close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Window_Close.BackColor = System.Drawing.Color.Transparent;
            this.btn_Window_Close.FlatAppearance.BorderSize = 0;
            this.btn_Window_Close.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btn_Window_Close.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.btn_Window_Close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Window_Close.Font = new System.Drawing.Font("Arial", 9F);
            this.btn_Window_Close.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.btn_Window_Close.Location = new System.Drawing.Point(252, 0);
            this.btn_Window_Close.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Window_Close.Name = "btn_Window_Close";
            this.btn_Window_Close.Size = new System.Drawing.Size(25, 25);
            this.btn_Window_Close.TabIndex = 1;
            this.btn_Window_Close.Text = "X";
            this.btn_Window_Close.UseVisualStyleBackColor = false;
            this.btn_Window_Close.Click += new System.EventHandler(this.btn_Window_Close_Click);
            // 
            // btnGenerateList
            // 
            this.btnGenerateList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGenerateList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.btnGenerateList.ColorStyle = GM_Tool_V5.XColorStyle.Blue;
            this.btnGenerateList.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnGenerateList.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnGenerateList.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.btnGenerateList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerateList.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.btnGenerateList.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.btnGenerateList.Location = new System.Drawing.Point(142, 206);
            this.btnGenerateList.Name = "btnGenerateList";
            this.btnGenerateList.Size = new System.Drawing.Size(124, 23);
            this.btnGenerateList.TabIndex = 6;
            this.btnGenerateList.Text = "Generate and save list";
            this.btnGenerateList.UseVisualStyleBackColor = false;
            this.btnGenerateList.Click += new System.EventHandler(this.btnGenerateList_Click);
            // 
            // cbSelectedList
            // 
            this.cbSelectedList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbSelectedList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.cbSelectedList.ColorStyle = GM_Tool_V5.XColorStyle.Blue;
            this.cbSelectedList.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbSelectedList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSelectedList.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.cbSelectedList.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.cbSelectedList.FormattingEnabled = true;
            this.cbSelectedList.Items.AddRange(new object[] {
            "Itemlist",
            "Bufflist",
            "Monsterlist",
            "Petlist",
            "Skilllist"});
            this.cbSelectedList.Location = new System.Drawing.Point(12, 206);
            this.cbSelectedList.Name = "cbSelectedList";
            this.cbSelectedList.Size = new System.Drawing.Size(124, 23);
            this.cbSelectedList.TabIndex = 5;
            // 
            // xPanel1
            // 
            this.xPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.xPanel1.ColorStyle = GM_Tool_V5.XColorStyle.Blue;
            this.xPanel1.Controls.Add(this.tbDbUsername);
            this.xPanel1.Controls.Add(this.cbSavePassword);
            this.xPanel1.Controls.Add(this.tbDbPassword);
            this.xPanel1.Controls.Add(this.tbDbDatabase);
            this.xPanel1.Controls.Add(this.tbDbAddress);
            this.xPanel1.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.xPanel1.Location = new System.Drawing.Point(12, 33);
            this.xPanel1.Name = "xPanel1";
            this.xPanel1.Size = new System.Drawing.Size(254, 165);
            this.xPanel1.TabIndex = 4;
            // 
            // tbDbUsername
            // 
            this.tbDbUsername.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbDbUsername.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.tbDbUsername.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbDbUsername.ColorStyle = GM_Tool_V5.XColorStyle.Blue;
            this.tbDbUsername.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.tbDbUsername.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.tbDbUsername.Location = new System.Drawing.Point(66, 79);
            this.tbDbUsername.Name = "tbDbUsername";
            this.tbDbUsername.NumericTextBox = false;
            this.tbDbUsername.Size = new System.Drawing.Size(122, 22);
            this.tbDbUsername.TabIndex = 2;
            this.tbDbUsername.Text = "sa";
            // 
            // cbSavePassword
            // 
            this.cbSavePassword.AutoSize = true;
            this.cbSavePassword.Location = new System.Drawing.Point(66, 131);
            this.cbSavePassword.Name = "cbSavePassword";
            this.cbSavePassword.Size = new System.Drawing.Size(103, 17);
            this.cbSavePassword.TabIndex = 4;
            this.cbSavePassword.Text = "Save (plaintext)";
            this.cbSavePassword.UseVisualStyleBackColor = true;
            // 
            // tbDbPassword
            // 
            this.tbDbPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbDbPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.tbDbPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbDbPassword.ColorStyle = GM_Tool_V5.XColorStyle.Blue;
            this.tbDbPassword.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.tbDbPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.tbDbPassword.Location = new System.Drawing.Point(66, 105);
            this.tbDbPassword.Name = "tbDbPassword";
            this.tbDbPassword.NumericTextBox = false;
            this.tbDbPassword.Size = new System.Drawing.Size(122, 22);
            this.tbDbPassword.TabIndex = 3;
            this.tbDbPassword.Text = "password";
            this.tbDbPassword.UseSystemPasswordChar = true;
            // 
            // tbDbDatabase
            // 
            this.tbDbDatabase.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbDbDatabase.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.tbDbDatabase.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbDbDatabase.ColorStyle = GM_Tool_V5.XColorStyle.Blue;
            this.tbDbDatabase.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.tbDbDatabase.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.tbDbDatabase.Location = new System.Drawing.Point(66, 53);
            this.tbDbDatabase.Name = "tbDbDatabase";
            this.tbDbDatabase.NumericTextBox = false;
            this.tbDbDatabase.Size = new System.Drawing.Size(122, 22);
            this.tbDbDatabase.TabIndex = 1;
            this.tbDbDatabase.Text = "Arcadia";
            // 
            // tbDbAddress
            // 
            this.tbDbAddress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbDbAddress.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.tbDbAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbDbAddress.ColorStyle = GM_Tool_V5.XColorStyle.Blue;
            this.tbDbAddress.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.tbDbAddress.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.tbDbAddress.Location = new System.Drawing.Point(66, 27);
            this.tbDbAddress.Name = "tbDbAddress";
            this.tbDbAddress.NumericTextBox = false;
            this.tbDbAddress.Size = new System.Drawing.Size(122, 22);
            this.tbDbAddress.TabIndex = 0;
            this.tbDbAddress.Text = "localhost";
            // 
            // frmDatabase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.ClientSize = new System.Drawing.Size(278, 249);
            this.Controls.Add(this.btnGenerateList);
            this.Controls.Add(this.cbSelectedList);
            this.Controls.Add(this.xPanel1);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmDatabase";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmDatabase";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.xPanel1.ResumeLayout(false);
            this.xPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_Window_Minimize;
        private System.Windows.Forms.Button btn_Window_Resize;
        private System.Windows.Forms.Button btn_Window_Close;
        private XTextBox tbDbAddress;
        private XPanel xPanel1;
        private XTextBox tbDbUsername;
        private System.Windows.Forms.CheckBox cbSavePassword;
        private XTextBox tbDbPassword;
        private XTextBox tbDbDatabase;
        private XComboBox cbSelectedList;
        private XButton btnGenerateList;
    }
}