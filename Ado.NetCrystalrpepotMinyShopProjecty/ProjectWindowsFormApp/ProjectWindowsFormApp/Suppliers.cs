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

    public partial class Suppliers : Form
    {
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataReader reader;
        DataSet ds;
        DataTable dt;
        string gender;

        public Suppliers()
        {
            InitializeComponent();

            String myConString = ConfigurationManager.ConnectionStrings["myConnection"].ConnectionString;
            conn = new SqlConnection(myConString);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (radioMale.Checked == true)
            {
                gender = "male";
            }
            else
            {
                gender = "female";
            }

            try
            {
                if (txtName.Text != "" && txtPhone.Text != "" && txtCountry.Text != "")
                {
                    conn.Open();

                    string sqlQuery = "INSERT INTO Suppliers VALUES(@name,@email,@phone,@gender,@country)";
                    cmd = new SqlCommand(sqlQuery, conn);

                    cmd.Parameters.AddWithValue("@name", txtName.Text);
                    cmd.Parameters.AddWithValue("@email", txtEmail.Text);
                    cmd.Parameters.AddWithValue("@phone", txtPhone.Text);

                    cmd.Parameters.AddWithValue("@gender", gender);
                    cmd.Parameters.AddWithValue("@country", txtCountry.Text);




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

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmLogin form = new frmLogin();
            form.ShowDialog();
        }
    }
}
