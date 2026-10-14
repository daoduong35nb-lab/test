using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bai_tap_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Giữ nguyên 2 hàm này để Form của bạn không bị lỗi khi mở lại giao diện Design
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        // =================================================================
        // CODE XỬ LÝ CHỨC NĂNG BÀI 2 (TIẾP NHẬN SỰ CỐ IT)
        // =================================================================

        // 1. Chức năng Tải ảnh
        private void btnTaiAnhLoi_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files (*.jpg;*.png)|*.jpg;*.png";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                picAnhLoi.Image = Image.FromFile(ofd.FileName);
                picAnhLoi.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        // 2. Chức năng Gửi yêu cầu
        private void btnGuiYeuCau_Click(object sender, EventArgs e)
        {
            // Lấy mức độ ưu tiên
            string mucDo = "Thấp";
            if (radTrungBinh.Checked) mucDo = "Trung bình";
            if (radKhanCap.Checked) mucDo = "Khẩn cấp";

            // Lấy thiết bị ảnh hưởng
            string thietBi = "";
            if (chkPC.Checked) thietBi += "Máy tính bàn, ";
            if (chkLaptop.Checked) thietBi += "Laptop, ";
            if (chkMayIn.Checked) thietBi += "Máy in, ";
            if (chkDienThoai.Checked) thietBi += "Điện thoại, ";

            // Cắt dấu phẩy thừa ở cuối
            if (thietBi.Length > 0)
            {
                thietBi = thietBi.TrimEnd(',', ' ');
            }
            else
            {
                thietBi = "Không có";
            }

            // Lấy loại sự cố
            string loaiSuCo = cboLoaiSuCo.SelectedItem != null ? cboLoaiSuCo.SelectedItem.ToString() : "Chưa chọn";

            // Gom thông tin tóm tắt
            string thongTinTomTat = $"MÃ PHIẾU: {txtMaPhieu.Text}\n" +
                                    $"Người yêu cầu: {txtNguoiYeuCau.Text}\n" +
                                    $"Ngày ghi nhận: {dtpNgayGhiNhan.Value.ToString("dd/MM/yyyy")}\n" +
                                    $"Mức độ ưu tiên: {mucDo}\n" +
                                    $"Loại sự cố: {loaiSuCo}\n" +
                                    $"Thiết bị ảnh hưởng: {thietBi}";

            // Hiển thị thông báo
            MessageBox.Show(thongTinTomTat, "Tóm tắt yêu cầu sự cố", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // 3. Chức năng Nhập lại (Clear dữ liệu)
        private void btnNhapLai_Click(object sender, EventArgs e)
        {
            txtMaPhieu.Clear();
            txtNguoiYeuCau.Clear();
            dtpNgayGhiNhan.Value = DateTime.Now;

            cboLoaiSuCo.SelectedIndex = -1;

            radThap.Checked = true;
            radTrungBinh.Checked = false;
            radKhanCap.Checked = false;

            chkPC.Checked = false;
            chkLaptop.Checked = false;
            chkMayIn.Checked = false;
            chkDienThoai.Checked = false;

            picAnhLoi.Image = null;

            txtMaPhieu.Focus();
        }
    }
}