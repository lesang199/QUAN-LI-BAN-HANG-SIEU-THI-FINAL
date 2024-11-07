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
    public partial class FormFood : Form
    {
        public FormFood()
        {
            InitializeComponent();
        }

        private FoodDAL _FoodDAL = new FoodDAL();
        private List<Food> _Foods = new List<Food>();

        BindingSource _src = new BindingSource();
        private void FormFood_Load(object sender, EventArgs e)
        {
            gridData.DataSource = _src;
            gridData.AllowUserToAddRows = false;
            gridData.ReadOnly = true;
            _Foods = _FoodDAL.Load();
            DisplayInGrid();
        }

        private void DisplayInGrid()
        {
            _src.DataSource = _Foods;
            _src.ResetBindings(true);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtCode.Text = "";
            txtName.Text = "";
            txtPrice.Text = "";
            txtQty.Text = "";
            dtExpirationDate.Value = DateTime.Now;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCode.Text))
            {
                MessageBox.Show("Mã thực phẩm không được để trống !"
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

            Food Food = null;

            for (int i = 0; i < _Foods.Count; i++)
            {
                if (_Foods[i].Code.ToLower() == txtCode.Text.ToLower())
                {
                    Food = _Foods[i];
                    break;
                }
            }

            if (Food == null)
            {
                Food = new Food(txtCode.Text, txtName.Text, txtPrice.Value, txtQty.Value, dtExpirationDate.Value);
                _Foods.Add(Food);
            }

            Food.Name = txtName.Text;
            Food.Price = txtPrice.Value;
            Food.Qty = txtQty.Value;
            Food.ExpirationDate = dtExpirationDate.Value;

            DisplayInGrid();

            // save data in database
            _FoodDAL.Save(_Foods);

            MessageBox.Show("Cập nhật thông tin thực phẩm thành công !"
                , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Food Food = null;

            for (int i = 0; i < _Foods.Count; i++)
            {
                if (_Foods[i].Code.ToLower() == txtCode.Text.ToLower())
                {
                    Food = _Foods[i];
                    break;
                }
            }

            if (Food != null)
            {
                _Foods.Remove(Food);
            }

            DisplayInGrid();

            _FoodDAL.Save(_Foods);


            MessageBox.Show("Xoá thông tin thực phẩm thành công !"
                , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        private void gridData_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (gridData.CurrentRow == null || gridData.CurrentRow.IsNewRow)
                return;

            Food Food = gridData.CurrentRow.DataBoundItem as Food;

            if (Food == null)
                return;

            Display(Food);
        }

        public void Display(Food Food)
        {
            txtCode.Text = Food.Code;
            txtName.Text = Food.Name;
            txtPrice.Value = Food.Price;
            txtQty.Value = Food.Qty;
            dtExpirationDate.Value = Food.ExpirationDate;
        }
    }
}
