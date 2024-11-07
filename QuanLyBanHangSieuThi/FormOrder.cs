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
using static System.Net.Mime.MediaTypeNames;

namespace QuanLyBanHangSieuThi
{
    public partial class FormOrder : Form
    {
        public FormOrder()
        {
            InitializeComponent();
        }

        public FormOrder(Order order)
            : this()
        {
            _order = order;
        }

        private OrderDAL orderDAL = new OrderDAL();
        private SellerDAL sellerDAL = new SellerDAL();
        private CustomerDAL customerDAL = new CustomerDAL();
        private BeverageDAL beverageDAL = new BeverageDAL();
        private FoodDAL foodDAL = new FoodDAL();
        private HouseHoldItemDAL houseHoldItemDAL = new HouseHoldItemDAL();
        private List<Order> orders;
        private List<Product> products = new List<Product>();
        private void FormOrder_Load(object sender, EventArgs e)
        {
            gridDataDetail.ReadOnly = true;
            gridDataDetail.AllowUserToAddRows = false;
            gridDataDetail.AutoGenerateColumns = false;
            gridDataDetail.DataSource = src;
            orders = orderDAL.Load();
            LoadProducts();
            LoadSellers();
            LoadCustomers();
            if (_order == null)
                _order = new Order();
            else
            {
                txtCode.Text = _order.Code;
                dtCreateDate.Value = _order.CreatedDate;
                cboSeller.SelectedValue = _order.Seller.Code;
                cboCustomer.SelectedValue = _order.Customer.Code;
                src.DataSource = _order.Details;
                src.ResetBindings(true);
            }
        }

        private void LoadCustomers()
        {
            List<Customer> customers = customerDAL.Load();
            cboCustomer.DataSource = customers;
            cboCustomer.ValueMember = "Code";
            cboCustomer.DisplayMember = "Name";
            if (cboCustomer.Items.Count > 0)
                cboCustomer.SelectedIndex = 0;
        }

        private void LoadSellers()
        {
            List<Seller> sellers = sellerDAL.Load();
            cboSeller.DataSource = sellers;
            cboSeller.ValueMember = "Code";
            cboSeller.DisplayMember = "Name";
            if (cboSeller.Items.Count > 0)
                cboSeller.SelectedIndex = 0;
        }

        private void LoadProducts()
        {
            List<Beverage> beverages = beverageDAL.Load();
            List<Food> foods = foodDAL.Load();
            List<HouseHoldItem> houseHoldItems = houseHoldItemDAL.Load();

            for (int i = 0; i < beverages.Count; i++)
            {
                products.Add(beverages[i]);
            }

            for (int i = 0; i < foods.Count; i++)
            {
                products.Add(foods[i]);
            }

            for (int i = 0; i < houseHoldItems.Count; i++)
            {
                products.Add(houseHoldItems[i]);
            }

            cboProduct.DataSource = products;
            cboProduct.ValueMember = "Code";
            cboProduct.DisplayMember = "Name";

            if (cboProduct.Items.Count > 0)
                cboProduct.SelectedIndex = 0;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtCode.Text = "";
            dtCreateDate.Value = DateTime.Now;
            cboCustomer.SelectedIndex = 0;
            cboSeller.SelectedIndex = 0;
            cboProduct.SelectedIndex = 0;
            txtQty.Value = 0;
            _order = new Order();
        }

        private Order _order;

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCode.Text))
            {
                MessageBox.Show("Mã đơn hàng không được để trống !"
                  , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (cboSeller.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn nhân viên bán hàng !"
                  , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (cboCustomer.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn khách hàng !"
                  , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (_order == null)
            {
                MessageBox.Show("Không có đơn hàng nào được khởi tạo ! Vui lòng nhấn làm mới để nhập đơn hàng "
                 , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (_order.Details.Count <= 0)
            {
                MessageBox.Show("Không có sản phẩm nào trong đơn hàng, không thể lưu đơn hàng này ! "
                 , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Kiểm tra trùng order
            bool found = false;

            for (int i = 0; i < orders.Count; i++)
            {
                if (orders[i].Code.ToLower() == txtCode.Text.ToLower())
                {
                    orders[i] = _order;
                    found = true;
                    break;
                }
            }

            if (!found)
                orders.Add(_order);

            // Gán các giá trị nhập cho order
            _order.Code = txtCode.Text;
            _order.CreatedDate = dtCreateDate.Value;
            _order.Seller = cboSeller.SelectedItem as Seller;
            _order.Customer = cboCustomer.SelectedItem as Customer;

            orderDAL.Save(orders);

            // Cập nhật lại số lượng sản phẩm

            List<Beverage> beverages = beverageDAL.Load();
            List<Food> foods = foodDAL.Load();
            List<HouseHoldItem> houseHoldItems = houseHoldItemDAL.Load();

            for (int i = 0; i < _order.Details.Count; i++)
            {
                if (_order.Details[i].Product is Beverage)
                {
                    for (int j = 0; j < beverages.Count; j++)
                    {
                        if (beverages[j].Code.ToLower() == _order.Details[i].Product.Code.ToLower())
                        {
                            beverages[j].Qty = beverages[j].Qty - _order.Details[i].Qty;
                            if (beverages[j].Qty < 0)
                                beverages[j].Qty = 0;
                            break;
                        }
                    }
                }

                if (_order.Details[i].Product is Food)
                {
                    for (int j = 0; j < foods.Count; j++)
                    {
                        if (foods[j].Code.ToLower() == _order.Details[i].Product.Code.ToLower())
                        {
                            foods[j].Qty = foods[j].Qty - _order.Details[i].Qty;
                            if (foods[j].Qty < 0)
                                foods[j].Qty = 0;
                            break;
                        }
                    }
                }

                if (_order.Details[i].Product is HouseHoldItem)
                {
                    for (int j = 0; j < houseHoldItems.Count; j++)
                    {
                        if (houseHoldItems[j].Code.ToLower() == _order.Details[i].Product.Code.ToLower())
                        {
                            houseHoldItems[j].Qty = houseHoldItems[j].Qty - _order.Details[i].Qty;
                            if (houseHoldItems[j].Qty < 0)
                                houseHoldItems[j].Qty = 0;
                            break;
                        }
                    }
                }
            }

            beverageDAL.Save(beverages);
            foodDAL.Save(foods);
            houseHoldItemDAL.Save(houseHoldItems);

            // Nạp lại số lượng thực tế
            LoadProducts();

            MessageBox.Show("Lưu thông tin đơn hàng thành công ! "
                 , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;

        }

        BindingSource src = new BindingSource();
        private void btnAddDetail_Click(object sender, EventArgs e)
        {
            if (_order == null)
            {
                MessageBox.Show("Không có đơn hàng nào được khởi tạo ! Vui lòng nhấn làm mới để nhập đơn hàng "
                 , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (cboProduct.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn sản phẩm hàng hoá ! "
                 , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (txtQty.Value <= 0)
            {
                MessageBox.Show("Số lượng hàng hoá phải lớn hơn 0 !"
                 , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Product product = cboProduct.SelectedItem as Product;

            if (product.Qty - txtQty.Value < 0)
            {

                MessageBox.Show("Sản phẩm không đủ số lượng ! Chỉ còn lại " + product.Qty + " sản phẩm !"
                 , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            bool found = false;

            for (int i = 0; i < _order.Details.Count; i++)
            {
                if (_order.Details[i].Product.Code.ToLower() == product.Code.ToLower())
                {
                    found = true;
                    _order.Details[i].Qty = _order.Details[i].Qty + txtQty.Value;
                    break;
                }
            }

            if (!found)
            {
                _order.Details.Add(new OrderDetail()
                {
                    Product = product,
                    Qty = txtQty.Value,
                });
            }

            // Trừ số lượng trong sản phẩm

            product.Qty = product.Qty - txtQty.Value;

            src.DataSource = _order.Details;
            src.ResetBindings(true);

        }

        private void btnDeleteDetail_Click(object sender, EventArgs e)
        {
            if (_order == null)
            {
                MessageBox.Show("Không có đơn hàng nào được khởi tạo ! Vui lòng nhấn làm mới để nhập đơn hàng "
                 , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (cboProduct.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn sản phẩm hàng hoá ! "
                 , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Product product = cboProduct.SelectedItem as Product;

            for (int i = 0; i < _order.Details.Count; i++)
            {
                if (_order.Details[i].Product.Code.ToLower() == product.Code.ToLower())
                {
                    product.Qty = product.Qty + _order.Details[i].Qty;
                    _order.Details.Remove(_order.Details[i]);
                    break;
                }
            }

            src.DataSource = _order.Details;
            src.ResetBindings(true);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCode.Text))
            {
                MessageBox.Show("Mã đơn hàng không được để trống !"
                  , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Order toDelete = null;

            for (int i = 0; i < orders.Count; i++)
            {
                if (orders[i].Code.ToLower() == txtCode.Text.ToLower())
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

            // Nạp lại số lượng thực tế
            LoadProducts();

            txtCode.Text = "";
            dtCreateDate.Value = DateTime.Now;
            cboCustomer.SelectedIndex = 0;
            cboSeller.SelectedIndex = 0;
            cboProduct.SelectedIndex = 0;
            txtQty.Value = 0;

            MessageBox.Show("Xoá thông tin đơn hàng thành công ! "
                 , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        private void btnViewInvoice_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCode.Text))
            {
                MessageBox.Show("Mã đơn hàng không được để trống !"
                  , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Order order = null;

            for (int i = 0; i < orders.Count; i++)
            {
                if (orders[i].Code.ToLower() == txtCode.Text.ToLower())
                {
                    order = orders[i];
                    break;
                }
            }

            if (order == null)
            {
                MessageBox.Show("Không tìm thấy đơn hàng ! "
               , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
