using System.Drawing;
using System.Windows.Forms;

namespace Bai_3
{
    partial class frmMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            heThongToolStripMenuItem = new ToolStripMenuItem();
            dangXuatToolStripMenuItem = new ToolStripMenuItem();
            thoatToolStripMenuItem = new ToolStripMenuItem();
            danhMucToolStripMenuItem = new ToolStripMenuItem();
            quanLySanPhamToolStripMenuItem = new ToolStripMenuItem();
            quanLyNhapXuatToolStripMenuItem = new ToolStripMenuItem();
            baoCaoToolStripMenuItem = new ToolStripMenuItem();
            thongKeDoanhThuToolStripMenuItem = new ToolStripMenuItem();
            cuaSoToolStripMenuItem = new ToolStripMenuItem();
            cascadeToolStripMenuItem = new ToolStripMenuItem();
            tileHorizontalToolStripMenuItem = new ToolStripMenuItem();
            tileVerticalToolStripMenuItem = new ToolStripMenuItem();
            statusStrip1 = new StatusStrip();
            lblUser = new ToolStripStatusLabel();
            prgLoading = new ToolStripProgressBar();
            menuStrip1.SuspendLayout();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { heThongToolStripMenuItem, danhMucToolStripMenuItem, baoCaoToolStripMenuItem, cuaSoToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 24);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // heThongToolStripMenuItem
            // 
            heThongToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { dangXuatToolStripMenuItem, thoatToolStripMenuItem });
            heThongToolStripMenuItem.Name = "heThongToolStripMenuItem";
            heThongToolStripMenuItem.Size = new Size(69, 20);
            heThongToolStripMenuItem.Text = "Hệ thống";
            // 
            // dangXuatToolStripMenuItem
            // 
            dangXuatToolStripMenuItem.Name = "dangXuatToolStripMenuItem";
            dangXuatToolStripMenuItem.Size = new Size(128, 22);
            dangXuatToolStripMenuItem.Text = "Đăng xuất";
            // 
            // thoatToolStripMenuItem
            // 
            thoatToolStripMenuItem.Name = "thoatToolStripMenuItem";
            thoatToolStripMenuItem.Size = new Size(128, 22);
            thoatToolStripMenuItem.Text = "Thoát";
            thoatToolStripMenuItem.Click += thoatToolStripMenuItem_Click;
            // 
            // danhMucToolStripMenuItem
            // 
            danhMucToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { quanLySanPhamToolStripMenuItem, quanLyNhapXuatToolStripMenuItem });
            danhMucToolStripMenuItem.Name = "danhMucToolStripMenuItem";
            danhMucToolStripMenuItem.Size = new Size(74, 20);
            danhMucToolStripMenuItem.Text = "Danh mục";
            // 
            // quanLySanPhamToolStripMenuItem
            // 
            quanLySanPhamToolStripMenuItem.Name = "quanLySanPhamToolStripMenuItem";
            quanLySanPhamToolStripMenuItem.Size = new Size(180, 22);
            quanLySanPhamToolStripMenuItem.Text = "Quản lý Sản phẩm";
            quanLySanPhamToolStripMenuItem.Click += quanLySanPhamToolStripMenuItem_Click;
            // 
            // quanLyNhapXuatToolStripMenuItem
            // 
            quanLyNhapXuatToolStripMenuItem.Name = "quanLyNhapXuatToolStripMenuItem";
            quanLyNhapXuatToolStripMenuItem.Size = new Size(180, 22);
            quanLyNhapXuatToolStripMenuItem.Text = "Quản lý Nhập xuất";
            // 
            // baoCaoToolStripMenuItem
            // 
            baoCaoToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { thongKeDoanhThuToolStripMenuItem });
            baoCaoToolStripMenuItem.Name = "baoCaoToolStripMenuItem";
            baoCaoToolStripMenuItem.Size = new Size(61, 20);
            baoCaoToolStripMenuItem.Text = "Báo cáo";
            // 
            // thongKeDoanhThuToolStripMenuItem
            // 
            thongKeDoanhThuToolStripMenuItem.Name = "thongKeDoanhThuToolStripMenuItem";
            thongKeDoanhThuToolStripMenuItem.Size = new Size(181, 22);
            thongKeDoanhThuToolStripMenuItem.Text = "Thống kê Doanh thu";
            thongKeDoanhThuToolStripMenuItem.Click += thongKeDoanhThuToolStripMenuItem_Click;
            // 
            // cuaSoToolStripMenuItem
            // 
            cuaSoToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { cascadeToolStripMenuItem, tileHorizontalToolStripMenuItem, tileVerticalToolStripMenuItem });
            cuaSoToolStripMenuItem.Name = "cuaSoToolStripMenuItem";
            cuaSoToolStripMenuItem.Size = new Size(56, 20);
            cuaSoToolStripMenuItem.Text = "Cửa sổ";
            // 
            // cascadeToolStripMenuItem
            // 
            cascadeToolStripMenuItem.Name = "cascadeToolStripMenuItem";
            cascadeToolStripMenuItem.Size = new Size(151, 22);
            cascadeToolStripMenuItem.Text = "Cascade";
            cascadeToolStripMenuItem.Click += cascadeToolStripMenuItem_Click;
            // 
            // tileHorizontalToolStripMenuItem
            // 
            tileHorizontalToolStripMenuItem.Name = "tileHorizontalToolStripMenuItem";
            tileHorizontalToolStripMenuItem.Size = new Size(151, 22);
            tileHorizontalToolStripMenuItem.Text = "Tile Horizontal";
            tileHorizontalToolStripMenuItem.Click += tileHorizontalToolStripMenuItem_Click;
            // 
            // tileVerticalToolStripMenuItem
            // 
            tileVerticalToolStripMenuItem.Name = "tileVerticalToolStripMenuItem";
            tileVerticalToolStripMenuItem.Size = new Size(151, 22);
            tileVerticalToolStripMenuItem.Text = "Tile Vertical";
            tileVerticalToolStripMenuItem.Click += tileVerticalToolStripMenuItem_Click;
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { lblUser, prgLoading });
            statusStrip1.Location = new Point(0, 428);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(800, 22);
            statusStrip1.TabIndex = 2;
            statusStrip1.Text = "statusStrip1";
            // 
            // lblUser
            // 
            lblUser.Name = "lblUser";
            lblUser.Size = new Size(116, 17);
            lblUser.Text = "Người dùng: Admin";
            // 
            // prgLoading
            // 
            prgLoading.Name = "prgLoading";
            prgLoading.Size = new Size(100, 16);
            prgLoading.Visible = false;
            // 
            // frmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(statusStrip1);
            Controls.Add(menuStrip1);
            IsMdiContainer = true;
            MainMenuStrip = menuStrip1;
            Name = "frmMain";
            Text = "Hệ thống Quản lý Bán hàng (MDI)";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem heThongToolStripMenuItem;
        private ToolStripMenuItem dangXuatToolStripMenuItem;
        private ToolStripMenuItem thoatToolStripMenuItem;
        private ToolStripMenuItem danhMucToolStripMenuItem;
        private ToolStripMenuItem quanLySanPhamToolStripMenuItem;
        private ToolStripMenuItem quanLyNhapXuatToolStripMenuItem;
        private ToolStripMenuItem baoCaoToolStripMenuItem;
        private ToolStripMenuItem thongKeDoanhThuToolStripMenuItem;
        private ToolStripMenuItem cuaSoToolStripMenuItem;
        private ToolStripMenuItem cascadeToolStripMenuItem;
        private ToolStripMenuItem tileHorizontalToolStripMenuItem;
        private ToolStripMenuItem tileVerticalToolStripMenuItem;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel lblUser;
        private ToolStripProgressBar prgLoading;
    }
}
