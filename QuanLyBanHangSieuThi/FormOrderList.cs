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
    public partial class FormOrderList : Form
    {
        public FormOrderList()
        {
            InitializeComponent();
        }

        private BeverageDAL beverageDAL = new BeverageDAL();
        private FoodDAL foodDAL = new FoodDAL();
        private HouseHoldItemDAL houseHoldItemDAL = new HouseHoldItemDAL();
        OrderDAL orderDAL = new OrderDAL();
        BindingSource src = new BindingSource();
        private void FormOrderList_Load(object sender, EventArgs e)
        {
            gridData.ReadOnly = true;
            gridData.AllowUserToAddRows = false;
            gridData.AutoGenerateColumns = false;
            gridData.DataSource = src;
            LoadGrid();
        }

        private void LoadGrid()
        {
            src.DataSource = orderDAL.Load();
            src.ResetBindings(true);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FormOrder frm = new FormOrder();
            frm.ShowDialog();
            LoadGrid();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (gridData.CurrentRow == null || gridData.CurrentRow.IsNewRow)
                return;

            Order order = gridData.CurrentRow.DataBoundItem as Order;

            if (order == null)
                return;

            FormOrder frm = new FormOrder(order);
            frm.ShowDialog();

            LoadGrid();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (gridData.CurrentRow == null || gridData.CurrentRow.IsNewRow)
                return;

            Order order = gridData.CurrentRow.DataBoundItem as Order;

            if (order == null)
            {
                MessageBox.Show("Không có đơn hàng nào được chọn !"
                 , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (MessageBox.Show("Bạn muốn xoá đơn hàng được chọn ?"
                , "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                List<Order> orders = orderDAL.Load();
                Order toDelete = null;
                for (int i = 0; i < orders.Count; i++)
                {
                    if (orders[i].Code.ToLower() == order.Code.ToLower())
                    {
                        toDelete = orders[i];
                        break;
                    }
                }

                if (toDelete == null)
                {
                    MessageBox.Show("Không tìm thấy đơn hàng cần xoá !"
                 , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                // Cập nhật lại số lượng sản phẩm

                List<Beverage> beverages = beverageDAL.Load();
                List<Food> foods = foodDAL.Load();
                List<HouseHoldItem> houseHoldItems = houseHoldItemDAL.Load();

                for (int i = 0; i < toDelete.Details.Count; i++)
                {
                    if (toDelete.Details[i].Product is Beverage)
                    {
                        for (int j = 0; j < beverages.Count; j++)
                        {
                            if (beverages[j].Code.ToLower() == toDelete.Details[i].Product.Code.ToLower())
                            {
                                beverages[j].Qty = beverages[j].Qty + toDelete.Details[i].Qty;
                                break;
                            }
                        }
                    }

                    if (toDelete.Details[i].Product is Food)
                    {
                        for (int j = 0; j < foods.Count; j++)
                        {
                            if (foods[j].Code.ToLower() == toDelete.Details[i].Product.Code.ToLower())
                            {
                                foods[j].Qty = foods[j].Qty + toDelete.Details[i].Qty;

                                break;
                            }
                        }
                    }

                    if (toDelete.Details[i].Product is HouseHoldItem)
                    {
                        for (int j = 0; j < houseHoldItems.Count; j++)
                        {
                            if (houseHoldItems[j].Code.ToLower() == toDelete.Details[i].Product.Code.ToLower())
                            {
                                houseHoldItems[j].Qty = houseHoldItems[j].Qty + toDelete.Details[i].Qty;
                                break;
                            }
                        }
                    }
                }

                beverageDAL.Save(beverages);
                foodDAL.Save(foods);
                houseHoldItemDAL.Save(houseHoldItems);
                orders.Remove(toDelete);
                orderDAL.Save(orders);
                LoadGrid();
            }
        }

        private void btnXemHoaDon_Click(object sender, EventArgs e)
        {
            if (gridData.CurrentRow == null || gridData.CurrentRow.IsNewRow)
                return;

            Order order = gridData.CurrentRow.DataBoundItem as Order;

            if (order == null)
            {
                MessageBox.Show("Không có đơn hàng nào được chọn !"
                 , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Invoice invoice = new Invoice();
            invoice.Code = order.Code;
            invoice.CreatedDate = order.CreatedDate;
            invoice.Seller = order.Seller;
            invoice.Customer = order.Customer;

            for (int i = 0; i < order.Details.Count; i++)
            {
                invoice.Details.Add(new InvoiceDetail()
                {
                    ProductCode = order.Details[i].Product.Code,
                    ProductName = order.Details[i].Product.Name,
                    Qty = order.Details[i].Qty,
                    Price = order.Details[i].Product.Price
                });

            }

            FormInvoice frm = new FormInvoice(invoice);
            frm.ShowDialog();
        }
    }
}
