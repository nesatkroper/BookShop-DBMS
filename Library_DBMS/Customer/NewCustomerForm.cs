using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library_DBMS.Customer
{
    public partial class NewCustomerForm : Form
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        public static extern IntPtr CreateRoundRectRgn(int left, int top, int right, int bottom, int width, int height);
        public NewCustomerForm()
        {
            InitializeComponent();
        }

        string conString = @"Data Source=(localdb)\local;Initial Catalog=BookShop_DB;Integrated Security=True;";

        void InsertDatabase_()
        {
            SqlConnection conn = new SqlConnection(conString);
            try
            {
                conn.Open();
                string query_ = "INSERT INTO Customer_TB (cus_name, cus_companyName, cus_phone, cus_email, cus_address) VALUES (@name, @company, @phone, @email, @address);";
                SqlCommand cmd = new SqlCommand(query_, conn);
                cmd.Parameters.AddWithValue("@name", txtName.Text);
                cmd.Parameters.AddWithValue("@company", txtCompany.Text);
                cmd.Parameters.AddWithValue("@phone", txtPhone.Text);
                cmd.Parameters.AddWithValue("@email", txtEmail.Text);
                cmd.Parameters.AddWithValue("@address", txtAddress.Text);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (SqlException ex)
            {
                conn.Close();
                MessageBox.Show(ex.Message);
            }
        }

        bool DoValidation_()
        {
            bool result = true;
            if (txtName.Text.Trim() == string.Empty)
            {
                epName.SetError(txtName, "Please enter Name!");
                result = false;
            }
            return result;
        }

        private void NewCustomerForm_Load(object sender, EventArgs e)
        {
            this.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, this.Width, this.Height, 20, 20));

            btnAdd.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnAdd.Width, btnAdd.Height, 20, 20));
            btnCancel.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnCancel.Width, btnCancel.Height, 20, 20));

            txtName.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, txtName.Width, txtName.Height, 20, 20));
            txtCompany.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, txtCompany.Width, txtCompany.Height, 20, 20));
            txtPhone.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, txtPhone.Width, txtPhone.Height, 20, 20));
            txtEmail.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, txtEmail.Width, txtEmail.Height, 20, 20));
            txtAddress.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, txtAddress.Width, txtAddress.Height, 20, 20));
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if(!DoValidation_()) return;
            InsertDatabase_();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtName.Text) || !string.IsNullOrEmpty(txtCompany.Text) || !string.IsNullOrEmpty(txtPhone.Text) || !string.IsNullOrEmpty(txtEmail.Text) || !string.IsNullOrEmpty(txtAddress.Text))
            {
                if (MessageBox.Show("The Task not Complete!", "Warning..", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    this.Close();
                }
            }
            else this.Close();
        }
    }
}
