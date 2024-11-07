using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHangSieuThi.Entity
{
    [Serializable]
    public class Store
    {
        private string name;
        private string address;
        private Manager manager;

        public string Name { get => name; set => name = value; }
        public string Address { get => address; set => address = value; }
        public virtual Manager Manager { get => manager; set => manager = value; }
        public virtual List<Product> Products { get; set; } = new List<Product>();
        public virtual List<Customer> Customers { get; set; } = new List<Customer>();

    }
}
