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
    public partial class FormSeller : Form
    {
        public FormSeller()
        {
            InitializeComponent();
        }

        private SellerDAL _SellerDAL = new SellerDAL();
        private List<Seller> _Sellers = new List<Seller>();

        BindingSource _src = new BindingSource();
        private void FormSeller_Load(object sender, EventArgs e)
        {
            gridData.DataSource = _src;
            gridData.AllowUserToAddRows = false;
            gridData.ReadOnly = true;

            rdoMale.Checked = true;
            rdoFemale.Checked = false;
            _Sellers = _SellerDAL.Load();
            DisplayInGrid();
        }

        private void DisplayInGrid()
        {
            _src.DataSource = _Sellers;
            _src.ResetBindings(true);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtCode.Text = "";
            txtName.Text = "";
            txtPhone.Text = "";
            txtAddress.Text = "";
            rdoMale.Checked = true;
            rdoFemale.Checked = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCode.Text))
            {
                MessageBox.Show("Mã nhân viên bán hàng không được để trống !"
                    , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show("Tên khách hàng không được để trống !"
                    , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(txtPhone.Text))
            {
                MessageBox.Show("Số điện thoại không được để trống !"
                    , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(txtAddress.Text))
            {
                MessageBox.Show("Địa chỉ không được để trống !"
                    , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Seller Seller = null;

            for (int i = 0; i < _Sellers.Count; i++)
            {
                if (_Sellers[i].Code.ToLower() == txtCode.Text.ToLower())
                {
                    Seller = _Sellers[i];
                    break;
                }
            }

            if (Seller == null)
            {
                Seller = new Seller();
                _Sellers.Add(Seller);
            }

            Seller.Code = txtCode.Text;
            Seller.Phone = txtPhone.Text;
            Seller.Address = txtAddress.Text;
            Seller.Name = txtName.Text;
            Seller.Gender = rdoMale.Checked ? "Nam" : "Nữ";

            DisplayInGrid();

            // save data in database
            _SellerDAL.Save(_Sellers);

            MessageBox.Show("Cập nhật thông tin nhân viên bán hàng thành công !"
                , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Seller Seller = null;

            for (int i = 0; i < _Sellers.Count; i++)
            {
                if (_Sellers[i].Code.ToLower() == txtCode.Text.ToLower())
                {
                    Seller = _Sellers[i];
                    break;
                }
            }

            if (Seller != null)
            {
                _Sellers.Remove(Seller);
            }

            DisplayInGrid();

            _SellerDAL.Save(_Sellers);


            MessageBox.Show("Xoá thông tin nhân viên bán hàng thành công !"
                , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        private void gridData_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (gridData.CurrentRow == null || gridData.CurrentRow.IsNewRow)
                return;

            Seller Seller = gridData.CurrentRow.DataBoundItem as Seller;

            if (Seller == null)
                return;

            Display(Seller);
        }

        public void Display(Seller Seller)
        {
            txtCode.Text = Seller.Code;
            txtName.Text = Seller.Name;
            rdoMale.Checked = Seller.Gender == "Nam" ? true : false;
            rdoFemale.Checked = Seller.Gender != "Nam" ? true : false;
            txtAddress.Text = Seller.Address;
            txtPhone.Text = Seller.Phone;
        }
    }
}
