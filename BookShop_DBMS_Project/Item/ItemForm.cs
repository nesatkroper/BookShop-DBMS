using BookShop_DBMS_Project.Customer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookShop_DBMS_Project.Book
{
    public partial class ItemForm : Form
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        public static extern IntPtr CreateRoundRectRgn(int left, int top, int right, int bottom, int width, int height);
        public ItemForm()
        {
            InitializeComponent();
        }

        Consts consts = new Consts();

        string id_ = null;
        string ImgPath_ = null;

        // htis is for reload value from database
        void Reload_()
        {
            SqlConnection conn = new SqlConnection(consts.conString);
            try
            {
                string query_ = "SELECT * FROM Item_TB;";
                conn.Open();
                SqlCommand cmd = new SqlCommand(query_, conn);
                SqlDataReader dr = cmd.ExecuteReader();
                dgvBook.Rows.Clear();
                dgvBook.Refresh();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        FileStream stream = new FileStream(dr[7].ToString(), FileMode.Open);
                        MemoryStream photoStream = new MemoryStream();
                        stream.CopyTo(photoStream);
                        stream.Close();
                        dgvBook.Rows.Add(dr[0], dr[1], dr[2], dr[3], dr[4], dr[5], dr[6], Image.FromStream(photoStream));

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

        void DeleteImg_()
        {
            SqlConnection conn = new SqlConnection(consts.conString);
            try
            {
                conn.Open();
                string query_ = "SELECT ite_pic FROM Item_TB WHERE ite_id = @id";
                SqlCommand cmd = new SqlCommand(query_, conn);
                cmd.Parameters.AddWithValue("@id", id_);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    ImgPath_ = dr[0].ToString();
                }
                dr.Close();
                conn.Close();
            }
            catch (SqlException ex)
            {
                conn.Close();
                MessageBox.Show(ex.Message);
            }
            File.Delete(ImgPath_);
        }

        //this is for delete record
        void DeleteRecord_()
        {
            SqlConnection conn = new SqlConnection(consts.conString);
            try
            {
                conn.Open();
                string query_ = "DELETE FROM Item_TB WHERE ite_id = @id";
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
            if (dgvBook.SelectedRows.Count <= 0)
            {
                MessageBox.Show("Please select list you want to edit!", "Note...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (MessageBox.Show("Are you sure to Delete this Record?", "Confirmation..", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;
            else
            {
                dgvBook.Rows.RemoveAt(dgvBook.SelectedRows[0].Index);
                DeleteImg_();
                DeleteRecord_();
            }
            Reload_();
        }

        private void dgvBook_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvBook.SelectedRows.Count > 0) id_ = dgvBook.SelectedRows[0].Cells[0].Value.ToString();
            else
            {
                MessageBox.Show("You Click Out of Range.", "Error...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvBook.SelectedRows.Count <= 0)
            {
                MessageBox.Show("Please select list you want to edit!", "Note...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            EditItemForm editBookForm = new EditItemForm();
            editBookForm.id_ = this.id_;
            if (editBookForm.ShowDialog() == DialogResult.OK) Reload_();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            NewItemForm newBookForm = new NewItemForm();
            if (newBookForm.ShowDialog() == DialogResult.OK) Reload_();
        }
    }
}
