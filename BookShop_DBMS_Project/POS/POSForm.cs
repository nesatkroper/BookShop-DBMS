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

namespace BookShop_DBMS_Project.POS
{
    public partial class POSForm : Form
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        public static extern IntPtr CreateRoundRectRgn(int left, int top, int right, int bottom, int width, int height);

        public POSForm()
        {
            InitializeComponent();
        }

        Consts consts = new Consts();
        DataSet ds = new DataSet();

        int index_ = 1;
        double orQty = 1;
        double amount = 0;
        double grandAmount = 0;

        string[] title_ = new string[100];
        string[] price_ = new string[100];
        string[] cate_ = new string[100];
        Image[] icon_ = new Image[100];
        string[] cateItem = new string[] { "All Items", "Book", "Note Book", "Pen", "Marker", "Ruler", "Pencil", "", "" };

        void CategoryAddItem_()
        {
            foreach (var item in cateItem) cbCate.Items.Add(item);
            cbCate.Text = cateItem[0];
        }

        // THIS IS USE FOR SORT ITEM
        void SortList_()
        {
            ds.Clear();
            if (cbCate.Text == cateItem[0])
            {
                ds.Clear();
                LoadData_();
            }
            else
            {
                ds.Clear();
                SqlConnection conn = new SqlConnection(consts.conString);
                try
                {
                    conn.Open();
                    string query_ = "SELECT ite_name, ite_pic, ite_salePrice, ite_category FROM Item_TB WHERE ite_category = '" + cbCate.Text + "';";

                    SqlDataAdapter adapter = new SqlDataAdapter(query_, conn);
                    adapter.Fill(ds);
                    dgvData.DataSource = ds.Tables[0];
                    flpOrder.Controls.Clear();
                    OrderList[] orderList = new OrderList[dgvData.Rows.Count - 1];

                    for (int i = 0; i < dgvData.Rows.Count - 1; i++)
                    {
                        FileStream stream = new FileStream(dgvData.Rows[i].Cells[1].Value.ToString(), FileMode.Open);
                        MemoryStream photoStream = new MemoryStream();
                        stream.CopyTo(photoStream);
                        stream.Close();
                        title_[i] = dgvData.Rows[i].Cells[0].Value.ToString();
                        icon_[i] = Image.FromStream(photoStream);
                        price_[i] = dgvData.Rows[i].Cells[2].Value.ToString();
                        cate_[i] = dgvData.Rows[i].Cells[3].Value.ToString();
                    }

                    for (int i = 0; i < orderList.Length; i++)
                    {
                        orderList[i] = new OrderList();
                        orderList[i].Icon = icon_[i];
                        orderList[i].Title = title_[i];
                        orderList[i].Price = price_[i];
                        orderList[i].Cate = cate_[i];

                        flpOrder.Controls.Add(orderList[i]);
                        orderList[i].Click += new System.EventHandler(this.OrderList_Click);
                    }
                    conn.Close();
                }
                catch (SqlException ex)
                {
                    conn.Close();
                    MessageBox.Show(ex.Message);
                }
            }
        }

        // THIS IS USE FOR LOAD ITEM
        void LoadData_()
        {
            ds.Clear();
            SqlConnection conn = new SqlConnection(consts.conString);
            try
            {
                conn.Open();
                string query_ = "SELECT ite_name, ite_pic, ite_salePrice, ite_category FROM Item_TB;";

                SqlDataAdapter adapter = new SqlDataAdapter(query_, conn);
                adapter.Fill(ds);
                dgvData.DataSource = ds.Tables[0];
                flpOrder.Controls.Clear();
                OrderList[] orderList = new OrderList[dgvData.Rows.Count - 1];

                for (int i = 0; i < dgvData.Rows.Count - 1; i++)
                {
                    FileStream stream = new FileStream(dgvData.Rows[i].Cells[1].Value.ToString(), FileMode.Open);
                    MemoryStream photoStream = new MemoryStream();
                    stream.CopyTo(photoStream);
                    stream.Close();
                    title_[i] = dgvData.Rows[i].Cells[0].Value.ToString();
                    icon_[i] = Image.FromStream(photoStream);
                    price_[i] = dgvData.Rows[i].Cells[2].Value.ToString();
                    cate_[i] = dgvData.Rows[i].Cells[3].Value.ToString();
                }

                for (int i = 0; i < orderList.Length; i++)
                {
                    orderList[i] = new OrderList();
                    orderList[i].Icon = icon_[i];
                    orderList[i].Title = title_[i];
                    orderList[i].Price = price_[i];
                    orderList[i].Cate = cate_[i];

                    flpOrder.Controls.Add(orderList[i]);
                    orderList[i].Click += new System.EventHandler(this.OrderList_Click);
                }
                conn.Close();
            }
            catch (SqlException ex)
            {
                conn.Close();
                MessageBox.Show(ex.Message);
            }
        }

        void OrderList_Click(object sender, EventArgs e)
        {
            try
            {
                OrderList orderList = (OrderList)sender;
                bool isExisted = false;
                double orPrice = Convert.ToDouble(orderList.Price);

                for (int i = 0; i < lvOrder.Items.Count; i++)
                {
                    if (lvOrder.Items[i].SubItems[1].Text == orderList.Title)
                    {
                        lvOrder.Items[i].SubItems[2].Text = (Convert.ToDouble(lvOrder.Items[i].SubItems[2].Text) + orQty).ToString("#.00");
                        lvOrder.Items[i].SubItems[3].Text = (Convert.ToDouble(lvOrder.Items[i].SubItems[3].Text) + Convert.ToDouble(orderList.Price)).ToString();
                        isExisted = true;
                        break;
                    }
                }
                if (!isExisted)
                {
                    ListViewItem lvi = new ListViewItem();
                    lvi.Text = index_.ToString();
                    lvi.SubItems.Add(orderList.Title);
                    lvi.SubItems.Add(orQty.ToString("#.00"));
                    lvi.SubItems.Add(orPrice.ToString());
                    lvOrder.Items.Add(lvi);
                    index_++;
                }
                for (int i = 0; i < lvOrder.Items.Count; i++)
                {
                    amount = 0;
                    amount += (Convert.ToDouble(lvOrder.Items[i].SubItems[3].Text));
                }
                grandAmount += amount;
                lbTotalCost.Text = grandAmount.ToString("$ #.##");
                btnClear.Enabled = true;
                btnPay.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void POSForm_Load(object sender, EventArgs e)
        {
            CategoryAddItem_();

            pnHeader.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, pnHeader.Width, pnHeader.Height, 20, 20));
            pnOrder.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, pnOrder.Width, pnOrder.Height, 20, 20));
            btnClear.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnClear.Width, btnClear.Height, 20, 20));
            btnPay.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnPay.Width, btnPay.Height, 20, 20));
            LoadData_();
            if (lvOrder.Items.Count - 1 <= 0)
            {
                btnPay.Enabled = false;
                btnClear.Enabled = false;
            }
        }

        private void cbCate_SelectedIndexChanged(object sender, EventArgs e)
        {
            SortList_();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            lvOrder.Items.Clear();
            index_ = 1;
            amount = 0;
            btnPay.Enabled = false;
            btnClear.Enabled = false;
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            InvoiceForm invoiceForm = new InvoiceForm(lvOrder);
            invoiceForm.amount = this.amount;
            invoiceForm.TopLevel = true;
            invoiceForm.Show();
        }
    }
}
