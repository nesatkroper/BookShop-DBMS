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

namespace BookShop_DBMS_Project.Customer
{
    public partial class CustomerForm : Form
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        public static extern IntPtr CreateRoundRectRgn(int left, int top, int right, int bottom, int width, int height);
        public CustomerForm()
        {
            InitializeComponent();
        }

        Consts Consts = new Consts();

        string id_ = null;

        // THIS IS USE FOR LOAD DATA FROM DATABASE
        void Reload_()
        {
            SqlConnection conn = new SqlConnection(Consts.conString);
            try
            {
                string query_ = "SELECT * FROM Customer_TB;";
                conn.Open();
                SqlCommand cmd = new SqlCommand(query_, conn);
                SqlDataReader dr = cmd.ExecuteReader();
                dgvCustomer.Rows.Clear();
                dgvCustomer.Refresh();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        dgvCustomer.Rows.Add(dr[0], dr[1], dr[2], dr[3], dr[4], dr[5]);
                    }
                }
                conn.Close();
            }
            catch (SqlException ex)
            {
                conn.Close();
                MessageBox.Show(ex.Message);
            }
        }

        //THIS IS USE FOR DELETE RECORD
        void DeleteRecord_()
        {
            SqlConnection conn = new SqlConnection(Consts.conString);
            try
            {
                conn.Open();
                string query_ = "DELETE FROM Customer_TB WHERE cus_id = @id";
                SqlCommand cmd = new SqlCommand(query_, conn);
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

        private void CustomerForm_Load(object sender, EventArgs e)
        {
            Reload_();

            btnAdd.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnAdd.Width, btnAdd.Height, 20, 20));
            btnEdit.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnEdit.Width, btnEdit.Height, 20, 20));
            btnDelete.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnDelete.Width, btnDelete.Height, 20, 20));
            dgvCustomer.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, dgvCustomer.Width, dgvCustomer.Height, 10, 10));
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            NewCustomerForm newCustomerForm = new NewCustomerForm();
            if (newCustomerForm.ShowDialog() == DialogResult.OK) Reload_();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvCustomer.SelectedRows.Count <= 0)
            {
                MessageBox.Show("Please select list you want to edit!", "Note...");
                return;
            }

            EditCustomerForm editCustomerForm = new EditCustomerForm();
            editCustomerForm.id_ = this.id_;
            if (editCustomerForm.ShowDialog() == DialogResult.OK) Reload_();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvCustomer.SelectedRows.Count <= 0) return;

            if (MessageBox.Show("Are you sure to Delete this Record?", "Confirmation..", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;
            else DeleteRecord_();
            Reload_();
        }

        private void dgvCustomer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvCustomer.SelectedRows.Count > 0) id_ = dgvCustomer.SelectedRows[0].Cells[0].Value.ToString();
        }
    }
}
