using Library_DBMS.Adjustment;
using Library_DBMS.Book;
using Library_DBMS.Borrow;
using Library_DBMS.Customer;
using Library_DBMS.Dashboard;
using Library_DBMS.Librarian;
using Library_DBMS.POS;
using Library_DBMS.Purchase;
using Library_DBMS.Return;
using Library_DBMS.Vendor;
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

namespace Library_DBMS
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        public static extern IntPtr CreateRoundRectRgn(int left, int top, int right, int bottom, int width, int height);

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, this.Width, this.Height, 20, 20));
            pnHeader.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, pnHeader.Width, pnHeader.Height, 20, 20));
            pnData.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, pnData.Width, pnData.Height, 20, 20));

            // EXCUTE DASHBOARD
            {
                btnDashboard.BackColor = Color.FromArgb(0, 255, 244);
                btnDashboard.ForeColor = Color.FromArgb(37, 37, 37);
                btnDashboard.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnDashboard.Width, btnDashboard.Height, 20, 20));

                btnBook.BackColor = Color.FromArgb(37, 37, 37);
                btnLibrarian.BackColor = Color.FromArgb(37, 37, 37);
                btnVendor.BackColor = Color.FromArgb(37, 37, 37);
                btnCustomer.BackColor = Color.FromArgb(37, 37, 37);
                btnBorrow.BackColor = Color.FromArgb(37, 37, 37);
                btnReturn.BackColor = Color.FromArgb(37, 37, 37);
                btnAdjustment.BackColor = Color.FromArgb(37, 37, 37);
                btnPurchase.BackColor = Color.FromArgb(37, 37, 37);
                btnPOS.BackColor = Color.FromArgb(37, 37, 37);

                btnBook.ForeColor = Color.FromArgb(0, 255, 244);
                btnLibrarian.ForeColor = Color.FromArgb(0, 255, 244);
                btnVendor.ForeColor = Color.FromArgb(0, 255, 244);
                btnCustomer.ForeColor = Color.FromArgb(0, 255, 244);
                btnBorrow.ForeColor = Color.FromArgb(0, 255, 244);
                btnReturn.ForeColor = Color.FromArgb(0, 255, 244);
                btnAdjustment.ForeColor = Color.FromArgb(0, 255, 244);
                btnPurchase.ForeColor = Color.FromArgb(0, 255, 244);
                btnPOS.ForeColor = Color.FromArgb(0, 255, 244);

                DashboardForm dashboardForm = new DashboardForm();
                dashboardForm.TopLevel = false;
                dashboardForm.WindowState = FormWindowState.Maximized;
                dashboardForm.Dock = DockStyle.Fill;
                pnData.Controls.Add(dashboardForm);
                dashboardForm.Show();
                dashboardForm.BringToFront();
            }
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            btnDashboard.BackColor = Color.FromArgb(0, 255, 244);
            btnDashboard.ForeColor = Color.FromArgb(37, 37, 37);
            btnDashboard.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnDashboard.Width, btnDashboard.Height, 20, 20));

            btnBook.BackColor = Color.FromArgb(37, 37, 37);
            btnLibrarian.BackColor = Color.FromArgb(37, 37, 37);
            btnVendor.BackColor = Color.FromArgb(37, 37, 37);
            btnCustomer.BackColor = Color.FromArgb(37, 37, 37);
            btnBorrow.BackColor = Color.FromArgb(37, 37, 37);
            btnReturn.BackColor = Color.FromArgb(37, 37, 37);
            btnAdjustment.BackColor = Color.FromArgb(37, 37, 37);
            btnPurchase.BackColor = Color.FromArgb(37, 37, 37);
            btnPOS.BackColor = Color.FromArgb(37, 37, 37);

            btnBook.ForeColor = Color.FromArgb(0, 255, 244);
            btnLibrarian.ForeColor = Color.FromArgb(0, 255, 244);
            btnVendor.ForeColor = Color.FromArgb(0, 255, 244);
            btnCustomer.ForeColor = Color.FromArgb(0, 255, 244);
            btnBorrow.ForeColor = Color.FromArgb(0, 255, 244);
            btnReturn.ForeColor = Color.FromArgb(0, 255, 244);
            btnAdjustment.ForeColor = Color.FromArgb(0, 255, 244);
            btnPurchase.ForeColor = Color.FromArgb(0, 255, 244);
            btnPOS.ForeColor = Color.FromArgb(0, 255, 244);

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
            btnBook.BackColor = Color.FromArgb(0, 255, 244);
            btnBook.ForeColor = Color.FromArgb(37, 37, 37);
            btnBook.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnBook.Width, btnBook.Height, 20, 20));

            btnDashboard.BackColor = Color.FromArgb(37, 37, 37);
            btnLibrarian.BackColor = Color.FromArgb(37, 37, 37);
            btnVendor.BackColor = Color.FromArgb(37, 37, 37);
            btnCustomer.BackColor = Color.FromArgb(37, 37, 37);
            btnBorrow.BackColor = Color.FromArgb(37, 37, 37);
            btnReturn.BackColor = Color.FromArgb(37, 37, 37);
            btnAdjustment.BackColor = Color.FromArgb(37, 37, 37);
            btnPurchase.BackColor = Color.FromArgb(37, 37, 37);
            btnPOS.BackColor = Color.FromArgb(37, 37, 37);

            btnDashboard.ForeColor = Color.FromArgb(0, 255, 244);
            btnLibrarian.ForeColor = Color.FromArgb(0, 255, 244);
            btnVendor.ForeColor = Color.FromArgb(0, 255, 244);
            btnCustomer.ForeColor = Color.FromArgb(0, 255, 244);
            btnBorrow.ForeColor = Color.FromArgb(0, 255, 244);
            btnReturn.ForeColor = Color.FromArgb(0, 255, 244);
            btnAdjustment.ForeColor = Color.FromArgb(0, 255, 244);
            btnPurchase.ForeColor = Color.FromArgb(0, 255, 244);
            btnPOS.ForeColor = Color.FromArgb(0, 255, 244);

            BookForm bookForm = new BookForm();
            bookForm.TopLevel = false;
            bookForm.WindowState = FormWindowState.Maximized;
            bookForm.Dock = DockStyle.Fill;
            pnData.Controls.Add(bookForm);
            bookForm.Show();
            bookForm.BringToFront();
        }

        private void btnLibrarian_Click(object sender, EventArgs e)
        {
            btnLibrarian.BackColor = Color.FromArgb(0, 255, 244);
            btnLibrarian.ForeColor = Color.FromArgb(37, 37, 37);
            btnLibrarian.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnLibrarian.Width, btnLibrarian.Height, 20, 20));

            btnDashboard.BackColor = Color.FromArgb(37, 37, 37);
            btnBook.BackColor = Color.FromArgb(37, 37, 37);
            btnVendor.BackColor = Color.FromArgb(37, 37, 37);
            btnCustomer.BackColor = Color.FromArgb(37, 37, 37);
            btnBorrow.BackColor = Color.FromArgb(37, 37, 37);
            btnReturn.BackColor = Color.FromArgb(37, 37, 37);
            btnAdjustment.BackColor = Color.FromArgb(37, 37, 37);
            btnPurchase.BackColor = Color.FromArgb(37, 37, 37);
            btnPOS.BackColor = Color.FromArgb(37, 37, 37);

            btnDashboard.ForeColor = Color.FromArgb(0, 255, 244);
            btnBook.ForeColor = Color.FromArgb(0, 255, 244);
            btnVendor.ForeColor = Color.FromArgb(0, 255, 244);
            btnCustomer.ForeColor = Color.FromArgb(0, 255, 244);
            btnBorrow.ForeColor = Color.FromArgb(0, 255, 244);
            btnReturn.ForeColor = Color.FromArgb(0, 255, 244);
            btnAdjustment.ForeColor = Color.FromArgb(0, 255, 244);
            btnPurchase.ForeColor = Color.FromArgb(0, 255, 244);
            btnPOS.ForeColor = Color.FromArgb(0, 255, 244);

            LibrarianForm librarianForm = new LibrarianForm();
            librarianForm.TopLevel = false;
            librarianForm.WindowState = FormWindowState.Maximized;
            librarianForm.Dock = DockStyle.Fill;
            pnData.Controls.Add(librarianForm);
            librarianForm.Show();
            librarianForm.BringToFront();
        }

        private void btnVendor_Click(object sender, EventArgs e)
        {
            btnVendor.BackColor = Color.FromArgb(0, 255, 244);
            btnVendor.ForeColor = Color.FromArgb(37, 37, 37);
            btnVendor.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnVendor.Width, btnVendor.Height, 20, 20));

            btnDashboard.BackColor = Color.FromArgb(37, 37, 37);
            btnBook.BackColor = Color.FromArgb(37, 37, 37);
            btnLibrarian.BackColor = Color.FromArgb(37, 37, 37);
            btnCustomer.BackColor = Color.FromArgb(37, 37, 37);
            btnBorrow.BackColor = Color.FromArgb(37, 37, 37);
            btnReturn.BackColor = Color.FromArgb(37, 37, 37);
            btnAdjustment.BackColor = Color.FromArgb(37, 37, 37);
            btnPurchase.BackColor = Color.FromArgb(37, 37, 37);
            btnPOS.BackColor = Color.FromArgb(37, 37, 37);

            btnDashboard.ForeColor = Color.FromArgb(0, 255, 244);
            btnBook.ForeColor = Color.FromArgb(0, 255, 244);
            btnLibrarian.ForeColor = Color.FromArgb(0, 255, 244);
            btnCustomer.ForeColor = Color.FromArgb(0, 255, 244);
            btnBorrow.ForeColor = Color.FromArgb(0, 255, 244);
            btnReturn.ForeColor = Color.FromArgb(0, 255, 244);
            btnAdjustment.ForeColor = Color.FromArgb(0, 255, 244);
            btnPurchase.ForeColor = Color.FromArgb(0, 255, 244);
            btnPOS.ForeColor = Color.FromArgb(0, 255, 244);

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
            btnCustomer.BackColor = Color.FromArgb(0, 255, 244);
            btnCustomer.ForeColor = Color.FromArgb(37, 37, 37);
            btnCustomer.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnCustomer.Width, btnCustomer.Height, 20, 20));

            btnDashboard.BackColor = Color.FromArgb(37, 37, 37);
            btnBook.BackColor = Color.FromArgb(37, 37, 37);
            btnLibrarian.BackColor = Color.FromArgb(37, 37, 37);
            btnVendor.BackColor = Color.FromArgb(37, 37, 37);
            btnBorrow.BackColor = Color.FromArgb(37, 37, 37);
            btnReturn.BackColor = Color.FromArgb(37, 37, 37);
            btnAdjustment.BackColor = Color.FromArgb(37, 37, 37);
            btnPurchase.BackColor = Color.FromArgb(37, 37, 37);
            btnPOS.BackColor = Color.FromArgb(37, 37, 37);

            btnDashboard.ForeColor = Color.FromArgb(0, 255, 244);
            btnBook.ForeColor = Color.FromArgb(0, 255, 244);
            btnLibrarian.ForeColor = Color.FromArgb(0, 255, 244);
            btnVendor.ForeColor = Color.FromArgb(0, 255, 244);
            btnBorrow.ForeColor = Color.FromArgb(0, 255, 244);
            btnReturn.ForeColor = Color.FromArgb(0, 255, 244);
            btnAdjustment.ForeColor = Color.FromArgb(0, 255, 244);
            btnPurchase.ForeColor = Color.FromArgb(0, 255, 244);
            btnPOS.ForeColor = Color.FromArgb(0, 255, 244);

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
            btnBorrow.BackColor = Color.FromArgb(0, 255, 244);
            btnBorrow.ForeColor = Color.FromArgb(37, 37, 37);
            btnBorrow.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnBorrow.Width, btnBorrow.Height, 20, 20));

            btnDashboard.BackColor = Color.FromArgb(37, 37, 37);
            btnBook.BackColor = Color.FromArgb(37, 37, 37);
            btnLibrarian.BackColor = Color.FromArgb(37, 37, 37);
            btnVendor.BackColor = Color.FromArgb(37, 37, 37);
            btnCustomer.BackColor = Color.FromArgb(37, 37, 37);
            btnReturn.BackColor = Color.FromArgb(37, 37, 37);
            btnAdjustment.BackColor = Color.FromArgb(37, 37, 37);
            btnPurchase.BackColor = Color.FromArgb(37, 37, 37);
            btnPOS.BackColor = Color.FromArgb(37, 37, 37);

            btnDashboard.ForeColor = Color.FromArgb(0, 255, 244);
            btnBook.ForeColor = Color.FromArgb(0, 255, 244);
            btnLibrarian.ForeColor = Color.FromArgb(0, 255, 244);
            btnVendor.ForeColor = Color.FromArgb(0, 255, 244);
            btnCustomer.ForeColor = Color.FromArgb(0, 255, 244);
            btnReturn.ForeColor = Color.FromArgb(0, 255, 244);
            btnAdjustment.ForeColor = Color.FromArgb(0, 255, 244);
            btnPurchase.ForeColor = Color.FromArgb(0, 255, 244);
            btnPOS.ForeColor = Color.FromArgb(0, 255, 244);

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
            btnReturn.BackColor = Color.FromArgb(0, 255, 244);
            btnReturn.ForeColor = Color.FromArgb(37, 37, 37);
            btnReturn.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnReturn.Width, btnReturn.Height, 20, 20));

            btnDashboard.BackColor = Color.FromArgb(37, 37, 37);
            btnBook.BackColor = Color.FromArgb(37, 37, 37);
            btnLibrarian.BackColor = Color.FromArgb(37, 37, 37);
            btnVendor.BackColor = Color.FromArgb(37, 37, 37);
            btnCustomer.BackColor = Color.FromArgb(37, 37, 37);
            btnBorrow.BackColor = Color.FromArgb(37, 37, 37);
            btnAdjustment.BackColor = Color.FromArgb(37, 37, 37);
            btnPurchase.BackColor = Color.FromArgb(37, 37, 37);
            btnPOS.BackColor = Color.FromArgb(37, 37, 37);

            btnDashboard.ForeColor = Color.FromArgb(0, 255, 244);
            btnBook.ForeColor = Color.FromArgb(0, 255, 244);
            btnLibrarian.ForeColor = Color.FromArgb(0, 255, 244);
            btnVendor.ForeColor = Color.FromArgb(0, 255, 244);
            btnCustomer.ForeColor = Color.FromArgb(0, 255, 244);
            btnBorrow.ForeColor = Color.FromArgb(0, 255, 244);
            btnAdjustment.ForeColor = Color.FromArgb(0, 255, 244);
            btnPurchase.ForeColor = Color.FromArgb(0, 255, 244);
            btnPOS.ForeColor = Color.FromArgb(0, 255, 244);

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
            btnAdjustment.BackColor = Color.FromArgb(0, 255, 244);
            btnAdjustment.ForeColor = Color.FromArgb(37, 37, 37);
            btnAdjustment.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnAdjustment.Width, btnAdjustment.Height, 20, 20));

            btnDashboard.BackColor = Color.FromArgb(37, 37, 37);
            btnBook.BackColor = Color.FromArgb(37, 37, 37);
            btnLibrarian.BackColor = Color.FromArgb(37, 37, 37);
            btnVendor.BackColor = Color.FromArgb(37, 37, 37);
            btnCustomer.BackColor = Color.FromArgb(37, 37, 37);
            btnBorrow.BackColor = Color.FromArgb(37, 37, 37);
            btnReturn.BackColor = Color.FromArgb(37, 37, 37);
            btnPurchase.BackColor = Color.FromArgb(37, 37, 37);
            btnPOS.BackColor = Color.FromArgb(37, 37, 37);

            btnDashboard.ForeColor = Color.FromArgb(0, 255, 244);
            btnBook.ForeColor = Color.FromArgb(0, 255, 244);
            btnLibrarian.ForeColor = Color.FromArgb(0, 255, 244);
            btnVendor.ForeColor = Color.FromArgb(0, 255, 244);
            btnCustomer.ForeColor = Color.FromArgb(0, 255, 244);
            btnBorrow.ForeColor = Color.FromArgb(0, 255, 244);
            btnReturn.ForeColor = Color.FromArgb(0, 255, 244);
            btnPurchase.ForeColor = Color.FromArgb(0, 255, 244);
            btnPOS.ForeColor = Color.FromArgb(0, 255, 244);

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
            btnPurchase.BackColor = Color.FromArgb(0, 255, 244);
            btnPurchase.ForeColor = Color.FromArgb(37, 37, 37);
            btnPurchase.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnPurchase.Width, btnPurchase.Height, 20, 20));

            btnDashboard.BackColor = Color.FromArgb(37, 37, 37);
            btnBook.BackColor = Color.FromArgb(37, 37, 37);
            btnLibrarian.BackColor = Color.FromArgb(37, 37, 37);
            btnVendor.BackColor = Color.FromArgb(37, 37, 37);
            btnCustomer.BackColor = Color.FromArgb(37, 37, 37);
            btnBorrow.BackColor = Color.FromArgb(37, 37, 37);
            btnReturn.BackColor = Color.FromArgb(37, 37, 37);
            btnAdjustment.BackColor = Color.FromArgb(37, 37, 37);
            btnPOS.BackColor = Color.FromArgb(37, 37, 37);

            btnDashboard.ForeColor = Color.FromArgb(0, 255, 244);
            btnBook.ForeColor = Color.FromArgb(0, 255, 244);
            btnLibrarian.ForeColor = Color.FromArgb(0, 255, 244);
            btnVendor.ForeColor = Color.FromArgb(0, 255, 244);
            btnCustomer.ForeColor = Color.FromArgb(0, 255, 244);
            btnBorrow.ForeColor = Color.FromArgb(0, 255, 244);
            btnReturn.ForeColor = Color.FromArgb(0, 255, 244);
            btnAdjustment.ForeColor = Color.FromArgb(0, 255, 244);
            btnPOS.ForeColor = Color.FromArgb(0, 255, 244);

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
            btnPOS.BackColor = Color.FromArgb(0, 255, 244);
            btnPOS.ForeColor = Color.FromArgb(37, 37, 37);
            btnPOS.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnPurchase.Width, btnPurchase.Height, 20, 20));

            btnDashboard.BackColor = Color.FromArgb(37, 37, 37);
            btnBook.BackColor = Color.FromArgb(37, 37, 37);
            btnLibrarian.BackColor = Color.FromArgb(37, 37, 37);
            btnVendor.BackColor = Color.FromArgb(37, 37, 37);
            btnCustomer.BackColor = Color.FromArgb(37, 37, 37);
            btnBorrow.BackColor = Color.FromArgb(37, 37, 37);
            btnReturn.BackColor = Color.FromArgb(37, 37, 37);
            btnAdjustment.BackColor = Color.FromArgb(37, 37, 37);
            btnPurchase.BackColor = Color.FromArgb(37, 37, 37);

            btnDashboard.ForeColor = Color.FromArgb(0, 255, 244);
            btnBook.ForeColor = Color.FromArgb(0, 255, 244);
            btnLibrarian.ForeColor = Color.FromArgb(0, 255, 244);
            btnVendor.ForeColor = Color.FromArgb(0, 255, 244);
            btnCustomer.ForeColor = Color.FromArgb(0, 255, 244);
            btnBorrow.ForeColor = Color.FromArgb(0, 255, 244);
            btnReturn.ForeColor = Color.FromArgb(0, 255, 244);
            btnAdjustment.ForeColor = Color.FromArgb(0, 255, 244);
            btnPurchase.ForeColor = Color.FromArgb(0, 255, 244);

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
    }
}
