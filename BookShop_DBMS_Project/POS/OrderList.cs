using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookShop_DBMS_Project.POS
{
    public partial class OrderList : UserControl
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        public static extern IntPtr CreateRoundRectRgn(int left, int top, int right, int bottom, int width, int height);

        public OrderList()
        {
            InitializeComponent();
        }

        private Image _icon;
        private string _title;
        private string _price;
        private string _cate;



        #region Properties

        [Category("Custom Props")]
        public Image Icon
        {
            get { return _icon; }
            set
            {
                _icon = value;
                pcOrderPic.Image = value;
            }
        }

        [Category("Custom Props")]
        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                lbOrderTitle.Text = value;
            }
        }

        [Category("Custom Props")]
        public string Price
        {
            get { return _price; }
            set
            {
                _price = value;
                lbOrderPrice.Text = value;
            }
        }

        [Category("Custom Props")]
        public string Cate
        {
            get { return _cate; }
            set
            {
                _cate = value;
                lbOrderCate.Text = value;
            }
        }
        #endregion

        private void OrderList_Load(object sender, EventArgs e)
        {
            this.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }
    }
}
