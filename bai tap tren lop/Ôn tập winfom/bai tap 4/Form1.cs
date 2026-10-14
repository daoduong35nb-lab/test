using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bai_tap_4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Sự kiện Form Load: Tự động sinh 20 nút vị trí
        private void Form1_Load(object sender, EventArgs e)
        {
            // Thêm các khung giờ vào ComboBox nếu bạn chưa thêm ở ngoài Design
            if (cboKhungGio.Items.Count == 0)
            {
                cboKhungGio.Items.Add("Sáng");
                cboKhungGio.Items.Add("Tối");
            }
            cboKhungGio.SelectedIndex = 0; // Chọn mặc định là "Sáng"

            // Dùng vòng lặp tạo 20 nút (Button)
            for (int i = 1; i <= 20; i++)
            {
                Button btn = new Button();
                btn.Text = i.ToString();
                btn.Width = 60;  // Chiều rộng nút
                btn.Height = 60; // Chiều cao nút
                btn.BackColor = Color.LightGray; // Màu mặc định (Trống)

                // Gắn hàm xử lý sự kiện Click chung cho cả 20 nút
                btn.Click += BtnViTri_Click;

                // Đẩy nút vừa tạo vào trong cái khung FlowLayoutPanel
                flpSoDo.Controls.Add(btn);
            }
        }

        // Hàm xử lý khi người dùng bấm vào 1 trong 20 vị trí
        private void BtnViTri_Click(object sender, EventArgs e)
        {
            Button clickedBtn = sender as Button;

            // Nếu nút màu Đỏ (Đã có người đặt) thì báo lỗi và dừng lại
            if (clickedBtn.BackColor == Color.Red)
            {
                MessageBox.Show("Vị trí này đã có người đặt!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Đổi màu qua lại: Trống (Xám nhạt) <-> Đang chọn (Xanh lá)
            if (clickedBtn.BackColor == Color.LightGray)
            {
                clickedBtn.BackColor = Color.Lime; // Chọn
            }
            else if (clickedBtn.BackColor == Color.Lime)
            {
                clickedBtn.BackColor = Color.LightGray; // Hủy chọn
            }

            // Tính toán lại số tiền
            CapNhatThongKe();
        }

        // Hàm hỗ trợ: Cập nhật lại số vị trí đang chọn và tạm tính tiền
        private void CapNhatThongKe()
        {
            int soViTri = 0;

            // Đếm xem có bao nhiêu nút đang màu xanh lá trong khung
            foreach (Control ctrl in flpSoDo.Controls)
            {
                if (ctrl is Button && ctrl.BackColor == Color.Lime)
                {
                    soViTri++;
                }
            }

            lblSoViTri.Text = $"Số vị trí đang chọn: {soViTri}";

            // Lấy đơn giá theo khung giờ
            int donGia = 0;
            if (cboKhungGio.SelectedItem != null)
            {
                if (cboKhungGio.SelectedItem.ToString() == "Sáng")
                    donGia = 100000;
                else if (cboKhungGio.SelectedItem.ToString() == "Tối")
                    donGia = 150000;
            }

            int tongTien = soViTri * donGia;
            lblTamTinh.Text = $"Tạm tính tiền: {tongTien:N0}đ";
        }

        // Sự kiện: Khi đổi khung giờ (Sáng/Tối) thì tính lại tiền
        private void cboKhungGio_SelectedIndexChanged(object sender, EventArgs e)
        {
            CapNhatThongKe();
        }

        // Sự kiện: Khi bấm nút "Xác nhận"
        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            bool hasSelection = false;
            foreach (Control ctrl in flpSoDo.Controls)
            {
                // Tìm các nút đang chọn (Màu xanh) và chốt đặt bàn (Màu đỏ)
                if (ctrl is Button && ctrl.BackColor == Color.Lime)
                {
                    ctrl.BackColor = Color.Red;
                    hasSelection = true;
                }
            }

            if (hasSelection)
            {
                MessageBox.Show("Xác nhận đặt bàn thành công!", "Thông báo");
                CapNhatThongKe(); // Cập nhật lại label về 0
            }
            else
            {
                MessageBox.Show("Vui lòng chọn ít nhất 1 vị trí để đặt!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Sự kiện: Khi bấm nút "Hủy chọn"
        private void btnHuyChon_Click(object sender, EventArgs e)
        {
            foreach (Control ctrl in flpSoDo.Controls)
            {
                // Chỉ hủy những bàn Đang Chọn (Màu xanh), không đụng tới bàn Đã Đặt (Màu đỏ)
                if (ctrl is Button && ctrl.BackColor == Color.Lime)
                {
                    ctrl.BackColor = Color.LightGray;
                }
            }
            CapNhatThongKe();
        }
    }
}