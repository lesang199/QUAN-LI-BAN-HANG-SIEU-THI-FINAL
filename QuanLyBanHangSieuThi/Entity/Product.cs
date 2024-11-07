using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHangSieuThi.Entity
{
    // Lớp abstract không thể tạo đối tượng của lớp abtract
    [Serializable]
    public abstract class Product
    {
        private string code;
        private string name;
        private decimal price;
        private decimal qty;

        public string Code { get => code; set => code = value; }
        public string Name { get => name; set => name = value; }
        public decimal Price { get => price; set => price = value; }
        public decimal Qty { get => qty; set => qty = value; }

        public Product(string code, string name, decimal price, decimal qty)
        {
            Code = code;
            Name = name;
            Price = price;
            Qty = qty;
        }

        // Phương thức DisplayInfo là phương thức trừu tượng
        // không có phần hiện thực cụ thể tại lớp Product
        // các lớp kế thừa sẽ hiện thực phương thức này và hiển thị 
        // các thông tin cụ thể tuỳ vào từng loại thực phẩm được kế thừa
        // (tính đa hình)
        public abstract string DisplayInfo();

        public string Info
        {
            get
            {
                return DisplayInfo();
            }
        }
    }
}
