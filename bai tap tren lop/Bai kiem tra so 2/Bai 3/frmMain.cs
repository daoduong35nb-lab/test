using System;
using System.Linq;
using System.Windows.Forms;

namespace Bai_3
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void OpenChildForm(Form childForm)
        {
            // Kiểm tra xem Form đã mở hay chưa
            Form? existingForm = this.MdiChildren.FirstOrDefault(f => f.GetType() == childForm.GetType());

            if (existingForm != null)
            {
                // Nếu đã mở thì mang lên trước
                existingForm.Activate();
                childForm.Dispose(); // Hủy instance mới tạo
            }
            else
            {
                // Nếu chưa thì gán MdiParent và hiển thị
                childForm.MdiParent = this;
                childForm.Show();
            }
        }

        private void quanLySanPhamToolStripMenuItem_Click(object? sender, EventArgs e)
        {
            OpenChildForm(new frmProductCatalog());
        }

        private void thongKeDoanhThuToolStripMenuItem_Click(object? sender, EventArgs e)
        {
            OpenChildForm(new frmAsyncReport());
        }

        private void cascadeToolStripMenuItem_Click(object? sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.Cascade);
        }

        private void tileHorizontalToolStripMenuItem_Click(object? sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void tileVerticalToolStripMenuItem_Click(object? sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileVertical);
        }

        private void thoatToolStripMenuItem_Click(object? sender, EventArgs e)
        {
            Application.Exit();
        }

        // Phương thức để Form con có thể cập nhật ProgressBar trên Form cha
        public void UpdateProgress(int value, bool visible)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() => UpdateProgress(value, visible)));
                return;
            }
            prgLoading.Visible = visible;
            prgLoading.Value = value;
        }
    }
}
