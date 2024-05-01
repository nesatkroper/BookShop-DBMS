using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library_DBMS.Customer
{
    public partial class EditCustomerForm : Form
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        public static extern IntPtr CreateRoundRectRgn(int left, int top, int right, int bottom, int width, int height);

        public EditCustomerForm()
        {
            InitializeComponent();
        }

        string conString = @"Data Source=(localdb)\local;Initial Catalog=BookShop_DB;Integrated Security=True;";
        public string id_;

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

        void LoadData_()
        {
            SqlConnection conn = new SqlConnection(conString);
            try
            {
                conn.Open();
                string query_ = "SELECT * FROM Customer_TB WHERE cus_id = @id";
                SqlCommand cmd = new SqlCommand(query_, conn);
                cmd.Parameters.AddWithValue("@id", id_);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    txtName.Text = dr[1].ToString();
                    txtCompany.Text = dr[2].ToString();
                    txtPhone.Text = dr[3].ToString();
                    txtEmail.Text = dr[4].ToString();
                    txtAddress.Text = dr[5].ToString();
                }
                dr.Close();
                conn.Close();
            }
            catch (SqlException ex)
            {
                conn.Close();
                MessageBox.Show(ex.Message);
            }
        }

        void UpdateDatabase_()
        {
            SqlConnection conn = new SqlConnection(conString);
            try
            {
                conn.Open();
                string query_ = "UPDATE Customer_TB SET cus_name = @name, cus_companyName = @company, cus_phone = @phone, cus_email = @email, cus_address =  @address WHERE cus_id = @id;";
                SqlCommand cmd = new SqlCommand(query_, conn);
                cmd.Parameters.AddWithValue("@name", txtName.Text);
                cmd.Parameters.AddWithValue("@company", txtCompany.Text);
                cmd.Parameters.AddWithValue("@phone", txtPhone.Text);
                cmd.Parameters.AddWithValue("@email", txtEmail.Text);
                cmd.Parameters.AddWithValue("@address", txtAddress.Text);
                cmd.Parameters.AddWithValue("@id", id_);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (SqlException ex)
            {
                conn.Close();
                MessageBox.Show(ex.Message);
            }
        }

        private void EditCustomerForm_Load(object sender, EventArgs e)
        {
            LoadData_();

            this.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, this.Width, this.Height, 20, 20));
            btnEdit.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnEdit.Width, btnEdit.Height, 20, 20));
            btnCancel.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnCancel.Width, btnCancel.Height, 20, 20));
            txtName.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, txtName.Width, txtName.Height, 20, 20));
            txtCompany.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, txtCompany.Width, txtCompany.Height, 20, 20));
            txtPhone.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, txtPhone.Width, txtPhone.Height, 20, 20));
            txtEmail.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, txtEmail.Width, txtEmail.Height, 20, 20));
            txtAddress.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, txtAddress.Width, txtAddress.Height, 20, 20));
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!DoValidation_()) return;
            UpdateDatabase_();
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
