using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace BookShop_DBMS_Project.Book
{
    public partial class NewItemForm : Form
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        public static extern IntPtr CreateRoundRectRgn(int left, int top, int right, int bottom, int width, int height);
        public NewItemForm()
        {
            InitializeComponent();
        }

        Consts Consts = new Consts();

        public string imgLocation = null;
        public string curentImageName = null;
        public string curentImagePath = null;
        string[] cateItem = new string[] { "Book", "Note Book", "Pen", "Marker", "Ruler", "Pencil", "", "" };

        void CategoryAddItem_()
        {
            foreach (var item in cateItem) cbCate.Items.Add(item);
            cbCate.Text = cateItem[0];
        }

        void InsertDatabase_()
        {
            SqlConnection conn = new SqlConnection(Consts.conString);
            try
            {
                conn.Open();
                string query_ = "INSERT INTO Item_TB (ite_name, ite_description, ite_quantity, ite_category, ite_price, ite_salePrice,ite_pic) VALUES (@name, @des, @qty, @cat, @price, @sprice, @pic);";
                SqlCommand cmd = new SqlCommand(query_, conn);
                cmd.Parameters.AddWithValue("@name", txtName.Text);
                cmd.Parameters.AddWithValue("@des", txtDes.Text);
                cmd.Parameters.AddWithValue("@qty", txtQty.Text);
                cmd.Parameters.AddWithValue("@cat", cbCate.Text);
                cmd.Parameters.AddWithValue("@price", txtPrice.Text);
                cmd.Parameters.AddWithValue("@sprice", txtSalePrice.Text);
                cmd.Parameters.AddWithValue("@pic", curentImagePath);
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
                epName.SetError(txtName, "Please the title!");
                result = false;
            }
            return result;
        }

        void BrowseImage_()
        {
            try
            {
                OpenFileDialog dailog = new OpenFileDialog();
                dailog.Filter = "jpg files(*.jpg)|*.jpg| PNG files(*.png)|*.png| All Files(*.*)|*.*";
                dailog.FilterIndex = 1;
                pcItem.ImageLocation = null;
                if (dailog.ShowDialog() == DialogResult.OK)
                {
                    imgLocation = null;
                    imgLocation = dailog.FileName.ToString();
                    pcItem.ImageLocation = imgLocation;
                    curentImageName = Path.GetFileName(imgLocation);
                }
                else return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void CopyImage_()
        {
            if (!string.IsNullOrEmpty(curentImageName))
            {
                string imgDesPath = Path.Combine(Application.StartupPath, "Item-img", curentImageName);
                try
                {
                    File.Copy(imgLocation, imgDesPath);
                    curentImagePath = imgDesPath;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else return;
        }

        private void NewBookForm_Load(object sender, EventArgs e)
        {
            CategoryAddItem_();

            this.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, this.Width, this.Height, 20, 20));

            btnOk.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnOk.Width, btnOk.Height, 20, 20));
            btnCancel.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnCancel.Width, btnCancel.Height, 20, 20));

            txtName.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, txtName.Width, txtName.Height, 20, 20));
            txtDes.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, txtName.Width, txtName.Height, 20, 20));
            txtQty.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, txtName.Width, txtName.Height, 20, 20));
            txtPrice.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, txtName.Width, txtName.Height, 20, 20));
            //cbCate.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, txtName.Width, txtName.Height, 20, 20));
            txtSalePrice.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, txtName.Width, txtName.Height, 20, 20));
   
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
            if (!string.IsNullOrEmpty(txtName.Text) || !string.IsNullOrEmpty(txtDes.Text) || !string.IsNullOrEmpty(txtQty.Text) || !string.IsNullOrEmpty(cbCate.Text) || !string.IsNullOrEmpty(txtPrice.Text) || !string.IsNullOrEmpty(txtSalePrice.Text) || !string.IsNullOrEmpty(curentImageName))
            {
                if (MessageBox.Show("The Task not Complete!", "Warning..", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    this.Close();
                }
            }
            else this.Close();
        }

        private void pcBook_Click(object sender, EventArgs e)
        {
            BrowseImage_();
            pcItem.BackColor = Color.FromArgb(37, 37, 37);
            CopyImage_();
        }

        private void txtPubYear_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            int ascii = (int)e.KeyChar;
            if (ascii >= 48 && ascii <= 57) e.Handled = false;
            else if (ascii == 8 || ascii == 46) e.Handled = false;
            else e.Handled = true;
        }

        private void pcItem_Click(object sender, EventArgs e)
        {
            BrowseImage_();
            CopyImage_();
        }
    }
}
