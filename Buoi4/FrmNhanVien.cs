using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Buoi4
{
    public partial class FrmNhanVien : Form
    {
        public FrmNhanVien()
        {
            InitializeComponent();
        }

        private void FrmNhanVien_Load(object sender, EventArgs e)
        {

        }
        
            public string MSNV
        {
            get { return txtMSNV.Text; }
        }

        public string EmployeeName
        {
            get { return txtEmployeeName.Text; }
        }

        public decimal Luong
        {
            get
            {
                decimal luong;
                if (decimal.TryParse(txtLuong.Text, out luong))
                {
                    return luong;
                }
                return 0; // Giá trị mặc định nếu không chuyển đổi được
            }
        }

        private void btnAgree_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem tất cả thông tin đã được nhập chưa
            if (string.IsNullOrWhiteSpace(txtMSNV.Text.Trim()) ||
                string.IsNullOrWhiteSpace(txtEmployeeName.Text.Trim()) ||
                string.IsNullOrWhiteSpace(txtLuong.Text.Trim()))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra lương có phải là số dương hợp lệ không
            if (!decimal.TryParse(txtLuong.Text.Trim(), out decimal luong) || luong <= 0)
            {
                MessageBox.Show("Lương cơ bản phải là số dương hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Nếu tất cả đều hợp lệ, đóng form với kết quả OK
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        public void SetData(string msnv, string tenNhanVien, decimal luongCB)
        {
            txtMSNV.Text = msnv;
            txtEmployeeName.Text = tenNhanVien;
            txtLuong.Text = luongCB.ToString();
        }

    }

}
