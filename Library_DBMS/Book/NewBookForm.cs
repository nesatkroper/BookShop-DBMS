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
using System.Xml.Linq;

namespace Library_DBMS.Book
{
    public partial class NewBookForm : Form
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        public static extern IntPtr CreateRoundRectRgn(int left, int top, int right, int bottom, int width, int height);
        public NewBookForm()
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
                string query_ = "INSERT INTO Book_TB (boo_title, boo_ISBN, boo_author, boo_publisher, boo_publ_year, boo_page_number) VALUES (@title, @isbn, @aut, @pub, @pyear, @pnum);";
                SqlCommand cmd = new SqlCommand(query_, conn);
                cmd.Parameters.AddWithValue("@title", txtTitle.Text);
                cmd.Parameters.AddWithValue("@isbn", txtisbn.Text);
                cmd.Parameters.AddWithValue("@aut", txtAuthor.Text);
                cmd.Parameters.AddWithValue("@pub", txtPublisher.Text);
                cmd.Parameters.AddWithValue("@pyear", txtPubYear.Text);
                cmd.Parameters.AddWithValue("@pnum", txtPageNum.Text);
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
            if (txtTitle.Text.Trim() == string.Empty)
            {
                epName.SetError(txtTitle, "Please the title!");
                result = false;
            }
            return result;
        }

        private void NewBookForm_Load(object sender, EventArgs e)
        {
            this.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, this.Width, this.Height, 20, 20));

            btnOk.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnOk.Width, btnOk.Height, 20, 20));
            btnCancel.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnCancel.Width, btnCancel.Height, 20, 20));

            txtTitle.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, txtTitle.Width, txtTitle.Height, 20, 20));
            txtisbn.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, txtisbn.Width, txtisbn.Height, 20, 20));
            txtAuthor.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, txtAuthor.Width, txtAuthor.Height, 20, 20));
            txtPublisher.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, txtPublisher.Width, txtPublisher.Height, 20, 20));
            txtPubYear.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, txtPubYear.Width, txtPubYear.Height, 20, 20));
            txtPageNum.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, txtPageNum.Width, txtPageNum.Height, 20, 20));
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (!DoValidation_()) return;
            InsertDatabase_();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtTitle.Text) || !string.IsNullOrEmpty(txtisbn.Text) || !string.IsNullOrEmpty(txtAuthor.Text) || !string.IsNullOrEmpty(txtPublisher.Text) || !string.IsNullOrEmpty(txtPubYear.Text) || !string.IsNullOrEmpty(txtPageNum.Text))
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
