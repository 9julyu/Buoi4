using System;
using System.Windows.Forms;

namespace Buoi4
{
    public partial class frmListView : Form
    {
        public frmListView()
        {
            InitializeComponent();
        }

        // Nút thêm nhân viên
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                FrmNhanVien frmNhanVien = new FrmNhanVien();
                if (frmNhanVien.ShowDialog() == DialogResult.OK)
                {
                    // Lấy dữ liệu từ form con
                    string msnv = frmNhanVien.MSNV;
                    string tenNV = frmNhanVien.EmployeeName;
                    decimal luongCB = frmNhanVien.Luong;

                    if (string.IsNullOrWhiteSpace(msnv) || string.IsNullOrWhiteSpace(tenNV) || luongCB <= 0)
                    {
                        MessageBox.Show("Dữ liệu không hợp lệ, vui lòng kiểm tra lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Thêm vào DataGridView
                    dgvNhanVien.Rows.Add(msnv, tenNV, luongCB);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Nút đóng form
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Nút xóa nhân viên
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvNhanVien.CurrentRow != null)
                {
                    DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        dgvNhanVien.Rows.RemoveAt(dgvNhanVien.CurrentRow.Index);
                        MessageBox.Show("Xóa nhân viên thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn một hàng để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Nút cập nhật thông tin nhân viên
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra xem có hàng nào được chọn không
                if (dgvNhanVien.CurrentRow != null)
                {
                    // Lấy dữ liệu từ hàng đang chọn
                    string employeeID = dgvNhanVien.CurrentRow.Cells[0]?.Value?.ToString();
                    string employeeName = dgvNhanVien.CurrentRow.Cells[1]?.Value?.ToString();
                    string salaryString = dgvNhanVien.CurrentRow.Cells[2]?.Value?.ToString();

                    if (string.IsNullOrWhiteSpace(employeeID) || string.IsNullOrWhiteSpace(employeeName) || !decimal.TryParse(salaryString, out decimal basicSalary))
                    {
                        MessageBox.Show("Dữ liệu không hợp lệ, vui lòng kiểm tra lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Hiển thị form chỉnh sửa
                    FrmNhanVien frmNhanVien = new FrmNhanVien();
                    frmNhanVien.SetData(employeeID, employeeName, basicSalary);

                    if (frmNhanVien.ShowDialog() == DialogResult.OK)
                    {
                        // Cập nhật lại dữ liệu vào DataGridView
                        dgvNhanVien.CurrentRow.Cells[0].Value = frmNhanVien.MSNV;
                        dgvNhanVien.CurrentRow.Cells[1].Value = frmNhanVien.EmployeeName;
                        dgvNhanVien.CurrentRow.Cells[2].Value = frmNhanVien.Luong;
                        MessageBox.Show("Cập nhật thông tin nhân viên thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn một hàng để cập nhật.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
