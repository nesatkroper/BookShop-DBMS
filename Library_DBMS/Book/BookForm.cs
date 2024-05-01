using Library_DBMS.Customer;
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

namespace Library_DBMS.Book
{
    public partial class BookForm : Form
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        public static extern IntPtr CreateRoundRectRgn(int left, int top, int right, int bottom, int width, int height);
        public BookForm()
        {
            InitializeComponent();
        }

        string conString = @"Data Source=(localdb)\local;Initial Catalog=BookShop_DB;Integrated Security=True;";
        string id_ = null;

        // htis is for reload value from database
        void Reload_()
        {
            SqlConnection conn = new SqlConnection(conString);
            try
            {
                string query_ = "SELECT * FROM Book_TB;";
                conn.Open();
                SqlCommand cmd = new SqlCommand(query_, conn);
                SqlDataReader dr = cmd.ExecuteReader();
                dgvBook.Rows.Clear();
                dgvBook.Refresh();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        dgvBook.Rows.Add(dr[0], dr[1], dr[2], dr[3], dr[4], dr[5], dr[6]);
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

        //this is for delete record
        void DeleteRecord_()
        {
            SqlConnection conn = new SqlConnection(conString);
            try
            {
                conn.Open();
                string query_ = "DELETE FROM Book_TB WHERE boo_id = @id";
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

        private void BookForm_Load(object sender, EventArgs e)
        {
            Reload_();

            btnAdd.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnAdd.Width, btnAdd.Height, 20, 20));
            btnEdit.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnEdit.Width, btnEdit.Height, 20, 20));
            btnDelete.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnDelete.Width, btnDelete.Height, 20, 20));
            dgvBook.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, dgvBook.Width, dgvBook.Height, 10, 10));
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvBook.SelectedRows.Count <= 0) return;

            if (MessageBox.Show("Are you sure to Delete this Record?", "Confirmation..", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;
            else DeleteRecord_();
            Reload_();
        }

        private void dgvBook_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvBook.SelectedRows.Count > 0)
            {
                id_ = dgvBook.SelectedRows[0].Cells[0].Value.ToString();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvBook.SelectedRows.Count <= 0) return;

            EditBookForm editBookForm = new EditBookForm();
            editBookForm.id_ = this.id_;
            if (editBookForm.ShowDialog() == DialogResult.OK)
            {
                Reload_();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            NewBookForm newBookForm = new NewBookForm();
            if (newBookForm.ShowDialog() == DialogResult.OK) Reload_();
        }
    }
}
