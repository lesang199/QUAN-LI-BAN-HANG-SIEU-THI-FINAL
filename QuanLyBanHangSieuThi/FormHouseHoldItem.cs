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
    public partial class FormHouseHoldItem : Form
    {
        public FormHouseHoldItem()
        {
            InitializeComponent();
        }


        private HouseHoldItemDAL _HouseHoldItemDAL = new HouseHoldItemDAL();
        private List<HouseHoldItem> _HouseHoldItems = new List<HouseHoldItem>();

        BindingSource _src = new BindingSource();
        private void FormHouseHoldItem_Load(object sender, EventArgs e)
        {
            gridData.DataSource = _src;
            gridData.AllowUserToAddRows = false;
            gridData.ReadOnly = true;
            cboBrand.Items.Clear();
            cboBrand.Items.Add("Sony");
            cboBrand.Items.Add("Samsung");
            cboBrand.Items.Add("Apple");
            cboBrand.Items.Add("Nature Hike");
            cboBrand.Items.Add("IKIA");
            cboBrand.SelectedIndex = 0;
            _HouseHoldItems = _HouseHoldItemDAL.Load();
            DisplayInGrid();
        }

        private void DisplayInGrid()
        {
            _src.DataSource = _HouseHoldItems;
            _src.ResetBindings(true);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtCode.Text = "";
            txtName.Text = "";
            txtPrice.Text = "";
            txtQty.Text = "";
            cboBrand.SelectedIndex = 0;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCode.Text))
            {
                MessageBox.Show("Mã đồ gia dụng không được để trống !"
                    , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show("Tên sản phẩm không được để trống !",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (txtPrice.Value < 0)
            {
                MessageBox.Show("Giá sản phẩm không được bé hơn 0 !",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (txtQty.Value < 0)
            {
                MessageBox.Show("Số lượng sản phẩm không được bé hơn 0 !",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (cboBrand.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn nhãn hiệu !"
                   , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            HouseHoldItem HouseHoldItem = null;

            for (int i = 0; i < _HouseHoldItems.Count; i++)
            {
                if (_HouseHoldItems[i].Code.ToLower() == txtCode.Text.ToLower())
                {
                    HouseHoldItem = _HouseHoldItems[i];
                    break;
                }
            }

            if (HouseHoldItem == null)
            {
                HouseHoldItem = new HouseHoldItem(txtCode.Text, txtName.Text, txtPrice.Value, txtQty.Value, (string) cboBrand.SelectedItem);
                _HouseHoldItems.Add(HouseHoldItem);
            }

            HouseHoldItem.Name = txtName.Text;
            HouseHoldItem.Price = txtPrice.Value;
            HouseHoldItem.Qty = txtQty.Value;
            HouseHoldItem.Brand = (string) cboBrand.SelectedItem;

            DisplayInGrid();

            // save data in database
            _HouseHoldItemDAL.Save(_HouseHoldItems);

            MessageBox.Show("Cập nhật thông tin đồ gia dụng thành công !"
                , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            HouseHoldItem HouseHoldItem = null;

            for (int i = 0; i < _HouseHoldItems.Count; i++)
            {
                if (_HouseHoldItems[i].Code.ToLower() == txtCode.Text.ToLower())
                {
                    HouseHoldItem = _HouseHoldItems[i];
                    break;
                }
            }

            if (HouseHoldItem != null)
            {
                _HouseHoldItems.Remove(HouseHoldItem);
            }

            DisplayInGrid();

            _HouseHoldItemDAL.Save(_HouseHoldItems);


            MessageBox.Show("Xoá thông tin đồ gia dụng thành công !"
                , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        private void gridData_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (gridData.CurrentRow == null || gridData.CurrentRow.IsNewRow)
                return;

            HouseHoldItem HouseHoldItem = gridData.CurrentRow.DataBoundItem as HouseHoldItem;

            if (HouseHoldItem == null)
                return;

            Display(HouseHoldItem);
        }

        public void Display(HouseHoldItem HouseHoldItem)
        {
            txtCode.Text = HouseHoldItem.Code;
            txtName.Text = HouseHoldItem.Name;
            txtPrice.Value = HouseHoldItem.Price;
            txtQty.Value = HouseHoldItem.Qty;
            cboBrand.SelectedItem = HouseHoldItem.Brand;
        }
    }
}
