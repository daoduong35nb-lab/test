using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bai_tap_5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Giữ lại hàm này để tránh lỗi màn hình Design
        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Bắt đầu chạy Timer để đếm thời gian
            timer1.Start();

            // Đảm bảo Form luôn ưu tiên nhận các phím tắt (F2, Delete)
            this.KeyPreview = true;
        }

        // 1. Cập nhật thời gian hệ thống liên tục trên StatusStrip
        private void timer1_Tick(object sender, EventArgs e)
        {
            lblThoiGian.Text = "Thời gian: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
        }

        // 2. Tự động tính Thành tiền khi nhập Số lượng hoặc Đơn giá
        private void dgvHangHoa_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvHangHoa.Rows[e.RowIndex];
                string colName = dgvHangHoa.Columns[e.ColumnIndex].Name;

                // Lưu ý: Nếu tên cột của bạn viết thường, hãy giữ nguyên. Nếu viết hoa (ColSoLuong), hãy sửa lại cho khớp.
                if (colName == "colSoLuong" || colName == "colDonGia")
                {
                    decimal soLuong = 0;
                    decimal donGia = 0;

                    decimal.TryParse(row.Cells["colSoLuong"].Value?.ToString(), out soLuong);
                    decimal.TryParse(row.Cells["colDonGia"].Value?.ToString(), out donGia);

                    // Tự động nhân tiền
                    row.Cells["colThanhTien"].Value = soLuong * donGia;
                }

                // Cập nhật lại thanh trạng thái bên dưới
                CapNhatStatusStrip();
            }
        }

        // 3. Cảnh báo lỗi nếu Số lượng hoặc Trọng lượng <= 0
        private void dgvHangHoa_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            // Bỏ qua kiểm tra nếu đang ở dòng mới chưa nhập gì
            if (dgvHangHoa.Rows[e.RowIndex].IsNewRow) return;

            string colName = dgvHangHoa.Columns[e.ColumnIndex].Name;

            if (colName == "colSoLuong" || colName == "colTrongLuong")
            {
                if (decimal.TryParse(e.FormattedValue.ToString(), out decimal value))
                {
                    if (value <= 0)
                    {
                        // Hiện cảnh báo đỏ
                        dgvHangHoa.Rows[e.RowIndex].ErrorText = "Số lượng và Trọng lượng phải > 0";
                        e.Cancel = true; // Chặn không cho thoát khỏi ô nhập
                    }
                    else
                    {
                        // Xóa cảnh báo nếu nhập đúng
                        dgvHangHoa.Rows[e.RowIndex].ErrorText = string.Empty;
                    }
                }
            }
        }

        // 4. Hàm hỗ trợ: Cập nhật tổng số trên StatusStrip
        private void CapNhatStatusStrip()
        {
            decimal tongSoLuong = 0;
            decimal tongTrongLuong = 0;
            decimal tongTien = 0;

            foreach (DataGridViewRow row in dgvHangHoa.Rows)
            {
                if (!row.IsNewRow)
                {
                    decimal sl = 0, tl = 0, tt = 0;
                    decimal.TryParse(row.Cells["colSoLuong"].Value?.ToString(), out sl);
                    decimal.TryParse(row.Cells["colTrongLuong"].Value?.ToString(), out tl);
                    decimal.TryParse(row.Cells["colThanhTien"].Value?.ToString(), out tt);

                    tongSoLuong += sl;
                    tongTrongLuong += tl;
                    tongTien += tt;
                }
            }

            lblTongSoLuong.Text = $"Tổng số lượng: {tongSoLuong}";
            lblTongTrongLuong.Text = $"Tổng trọng lượng: {tongTrongLuong} kg";
            lblTongTien.Text = $"Tổng tiền đơn hàng: {tongTien:N0} đ";
        }

        // 5. Xử lý Phím tắt (F2 và Delete)
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            // Nhấn F2 để thêm nhanh dòng mới
            if (e.KeyCode == Keys.F2)
            {
                int lastRow = dgvHangHoa.Rows.Count - 1;
                if (lastRow >= 0)
                {
                    dgvHangHoa.CurrentCell = dgvHangHoa.Rows[lastRow].Cells[0];
                    dgvHangHoa.BeginEdit(true);
                }
            }
            // Nhấn Delete để xóa dòng đang chọn
            else if (e.KeyCode == Keys.Delete)
            {
                if (dgvHangHoa.SelectedRows.Count > 0 && !dgvHangHoa.CurrentRow.IsNewRow)
                {
                    DialogResult rs = MessageBox.Show("Bạn có chắc chắn muốn xóa dòng đang chọn?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (rs == DialogResult.Yes)
                    {
                        foreach (DataGridViewRow row in dgvHangHoa.SelectedRows)
                        {
                            if (!row.IsNewRow)
                            {
                                dgvHangHoa.Rows.Remove(row);
                            }
                        }
                        CapNhatStatusStrip(); // Tính lại tổng sau khi xóa
                    }
                }
            }
        }
    }
}