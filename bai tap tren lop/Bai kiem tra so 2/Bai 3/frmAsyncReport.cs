using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bai_3
{
    public partial class frmAsyncReport : Form
    {
        private Button btnLoadReport = new();
        private DataGridView dgvReport = new();
        private Label lblRealTimeStatus = new();
        private Label lblExchangeRate = new();
        private CancellationTokenSource? _cts;

        public frmAsyncReport()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Text = "Báo cáo Thống kê & Đồng bộ";
            this.Size = new System.Drawing.Size(600, 400);

            btnLoadReport = new Button
            {
                Text = "Tải Báo Cáo Doanh Thu",
                Location = new System.Drawing.Point(20, 20),
                Size = new System.Drawing.Size(200, 40)
            };
            btnLoadReport.Click += BtnLoadReport_Click;

            lblRealTimeStatus = new Label
            {
                Text = "Trạng thái hệ thống: Đang chờ...",
                Location = new System.Drawing.Point(240, 20),
                AutoSize = true
            };

            lblExchangeRate = new Label
            {
                Text = "Tỷ giá USD/VND: 25.450",
                Location = new System.Drawing.Point(240, 45),
                AutoSize = true
            };

            dgvReport = new DataGridView
            {
                Location = new System.Drawing.Point(20, 80),
                Size = new System.Drawing.Size(540, 260),
                ReadOnly = true,
                AllowUserToAddRows = false
            };

            this.Controls.AddRange(new Control[] { btnLoadReport, lblRealTimeStatus, lblExchangeRate, dgvReport });

            this.Load += FrmAsyncReport_Load;
            this.FormClosing += FrmAsyncReport_FormClosing;
        }

        private void FrmAsyncReport_Load(object? sender, EventArgs e)
        {
            // Bắt đầu tiến trình chạy ngầm giả lập đồng bộ dữ liệu (Scenario C)
            StartBackgroundSync();
        }

        private void FrmAsyncReport_FormClosing(object? sender, FormClosingEventArgs e)
        {
            _cts?.Cancel();
        }

        // Scenario B: Tải dữ liệu bất đồng bộ (async / await)
        private async void BtnLoadReport_Click(object? sender, EventArgs e)
        {
            btnLoadReport.Enabled = false;
            dgvReport.DataSource = null;
            
            // Truy cập ProgressBar trên Form Cha
            if (this.MdiParent is frmMain mainForm)
            {
                mainForm.UpdateProgress(0, true);

                try
                {
                    // Giả lập tác vụ nặng trong 3-5 giây (Scenario B)
                    var reportData = await Task.Run(async () =>
                    {
                        var data = new List<dynamic>();
                        for (int i = 1; i <= 10; i++)
                        {
                            // Giả lập tính toán hoặc truy xuất CSDL
                            await Task.Delay(400); // Tổng ~4 giây
                            
                            data.Add(new { 
                                Thang = $"Tháng {i}", 
                                DoanhThu = new Random().Next(100, 1000) * 1000000 
                            });

                            // Cập nhật ProgressBar (Cross-Thread an toàn qua Main Form)
                            mainForm.UpdateProgress(i * 10, true);
                        }
                        return data;
                    });

                    dgvReport.DataSource = reportData;
                    MessageBox.Show("Tải báo cáo hoàn tất!", "Thông báo");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
                finally
                {
                    mainForm.UpdateProgress(0, false);
                    btnLoadReport.Enabled = true;
                }
            }
            else
            {
                MessageBox.Show("Form này phải được mở trong Form Cha MDI!", "Lỗi");
                btnLoadReport.Enabled = true;
            }
        }

        // Scenario C: Cập nhật UI an toàn từ Background Thread
        private void StartBackgroundSync()
        {
            _cts = new CancellationTokenSource();
            var token = _cts.Token;

            Task.Run(async () =>
            {
                try
                {
                    while (!token.IsCancellationRequested)
                    {
                        // Giả lập quét số lượng đơn hàng mới hoặc tỷ giá mỗi 2 giây
                        await Task.Delay(2000, token);

                        string newRate = (25450 + new Random().Next(-10, 10)).ToString("N0");
                        string status = $"Cập nhật lúc: {DateTime.Now:HH:mm:ss}";

                        // Áp dụng quy tắc Thread Safety (this.Invoke)
                        SafeUpdateUI(newRate, status);
                    }
                }
                catch (TaskCanceledException) { }
            }, token);
        }

        private void SafeUpdateUI(string rate, string status)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() => SafeUpdateUI(rate, status)));
                return;
            }

            // Cập nhật UI trực tiếp vì đã ở UI Thread
            lblExchangeRate.Text = $"Tỷ giá USD/VND: {rate}";
            lblRealTimeStatus.Text = $"Trạng thái hệ thống: {status}";
        }
    }
}
