﻿namespace QuanLyBanHangSieuThi
{
    partial class FormAbout
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
            label1 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Red;
            label1.Location = new Point(63, 74);
            label1.Name = "label1";
            label1.Size = new Size(475, 31);
            label1.TabIndex = 0;
            label1.Text = "PHẦN MỀM QUẢN LÝ BÁN HÀNG SIÊU THỊ";
            // 
            // FormAbout
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(607, 193);
            Controls.Add(label1);
            Name = "FormAbout";
            Text = "THÔNG TIN SẢN PHẨM";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
    }
}