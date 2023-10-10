using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace ProjectWindowsFormApp
{
    public partial class Orders : Form
    {
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataReader reader;
        DataSet ds;
        DataTable dt;
        string gender;
        public Orders()
        {
            InitializeComponent();

            String myConString = ConfigurationManager.ConnectionStrings["myConnection"].ConnectionString;
            conn = new SqlConnection(myConString);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {


            try
            {
                if (txtType.Text != "" && dateTime.Text != "" && txtQuantity.Text != "")
                {
                    conn.Open();

                    string sqlQuery = "INSERT INTO Orders VALUES(@type,@quantity,@rate,@discount,@totalPrice,@dateTime)";
                    cmd = new SqlCommand(sqlQuery, conn);

                    cmd.Parameters.AddWithValue("@type", txtType.Text);
                   
                    cmd.Parameters.AddWithValue("@quantity", txtQuantity.Text);
                    cmd.Parameters.AddWithValue("@rate", txtRate.Text);
                    cmd.Parameters.AddWithValue("@discount", txtdiscount.Text);
                    cmd.Parameters.AddWithValue("@totalPrice", totalPrice.Text);
                    cmd.Parameters.AddWithValue("@dateTime", dateTime.Text);




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
            Products productPage= new Products();
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
    }
}
