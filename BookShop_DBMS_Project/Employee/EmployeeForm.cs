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

namespace BookShop_DBMS_Project.Librarian
{
    public partial class EmployeeForm : Form
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        public static extern IntPtr CreateRoundRectRgn(int left, int top, int right, int bottom, int width, int height);

        public EmployeeForm()
        {
            InitializeComponent();
        }

        Consts Consts = new Consts();
        bool succes = false;
        
        // SOME VARIBLE AND ARRAY
        string id_;
        string imgLocation = null;
        string curentImageName = null;
        string curentImagePath = null;
        string[] gender = new string[] { "Male", "Female", "Other" };
        string[] status = new string[] { "Single", "Taken", "Divoid" };
        string[] child = new string[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
        string[] department = new string[] { "Owner", "Manager", "Admin Staff", "Sale Staff" };

        // THIS IS USE FOR ADD ITEMS TO COMBOBOX
        void ComboBoxAddItem_()
        {
            foreach (var item in gender) cbGender.Items.Add(item);
            foreach (var item in status) cbStatus.Items.Add(item);
            foreach (var item in department) cbDep.Items.Add(item);
            cbGender.Text = gender[0];
            cbStatus.Text = status[0];
            cbDep.Text = department[0];
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

        // THIS IS USE FOR BROWSE IMAGE
        void BrowseImage_()
        {
            try
            {
                OpenFileDialog dailog = new OpenFileDialog();
                dailog.Filter = "jpg files(*.jpg)|*.jpg| PNG files(*.png)|*.png| All Files(*.*)|*.*";
                dailog.FilterIndex = 1;
                pcbEmp.ImageLocation = null;
                if (dailog.ShowDialog() == DialogResult.OK)
                {
                    imgLocation = null;
                    imgLocation = dailog.FileName.ToString();
                    pcbEmp.ImageLocation = imgLocation;
                    curentImageName = Path.GetFileName(imgLocation);
                }
                else return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // THIS IS USE FOR COPY IMAGE AND STORE IN APPLICATION
        void CopyImage_()
        {
            if (!string.IsNullOrEmpty(curentImageName))
            {
                string imgDesPath = Path.Combine(Application.StartupPath, "Staff-img", curentImageName);
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

        //void DeleteImg_()
        //{
        //    SqlConnection conn = new SqlConnection(Consts.conString);
        //    try
        //    {
        //        conn.Open();
        //        string query_ = "SELECT ite_pic FROM Item_TB WHERE ite_id = @id";
        //        SqlCommand cmd = new SqlCommand(query_, conn);
        //        cmd.Parameters.AddWithValue("@id", id_);
        //        SqlDataReader dr = cmd.ExecuteReader();
        //        if (dr.Read())
        //        {
        //            ImgPath_ = dr[0].ToString();
        //        }
        //        dr.Close();
        //        conn.Close();
        //    }
        //    catch (SqlException ex)
        //    {
        //        conn.Close();
        //        MessageBox.Show(ex.Message);
        //    }
        //    File.Delete(ImgPath_);
        //}


        // THIS IS USE FOR CLEAR TEMP IMAGE
        void ClearImg_()
        {
            if (!string.IsNullOrEmpty(curentImagePath))
            {
                if (!succes) File.Delete(curentImagePath);
                else return;
            }
            else return;
            
        }

        // CLEAR INPUT
        void ClearInput_()
        {
            cbSpouse.Text = ("null");
            cbChild.Text = "null";
            txtName.Text = "Example Name:";
            txtName.ForeColor = Color.Gray;
            txtPhone.Text = "0xx xxx xxx";
            txtPhone.ForeColor = Color.Gray;
            txtAddress.Text = "Siem Reap";
            txtAddress.ForeColor = Color.Gray;
            txtUs.Text = string.Empty;
            txtPass.Text = string.Empty;
        }

        // THIS USE FORM LOAD DATA
        void LoadData_()
        {
            SqlConnection conn = new SqlConnection(Consts.conString);
            try
            {
                conn.Open();
                string sql = "SELECT * FROM Employee_TB, User_TB;";
                SqlCommand command = new SqlCommand(sql, conn);
                SqlDataReader reader = command.ExecuteReader();
                //dgvEmp.Refresh();
                dgvEmp.Rows.Clear();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        FileStream stream = new FileStream(reader[12].ToString(), FileMode.Open);
                        MemoryStream photoStream = new MemoryStream();
                        stream.CopyTo(photoStream);
                        stream.Close();
                        dgvEmp.Rows.Add(reader[0], reader[1], reader[2], reader[4], reader[5], reader[6], reader[3], reader[7], reader[8], reader[10], reader[9], reader[15], reader[16], reader[11], Image.FromStream(photoStream));
                    }
                }
                reader.Close();
                conn.Close();
            }
            catch (SqlException ex)
            {
                conn.Close();
                MessageBox.Show(ex.Message);
            }
        }

        // ADD RECORD
        void InsertDatabase_()
        {
            SqlConnection conn = new SqlConnection(Consts.conString);
            try
            {
                conn.Open();
                string sql = "INSERT INTO Employee_TB (emp_name, emp_gen, emp_dob, emp_status, emp_spouse, emp_child, emp_position, emp_department, emp_doh, emp_phone, emp_address, emp_photo) VALUES (@name, @gen, @dob, @status, @spouse, @child, @pos, @dep, @doh, @phone, @add, @pic) INSERT INTO User_TB (usr_username, usr_password) VALUES (@uname, @pass);";
                SqlCommand command = new SqlCommand(sql, conn);
                command.Parameters.AddWithValue("@name", txtName.Text);
                command.Parameters.AddWithValue("@gen", cbGender.Text);
                command.Parameters.AddWithValue("@dob", dtpDob.Value);
                command.Parameters.AddWithValue("@status", cbStatus.Text);
                command.Parameters.AddWithValue("@spouse", cbSpouse.Text);
                command.Parameters.AddWithValue("@child", cbChild.Text);
                command.Parameters.AddWithValue("@pos", cbPos.Text);
                command.Parameters.AddWithValue("@dep", cbDep.Text);
                command.Parameters.AddWithValue("@doh", dtpDoh.Value);
                command.Parameters.AddWithValue("@phone", txtPhone.Text);
                command.Parameters.AddWithValue("@add", txtAddress.Text);
                command.Parameters.AddWithValue("@pic", curentImagePath);
                command.Parameters.AddWithValue("@uname", txtUs.Text);
                command.Parameters.AddWithValue("@pass", txtPass.Text);
                command.ExecuteNonQuery();
                conn.Close();
                LoadData_();
                succes = true;
            }
            catch (SqlException ex)
            {
                succes = false;
                conn.Close();
                MessageBox.Show(ex.Message);
            }
        }

        private void EmployeeForm_Load(object sender, EventArgs e)
        {
            LoadData_();
            ComboBoxAddItem_();
            cbSpouse.Text = ("null");
            cbChild.Text = "null";
            txtName.Text = "Example Name:";
            txtName.ForeColor = Color.Gray;
            txtPhone.Text = "0xx xxx xxx";
            txtPhone.ForeColor = Color.Gray;
            txtAddress.Text = "Siem Reap";
            txtAddress.ForeColor = Color.Gray;

            dtpDob.CustomFormat = "dd-MMM-yyyy";
            dtpDoh.CustomFormat = "dd-MMM-yyyy";
        }

        private void pcbEmp_Click(object sender, EventArgs e)
        {
            BrowseImage_();
            CopyImage_();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!DoValidation_()) return;
            InsertDatabase_();
            ClearImg_();
            ClearInput_();
        }

        private void cbGender_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbGender.SelectedIndex == 0 && cbStatus.SelectedIndex == 1) cbSpouse.Text = ("Wife");
            else if (cbGender.SelectedIndex == 1 && cbStatus.SelectedIndex == 1) cbSpouse.Text = ("Husband");
            else if (cbGender.SelectedIndex == 2) cbSpouse.Text = ("Other");
            else cbSpouse.Text = "null";
        }

        private void cbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbGender.SelectedIndex == 0 && cbStatus.SelectedIndex == 1)
            {
                cbSpouse.Text = ("Wife");
                foreach (var item in child) cbChild.Items.Add(item);
                cbChild.Text = (child[0]);
            }
            else if (cbGender.SelectedIndex == 1 && cbStatus.SelectedIndex == 1)
            {
                cbSpouse.Text = ("Husband");
                foreach (var item in child) cbChild.Items.Add(item);
                cbChild.Text = (child[0]);
            }
            else if (cbGender.SelectedIndex == 2) cbSpouse.Text = ("Other");
            else
            {
                cbSpouse.Text = "null";
                cbChild.Text = "null";
            }
        }

        private void txtName_Click(object sender, EventArgs e)
        {
            txtName.Text = string.Empty;
            txtName.ForeColor = Color.Black;
        }

        private void cbDep_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbDep.SelectedIndex == 0)
            {
                cbPos.Items.Clear();
                cbPos.Items.Add("Owner");
                cbPos.Text = "Owner";
            }
            else if (cbDep.SelectedIndex == 1)
            {
                cbPos.Items.Clear();
                cbPos.Items.Add("Manager");
                cbPos.Text = "Manager";
            }
            else if (cbDep.SelectedIndex == 2)
            {
                cbPos.Items.Clear();
                cbPos.Items.Add("Admin");
                cbPos.Items.Add("HR");
                cbPos.Items.Add("Account");
                cbPos.Text = "Admin";
            }
            else
            {
                cbPos.Items.Clear();
                cbPos.Items.Add("Sale");
                cbPos.Text = "Sale";
            }
        }

        private void txtPhone_Click(object sender, EventArgs e)
        {
            txtPhone.Text = string.Empty;
            txtPhone.ForeColor = Color.Black;
        }

        private void txtAddress_Click(object sender, EventArgs e)
        {
            txtAddress.Text = string.Empty;
            txtAddress.ForeColor = Color.Black;
        }

        private void dgvEmp_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvEmp.SelectedRows.Count > 0) id_ = dgvEmp.SelectedRows[0].Cells[0].Value.ToString();
            else
            {
                MessageBox.Show("You Click Out of Range.", "Error...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
    }
}
