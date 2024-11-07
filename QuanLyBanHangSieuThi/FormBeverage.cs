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
    public partial class FormBeverage : Form
    {
        public FormBeverage()
        {
            InitializeComponent();
        }

        private BeverageDAL _BeverageDAL = new BeverageDAL();
        private List<Beverage> _Beverages = new List<Beverage>();

        BindingSource _src = new BindingSource();
        private void FormBeverage_Load(object sender, EventArgs e)
        {
            gridData.DataSource = _src;
            gridData.AllowUserToAddRows = false;
            gridData.ReadOnly = true;

            chkIsAlcoholic.Checked = true;
            _Beverages = _BeverageDAL.Load();
            DisplayInGrid();
        }

        // Hiển thị dữ liệu từ danh sách ra lưới
        private void DisplayInGrid()
        {
            // Gán nguồn dữ liệu cho BindinSource
            _src.DataSource = _Beverages;
            // Làm tươi lại dữ liệu hiển thị
            _src.ResetBindings(true);
        }

        // Xoá trống các control trên form
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtCode.Text = "";
            txtName.Text = "";
            txtPrice.Text = "";
            txtQty.Text = "";
            chkIsAlcoholic.Checked = false;
        }

        // Lưu lại thông tin
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCode.Text))
            {
                MessageBox.Show("Mã đồ uống không được để trống !"
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

            // Duyệt qua danh sách kiểm tra đã tồn tại mã hàng này chưa
            Beverage Beverage = null;

            for (int i = 0; i < _Beverages.Count; i++)
            {
                if (_Beverages[i].Code.ToLower() == txtCode.Text.ToLower())
                {
                    Beverage = _Beverages[i];
                    break;
                }
            }

            // Nếu không tồn tại thì tạo mới đối tượng và
            // thêm vào danh sách
            if (Beverage == null)
            {
                Beverage = new Beverage(txtCode.Text, txtName.Text, txtPrice.Value, txtQty.Value, chkIsAlcoholic.Checked);
                _Beverages.Add(Beverage);
            }

            // Ngược lại thay đổi các thông tin của đối tượng tìm được
            // trong dánh sách
            Beverage.Name = txtName.Text;
            Beverage.Price = txtPrice.Value;
            Beverage.Qty = txtQty.Value;
            Beverage.IsAlcoholic = chkIsAlcoholic.Checked;

            // Hiển thị thông tin của danh sách mới ra lưới
            DisplayInGrid();

            // Lưu lại danh sách vào tập tin 
            _BeverageDAL.Save(_Beverages);

            // Hiên thị thông báo lưu thành công

            MessageBox.Show("Cập nhật thông tin đồ uống thành công !"
                , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Tìm đối tượng cần xoá trong danh sách

            Beverage Beverage = null;

            for (int i = 0; i < _Beverages.Count; i++)
            {
                if (_Beverages[i].Code.ToLower() == txtCode.Text.ToLower())
                {
                    Beverage = _Beverages[i];
                    break;
                }
            }

            // Nếu tìm thấy thì xoá khỏi danh sách
            if (Beverage != null)
            {
                _Beverages.Remove(Beverage);
            }

            // Hiển thị lại lưới
            DisplayInGrid();

            // Lưu danh sách vào tập tin
            _BeverageDAL.Save(_Beverages);

            // Hiển thị thông báo lưu thông tin thành công

            MessageBox.Show("Xoá thông tin đồ uống thành công !"
                , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        private void gridData_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (gridData.CurrentRow == null || gridData.CurrentRow.IsNewRow)
                return;

            Beverage Beverage = gridData.CurrentRow.DataBoundItem as Beverage;

            if (Beverage == null)
                return;

            Display(Beverage);
        }

        public void Display(Beverage Beverage)
        {
            txtCode.Text = Beverage.Code;
            txtName.Text = Beverage.Name;
            txtPrice.Value = Beverage.Price;
            txtQty.Value = Beverage.Qty;
            chkIsAlcoholic.Checked = Beverage.IsAlcoholic;
        }
    }
}
