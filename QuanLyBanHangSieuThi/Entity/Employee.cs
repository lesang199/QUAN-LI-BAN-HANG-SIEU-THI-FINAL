using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHangSieuThi.Entity
{
    [Serializable]
    public class Employee
    {
        private string code;
        private string name;
        private string gender;
        private string phone;
        private string address;

        public string Code { get => code; set => code = value; }
        public string Name { get => name; set => name = value; }
        public string Gender { get => gender; set => gender = value; }
        public string Phone { get => phone; set => phone = value; }
        public string Address { get => address; set => address = value; }
    }
}
