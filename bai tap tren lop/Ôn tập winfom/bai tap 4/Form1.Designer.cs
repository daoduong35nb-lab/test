namespace bai_tap_4
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
            this.flpSoDo = new System.Windows.Forms.FlowLayoutPanel();
            this.cboKhungGio = new System.Windows.Forms.ComboBox();
            this.lblSoViTri = new System.Windows.Forms.Label();
            this.lblTamTinh = new System.Windows.Forms.Label();
            this.btnXacNhan = new System.Windows.Forms.Button();
            this.btnHuyChon = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // flpSoDo
            // 
            this.flpSoDo.Location = new System.Drawing.Point(71, 63);
            this.flpSoDo.Name = "flpSoDo";
            this.flpSoDo.Size = new System.Drawing.Size(528, 322);
            this.flpSoDo.TabIndex = 0;
            // 
            // cboKhungGio
            // 
            this.cboKhungGio.FormattingEnabled = true;
            this.cboKhungGio.Items.AddRange(new object[] {
            "Sáng",
            "Tối"});
            this.cboKhungGio.Location = new System.Drawing.Point(704, 63);
            this.cboKhungGio.Name = "cboKhungGio";
            this.cboKhungGio.Size = new System.Drawing.Size(121, 24);
            this.cboKhungGio.TabIndex = 1;
            this.cboKhungGio.SelectedIndexChanged += new System.EventHandler(this.cboKhungGio_SelectedIndexChanged);
            // 
            // lblSoViTri
            // 
            this.lblSoViTri.AutoSize = true;
            this.lblSoViTri.Location = new System.Drawing.Point(710, 180);
            this.lblSoViTri.Name = "lblSoViTri";
            this.lblSoViTri.Size = new System.Drawing.Size(129, 16);
            this.lblSoViTri.TabIndex = 2;
            this.lblSoViTri.Text = "Số vị trí đang chọn: 0";
            // 
            // lblTamTinh
            // 
            this.lblTamTinh.AutoSize = true;
            this.lblTamTinh.Location = new System.Drawing.Point(710, 211);
            this.lblTamTinh.Name = "lblTamTinh";
            this.lblTamTinh.Size = new System.Drawing.Size(103, 16);
            this.lblTamTinh.TabIndex = 3;
            this.lblTamTinh.Text = "Tạm tính tiền: 0đ";
            // 
            // btnXacNhan
            // 
            this.btnXacNhan.Location = new System.Drawing.Point(661, 267);
            this.btnXacNhan.Name = "btnXacNhan";
            this.btnXacNhan.Size = new System.Drawing.Size(152, 23);
            this.btnXacNhan.TabIndex = 4;
            this.btnXacNhan.Text = "Xác nhận đặt";
            this.btnXacNhan.UseVisualStyleBackColor = true;
            this.btnXacNhan.Click += new System.EventHandler(this.btnXacNhan_Click);
            // 
            // btnHuyChon
            // 
            this.btnHuyChon.Location = new System.Drawing.Point(850, 267);
            this.btnHuyChon.Name = "btnHuyChon";
            this.btnHuyChon.Size = new System.Drawing.Size(171, 23);
            this.btnHuyChon.TabIndex = 5;
            this.btnHuyChon.Text = "Hủy chọn tất cả";
            this.btnHuyChon.UseVisualStyleBackColor = true;
            this.btnHuyChon.Click += new System.EventHandler(this.btnHuyChon_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1078, 752);
            this.Controls.Add(this.btnHuyChon);
            this.Controls.Add(this.btnXacNhan);
            this.Controls.Add(this.lblTamTinh);
            this.Controls.Add(this.lblSoViTri);
            this.Controls.Add(this.cboKhungGio);
            this.Controls.Add(this.flpSoDo);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flpSoDo;
        private System.Windows.Forms.ComboBox cboKhungGio;
        private System.Windows.Forms.Label lblSoViTri;
        private System.Windows.Forms.Label lblTamTinh;
        private System.Windows.Forms.Button btnXacNhan;
        private System.Windows.Forms.Button btnHuyChon;
    }
}

