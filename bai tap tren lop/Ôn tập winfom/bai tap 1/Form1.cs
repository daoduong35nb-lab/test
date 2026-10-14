using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bai_tap_14_10_2026
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Các hàm bạn đã tạo sẵn (giữ nguyên để không bị lỗi giao diện)
        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void label2_Click(object sender, EventArgs e)
        {
        }

        private void txtSoLuong_TextChanged(object sender, EventArgs e)
        {
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        // =========================================================
        // PHẦN CODE MỚI ĐỂ XỬ LÝ BÀI TẬP CỦA BẠN
        // =========================================================

        // Sự kiện cho nút "Tính tiền"
        private void btnTinhTien_Click(object sender, EventArgs e)
        {
            // Lưu ý: Đảm bảo bạn đã đặt tên (thuộc tính Name) cho các ô nhập liệu lần lượt là: 
            // txtDonGia, txtSoLuong, txtGiamGia
            if (!decimal.TryParse(txtDonGia.Text, out decimal donGia) ||
                !int.TryParse(txtSoLuong.Text, out int soLuong) ||
                !decimal.TryParse(txtGiamGia.Text, out decimal giamGia))
            {
                MessageBox.Show("Dữ liệu nhập không hợp lệ. Vui lòng nhập số và không để trống.",
                                "Cảnh báo lỗi nhập liệu",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            // Tự động tính Tổng tiền = (Đơn giá x Số lượng) x (100 - % Giảm) / 100
            decimal tongTien = (donGia * soLuong) * ((100 - giamGia) / 100);

            // Hiển thị kết quả (Đảm bảo Label hiển thị kết quả có tên là lblTongTien)
            lblTongTien.Text = $"Tổng tiền: {tongTien:N2} VNĐ";
        }

        // Sự kiện cho nút "Làm mới"
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtDonGia.Clear();
            txtSoLuong.Clear();
            txtGiamGia.Clear();
            lblTongTien.Text = "Tổng tiền thanh toán:";

            // Đưa con trỏ chuột về ô Đơn giá
            txtDonGia.Focus();
        }
    }
}