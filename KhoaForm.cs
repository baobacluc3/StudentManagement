using System;
using System.Linq;
using System.Windows.Forms;
using StudentManagement.Models;

namespace StudentManagement
{
    public partial class KhoaForm : Form
    {
        private Khoa currentKhoa = null;

        public KhoaForm()
        {
            InitializeComponent();
            LoadKhoas();
        }

        private void LoadKhoas()
        {
            // Bind the DataGridView to the list of departments
            dgvKhoa.DataSource = null;
            dgvKhoa.DataSource = DataStore.Khoas.ToList();

            // Clear the input fields
            ClearFields();
        }

        private void ClearFields()
        {
            txtMaKhoa.Clear();
            txtTenKhoa.Clear();
            txtGhiChu.Clear();
            currentKhoa = null;
            txtMaKhoa.Enabled = true;
        }

        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(txtMaKhoa.Text))
            {
                MessageBox.Show("Vui lòng nhập Mã Khoa", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMaKhoa.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtTenKhoa.Text))
            {
                MessageBox.Show("Vui lòng nhập Tên Khoa", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTenKhoa.Focus();
                return false;
            }

            return true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs())
                return;

            string maKhoa = txtMaKhoa.Text.Trim();

            // Check if the department code already exists
            if (DataStore.Khoas.Any(k => k.MaKhoa == maKhoa))
            {
                MessageBox.Show("Mã Khoa đã tồn tại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMaKhoa.Focus();
                return;
            }

            // Create a new department and add it to the DataStore
            Khoa khoa = new Khoa
            {
                MaKhoa = maKhoa,
                TenKhoa = txtTenKhoa.Text.Trim(),
                GhiChu = txtGhiChu.Text.Trim()
            };

            DataStore.Khoas.Add(khoa);
            LoadKhoas();
            MessageBox.Show("Thêm Khoa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (currentKhoa == null)
            {
                MessageBox.Show("Vui lòng chọn Khoa cần sửa", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!ValidateInputs())
                return;

            // Update the department properties
            currentKhoa.TenKhoa = txtTenKhoa.Text.Trim();
            currentKhoa.GhiChu = txtGhiChu.Text.Trim();

            LoadKhoas();
            MessageBox.Show("Cập nhật Khoa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (currentKhoa == null)
            {
                MessageBox.Show("Vui lòng chọn Khoa cần xóa", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Check if there are any students in this department
            if (DataStore.SinhViens.Any(sv => sv.Khoa == currentKhoa.MaKhoa))
            {
                MessageBox.Show("Không thể xóa Khoa này vì đã có Sinh viên thuộc Khoa",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Confirm deletion
            DialogResult result = MessageBox.Show($"Bạn có chắc chắn muốn xóa Khoa '{currentKhoa.TenKhoa}'?",
                "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                DataStore.Khoas.Remove(currentKhoa);
                LoadKhoas();
                MessageBox.Show("Xóa Khoa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvKhoa_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < DataStore.Khoas.Count)
            {
                // Get the selected department
                currentKhoa = DataStore.Khoas[e.RowIndex];

                // Populate the fields with the selected department's data
                txtMaKhoa.Text = currentKhoa.MaKhoa;
                txtTenKhoa.Text = currentKhoa.TenKhoa;
                txtGhiChu.Text = currentKhoa.GhiChu;

                // Disable the department code field when editing
                txtMaKhoa.Enabled = false;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}