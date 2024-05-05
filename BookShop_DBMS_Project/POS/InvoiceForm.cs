using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookShop_DBMS_Project.POS
{
    public partial class InvoiceForm : Form
    {
        public ListView lv_ { get; set; }
        public string staffName;

        public InvoiceForm()
        {
            InitializeComponent();
        }
        public InvoiceForm(ListView listView)
        {
            lv_ = listView;
            InitializeComponent();
        }

        DateTime now = DateTime.Now;
        int No_ = 1000000;
        public double amount = 0;
        PrintPreviewDialog ppd = new PrintPreviewDialog();


        private void InvoiceForm_Load(object sender, EventArgs e)
        {
            lbStaffName.Text = this.staffName;
            lvOrder.Items.AddRange((from ListViewItem item in lv_.Items select (ListViewItem)item.Clone()).ToArray());

            lbDate.Text = now.ToString("dd-MMMM-yyyy");
            lbTime.Text = now.ToString("hh:mm:ss");
            No_++;
            lbNo_.Text = No_.ToString();
            lbTotalCost.Text = amount.ToString("$ #.##");
            
        }

        Bitmap MemoryImage;
        public void GetPrintArea(Panel pnl)
        {
            MemoryImage = new Bitmap(pnl.Width, pnl.Height);
            pnl.DrawToBitmap(MemoryImage, new Rectangle(0, 0, pnl.Width, pnl.Height));
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            if (MemoryImage != null)
            {
                e.Graphics.DrawImage(MemoryImage, 0, 0);
                base.OnPaint(e);
            }
        }

        public void Print(Panel pnl)
        {
            pnInvoice = pnl;
            GetPrintArea(pnl);
            printPrev.Document = printDoc;
            printPrev.ShowDialog();
        }

        private void btnPrint_MouseHover(object sender, EventArgs e)
        {
            ttInvoice.SetToolTip(btnPrint, "Print");

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            Print(this.pnInvoice);
            this.Close();
        }

        private void printDoc_PrintPage(object sender, PrintPageEventArgs e)
        {
            Rectangle pagearea = e.PageBounds;
            e.Graphics.DrawImage(MemoryImage, (pagearea.Width / 2) - (this.pnInvoice.Width / 2), this.pnInvoice.Location.Y);
        }
    }
}
