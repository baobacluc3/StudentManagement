using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StudentManagement.Models;

namespace StudentManagement
{
    public partial class LoginForm : Form
    {
        private int loginAttempts = 0;

        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            // Check if the credentials match any user in the DataStore
            User user = DataStore.Users.FirstOrDefault(u =>
                u.Username == username && u.Password == password);

            if (user != null)
            {
                // Login successful
                MainForm mainForm = new MainForm();
                this.Hide();
                mainForm.ShowDialog();
                this.Close();
            }
            else
            {
                // Login failed
                loginAttempts++;

                if (loginAttempts >= 3)
                {
                    MessageBox.Show($"Đăng nhập sai {loginAttempts} lần. Ứng dụng sẽ thoát.",
                        "Lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                }
                else
                {
                    MessageBox.Show($"Tên đăng nhập hoặc mật khẩu không đúng. Bạn còn {3 - loginAttempts} lần thử.",
                        "Lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPassword.Clear();
                    txtPassword.Focus();
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }
    }
}
