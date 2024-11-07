namespace QuanLyBanHangSieuThi
{
    partial class FormStore
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
            btnSave = new Button();
            btnRefresh = new Button();
            txtAddress = new TextBox();
            label5 = new Label();
            txtName = new TextBox();
            label2 = new Label();
            groupBox1 = new GroupBox();
            label1 = new Label();
            cboManager = new ComboBox();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // btnSave
            // 
            btnSave.Location = new Point(636, 210);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(146, 34);
            btnSave.TabIndex = 3;
            btnSave.Text = "Lưu";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnRefresh
            // 
            btnRefresh.Location = new Point(469, 210);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(146, 34);
            btnRefresh.TabIndex = 3;
            btnRefresh.Text = "Làm mới";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // txtAddress
            // 
            txtAddress.Location = new Point(154, 85);
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(628, 27);
            txtAddress.TabIndex = 1;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(72, 92);
            label5.Name = "label5";
            label5.Size = new Size(57, 20);
            label5.TabIndex = 0;
            label5.Text = "Địa Chỉ";
            // 
            // txtName
            // 
            txtName.Location = new Point(154, 35);
            txtName.Name = "txtName";
            txtName.Size = new Size(387, 27);
            txtName.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(30, 38);
            label2.Name = "label2";
            label2.Size = new Size(102, 20);
            label2.TabIndex = 0;
            label2.Text = "Tên Cửa Hàng";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(cboManager);
            groupBox1.Controls.Add(btnSave);
            groupBox1.Controls.Add(btnRefresh);
            groupBox1.Controls.Add(txtAddress);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(txtName);
            groupBox1.Controls.Add(label2);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(813, 282);
            groupBox1.TabIndex = 4;
            groupBox1.TabStop = false;
            groupBox1.Text = "Chức năng";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(20, 147);
            label1.Name = "label1";
            label1.Size = new Size(127, 20);
            label1.TabIndex = 0;
            label1.Text = "Nhân viên quản lý";
            // 
            // cboManager
            // 
            cboManager.FormattingEnabled = true;
            cboManager.Location = new Point(154, 139);
            cboManager.Name = "cboManager";
            cboManager.Size = new Size(387, 28);
            cboManager.TabIndex = 4;
            // 
            // FormStore
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(837, 316);
            Controls.Add(groupBox1);
            Name = "FormStore";
            Text = "QUẢN LÝ THÔNG TIN CỬA HÀNG";
            Load += FormStore_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Button btnSave;
        private Button btnRefresh;
        private TextBox txtAddress;
        private Label label5;
        private TextBox txtName;
        private Label label2;
        private GroupBox groupBox1;
        private Label label1;
        private ComboBox cboManager;
    }
}