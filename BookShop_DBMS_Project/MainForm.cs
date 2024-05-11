using BookShop_DBMS_Project.Adjustment;
using BookShop_DBMS_Project.Book;
using BookShop_DBMS_Project.Borrow;
using BookShop_DBMS_Project.Customer;
using BookShop_DBMS_Project.Dashboard;
using BookShop_DBMS_Project.Librarian;
using BookShop_DBMS_Project.POS;
using BookShop_DBMS_Project.Purchase;
using BookShop_DBMS_Project.Return;
using BookShop_DBMS_Project.Vendor;
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

namespace BookShop_DBMS_Project
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        public static extern IntPtr CreateRoundRectRgn(int left, int top, int right, int bottom, int width, int height);

        public string staffName;
        public string staffID;
        public string legally;

        public string profile;

        InvoiceForm InvoiceForm = new InvoiceForm();
        AboutUs AboutUs = new AboutUs();

        private void MainForm_Load(object sender, EventArgs  e)
        {
            // THIS IS USE FOR SET LEGALLY OF USER
            if (this.legally == "Sale Staff")
            {
                btnAdjustment.Enabled = false;
                btnItem.Enabled = false;
                btnBorrow.Enabled = false;
                btnItem.Enabled=false;
                btnCustomer.Enabled = false;
                btnLibrarian.Enabled = false;
            }

            // THIS IS USE FOR SHOW USER NAME
            lbStaffID.Text = staffID;
            lbStaffName.Text = staffName;
            InvoiceForm.staffName = this.staffName;
            pcbProfile.ImageLocation = this.profile;

            this.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, this.Width, this.Height, 20, 20));
            pnHeader.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, pnHeader.Width, pnHeader.Height, 20, 20));
            pnData.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, pnData.Width, pnData.Height, 20, 20));
            btnDashboard.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnDashboard.Width, btnDashboard.Height, 20, 20));
            btnPOS.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnPurchase.Width, btnPurchase.Height, 20, 20));
            pnFooter.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, pnFooter.Width, pnFooter.Height, 20, 20));

            // EXCUTE DASHBOARD
            {
                btnPOS.BackColor = Color.FromArgb(119, 176, 170);
                btnPOS.ForeColor = Color.FromArgb(224, 224, 224);

                btnItem.BackColor = Color.FromArgb(224, 224, 224);
                btnLibrarian.BackColor = Color.FromArgb(224, 224, 224);
                btnVendor.BackColor = Color.FromArgb(224, 224, 224);
                btnCustomer.BackColor = Color.FromArgb(224, 224, 224);
                btnBorrow.BackColor = Color.FromArgb(224, 224, 224);
                btnReturn.BackColor = Color.FromArgb(224, 224, 224);
                btnAdjustment.BackColor = Color.FromArgb(224, 224, 224);
                btnPurchase.BackColor = Color.FromArgb(224, 224, 224);
                btnDashboard.BackColor = Color.FromArgb(224, 224, 224);

                btnItem.ForeColor = Color.FromArgb(119, 176, 170);
                btnLibrarian.ForeColor = Color.FromArgb(119, 176, 170);
                btnVendor.ForeColor = Color.FromArgb(119, 176, 170);
                btnCustomer.ForeColor = Color.FromArgb(119, 176, 170);
                btnBorrow.ForeColor = Color.FromArgb(119, 176, 170);
                btnReturn.ForeColor = Color.FromArgb(119, 176, 170);
                btnAdjustment.ForeColor = Color.FromArgb(119, 176, 170);
                btnPurchase.ForeColor = Color.FromArgb(119, 176, 170);
                btnDashboard.ForeColor = Color.FromArgb(119, 176, 170);

                POSForm pOSForm = new POSForm();
                pOSForm.TopLevel = false;
                pOSForm.WindowState = FormWindowState.Maximized;
                pOSForm.Dock = DockStyle.Fill;
                pnData.Controls.Add(pOSForm);
                pOSForm.Show();
                pOSForm.BringToFront();
            }
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            btnDashboard.BackColor = Color.FromArgb(119, 176, 170);
            btnDashboard.ForeColor = Color.FromArgb(224, 224, 224);

            btnItem.BackColor = Color.FromArgb(224, 224, 224);
            btnLibrarian.BackColor = Color.FromArgb(224, 224, 224);
            btnVendor.BackColor = Color.FromArgb(224, 224, 224);
            btnCustomer.BackColor = Color.FromArgb(224, 224, 224);
            btnBorrow.BackColor = Color.FromArgb(224, 224, 224);
            btnReturn.BackColor = Color.FromArgb(224, 224, 224);
            btnAdjustment.BackColor = Color.FromArgb(224, 224, 224);
            btnPurchase.BackColor = Color.FromArgb(224, 224, 224);
            btnPOS.BackColor = Color.FromArgb(224, 224, 224);

            btnItem.ForeColor = Color.FromArgb(119, 176, 170);
            btnLibrarian.ForeColor = Color.FromArgb(119, 176, 170);
            btnVendor.ForeColor = Color.FromArgb(119, 176, 170);
            btnCustomer.ForeColor = Color.FromArgb(119, 176, 170);
            btnBorrow.ForeColor = Color.FromArgb(119, 176, 170);
            btnReturn.ForeColor = Color.FromArgb(119, 176, 170);
            btnAdjustment.ForeColor = Color.FromArgb(119, 176, 170);
            btnPurchase.ForeColor = Color.FromArgb(119, 176, 170);
            btnPOS.ForeColor = Color.FromArgb(119, 176, 170);

            DashboardForm dashboardForm = new DashboardForm();
            dashboardForm.TopLevel = false;
            dashboardForm.WindowState = FormWindowState.Maximized;
            dashboardForm.Dock = DockStyle.Fill;
            pnData.Controls.Add(dashboardForm);
            dashboardForm.Show();
            dashboardForm.BringToFront();
        }

        private void btnBook_Click(object sender, EventArgs e)
        {
            btnItem.BackColor = Color.FromArgb(119, 176, 170);
            btnItem.ForeColor = Color.FromArgb(224, 224, 224);
            btnItem.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnItem.Width, btnItem.Height, 20, 20));

            btnDashboard.BackColor = Color.FromArgb(224, 224, 224);
            btnLibrarian.BackColor = Color.FromArgb(224, 224, 224);
            btnVendor.BackColor = Color.FromArgb(224, 224, 224);
            btnCustomer.BackColor = Color.FromArgb(224, 224, 224);
            btnBorrow.BackColor = Color.FromArgb(224, 224, 224);
            btnReturn.BackColor = Color.FromArgb(224, 224, 224);
            btnAdjustment.BackColor = Color.FromArgb(224, 224, 224);
            btnPurchase.BackColor = Color.FromArgb(224, 224, 224);
            btnPOS.BackColor = Color.FromArgb(224, 224, 224);

            btnDashboard.ForeColor = Color.FromArgb(119, 176, 170);
            btnLibrarian.ForeColor = Color.FromArgb(119, 176, 170);
            btnVendor.ForeColor = Color.FromArgb(119, 176, 170);
            btnCustomer.ForeColor = Color.FromArgb(119, 176, 170);
            btnBorrow.ForeColor = Color.FromArgb(119, 176, 170);
            btnReturn.ForeColor = Color.FromArgb(119, 176, 170);
            btnAdjustment.ForeColor = Color.FromArgb(119, 176, 170);
            btnPurchase.ForeColor = Color.FromArgb(119, 176, 170);
            btnPOS.ForeColor = Color.FromArgb(119, 176, 170);

            ItemForm bookForm = new ItemForm();
            bookForm.TopLevel = false;
            bookForm.WindowState = FormWindowState.Maximized;
            bookForm.Dock = DockStyle.Fill;
            pnData.Controls.Add(bookForm);
            bookForm.Show();
            bookForm.BringToFront();
        }

        private void btnLibrarian_Click(object sender, EventArgs e)
        {
            btnLibrarian.BackColor = Color.FromArgb(119, 176, 170);
            btnLibrarian.ForeColor = Color.FromArgb(224, 224, 224);
            btnLibrarian.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnLibrarian.Width, btnLibrarian.Height, 20, 20));

            btnDashboard.BackColor = Color.FromArgb(224, 224, 224);
            btnItem.BackColor = Color.FromArgb(224, 224, 224);
            btnVendor.BackColor = Color.FromArgb(224, 224, 224);
            btnCustomer.BackColor = Color.FromArgb(224, 224, 224);
            btnBorrow.BackColor = Color.FromArgb(224, 224, 224);
            btnReturn.BackColor = Color.FromArgb(224, 224, 224);
            btnAdjustment.BackColor = Color.FromArgb(224, 224, 224);
            btnPurchase.BackColor = Color.FromArgb(224, 224, 224);
            btnPOS.BackColor = Color.FromArgb(224, 224, 224);

            btnDashboard.ForeColor = Color.FromArgb(119, 176, 170);
            btnItem.ForeColor = Color.FromArgb(119, 176, 170);
            btnVendor.ForeColor = Color.FromArgb(119, 176, 170);
            btnCustomer.ForeColor = Color.FromArgb(119, 176, 170);
            btnBorrow.ForeColor = Color.FromArgb(119, 176, 170);
            btnReturn.ForeColor = Color.FromArgb(119, 176, 170);
            btnAdjustment.ForeColor = Color.FromArgb(119, 176, 170);
            btnPurchase.ForeColor = Color.FromArgb(119, 176, 170);
            btnPOS.ForeColor = Color.FromArgb(119, 176, 170);

            EmployeeForm librarianForm = new EmployeeForm();
            librarianForm.TopLevel = false;
            librarianForm.WindowState = FormWindowState.Maximized;
            librarianForm.Dock = DockStyle.Fill;
            pnData.Controls.Add(librarianForm);
            librarianForm.Show();
            librarianForm.BringToFront();
        }

        private void btnVendor_Click(object sender, EventArgs e)
        {
            btnVendor.BackColor = Color.FromArgb(119, 176, 170);
            btnVendor.ForeColor = Color.FromArgb(224, 224, 224);
            btnVendor.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnVendor.Width, btnVendor.Height, 20, 20));

            btnDashboard.BackColor = Color.FromArgb(224, 224, 224);
            btnItem.BackColor = Color.FromArgb(224, 224, 224);
            btnLibrarian.BackColor = Color.FromArgb(224, 224, 224);
            btnCustomer.BackColor = Color.FromArgb(224, 224, 224);
            btnBorrow.BackColor = Color.FromArgb(224, 224, 224);
            btnReturn.BackColor = Color.FromArgb(224, 224, 224);
            btnAdjustment.BackColor = Color.FromArgb(224, 224, 224);
            btnPurchase.BackColor = Color.FromArgb(224, 224, 224);
            btnPOS.BackColor = Color.FromArgb(224, 224, 224);

            btnDashboard.ForeColor = Color.FromArgb(119, 176, 170);
            btnItem.ForeColor = Color.FromArgb(119, 176, 170);
            btnLibrarian.ForeColor = Color.FromArgb(119, 176, 170);
            btnCustomer.ForeColor = Color.FromArgb(119, 176, 170);
            btnBorrow.ForeColor = Color.FromArgb(119, 176, 170);
            btnReturn.ForeColor = Color.FromArgb(119, 176, 170);
            btnAdjustment.ForeColor = Color.FromArgb(119, 176, 170);
            btnPurchase.ForeColor = Color.FromArgb(119, 176, 170);
            btnPOS.ForeColor = Color.FromArgb(119, 176, 170);

            VendorForm vendorForm = new VendorForm();
            vendorForm.TopLevel = false;
            vendorForm.WindowState = FormWindowState.Maximized;
            vendorForm.Dock = DockStyle.Fill;
            pnData.Controls.Add(vendorForm);
            vendorForm.Show();
            vendorForm.BringToFront();
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            btnCustomer.BackColor = Color.FromArgb(119, 176, 170);
            btnCustomer.ForeColor = Color.FromArgb(224, 224, 224);
            btnCustomer.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnCustomer.Width, btnCustomer.Height, 20, 20));

            btnDashboard.BackColor = Color.FromArgb(224, 224, 224);
            btnItem.BackColor = Color.FromArgb(224, 224, 224);
            btnLibrarian.BackColor = Color.FromArgb(224, 224, 224);
            btnVendor.BackColor = Color.FromArgb(224, 224, 224);
            btnBorrow.BackColor = Color.FromArgb(224, 224, 224);
            btnReturn.BackColor = Color.FromArgb(224, 224, 224);
            btnAdjustment.BackColor = Color.FromArgb(224, 224, 224);
            btnPurchase.BackColor = Color.FromArgb(224, 224, 224);
            btnPOS.BackColor = Color.FromArgb(224, 224, 224);

            btnDashboard.ForeColor = Color.FromArgb(119, 176, 170);
            btnItem.ForeColor = Color.FromArgb(119, 176, 170);
            btnLibrarian.ForeColor = Color.FromArgb(119, 176, 170);
            btnVendor.ForeColor = Color.FromArgb(119, 176, 170);
            btnBorrow.ForeColor = Color.FromArgb(119, 176, 170);
            btnReturn.ForeColor = Color.FromArgb(119, 176, 170);
            btnAdjustment.ForeColor = Color.FromArgb(119, 176, 170);
            btnPurchase.ForeColor = Color.FromArgb(119, 176, 170);
            btnPOS.ForeColor = Color.FromArgb(119, 176, 170);

            CustomerForm customerForm = new CustomerForm();
            customerForm.TopLevel = false;
            customerForm.WindowState = FormWindowState.Maximized;
            customerForm.Dock = DockStyle.Fill;
            pnData.Controls.Add(customerForm);
            customerForm.Show();
            customerForm.BringToFront();
        }

        private void btnBorrow_Click(object sender, EventArgs e)
        {
            btnBorrow.BackColor = Color.FromArgb(119, 176, 170);
            btnBorrow.ForeColor = Color.FromArgb(224, 224, 224);
            btnBorrow.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnBorrow.Width, btnBorrow.Height, 20, 20));

            btnDashboard.BackColor = Color.FromArgb(224, 224, 224);
            btnItem.BackColor = Color.FromArgb(224, 224, 224);
            btnLibrarian.BackColor = Color.FromArgb(224, 224, 224);
            btnVendor.BackColor = Color.FromArgb(224, 224, 224);
            btnCustomer.BackColor = Color.FromArgb(224, 224, 224);
            btnReturn.BackColor = Color.FromArgb(224, 224, 224);
            btnAdjustment.BackColor = Color.FromArgb(224, 224, 224);
            btnPurchase.BackColor = Color.FromArgb(224, 224, 224);
            btnPOS.BackColor = Color.FromArgb(224, 224, 224);

            btnDashboard.ForeColor = Color.FromArgb(119, 176, 170);
            btnItem.ForeColor = Color.FromArgb(119, 176, 170);
            btnLibrarian.ForeColor = Color.FromArgb(119, 176, 170);
            btnVendor.ForeColor = Color.FromArgb(119, 176, 170);
            btnCustomer.ForeColor = Color.FromArgb(119, 176, 170);
            btnReturn.ForeColor = Color.FromArgb(119, 176, 170);
            btnAdjustment.ForeColor = Color.FromArgb(119, 176, 170);
            btnPurchase.ForeColor = Color.FromArgb(119, 176, 170);
            btnPOS.ForeColor = Color.FromArgb(119, 176, 170);

            BorrowForm borrowForm = new BorrowForm();
            borrowForm.TopLevel = false;
            borrowForm.WindowState = FormWindowState.Maximized;
            borrowForm.Dock = DockStyle.Fill;
            pnData.Controls.Add(borrowForm);
            borrowForm.Show();
            borrowForm.BringToFront();
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            btnReturn.BackColor = Color.FromArgb(119, 176, 170);
            btnReturn.ForeColor = Color.FromArgb(224, 224, 224);
            btnReturn.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnReturn.Width, btnReturn.Height, 20, 20));

            btnDashboard.BackColor = Color.FromArgb(224, 224, 224);
            btnItem.BackColor = Color.FromArgb(224, 224, 224);
            btnLibrarian.BackColor = Color.FromArgb(224, 224, 224);
            btnVendor.BackColor = Color.FromArgb(224, 224, 224);
            btnCustomer.BackColor = Color.FromArgb(224, 224, 224);
            btnBorrow.BackColor = Color.FromArgb(224, 224, 224);
            btnAdjustment.BackColor = Color.FromArgb(224, 224, 224);
            btnPurchase.BackColor = Color.FromArgb(224, 224, 224);
            btnPOS.BackColor = Color.FromArgb(224, 224, 224);

            btnDashboard.ForeColor = Color.FromArgb(119, 176, 170);
            btnItem.ForeColor = Color.FromArgb(119, 176, 170);
            btnLibrarian.ForeColor = Color.FromArgb(119, 176, 170);
            btnVendor.ForeColor = Color.FromArgb(119, 176, 170);
            btnCustomer.ForeColor = Color.FromArgb(119, 176, 170);
            btnBorrow.ForeColor = Color.FromArgb(119, 176, 170);
            btnAdjustment.ForeColor = Color.FromArgb(119, 176, 170);
            btnPurchase.ForeColor = Color.FromArgb(119, 176, 170);
            btnPOS.ForeColor = Color.FromArgb(119, 176, 170);

            ReturnForm returnForm = new ReturnForm();
            returnForm.TopLevel = false;
            returnForm.WindowState = FormWindowState.Maximized;
            returnForm.Dock = DockStyle.Fill;
            pnData.Controls.Add(returnForm);
            returnForm.Show();
            returnForm.BringToFront();
        }

        private void btnAdjustment_Click(object sender, EventArgs e)
        {
            btnAdjustment.BackColor = Color.FromArgb(119, 176, 170);
            btnAdjustment.ForeColor = Color.FromArgb(224, 224, 224);
            btnAdjustment.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnAdjustment.Width, btnAdjustment.Height, 20, 20));

            btnDashboard.BackColor = Color.FromArgb(224, 224, 224);
            btnItem.BackColor = Color.FromArgb(224, 224, 224);
            btnLibrarian.BackColor = Color.FromArgb(224, 224, 224);
            btnVendor.BackColor = Color.FromArgb(224, 224, 224);
            btnCustomer.BackColor = Color.FromArgb(224, 224, 224);
            btnBorrow.BackColor = Color.FromArgb(224, 224, 224);
            btnReturn.BackColor = Color.FromArgb(224, 224, 224);
            btnPurchase.BackColor = Color.FromArgb(224, 224, 224);
            btnPOS.BackColor = Color.FromArgb(224, 224, 224);

            btnDashboard.ForeColor = Color.FromArgb(119, 176, 170);
            btnItem.ForeColor = Color.FromArgb(119, 176, 170);
            btnLibrarian.ForeColor = Color.FromArgb(119, 176, 170);
            btnVendor.ForeColor = Color.FromArgb(119, 176, 170);
            btnCustomer.ForeColor = Color.FromArgb(119, 176, 170);
            btnBorrow.ForeColor = Color.FromArgb(119, 176, 170);
            btnReturn.ForeColor = Color.FromArgb(119, 176, 170);
            btnPurchase.ForeColor = Color.FromArgb(119, 176, 170);
            btnPOS.ForeColor = Color.FromArgb(119, 176, 170);

            AdjustmentForm adjustmentForm = new AdjustmentForm();
            adjustmentForm.TopLevel = false;
            adjustmentForm.WindowState = FormWindowState.Maximized;
            adjustmentForm.Dock = DockStyle.Fill;
            pnData.Controls.Add(adjustmentForm);
            adjustmentForm.Show();
            adjustmentForm.BringToFront();
        }

        private void btnPurchase_Click(object sender, EventArgs e)
        {
            btnPurchase.BackColor = Color.FromArgb(119, 176, 170);
            btnPurchase.ForeColor = Color.FromArgb(224, 224, 224);
            btnPurchase.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnPurchase.Width, btnPurchase.Height, 20, 20));

            btnDashboard.BackColor = Color.FromArgb(224, 224, 224);
            btnItem.BackColor = Color.FromArgb(224, 224, 224);
            btnLibrarian.BackColor = Color.FromArgb(224, 224, 224);
            btnVendor.BackColor = Color.FromArgb(224, 224, 224);
            btnCustomer.BackColor = Color.FromArgb(224, 224, 224);
            btnBorrow.BackColor = Color.FromArgb(224, 224, 224);
            btnReturn.BackColor = Color.FromArgb(224, 224, 224);
            btnAdjustment.BackColor = Color.FromArgb(224, 224, 224);
            btnPOS.BackColor = Color.FromArgb(224, 224, 224);

            btnDashboard.ForeColor = Color.FromArgb(119, 176, 170);
            btnItem.ForeColor = Color.FromArgb(119, 176, 170);
            btnLibrarian.ForeColor = Color.FromArgb(119, 176, 170);
            btnVendor.ForeColor = Color.FromArgb(119, 176, 170);
            btnCustomer.ForeColor = Color.FromArgb(119, 176, 170);
            btnBorrow.ForeColor = Color.FromArgb(119, 176, 170);
            btnReturn.ForeColor = Color.FromArgb(119, 176, 170);
            btnAdjustment.ForeColor = Color.FromArgb(119, 176, 170);
            btnPOS.ForeColor = Color.FromArgb(119, 176, 170);

            PurchaseForm purchaseForm = new PurchaseForm();
            purchaseForm.TopLevel = false;
            purchaseForm.WindowState = FormWindowState.Maximized;
            purchaseForm.Dock = DockStyle.Fill;
            pnData.Controls.Add(purchaseForm);
            purchaseForm.Show();
            purchaseForm.BringToFront();
        }

        private void btnPOS_Click(object sender, EventArgs e)
        {
            btnPOS.BackColor = Color.FromArgb(119, 176, 170);
            btnPOS.ForeColor = Color.FromArgb(224, 224, 224);

            btnItem.BackColor = Color.FromArgb(224, 224, 224);
            btnLibrarian.BackColor = Color.FromArgb(224, 224, 224);
            btnVendor.BackColor = Color.FromArgb(224, 224, 224);
            btnCustomer.BackColor = Color.FromArgb(224, 224, 224);
            btnBorrow.BackColor = Color.FromArgb(224, 224, 224);
            btnReturn.BackColor = Color.FromArgb(224, 224, 224);
            btnAdjustment.BackColor = Color.FromArgb(224, 224, 224);
            btnPurchase.BackColor = Color.FromArgb(224, 224, 224);
            btnDashboard.BackColor = Color.FromArgb(224, 224, 224);

            btnItem.ForeColor = Color.FromArgb(119, 176, 170);
            btnLibrarian.ForeColor = Color.FromArgb(119, 176, 170);
            btnVendor.ForeColor = Color.FromArgb(119, 176, 170);
            btnCustomer.ForeColor = Color.FromArgb(119, 176, 170);
            btnBorrow.ForeColor = Color.FromArgb(119, 176, 170);
            btnReturn.ForeColor = Color.FromArgb(119, 176, 170);
            btnAdjustment.ForeColor = Color.FromArgb(119, 176, 170);
            btnPurchase.ForeColor = Color.FromArgb(119, 176, 170);
            btnDashboard.ForeColor = Color.FromArgb(119, 176, 170);
            POSForm pOSForm = new POSForm();
            pOSForm.TopLevel = false;
            pOSForm.WindowState = FormWindowState.Maximized;
            pOSForm.Dock = DockStyle.Fill;
            pnData.Controls.Add(pOSForm);
            pOSForm.Show();
            pOSForm.BringToFront();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void tmr_Tick(object sender, EventArgs e)
        {
            lbDate.Text = DateTime.Now.ToString("D");
            lbTime.Text = DateTime.Now.ToString("T");
        }

        private void label3_Click(object sender, EventArgs e)
        {
            AboutUs.TopLevel = true;
            AboutUs.ShowDialog();
        }

        private void pnFooter_Click(object sender, EventArgs e)
        {
            AboutUs.TopLevel = true;
            AboutUs.ShowDialog();
        }

        private void pnHeader_Click(object sender, EventArgs e)
        {
            AboutUs.TopLevel = true;
            AboutUs.ShowDialog();
        }
    }
}
