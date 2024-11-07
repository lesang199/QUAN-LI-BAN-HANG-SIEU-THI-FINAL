using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHangSieuThi.Entity
{
    [Serializable]
    public class Beverage : Product
    {
        private bool isAlcoholic;

        public bool IsAlcoholic { get => isAlcoholic; set => isAlcoholic = value; }

        public Beverage(string code, string name, decimal price, decimal qty, bool isAlcoholic)
            : base(code, name, price, qty)
        {
            IsAlcoholic = isAlcoholic;
        }

        public override string DisplayInfo()
        {
            return ($"Đồ uống. Có chứa cồn: {IsAlcoholic}");
        }
    }
}
