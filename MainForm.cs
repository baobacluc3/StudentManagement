using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentManagement
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void exitMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void khoaMenuItem_Click(object sender, EventArgs e)
        {
            // Show Khoa form
            KhoaForm khoaForm = new KhoaForm();
            khoaForm.MdiParent = this;
            khoaForm.Show();
        }

        private void sinhVienMenuItem_Click(object sender, EventArgs e)
        {
            // Show SinhVien form
            SinhVienForm sinhVienForm = new SinhVienForm();
            sinhVienForm.MdiParent = this;
            sinhVienForm.Show();
        }
    }
}
