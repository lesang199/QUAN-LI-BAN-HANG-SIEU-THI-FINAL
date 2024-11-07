using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHangSieuThi.Entity
{
    [Serializable]
    public class Invoice
    {
        private string code;
        private DateTime createdDate;
        private Customer customer;
        private Seller seller;
        private List<InvoiceDetail> details = new List<InvoiceDetail>();

        public string Code { get => code; set => code = value; }
        public DateTime CreatedDate { get => createdDate; set => createdDate = value; }
        public virtual Customer Customer { get => customer; set => customer = value; }
        public virtual string CustomerName
        {
            get
            {
                if (Customer == null)
                    return "";

                return Customer.Name;
            }
        }
        public virtual Seller Seller { get => seller; set => seller = value; }
        public virtual string SellerName
        {
            get
            {
                if (Seller == null)
                    return "";

                return Seller.Name;
            }
        }
        public virtual List<InvoiceDetail> Details { get => details; set => details = value; }
        public virtual decimal SumTotal {
            get {
                decimal sumTotal = 0;

                for (int i = 0; i < Details.Count; i++)
                { 
                    sumTotal += Details[i].Total;
                }
                return sumTotal;
            }
        }
    }
}
