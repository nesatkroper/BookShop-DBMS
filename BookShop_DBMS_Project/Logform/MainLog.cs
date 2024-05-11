using BookShop_DBMS_Project.POS;
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

namespace BookShop_DBMS_Project.Logform
{
    public partial class MainLog : Form
    {
        public MainLog()
        {
            InitializeComponent();
        }

        Consts consts = new Consts();

        private void btnLogin_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(consts.conString);
            try
            {
                conn.Open();
                //string sql = "SELECT usr_id, usr_username, usr_password, emp_name FROM User_TB, Employee_TB WHERE usr_username = @name AND usr_password = @pass;";
                //string sql = "SELECT * FROM User_TB WHERE usr_username = @name AND usr_password = @pass;";
                string sql = "select * from employee_tb  inner join user_tb on User_TB.emp_id = Employee_TB.emp_id;";
                SqlCommand command = new SqlCommand(sql, conn);
                command.Parameters.AddWithValue("@name", txtUs.Text);
                command.Parameters.AddWithValue("@pass", txtPass.Text);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    MainForm main = new MainForm();
                    InvoiceForm invoiceForm = new InvoiceForm();
                    invoiceForm.staffName = reader[2].ToString();
                    main.legally = reader[7].ToString();
                    main.staffName = reader[2].ToString();
                    main.staffID = reader[0].ToString();
                    main.profile = reader[12].ToString();
                    this.Hide();
                    main.ShowDialog();
                    this.Close();
                }
                else
                {
                    conn.Close();
                    MessageBox.Show("Incorrect Username and Password!!!", "Error...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtUs.Clear();
                    txtPass.Clear();
                }
                conn.Close();
            }
            catch (SqlException ex)
            {
                conn.Close();
                MessageBox.Show(ex.Message);
            }
        }

        private void cbShow_CheckedChanged(object sender, EventArgs e)
        {
            if (cbShow.Checked) txtPass.UseSystemPasswordChar = false;
            else txtPass.UseSystemPasswordChar = true;
        }
    }
}
