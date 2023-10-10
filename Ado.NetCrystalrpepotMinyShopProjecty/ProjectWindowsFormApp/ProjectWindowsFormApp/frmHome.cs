using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectWindowsFormApp
{
    public partial class frmHome : Form
    {
        public frmHome()
        {
            InitializeComponent();
        }

        private void lblCustomers_Click(object sender, EventArgs e)
        {
            this.Hide();
            Customers customerPage = new Customers();
            customerPage.ShowDialog();
        }

        private void lblProducts_Click(object sender, EventArgs e)
        {
            this.Hide();
            Products productPage = new Products();
            productPage.ShowDialog();

        }

        private void lblOrders_Click(object sender, EventArgs e)
        {
            this.Hide();
            Orders orderPage = new Orders();
            orderPage.ShowDialog();
        }

        private void lblSupplier_Click(object sender, EventArgs e)
        {
            this.Hide();
            Suppliers SupplierPage = new Suppliers();
            SupplierPage.ShowDialog();
        }
    }
}
