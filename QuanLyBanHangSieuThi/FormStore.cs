using QuanLyBanHangSieuThi.DAL;
using QuanLyBanHangSieuThi.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyBanHangSieuThi
{
    public partial class FormStore : Form
    {
        public FormStore()
        {
            InitializeComponent();
        }

        StoreDAL _storeDAL = new StoreDAL();
        ManagerDAL managerDAL = new ManagerDAL();
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtName.Text = "";
            txtAddress.Text = "";
            
        }

        private void FormStore_Load(object sender, EventArgs e)
        {
            cboManager.DataSource = managerDAL.Load();
            cboManager.ValueMember = "Code";
            cboManager.DisplayMember = "Name";
            
            if (cboManager.Items.Count > 0)
                cboManager.SelectedIndex = 0;

            Store store = _storeDAL.Load();
            Display(store);
        }

        private void Display(Store store)
        {
            txtName.Text = store.Name;
            txtAddress.Text = store.Address;

            if (store.Manager != null)
            {
                cboManager.SelectedValue = store.Manager.Code;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show("Tên cửa hàng không được để trống !",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(txtAddress.Text))
            {
                MessageBox.Show("Địa chỉ cửa hàng không được để trống !",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (cboManager.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn quản lý !"
                    , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            } 


            Store store = new Store();
            store.Name = txtName.Text;
            store.Address = txtAddress.Text;
            store.Manager = cboManager.SelectedItem as Manager;

            _storeDAL.Save(store);

            MessageBox.Show("Lưu thông tin cửa hàng thành công !"
             , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }
    }
}
