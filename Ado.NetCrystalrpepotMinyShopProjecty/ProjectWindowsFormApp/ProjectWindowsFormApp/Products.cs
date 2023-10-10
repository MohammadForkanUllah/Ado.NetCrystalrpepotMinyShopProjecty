using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace ProjectWindowsFormApp
{
    public partial class Products : Form
    {
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataReader reader;
        DataSet ds;
        DataTable dt;
        string gender;
        public Products()
        {
            InitializeComponent();

            String myConString = ConfigurationManager.ConnectionStrings["myConnection"].ConnectionString;
            conn = new SqlConnection(myConString);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            try
            {
                if (txtName.Text != "" && comboCategory.Text != "" && txtQuantity.Text != "")
                {
                    conn.Open();

                    string sqlQuery = "INSERT INTO Products VALUES(@name,@category,@quantity,@price,@total)";
                    cmd = new SqlCommand(sqlQuery, conn);

                    cmd.Parameters.AddWithValue("@name", txtName.Text);
                    cmd.Parameters.AddWithValue("@category", comboCategory.Text);
                    cmd.Parameters.AddWithValue("@quantity", txtQuantity.Text);

                    cmd.Parameters.AddWithValue("@price", txtPrice.Text);
                    cmd.Parameters.AddWithValue("@total", txtTotl.Text);



                    cmd.ExecuteNonQuery();

                    conn.Close();
                    MessageBox.Show("Record Insert succesfuly..");
                }
                else
                {
                    MessageBox.Show("Wrong input...Try Again");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error found!!" + ex.Message);
            }
        }

        private void lblProducts_Click(object sender, EventArgs e)
        {
            this.Hide();
            Products productPage = new Products();
            productPage.ShowDialog();
        }

        private void lblCustomers_Click(object sender, EventArgs e)
        {
            this.Hide();
            Customers customerPage = new Customers();
            customerPage.ShowDialog();
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

        private void btnLogin_Click(object sender, EventArgs e)
        {

        }
    }
}
