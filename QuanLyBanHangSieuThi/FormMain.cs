namespace QuanLyBanHangSieuThi
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void LoadForm(Form current)
        {
            if (current == null)
                return;

            foreach (Form frm in this.MdiChildren)
            {
                frm.Dispose();
                frm.Close();
            }

            current.MdiParent = this;
            current.Show();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {

        }

        private void mnuCustomer_Click(object sender, EventArgs e)
        {
            LoadForm(new FormCustomer());
        }

        private void mnuStore_Click(object sender, EventArgs e)
        {
            LoadForm(new FormStore());
        }

        private void mnuManager_Click(object sender, EventArgs e)
        {
            LoadForm(new FormManager());
        }

        private void mnuSeller_Click(object sender, EventArgs e)
        {
            LoadForm(new FormSeller());
        }

        private void mnuProduct_Click(object sender, EventArgs e)
        {
            LoadForm(new FormProduct());
        }

        private void mnuOrder_Click(object sender, EventArgs e)
        {
            LoadForm(new FormOrder());
        }

        private void mnuExit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn muốn thoát ứng dụng ?", "Quản Lý Bán Hàng Siêu Thị - Thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
                Application.Exit();
        }

        private void đồUốngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadForm(new FormBeverage());
        }

        private void mnuFood_Click(object sender, EventArgs e)
        {
            LoadForm(new FormFood());
        }

        private void mnuHouseHold_Click(object sender, EventArgs e)
        {
            LoadForm(new FormHouseHoldItem());
        }

        private void mnuOrderList_Click(object sender, EventArgs e)
        {
            LoadForm(new FormOrderList());
        }

        private void mnuInvoiceList_Click(object sender, EventArgs e)
        {
            LoadForm(new FormInvoiceList());
        }

        private void thôngTinSảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FormAbout().ShowDialog();
        }
    }
}
