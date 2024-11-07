using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHangSieuThi.Entity
{
    [Serializable]
    public class Order
    {
        private string code;
        private DateTime createdDate;

        public string Code { get => code; set => code = value; }
        public DateTime CreatedDate { get => createdDate; set => createdDate = value; }
        public virtual Customer Customer { get; set; }
        public virtual string CustomerName
        {
            get
            {
                if (Customer == null)
                    return "";

                return Customer.Name;
            }
        }
        public virtual Seller Seller { get; set; }
        public virtual string SellerName
        {
            get
            {
                if (Seller == null)
                    return "";

                return Seller.Name;
            }
        }
        public virtual List<OrderDetail> Details { get; set; } = new List<OrderDetail>();
        public virtual decimal SumTotal
        {
            get
            {
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
