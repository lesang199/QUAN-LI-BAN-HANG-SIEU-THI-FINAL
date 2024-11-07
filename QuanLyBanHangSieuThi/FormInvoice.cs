using QuanLyBanHangSieuThi.DAL;
using QuanLyBanHangSieuThi.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyBanHangSieuThi
{
    public partial class FormInvoice : Form
    {
        private Invoice _invoice;
        InvoiceDAL invoiceDAL = new InvoiceDAL();
        public FormInvoice()
        {
            InitializeComponent();
        }

        public FormInvoice(Invoice invoice)
            : this()
        {
            _invoice = invoice;
        }

        BindingSource src = new BindingSource();
        private void FormInvoice_Load(object sender, EventArgs e)
        {
            if (_invoice == null)
            {
                return;
            }
            gridData.DataSource = src;
            gridData.AutoGenerateColumns = false;
            lblCode.Text = _invoice.Code;
            lblCreatedDate.Text = _invoice.CreatedDate.ToString("dd/MM/yyyy");
            lblSellerName.Text = _invoice.Seller.Name;
            lblCustomerName.Text = _invoice.Customer.Name;
            lblSumTotal.Text = _invoice.SumTotal.ToString("#,###");
            src.DataSource = _invoice.Details;
            src.ResetBindings(true);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            List<Invoice> invoices = invoiceDAL.Load();

            Invoice invoice = null;

            for (int i = 0; i < invoices.Count; i++)
            {
                if (_invoice.Code.ToLower() == invoices[i].Code.ToLower())
                {
                    invoices[i] = _invoice;
                    invoice = invoices[i];
                    break;
                }
            }

            if (invoice == null)
            {
                invoices.Add(_invoice);
            }

            invoiceDAL.Save(invoices);

            MessageBox.Show("Lưu thông tin hoá đơn thành công ! "
               , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
