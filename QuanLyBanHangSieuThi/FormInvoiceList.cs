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
    public partial class FormInvoiceList : Form
    {
        public FormInvoiceList()
        {
            InitializeComponent();
        }

        InvoiceDAL invoiceDAL = new InvoiceDAL();
        BindingSource src = new BindingSource();
        private void FormInvoiceList_Load(object sender, EventArgs e)
        {
            gridData.AutoGenerateColumns = false;
            gridData.AllowUserToAddRows = false;
            gridData.ReadOnly = true;
            gridData.DataSource = src;
            LoadGrid();
        }

        private void LoadGrid()
        {
            src.DataSource = invoiceDAL.Load();
            src.ResetBindings(true);
        }

        private void btnXemHoaDon_Click(object sender, EventArgs e)
        {
            if (gridData.CurrentRow == null || gridData.CurrentRow.IsNewRow)
                return;
            
            Invoice invoice = gridData.CurrentRow.DataBoundItem as Invoice;

            if (invoice == null)
                return;
            
            FormInvoice frm = new FormInvoice(invoice);
            frm.ShowDialog();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (gridData.CurrentRow == null || gridData.CurrentRow.IsNewRow)
                return;
            
            Invoice invoice = gridData.CurrentRow.DataBoundItem as Invoice;

            if (invoice == null)
            {
                MessageBox.Show("Không tìm thấy hoá đơn cần xoá ! "
              , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (MessageBox.Show("Bạn muốn xoá hoá đơn được chọn ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            List<Invoice> invoices = invoiceDAL.Load();
            
            Invoice toDelete = null;
            
            for (int i = 0; i < invoices.Count; i++)
            {
                if (invoices[i].Code.ToLower() == invoice.Code.ToLower())
                {
                    toDelete = invoices[i];
                    break;
                }
            }

            if (toDelete != null)
            { 
                invoices.Remove(toDelete);
            }

            invoiceDAL.Save(invoices);

            LoadGrid();
            
        }
    }
}
