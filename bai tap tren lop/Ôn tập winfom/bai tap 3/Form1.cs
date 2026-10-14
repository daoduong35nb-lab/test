using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bai_tap_3
{
    public partial class name : Form
    {
        public name()
        {
            InitializeComponent();
        }

        // Giữ lại các hàm bạn đã lỡ tạo để Form không bị lỗi hiển thị
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void name_Load(object sender, EventArgs e)
        {
        }

        // =================================================================
        // CODE XỬ LÝ CHỨC NĂNG QUẢN LÝ VẬT TƯ
        // =================================================================

        // 1. Nút Thêm Mới
        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem đã nhập đủ Mã và Tên chưa
            if (string.IsNullOrWhiteSpace(txtMaVT.Text) || string.IsNullOrWhiteSpace(txtTenVT.Text))
            {
                MessageBox.Show("Vui lòng nhập đủ Mã và Tên vật tư!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra trùng Mã Vật Tư trong ListView
            foreach (ListViewItem item in lvwVatTu.Items)
            {
                if (item.Text.Equals(txtMaVT.Text, StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show("Mã vật tư này đã tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            // Tạo dòng mới và thêm các cột dữ liệu
            ListViewItem lvi = new ListViewItem(txtMaVT.Text); // Cột 1: Mã VT
            lvi.SubItems.Add(txtTenVT.Text);                   // Cột 2: Tên VT
            lvi.SubItems.Add(cboDonVi.Text);                   // Cột 3: Đơn vị tính
            lvi.SubItems.Add(txtDonGia.Text);                  // Cột 4: Đơn giá

            // Đưa dòng vừa tạo vào ListView
            lvwVatTu.Items.Add(lvi);

            // Xóa trắng ô nhập liệu sau khi thêm xong
            ClearInputs();
        }

        // 2. Nút Cập Nhật
        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (lvwVatTu.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = lvwVatTu.SelectedItems[0];

                // Ghi đè dữ liệu mới vào dòng đang chọn
                selectedItem.Text = txtMaVT.Text;
                selectedItem.SubItems[1].Text = txtTenVT.Text;
                selectedItem.SubItems[2].Text = cboDonVi.Text;
                selectedItem.SubItems[3].Text = txtDonGia.Text;

                MessageBox.Show("Cập nhật thành công!", "Thông báo");
                ClearInputs();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một dòng trên bảng để cập nhật!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // 3. Nút Xóa Dòng
        private void btnXoaDong_Click(object sender, EventArgs e)
        {
            if (lvwVatTu.SelectedItems.Count > 0)
            {
                DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa dòng này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    lvwVatTu.Items.Remove(lvwVatTu.SelectedItems[0]);
                    ClearInputs();
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một dòng để xóa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // 4. Nút Xóa Toàn Bộ
        private void btnXoaToanBo_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa TOÀN BỘ danh sách?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                lvwVatTu.Items.Clear();
                ClearInputs();
            }
        }

        // 5. Sự kiện bấm vào 1 dòng trong bảng thì đẩy dữ liệu lên lại TextBox
        private void lvwVatTu_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvwVatTu.SelectedItems.Count > 0)
            {
                ListViewItem item = lvwVatTu.SelectedItems[0];
                txtMaVT.Text = item.Text;
                txtTenVT.Text = item.SubItems[1].Text;
                cboDonVi.Text = item.SubItems[2].Text;
                txtDonGia.Text = item.SubItems[3].Text;
            }
        }

        // Hàm hỗ trợ dọn dẹp các ô nhập liệu
        private void ClearInputs()
        {
            txtMaVT.Clear();
            txtTenVT.Clear();
            txtDonGia.Clear();
            cboDonVi.SelectedIndex = -1; // Bỏ chọn ComboBox
            txtMaVT.Focus(); // Đưa con trỏ chuột về ô Mã VT
        }

        private void txtMaVatTu_TextChanged(object sender, EventArgs e)
        {

        }
    }
}