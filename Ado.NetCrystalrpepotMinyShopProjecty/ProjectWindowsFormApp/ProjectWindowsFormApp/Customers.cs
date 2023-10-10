using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Configuration;
using System.Runtime.InteropServices;
using System.Xml.Linq;

namespace ProjectWindowsFormApp
{
    public partial class Customers : Form
    {
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataReader reader;
        DataSet ds;
        DataTable dt;
        string gender;
        public Customers()
        {
            InitializeComponent();

            String myConString = ConfigurationManager.ConnectionStrings["myConnection"].ConnectionString;
            conn = new SqlConnection(myConString);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (checkMale.Checked == true)
            {
                gender = "male";
            }
            else
            {
                gender = "female";
            }

            try
            {
                if (txtName.Text != "" && txtPhone.Text != "" && txtPhone.Text != "")
                {
                    conn.Open();

                    string sqlQuery = "INSERT INTO Customers VALUES(@name,@email,@phone,@gender,@country,@photo)";

                    cmd = new SqlCommand(sqlQuery, conn);

                    cmd.Parameters.AddWithValue("@name", txtName.Text);
                    cmd.Parameters.AddWithValue("@email", txtEmail.Text);
                    cmd.Parameters.AddWithValue("@phone", txtPhone.Text);

                    cmd.Parameters.AddWithValue("@gender", gender);
                    cmd.Parameters.AddWithValue("@country", txtCountry.Text);
                    cmd.Parameters.AddWithValue("@photo", Path.GetFileName(txtPhoto.Text));



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

        private void btnUpdate_Click(object sender, EventArgs e)
        {

        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            if (open.ShowDialog() == DialogResult.OK)
            {
                string imagePath = open.FileName;
                pictureBox1.Image = new Bitmap(imagePath);
                txtPhoto.Text = imagePath;

                string path = Application.StartupPath.Substring(0, (Application.StartupPath.Length - 10));
                string correctName = System.IO.Path.GetFileName(open.FileName);
                System.IO.File.Copy(open.FileName, path + "\\Photo\\" + correctName);
            }

        }





        private void lblCustomers_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Customers customerPage = new Customers();
            customerPage.ShowDialog();
        }

        private void lblProducts_Click_1(object sender, EventArgs e)
        {
           
            this.Hide();
            Products orderPage = new Products();
            orderPage.ShowDialog();
        }

        private void lblOrders_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Orders orderPage = new Orders();
            orderPage.ShowDialog();

        }

        private void lblSupplier_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Suppliers SupplierPage = new Suppliers();
            SupplierPage.ShowDialog();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
