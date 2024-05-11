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
using static Bunifu.UI.WinForms.BunifuSnackbar;

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
        string currentImgUrl = null;
        string ImgPath_ = null;
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
                    succes = true;
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
            if (!string.IsNullOrEmpty(imgLocation))
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
                string sql = "select * from employee_tb  inner join user_tb on User_TB.emp_id = Employee_TB.emp_id;";
                SqlCommand command = new SqlCommand(sql, conn);
                SqlDataReader reader = command.ExecuteReader();
                dgvEmp.Refresh();
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
                string sql_insert = "INSERT INTO Employee_TB (emp_name, emp_gen, emp_dob, emp_status, emp_spouse, emp_child, emp_position, emp_department, emp_doh, emp_phone, emp_address, emp_photo) OUTPUT INSERTED.emp_id VALUES (@name, @gen, @dob, @status, @spouse, @child, @pos, @dep, @doh, @phone, @add, @pic);";
                string sql = "INSERT INTO User_TB (emp_id, usr_username, usr_password) VALUES (@id_, @u_name, @pass);";

                SqlCommand command = new SqlCommand(sql_insert, conn);
                SqlCommand cmdAddId = new SqlCommand(sql, conn);

                command.Parameters.AddWithValue("@name", txtName.Text);
                command.Parameters.AddWithValue("@gen", cbGender.Text);
                command.Parameters.AddWithValue("@dob", dtpDob.Value.Date);
                command.Parameters.AddWithValue("@status", cbStatus.Text);
                command.Parameters.AddWithValue("@spouse", cbSpouse.Text);
                command.Parameters.AddWithValue("@child", cbChild.Text);
                command.Parameters.AddWithValue("@pos", cbPos.Text);
                command.Parameters.AddWithValue("@dep", cbDep.Text);
                command.Parameters.AddWithValue("@doh", dtpDoh.Value.Date);
                command.Parameters.AddWithValue("@phone", txtPhone.Text);
                command.Parameters.AddWithValue("@add", txtAddress.Text);
                command.Parameters.AddWithValue("@pic", curentImagePath);

                //INSERT ID
                string empid = command.ExecuteScalar().ToString();
                cmdAddId.Parameters.AddWithValue("@id_", empid);
                cmdAddId.Parameters.AddWithValue("@u_name", txtUs.Text);
                cmdAddId.Parameters.AddWithValue("@pass", txtPass.Text);
                cmdAddId.ExecuteNonQuery();
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

        void DeleteImg_()
        {
            SqlConnection conn = new SqlConnection(Consts.conString);
            try
            {
                conn.Open();
                string query_ = "SELECT emp_photo FROM Employee_TB WHERE emp_id = @id";
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

        // UPDATE RECORD
        void UpdateDatabase_()
        {
            SqlConnection conn = new SqlConnection(Consts.conString);
            try
            {
                conn.Open();
                string sql = "UPDATE Employee_TB SET emp_name = @name, emp_gen = @gen, emp_dob = @dob, emp_status = @status, emp_spouse = @spouse, emp_child = @child, emp_position = @pos, emp_department = @dep, emp_doh = @doh, emp_phone = @phone, emp_address = @add, emp_photo = @pic WHERE emp_id = @id_;";
                string sql_1 = "UPDATE Employee_TB SET emp_name = @name, emp_gen = @gen, emp_dob = @dob, emp_status = @status, emp_spouse = @spouse, emp_child = @child, emp_position = @pos, emp_department = @dep, emp_doh = @doh, emp_phone = @phone, emp_address = @add WHERE emp_id = @id_;";
                string query_1 = "UPDATE User_TB SET usr_username = @us, usr_password = @pass WHERE emp_id = @ids;";

                SqlCommand updateCmd = new SqlCommand(sql, conn);
                SqlCommand updateCmd1 = new SqlCommand(query_1, conn);
                updateCmd.Parameters.AddWithValue("@name", txtName.Text);
                updateCmd.Parameters.AddWithValue("@gen", cbGender.Text);
                updateCmd.Parameters.AddWithValue("@dob", dtpDob.Value.Date);
                updateCmd.Parameters.AddWithValue("@status", cbStatus.Text);
                updateCmd.Parameters.AddWithValue("@spouse", cbSpouse.Text);
                updateCmd.Parameters.AddWithValue("@child", cbChild.Text);
                updateCmd.Parameters.AddWithValue("@pos", cbPos.Text);
                updateCmd.Parameters.AddWithValue("@dep", cbDep.Text);
                updateCmd.Parameters.AddWithValue("@doh", dtpDoh.Value.Date);
                updateCmd.Parameters.AddWithValue("@phone", txtPhone.Text);
                updateCmd.Parameters.AddWithValue("@add", txtAddress.Text);
                updateCmd1.Parameters.AddWithValue("@us", txtUs.Text);
                updateCmd1.Parameters.AddWithValue("@pass", txtPass.Text);
                updateCmd.Parameters.AddWithValue("@id_", id_);
                updateCmd1.Parameters.AddWithValue("@ids", id_);
                if (succes)
                {
                    updateCmd.Parameters.AddWithValue("@pic", curentImagePath);
                    File.Delete(currentImgUrl);
                    succes = false;
                    updateCmd.CommandText = sql;
                }
                else
                {
                    updateCmd.CommandText = sql_1;

                }
                updateCmd.ExecuteNonQuery();
                updateCmd1.ExecuteNonQuery();
                MessageBox.Show("Employee Information Updated.", "Success...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                conn.Close();
            }
            catch (SqlException ex)
            {
                conn.Close();
                MessageBox.Show(ex.Message);
            }
        }

        // DELETE RECORD
        void DeleteRecord_()
        {
            SqlConnection conn = new SqlConnection(Consts.conString);
            try
            {
                conn.Open();
                string sql = "DELETE FROM Employee_TB WHERE emp_id = @id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", id_);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch(SqlException ex)
            {
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
            txtUs.Text = "admin";
            txtUs.ForeColor = Color.Gray;
            txtPass.Text = "admin";
            txtPass.ForeColor = Color.Gray;

            dtpDob.CustomFormat = "dd-MMM-yyyy";
            dtpDoh.CustomFormat = "dd-MMM-yyyy";
        }

        private void pcbEmp_Click(object sender, EventArgs e)
        {
            BrowseImage_();
            CopyImage_();
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
            SqlConnection conn = new SqlConnection(Consts.conString);
            if (dgvEmp.SelectedRows.Count > 0)
            {
                id_ = dgvEmp.SelectedRows[0].Cells[0].Value.ToString();
                txtName.Text = dgvEmp.SelectedRows[0].Cells[1].Value.ToString();
                cbGender.Text = dgvEmp.SelectedRows[0].Cells[2].Value.ToString();
                cbStatus.Text = dgvEmp.SelectedRows[0].Cells[3].Value.ToString();
                cbSpouse.Text = dgvEmp.SelectedRows[0].Cells[4].Value.ToString();
                cbChild.Text = dgvEmp.SelectedRows[0].Cells[5].Value.ToString();
                dtpDob.Value = Convert.ToDateTime(dgvEmp.SelectedRows[0].Cells[6].Value.ToString());
                cbPos.Text = dgvEmp.SelectedRows[0].Cells[7].Value.ToString();
                cbDep.Text = dgvEmp.SelectedRows[0].Cells[8].Value.ToString();
                txtPhone.Text = dgvEmp.SelectedRows[0].Cells[9].Value.ToString();
                dtpDoh.Value = Convert.ToDateTime(dgvEmp.SelectedRows[0].Cells[10].Value.ToString());
                txtUs.Text = dgvEmp.SelectedRows[0].Cells[11].Value.ToString();
                txtPass.Text = dgvEmp.SelectedRows[0].Cells[12].Value.ToString();
                txtAddress.Text = dgvEmp.SelectedRows[0].Cells[13].Value.ToString();
                conn.Open();
                SqlCommand cmd = new SqlCommand($"select emp_photo from employee_tb where emp_id = '{id_}'", conn);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read()) currentImgUrl = dr[0].ToString();
                conn.Close();
                pcbEmp.ImageLocation = currentImgUrl;
            }
            else
            {
                //MessageBox.Show("You Click Out of Range.", "Error...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void txtUs_Click(object sender, EventArgs e)
        {
            txtUs.Text = string.Empty;
            txtUs.ForeColor = Color.Black;
        }

        private void txtPass_Click(object sender, EventArgs e)
        {
            txtPass.Text = string.Empty;
            txtPass.ForeColor = Color.Black;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            UpdateDatabase_();
            LoadData_();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!DoValidation_()) return;
            InsertDatabase_();
            ClearInput_();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are You Sure Wanna Delete This Record?", "Question...", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                DeleteImg_();
                DeleteRecord_();
                LoadData_();
            }
            else return;
        }
    }
}
