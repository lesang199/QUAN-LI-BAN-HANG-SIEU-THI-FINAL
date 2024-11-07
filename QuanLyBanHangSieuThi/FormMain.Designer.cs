namespace QuanLyBanHangSieuThi
{
    partial class FormMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            chứcNăngToolStripMenuItem = new ToolStripMenuItem();
            mnuExit = new ToolStripMenuItem();
            quảnLýToolStripMenuItem = new ToolStripMenuItem();
            mnuStore = new ToolStripMenuItem();
            mnuCustomer = new ToolStripMenuItem();
            mnuManager = new ToolStripMenuItem();
            mnuSeller = new ToolStripMenuItem();
            mnuProduct = new ToolStripMenuItem();
            mnuBeverage = new ToolStripMenuItem();
            mnuFood = new ToolStripMenuItem();
            mnuHouseHold = new ToolStripMenuItem();
            bánHàngToolStripMenuItem = new ToolStripMenuItem();
            mnuInvoiceList = new ToolStripMenuItem();
            mnuOrderList = new ToolStripMenuItem();
            mnuOrder = new ToolStripMenuItem();
            trợGiúpToolStripMenuItem = new ToolStripMenuItem();
            thôngTinSảnPhẩmToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { chứcNăngToolStripMenuItem, quảnLýToolStripMenuItem, bánHàngToolStripMenuItem, trợGiúpToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 28);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // chứcNăngToolStripMenuItem
            // 
            chứcNăngToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { mnuExit });
            chứcNăngToolStripMenuItem.Name = "chứcNăngToolStripMenuItem";
            chứcNăngToolStripMenuItem.Size = new Size(96, 24);
            chứcNăngToolStripMenuItem.Text = "Chức Năng";
            // 
            // mnuExit
            // 
            mnuExit.Name = "mnuExit";
            mnuExit.Size = new Size(116, 26);
            mnuExit.Text = "Exit";
            mnuExit.Click += mnuExit_Click;
            // 
            // quảnLýToolStripMenuItem
            // 
            quảnLýToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { mnuStore, mnuCustomer, mnuManager, mnuSeller, mnuProduct, mnuBeverage, mnuFood, mnuHouseHold });
            quảnLýToolStripMenuItem.Name = "quảnLýToolStripMenuItem";
            quảnLýToolStripMenuItem.Size = new Size(75, 24);
            quảnLýToolStripMenuItem.Text = "Quản Lý";
            // 
            // mnuStore
            // 
            mnuStore.Name = "mnuStore";
            mnuStore.Size = new Size(229, 26);
            mnuStore.Text = "Cửa Hàng";
            mnuStore.Click += mnuStore_Click;
            // 
            // mnuCustomer
            // 
            mnuCustomer.Name = "mnuCustomer";
            mnuCustomer.Size = new Size(229, 26);
            mnuCustomer.Text = "Khách Hàng";
            mnuCustomer.Click += mnuCustomer_Click;
            // 
            // mnuManager
            // 
            mnuManager.Name = "mnuManager";
            mnuManager.Size = new Size(229, 26);
            mnuManager.Text = "Nhân Viên Quản Lý";
            mnuManager.Click += mnuManager_Click;
            // 
            // mnuSeller
            // 
            mnuSeller.Name = "mnuSeller";
            mnuSeller.Size = new Size(229, 26);
            mnuSeller.Text = "Nhân Viên Bán Hàng";
            mnuSeller.Click += mnuSeller_Click;
            // 
            // mnuProduct
            // 
            mnuProduct.Name = "mnuProduct";
            mnuProduct.Size = new Size(229, 26);
            mnuProduct.Text = "Sản Phẩm";
            mnuProduct.Click += mnuProduct_Click;
            // 
            // mnuBeverage
            // 
            mnuBeverage.Name = "mnuBeverage";
            mnuBeverage.Size = new Size(229, 26);
            mnuBeverage.Text = "Đồ Uống";
            mnuBeverage.Click += đồUốngToolStripMenuItem_Click;
            // 
            // mnuFood
            // 
            mnuFood.Name = "mnuFood";
            mnuFood.Size = new Size(229, 26);
            mnuFood.Text = "Thực Phẩm";
            mnuFood.Click += mnuFood_Click;
            // 
            // mnuHouseHold
            // 
            mnuHouseHold.Name = "mnuHouseHold";
            mnuHouseHold.Size = new Size(229, 26);
            mnuHouseHold.Text = "Đồ Gia Dụng";
            mnuHouseHold.Click += mnuHouseHold_Click;
            // 
            // bánHàngToolStripMenuItem
            // 
            bánHàngToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { mnuInvoiceList, mnuOrderList, mnuOrder });
            bánHàngToolStripMenuItem.Name = "bánHàngToolStripMenuItem";
            bánHàngToolStripMenuItem.Size = new Size(88, 24);
            bánHàngToolStripMenuItem.Text = "Bán Hàng";
            // 
            // mnuInvoiceList
            // 
            mnuInvoiceList.Name = "mnuInvoiceList";
            mnuInvoiceList.Size = new Size(234, 26);
            mnuInvoiceList.Text = "Danh Sách Hoá Đơn";
            mnuInvoiceList.Click += mnuInvoiceList_Click;
            // 
            // mnuOrderList
            // 
            mnuOrderList.Name = "mnuOrderList";
            mnuOrderList.Size = new Size(234, 26);
            mnuOrderList.Text = "Danh Sách Đơn Hàng";
            mnuOrderList.Click += mnuOrderList_Click;
            // 
            // mnuOrder
            // 
            mnuOrder.Name = "mnuOrder";
            mnuOrder.Size = new Size(234, 26);
            mnuOrder.Text = "Tạo Đơn Hàng";
            mnuOrder.Click += mnuOrder_Click;
            // 
            // trợGiúpToolStripMenuItem
            // 
            trợGiúpToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { thôngTinSảnPhẩmToolStripMenuItem });
            trợGiúpToolStripMenuItem.Name = "trợGiúpToolStripMenuItem";
            trợGiúpToolStripMenuItem.Size = new Size(79, 24);
            trợGiúpToolStripMenuItem.Text = "Trợ Giúp";
            // 
            // thôngTinSảnPhẩmToolStripMenuItem
            // 
            thôngTinSảnPhẩmToolStripMenuItem.Name = "thôngTinSảnPhẩmToolStripMenuItem";
            thôngTinSảnPhẩmToolStripMenuItem.Size = new Size(227, 26);
            thôngTinSảnPhẩmToolStripMenuItem.Text = "Thông Tin Sản Phẩm";
            thôngTinSảnPhẩmToolStripMenuItem.Click += thôngTinSảnPhẩmToolStripMenuItem_Click;
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(menuStrip1);
            IsMdiContainer = true;
            MainMenuStrip = menuStrip1;
            Name = "FormMain";
            Text = "QUẢN LÝ BÁN HÀNG SIÊU THỊ";
            WindowState = FormWindowState.Maximized;
            Load += FormMain_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem chứcNăngToolStripMenuItem;
        private ToolStripMenuItem mnuExit;
        private ToolStripMenuItem quảnLýToolStripMenuItem;
        private ToolStripMenuItem mnuCustomer;
        private ToolStripMenuItem bánHàngToolStripMenuItem;
        private ToolStripMenuItem trợGiúpToolStripMenuItem;
        private ToolStripMenuItem mnuStore;
        private ToolStripMenuItem mnuManager;
        private ToolStripMenuItem mnuSeller;
        private ToolStripMenuItem mnuProduct;
        private ToolStripMenuItem mnuOrder;
        private ToolStripMenuItem mnuBeverage;
        private ToolStripMenuItem mnuFood;
        private ToolStripMenuItem mnuHouseHold;
        private ToolStripMenuItem mnuOrderList;
        private ToolStripMenuItem mnuInvoiceList;
        private ToolStripMenuItem thôngTinSảnPhẩmToolStripMenuItem;
    }
}
