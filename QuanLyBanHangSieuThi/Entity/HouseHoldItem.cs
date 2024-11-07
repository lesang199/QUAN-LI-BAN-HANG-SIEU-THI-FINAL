using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHangSieuThi.Entity
{
    [Serializable]
    public class HouseHoldItem : Product
    {
        private string brand;

        public string Brand { get => brand; set => brand = value; }

        public HouseHoldItem(string code, string name, decimal price, decimal qty, string brand)
            : base(code, name, price, qty)
        {
            Brand = brand;
        }

        // Ghi đè lại phương thức Display Info để hiển thị thông tin của loại sản phẩm
        // hiện tại
        public override string DisplayInfo()
        {
            return ($"Đồ gia dụng. Thương hiệu: {Brand}");
        }
    }
}
