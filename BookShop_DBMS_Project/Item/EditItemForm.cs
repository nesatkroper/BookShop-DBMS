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
using System.Xml.Linq;

namespace BookShop_DBMS_Project.Book
{
    public partial class EditItemForm : Form
    {
        public EditItemForm()
        {
            InitializeComponent();
        }

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        public static extern IntPtr CreateRoundRectRgn(int left, int top, int right, int bottom, int width, int height);

        Consts consts = new Consts();

        public string id_;
        public string imgLocation = null;
        public string curentImageName = null;
        public string curentImagePath = null;
        public string curentImageUrl = null;
        bool isTrue = false;
        string[] cateItem = new string[] { "Book", "Note Book", "Pen", "Marker", "Ruler", "Pencil", "", "" };

        void CategoryAddItem_()
        {
            foreach (var item in cateItem) cbCate.Items.Add(item);
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

        void LoadData_()
        {
            SqlConnection conn = new SqlConnection(consts.conString);
            try
            {
                conn.Open();
                string query_ = "SELECT * FROM Item_TB WHERE ite_id = @id";
                SqlCommand cmd = new SqlCommand(query_, conn);
                cmd.Parameters.AddWithValue("@id", id_);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    txtName.Text = dr[1].ToString();
                    txtDes.Text = dr[2].ToString();
                    txtQty.Text = dr[3].ToString();
                    cbCate.Text = dr[4].ToString();
                    txtPrice.Text = dr[5].ToString();
                    txtSalePrice.Text = dr[6].ToString();
                    pcItem.ImageLocation = dr[7].ToString();
                    curentImageUrl = dr[7].ToString();
                    isTrue = true;
                }
                else return;
                dr.Close();
                conn.Close();
            }
            catch (SqlException ex)
            {
                conn.Close();
                MessageBox.Show(ex.Message);
            }
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
                    isTrue = false;
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

        void UpdateDatabase_()
        {
            SqlConnection conn = new SqlConnection(consts.conString);
            try
            {
                conn.Open();
                bool isTrue = false;
                string query_ = "UPDATE Item_TB SET ite_name = @name, ite_description = @des, ite_quantity = @qty, ite_category = @cat, ite_price =  @price, ite_salePrice = @sprice, ite_pic = @pic WHERE ite_id = @id;";
                SqlCommand cmd = new SqlCommand(query_, conn);
                cmd.Parameters.AddWithValue("@name", txtName.Text);
                cmd.Parameters.AddWithValue("@des", txtDes.Text);
                cmd.Parameters.AddWithValue("@qty", txtQty.Text);
                cmd.Parameters.AddWithValue("@cat", cbCate.Text);
                cmd.Parameters.AddWithValue("@price", txtPrice.Text);
                cmd.Parameters.AddWithValue("@sprice", txtSalePrice.Text);

                //THIS IS USE FOR UPDATE AND DELETE OLD PIC
                if (isTrue)
                {
                    cmd.Parameters.AddWithValue("@pic", curentImageUrl);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@pic", curentImagePath);
                    File.Delete(curentImageUrl);
                }
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

        private void EditBookForm_Load(object sender, EventArgs e)
        {
            
            LoadData_();

            this.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, this.Width, this.Height, 20, 20));
            btnOk.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnOk.Width, btnOk.Height, 20, 20));
            btnCancel.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnCancel.Width, btnCancel.Height, 20, 20));
            txtName.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, txtName.Width, txtName.Height, 20, 20));
            txtPrice.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, txtName.Width, txtName.Height, 20, 20));
            //cbCate.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, txtName.Width, txtName.Height, 20, 20));
            txtSalePrice.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, txtName.Width, txtName.Height, 20, 20));
            txtDes.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, txtName.Width, txtName.Height, 20, 20));
            txtPrice.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, txtName.Width, txtName.Height, 20, 20));
            txtQty.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, txtName.Width, txtName.Height, 20, 20));
            pcItem.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, pcItem.Width, pcItem.Height, 20, 20));

            pcItem.BackColor = Color.FromArgb(37, 37, 37);
            CategoryAddItem_();
        }

        private void pcBook_Click(object sender, EventArgs e)
        {
            BrowseImage_();
            CopyImage_();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (!DoValidation_()) return;
            UpdateDatabase_();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtName.Text) || !string.IsNullOrEmpty(txtDes.Text) || !string.IsNullOrEmpty(txtQty.Text) || !string.IsNullOrEmpty(cbCate.Text) || !string.IsNullOrEmpty(txtPrice.Text) || !string.IsNullOrEmpty(txtSalePrice.Text))
            {
                if (MessageBox.Show("The Task not Complete!", "Warning..", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK) this.Close();
            }
            else this.Close();
        }

        private void txtTitle_Click(object sender, EventArgs e)
        {
            txtName.SelectAll();
        }

        private void txtisbn_Click(object sender, EventArgs e)
        {
            txtDes.SelectAll();
        }

        private void txtAuthor_Click(object sender, EventArgs e)
        {
            txtQty.SelectAll();
        }

        private void txtPubYear_Click(object sender, EventArgs e)
        {
            txtPrice.SelectAll();
        }

        private void txtPageNum_Click(object sender, EventArgs e)
        {
            txtSalePrice.SelectAll();
        }

        private void txtPubYear_KeyPress(object sender, KeyPressEventArgs e)
        {
            int ascii = (int)e.KeyChar;
            if (ascii >= 48 && ascii <= 57) e.Handled = false;
            else if (ascii == 8 || ascii == 46) e.Handled = false;
            else e.Handled = true;
        }
    }
}
