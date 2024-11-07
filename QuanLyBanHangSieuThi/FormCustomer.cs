using QuanLyBanHangSieuThi.DAL;
using QuanLyBanHangSieuThi.Entity;
using QuanLyBanHangSieuThi.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyBanHangSieuThi
{
    public partial class FormCustomer : Form
    {
        public FormCustomer()
        {
            InitializeComponent();
        }

        private CustomerDAL _customerDAL = new CustomerDAL();
        private List<Customer> _customers = new List<Customer>();

        BindingSource _src = new BindingSource();
        private void FormCustomer_Load(object sender, EventArgs e)
        {
            gridData.DataSource = _src;
            gridData.AllowUserToAddRows = false;
            gridData.ReadOnly = true;

            rdoMale.Checked = true;
            rdoFemale.Checked = false;
            _customers = _customerDAL.Load();
            DisplayInGrid();
        }

        private void DisplayInGrid()
        {
            _src.DataSource = _customers;
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
                MessageBox.Show("Mã khách hàng không được để trống !"
                    , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show("Tên khách hàng không được để trống !"
                    , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error );
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

            Customer customer = null;

            for (int i = 0; i < _customers.Count; i++)
            {
                if (_customers[i].Code.ToLower() == txtCode.Text.ToLower())
                {
                    customer = _customers[i];
                    break;
                }
            }

            if (customer == null)
            {
                customer = new Customer();
                _customers.Add(customer);
            }

            customer.Code = txtCode.Text;
            customer.Phone = txtPhone.Text;
            customer.Address = txtAddress.Text;
            customer.Name = txtName.Text;
            customer.Gender = rdoMale.Checked ? "Nam" : "Nữ";

            DisplayInGrid();

            // save data in database
            _customerDAL.Save(_customers);

            MessageBox.Show("Cập nhật thông tin khách hàng thành công !"
                , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Customer customer = null;

            for (int i = 0; i < _customers.Count; i++)
            {
                if (_customers[i].Code.ToLower() == txtCode.Text.ToLower())
                {
                    customer = _customers[i];
                    break;
                }
            }

            if (customer != null)
            {
                _customers.Remove(customer);
            }

            DisplayInGrid();

            _customerDAL.Save(_customers);


            MessageBox.Show("Xoá thông tin khách hàng thành công !"
                , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        private void gridData_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (gridData.CurrentRow == null || gridData.CurrentRow.IsNewRow)
                return;

            Customer customer = gridData.CurrentRow.DataBoundItem as Customer;
            
            if (customer == null)
                return;

            Display(customer);
        }

        public void Display(Customer customer)
        {
            txtCode.Text = customer.Code;
            txtName.Text = customer.Name;
            rdoMale.Checked = customer.Gender == "Nam" ? true : false;
            rdoFemale.Checked = customer.Gender != "Nam" ? true : false;
            txtAddress.Text = customer.Address;
            txtPhone.Text = customer.Phone;
        }
    }
}
