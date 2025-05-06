using System;
using System.Linq;
using System.Windows.Forms;
using StudentManagement.Models;

namespace StudentManagement
{
    public partial class SinhVienForm : Form
    {
        private SinhVien currentSinhVien = null;

        public SinhVienForm()
        {
            InitializeComponent();
            LoadSinhViens();
            LoadKhoas();
        }

        private void LoadSinhViens()
        {
            // Bind the DataGridView to the list of students
            dgvSinhVien.DataSource = null;
            dgvSinhVien.DataSource = DataStore.SinhViens.ToList();

            // Clear the input fields
            ClearFields();
        }

        private void LoadKhoas()
        {
            // Populate the ComboBox with departments
            cboKhoa.DataSource = null;
            cboKhoa.DisplayMember = "TenKhoa";
            cboKhoa.ValueMember = "MaKhoa";
            cboKhoa.DataSource = DataStore.Khoas.ToList();
        }

        private void ClearFields()
        {
            txtMaSV.Clear();
            txtHoTen.Clear();
            if (cboKhoa.Items.Count > 0)
                cboKhoa.SelectedIndex = 0;
            txtLop.Clear();
            dtpNgaySinh.Value = DateTime.Now;
            txtDiaChi.Clear();
            currentSinhVien = null;
            txtMaSV.Enabled = true;
        }

        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(txtMaSV.Text))
            {
                MessageBox.Show("Vui lòng nhập Mã SV", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMaSV.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtHoTen.Text))
            {
                MessageBox.Show("Vui lòng nhập Họ Tên", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtHoTen.Focus();
                return false;
            }

            if (cboKhoa.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn Khoa", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cboKhoa.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtLop.Text))
            {
                MessageBox.Show("Vui lòng nhập Lớp", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtLop.Focus();
                return false;
            }

            return true;
        }

        

        

        
        

        

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs())
                return;

            string maSV = txtMaSV.Text.Trim();

            // Check if the student ID already exists
            if (DataStore.SinhViens.Any(sv => sv.MaSV == maSV))
            {
                MessageBox.Show("Mã SV đã tồn tại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMaSV.Focus();
                return;
            }

            // Create a new student and add it to the DataStore
            SinhVien sinhVien = new SinhVien
            {
                MaSV = maSV,
                HoTen = txtHoTen.Text.Trim(),
                Khoa = cboKhoa.SelectedValue.ToString(),
                Lop = txtLop.Text.Trim(),
                NgaySinh = dtpNgaySinh.Value,
                DiaChi = txtDiaChi.Text.Trim()
            };

            DataStore.SinhViens.Add(sinhVien);
            LoadSinhViens();
            MessageBox.Show("Thêm Sinh viên thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (currentSinhVien == null)
            {
                MessageBox.Show("Vui lòng chọn Sinh viên cần sửa", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!ValidateInputs())
                return;

            // Update the student properties
            currentSinhVien.HoTen = txtHoTen.Text.Trim();
            currentSinhVien.Khoa = cboKhoa.SelectedValue.ToString();
            currentSinhVien.Lop = txtLop.Text.Trim();
            currentSinhVien.NgaySinh = dtpNgaySinh.Value;
            currentSinhVien.DiaChi = txtDiaChi.Text.Trim();

            LoadSinhViens();
            MessageBox.Show("Cập nhật Sinh viên thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (currentSinhVien == null)
            {
                MessageBox.Show("Vui lòng chọn Sinh viên cần xóa", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Confirm deletion
            DialogResult result = MessageBox.Show($"Bạn có chắc chắn muốn xóa Sinh viên '{currentSinhVien.HoTen}'?",
                "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                DataStore.SinhViens.Remove(currentSinhVien);
                LoadSinhViens();
                MessageBox.Show("Xóa Sinh viên thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dgvSinhVien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < DataStore.SinhViens.Count)
            {
                // Get the selected student
                currentSinhVien = DataStore.SinhViens[e.RowIndex];

                // Populate the fields with the selected student's data
                txtMaSV.Text = currentSinhVien.MaSV;
                txtHoTen.Text = currentSinhVien.HoTen;

                // Find and select the department in the ComboBox
                for (int i = 0; i < cboKhoa.Items.Count; i++)
                {
                    Khoa khoa = cboKhoa.Items[i] as Khoa;
                    if (khoa != null && khoa.MaKhoa == currentSinhVien.Khoa)
                    {
                        cboKhoa.SelectedIndex = i;
                        break;
                    }
                }

                txtLop.Text = currentSinhVien.Lop;
                dtpNgaySinh.Value = currentSinhVien.NgaySinh;
                txtDiaChi.Text = currentSinhVien.DiaChi;

                // Disable the student ID field when editing
                txtMaSV.Enabled = false;
            }
        }
    }
}
