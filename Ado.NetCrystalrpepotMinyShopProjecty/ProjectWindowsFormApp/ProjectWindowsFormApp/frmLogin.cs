using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ProjectWindowsFormApp
{
    public partial class frmLogin : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\USER\Desktop\New folder\ProjectDatabase\LoginDB.mdf;Integrated Security=True;Connect Timeout=30");
        SqlCommand cmd;
        SqlDataReader data_reader;
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
          
            try
            {
                conn.Open();
                string sqlQuery = "select* from tblLogin where username=@uname and password=@pass";
                cmd = new SqlCommand(sqlQuery, conn);

                cmd.Parameters.AddWithValue("@uname", txtUser.Text);
                cmd.Parameters.AddWithValue("@pass", txtPassword.Text);
                cmd.ExecuteNonQuery();
                data_reader = cmd.ExecuteReader();
                int count = 0;
                while (data_reader.Read())
                {
                    count++;
                }
                if (count == 1)
                {
                    MessageBox.Show("welcome");
                    this.Hide();
                    frmHome form = new frmHome();
                    form.ShowDialog();
                }
                else if (count > 1)
                {
                    MessageBox.Show("Duplicate");
                    this.Hide();
                    frmLogin log = new frmLogin();
                    log.ShowDialog();
                }
                else if (count < 1)
                {
                    MessageBox.Show("Please provide valid info");
                    this.Hide();
                    frmLogin log = new frmLogin();
                    log.ShowDialog();
                }
                conn.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

            //if(usrtxt.Text=="minhaj" && passtxt.Text == "minhaj")
            //{
            //    MessageBox.Show("Borabor Diun");
            //    this.Hide();
            //    formHome myForm = new formHome();
            //    myForm.ShowDialog();


            //}
            //else
            //{
            //    MessageBox.Show("Vul oiyyi.. abar don");
            //}
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }

        private void lblUserName_Click(object sender, EventArgs e)
        {

        }
    }
}
