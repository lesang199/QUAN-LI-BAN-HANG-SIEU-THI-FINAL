using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHangSieuThi.Entity
{
    [Serializable]
    public class InvoiceDetail
    {
        private string productCode;
        private string productName;
        private decimal price = 0;
        private decimal qty = 0;

        public string ProductCode { get => productCode; set => productCode = value; }
        public string ProductName { get => productName; set => productName = value; }
        public decimal Price { get => price; set => price = value; }
        public decimal Qty { get => qty; set => qty = value; }
        public decimal Total {
            get
            {
                return Qty * Price; 
            }
        }
    }
}
