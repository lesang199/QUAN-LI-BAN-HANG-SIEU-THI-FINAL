using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHangSieuThi.Entity
{
    [Serializable]
    public class OrderDetail
    {
        private Product product;
        private decimal qty;

        public Product Product { get => product; set => product = value; }
        public string Code
        {
            get
            {
                if (Product == null)
                    return "";

                return this.Product.Code;
            }
        }

        public string Name
        {
            get {
                if (Product == null)
                    return "";
                return this.Product.Name; 
            }
        }

        public decimal Qty { get => qty; set => qty = value; }

        public decimal Total
        {
            get
            {
                if (Product == null)
                    return 0;

                return Product.Price * Qty;
            }
        }
    }
}
