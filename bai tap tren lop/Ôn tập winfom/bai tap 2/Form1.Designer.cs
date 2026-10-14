namespace bai_tap_2
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtMaPhieu = new System.Windows.Forms.TextBox();
            this.txtNguoiYeuCau = new System.Windows.Forms.TextBox();
            this.dtpNgayGhiNhan = new System.Windows.Forms.DateTimePicker();
            this.radThap = new System.Windows.Forms.RadioButton();
            this.radTrungBinh = new System.Windows.Forms.RadioButton();
            this.radKhanCap = new System.Windows.Forms.RadioButton();
            this.cboLoaiSuCo = new System.Windows.Forms.ComboBox();
            this.chkPC = new System.Windows.Forms.CheckBox();
            this.chkLaptop = new System.Windows.Forms.CheckBox();
            this.chkMayIn = new System.Windows.Forms.CheckBox();
            this.chkDienThoai = new System.Windows.Forms.CheckBox();
            this.picAnhLoi = new System.Windows.Forms.PictureBox();
            this.btnTaiAnhLoi = new System.Windows.Forms.Button();
            this.btnGuiYeuCau = new System.Windows.Forms.Button();
            this.btnNhapLai = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picAnhLoi)).BeginInit();
            this.SuspendLayout();
            // 
            // txtMaPhieu
            // 
            this.txtMaPhieu.Location = new System.Drawing.Point(317, 138);
            this.txtMaPhieu.Name = "txtMaPhieu";
            this.txtMaPhieu.Size = new System.Drawing.Size(256, 22);
            this.txtMaPhieu.TabIndex = 0;
            this.txtMaPhieu.Text = "Mã phiếu: ";
            this.txtMaPhieu.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // txtNguoiYeuCau
            // 
            this.txtNguoiYeuCau.Location = new System.Drawing.Point(317, 177);
            this.txtNguoiYeuCau.Name = "txtNguoiYeuCau";
            this.txtNguoiYeuCau.Size = new System.Drawing.Size(256, 22);
            this.txtNguoiYeuCau.TabIndex = 1;
            this.txtNguoiYeuCau.Text = "Người Yêu Cầu: ";
            // 
            // dtpNgayGhiNhan
            // 
            this.dtpNgayGhiNhan.Location = new System.Drawing.Point(317, 217);
            this.dtpNgayGhiNhan.Name = "dtpNgayGhiNhan";
            this.dtpNgayGhiNhan.Size = new System.Drawing.Size(256, 22);
            this.dtpNgayGhiNhan.TabIndex = 2;
            // 
            // radThap
            // 
            this.radThap.AutoSize = true;
            this.radThap.Location = new System.Drawing.Point(317, 277);
            this.radThap.Name = "radThap";
            this.radThap.Size = new System.Drawing.Size(60, 20);
            this.radThap.TabIndex = 3;
            this.radThap.TabStop = true;
            this.radThap.Text = "Thấp";
            this.radThap.UseVisualStyleBackColor = true;
            // 
            // radTrungBinh
            // 
            this.radTrungBinh.AutoSize = true;
            this.radTrungBinh.Location = new System.Drawing.Point(317, 303);
            this.radTrungBinh.Name = "radTrungBinh";
            this.radTrungBinh.Size = new System.Drawing.Size(91, 20);
            this.radTrungBinh.TabIndex = 4;
            this.radTrungBinh.TabStop = true;
            this.radTrungBinh.Text = "Trung bình";
            this.radTrungBinh.UseVisualStyleBackColor = true;
            // 
            // radKhanCap
            // 
            this.radKhanCap.AutoSize = true;
            this.radKhanCap.Location = new System.Drawing.Point(317, 329);
            this.radKhanCap.Name = "radKhanCap";
            this.radKhanCap.Size = new System.Drawing.Size(84, 20);
            this.radKhanCap.TabIndex = 5;
            this.radKhanCap.TabStop = true;
            this.radKhanCap.Text = "Khẩn cấp";
            this.radKhanCap.UseVisualStyleBackColor = true;
            // 
            // cboLoaiSuCo
            // 
            this.cboLoaiSuCo.FormattingEnabled = true;
            this.cboLoaiSuCo.Items.AddRange(new object[] {
            "Phần cứng",
            "Phần mềm",
            "Mạng",
            "Tài khoản"});
            this.cboLoaiSuCo.Location = new System.Drawing.Point(702, 136);
            this.cboLoaiSuCo.Name = "cboLoaiSuCo";
            this.cboLoaiSuCo.Size = new System.Drawing.Size(121, 24);
            this.cboLoaiSuCo.TabIndex = 6;
            // 
            // chkPC
            // 
            this.chkPC.AutoSize = true;
            this.chkPC.Location = new System.Drawing.Point(702, 176);
            this.chkPC.Name = "chkPC";
            this.chkPC.Size = new System.Drawing.Size(104, 20);
            this.chkPC.TabIndex = 7;
            this.chkPC.Text = "Máy tính bàn";
            this.chkPC.UseVisualStyleBackColor = true;
            // 
            // chkLaptop
            // 
            this.chkLaptop.AutoSize = true;
            this.chkLaptop.Location = new System.Drawing.Point(702, 203);
            this.chkLaptop.Name = "chkLaptop";
            this.chkLaptop.Size = new System.Drawing.Size(71, 20);
            this.chkLaptop.TabIndex = 8;
            this.chkLaptop.Text = "Laptop";
            this.chkLaptop.UseVisualStyleBackColor = true;
            // 
            // chkMayIn
            // 
            this.chkMayIn.AutoSize = true;
            this.chkMayIn.Location = new System.Drawing.Point(702, 230);
            this.chkMayIn.Name = "chkMayIn";
            this.chkMayIn.Size = new System.Drawing.Size(68, 20);
            this.chkMayIn.TabIndex = 9;
            this.chkMayIn.Text = "Máy in";
            this.chkMayIn.UseVisualStyleBackColor = true;
            // 
            // chkDienThoai
            // 
            this.chkDienThoai.AutoSize = true;
            this.chkDienThoai.Location = new System.Drawing.Point(702, 257);
            this.chkDienThoai.Name = "chkDienThoai";
            this.chkDienThoai.Size = new System.Drawing.Size(88, 20);
            this.chkDienThoai.TabIndex = 10;
            this.chkDienThoai.Text = "Điện thoại";
            this.chkDienThoai.UseVisualStyleBackColor = true;
            // 
            // picAnhLoi
            // 
            this.picAnhLoi.Location = new System.Drawing.Point(707, 303);
            this.picAnhLoi.Name = "picAnhLoi";
            this.picAnhLoi.Size = new System.Drawing.Size(124, 76);
            this.picAnhLoi.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picAnhLoi.TabIndex = 11;
            this.picAnhLoi.TabStop = false;
            // 
            // btnTaiAnhLoi
            // 
            this.btnTaiAnhLoi.Location = new System.Drawing.Point(731, 399);
            this.btnTaiAnhLoi.Name = "btnTaiAnhLoi";
            this.btnTaiAnhLoi.Size = new System.Drawing.Size(100, 23);
            this.btnTaiAnhLoi.TabIndex = 12;
            this.btnTaiAnhLoi.Text = "Tải ảnh lỗi";
            this.btnTaiAnhLoi.UseVisualStyleBackColor = true;
            this.btnTaiAnhLoi.Click += new System.EventHandler(this.btnTaiAnhLoi_Click);
            // 
            // btnGuiYeuCau
            // 
            this.btnGuiYeuCau.Location = new System.Drawing.Point(528, 465);
            this.btnGuiYeuCau.Name = "btnGuiYeuCau";
            this.btnGuiYeuCau.Size = new System.Drawing.Size(119, 23);
            this.btnGuiYeuCau.TabIndex = 13;
            this.btnGuiYeuCau.Text = "Gửi yêu cầu";
            this.btnGuiYeuCau.UseVisualStyleBackColor = true;
            this.btnGuiYeuCau.Click += new System.EventHandler(this.btnGuiYeuCau_Click);
            // 
            // btnNhapLai
            // 
            this.btnNhapLai.Location = new System.Drawing.Point(528, 504);
            this.btnNhapLai.Name = "btnNhapLai";
            this.btnNhapLai.Size = new System.Drawing.Size(119, 23);
            this.btnNhapLai.TabIndex = 14;
            this.btnNhapLai.Text = "Nhập lại";
            this.btnNhapLai.UseVisualStyleBackColor = true;
            this.btnNhapLai.Click += new System.EventHandler(this.btnNhapLai_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1109, 738);
            this.Controls.Add(this.btnNhapLai);
            this.Controls.Add(this.btnGuiYeuCau);
            this.Controls.Add(this.btnTaiAnhLoi);
            this.Controls.Add(this.picAnhLoi);
            this.Controls.Add(this.chkDienThoai);
            this.Controls.Add(this.chkMayIn);
            this.Controls.Add(this.chkLaptop);
            this.Controls.Add(this.chkPC);
            this.Controls.Add(this.cboLoaiSuCo);
            this.Controls.Add(this.radKhanCap);
            this.Controls.Add(this.radTrungBinh);
            this.Controls.Add(this.radThap);
            this.Controls.Add(this.dtpNgayGhiNhan);
            this.Controls.Add(this.txtNguoiYeuCau);
            this.Controls.Add(this.txtMaPhieu);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picAnhLoi)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtMaPhieu;
        private System.Windows.Forms.TextBox txtNguoiYeuCau;
        private System.Windows.Forms.DateTimePicker dtpNgayGhiNhan;
        private System.Windows.Forms.RadioButton radThap;
        private System.Windows.Forms.RadioButton radTrungBinh;
        private System.Windows.Forms.RadioButton radKhanCap;
        private System.Windows.Forms.ComboBox cboLoaiSuCo;
        private System.Windows.Forms.CheckBox chkPC;
        private System.Windows.Forms.CheckBox chkLaptop;
        private System.Windows.Forms.CheckBox chkMayIn;
        private System.Windows.Forms.CheckBox chkDienThoai;
        private System.Windows.Forms.PictureBox picAnhLoi;
        private System.Windows.Forms.Button btnTaiAnhLoi;
        private System.Windows.Forms.Button btnGuiYeuCau;
        private System.Windows.Forms.Button btnNhapLai;
    }
}

