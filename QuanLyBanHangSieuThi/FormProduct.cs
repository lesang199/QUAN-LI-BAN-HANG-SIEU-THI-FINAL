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
    public partial class FormProduct : Form
    {
        public FormProduct()
        {
            InitializeComponent();
        }

        private BeverageDAL beverageDAL = new BeverageDAL();
        private FoodDAL foodDAL = new FoodDAL();
        private HouseHoldItemDAL houseHoldItemDAL = new HouseHoldItemDAL();

        // Danh sách chứa đối tượng sản phẩm tổng quát
        // không phụ thuộc vào sản phẩm cụ thể thuộc loại nào
        private List<Product> products = new List<Product>();

        BindingSource src = new BindingSource();
        private void FormProduct_Load(object sender, EventArgs e)
        {
            gridData.ReadOnly = true;
            gridData.DataSource = src;
            LoadProducts();
        }

        private void LoadProducts()
        {
            // Lấy ra danh sách các sản phẩm thuộc các thể loại khác
            // nhau nạp vào danh sách sản phẩm tổng quát
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

            // Gán dữ liệu danh sách tổng quát vào BindingSource để hiển thị ra lưới
            src.DataSource = products;
            // Làm tươi lưới dữ liệu
            src.ResetBindings(true);
        }
    }
}
