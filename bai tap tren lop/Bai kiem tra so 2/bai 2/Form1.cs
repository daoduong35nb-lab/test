using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace bai_2
{
    public partial class Form1 : Form
    {
        private BindingList<Product> productList;
        private BindingSource productBindingSource;
        private string currentImagePath = string.Empty;

        // Controls
        private DataGridView dgvProducts;
        private TextBox txtId, txtName, txtPrice;
        private ComboBox cboCategory;
        private NumericUpDown numQuantity;
        private Button btnAdd, btnUpdate, btnDelete, btnClear, btnSelectImage;
        private PictureBox picProductImage;
        private Label lblClock, lblTotalQuantity, lblTotalValue;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem mnuFile, mnuImportCSV, mnuExportCSV, mnuExit;
        private Timer timer1;

        public Form1()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Text = "Quản lý sản phẩm";
            this.ClientSize = new Size(900, 600);
            this.StartPosition = FormStartPosition.CenterScreen;

            // MenuStrip
            menuStrip1 = new MenuStrip();
            mnuFile = new ToolStripMenuItem("File");
            mnuImportCSV = new ToolStripMenuItem("Import CSV");
            mnuExportCSV = new ToolStripMenuItem("Export CSV");
            mnuExit = new ToolStripMenuItem("Exit");
            mnuFile.DropDownItems.AddRange(new ToolStripItem[] { mnuImportCSV, mnuExportCSV, new ToolStripSeparator(), mnuExit });
            menuStrip1.Items.Add(mnuFile);
            this.MainMenuStrip = menuStrip1;
            this.Controls.Add(menuStrip1);

            // DataGridView
            dgvProducts = new DataGridView
            {
                Location = new Point(10, 40),
                Size = new Size(560, 400),
                Name = "dgvProducts"
            };
            this.Controls.Add(dgvProducts);

            // Input Controls - Left side
            Label lbl1 = new Label { Text = "Mã SP:", Location = new Point(580, 55), AutoSize = true };
            txtId = new TextBox { Location = new Point(650, 50), Width = 220, Name = "txtId" };

            Label lbl2 = new Label { Text = "Tên SP:", Location = new Point(580, 95), AutoSize = true };
            txtName = new TextBox { Location = new Point(650, 90), Width = 220, Name = "txtName" };

            Label lbl3 = new Label { Text = "Loại:", Location = new Point(580, 135), AutoSize = true };
            cboCategory = new ComboBox { Location = new Point(650, 130), Width = 220, DropDownStyle = ComboBoxStyle.DropDownList, Name = "cboCategory" };
            cboCategory.Items.AddRange(new string[] { "Điện thoại", "Laptop", "Linh kiện", "Phụ kiện" });

            Label lbl4 = new Label { Text = "Đơn giá:", Location = new Point(580, 175), AutoSize = true };
            txtPrice = new TextBox { Location = new Point(650, 170), Width = 220, Name = "txtPrice" };

            Label lbl5 = new Label { Text = "SL:", Location = new Point(580, 215), AutoSize = true };
            numQuantity = new NumericUpDown { Location = new Point(650, 210), Width = 100, Minimum = 0, Maximum = 100000, Name = "numQuantity" };

            // Buttons
            btnAdd = new Button { Text = "Thêm", Location = new Point(580, 250), Width = 80, Name = "btnAdd" };
            btnUpdate = new Button { Text = "Cập nhật", Location = new Point(670, 250), Width = 80, Name = "btnUpdate" };
            btnDelete = new Button { Text = "Xóa", Location = new Point(760, 250), Width = 80, Name = "btnDelete" };
            btnClear = new Button { Text = "Clear", Location = new Point(850, 250), Width = 50, Name = "btnClear" };

            btnSelectImage = new Button { Text = "Chọn ảnh", Location = new Point(580, 290), Width = 80, Name = "btnSelectImage" };
            picProductImage = new PictureBox
            {
                Location = new Point(670, 290),
                Size = new Size(200, 100),
                BorderStyle = BorderStyle.FixedSingle,
                SizeMode = PictureBoxSizeMode.Zoom,
                Name = "picProductImage"
            };

            // Status Labels
            lblClock = new Label { Text = "Thời gian:", Location = new Point(580, 410), AutoSize = true, Name = "lblClock" };
            lblTotalQuantity = new Label { Text = "Tổng SL: 0", Location = new Point(580, 440), AutoSize = true, Name = "lblTotalQuantity" };
            lblTotalValue = new Label { Text = "Tổng giá trị: 0 VNĐ", Location = new Point(580, 470), AutoSize = true, Name = "lblTotalValue" };

            // Add all controls
            this.Controls.AddRange(new Control[] 
            { 
                lbl1, txtId, lbl2, txtName, lbl3, cboCategory, lbl4, txtPrice, lbl5, numQuantity,
                btnAdd, btnUpdate, btnDelete, btnClear, btnSelectImage, picProductImage, 
                lblClock, lblTotalQuantity, lblTotalValue 
            });

            // Timer
            timer1 = new Timer();
            timer1.Interval = 1000;

            // Event handlers
            this.Load += Form1_Load;
            btnAdd.Click += BtnAdd_Click;
            btnUpdate.Click += BtnUpdate_Click;
            btnDelete.Click += BtnDelete_Click;
            btnClear.Click += BtnClear_Click;
            btnSelectImage.Click += BtnSelectImage_Click;
            dgvProducts.SelectionChanged += DgvProducts_SelectionChanged;
            timer1.Tick += Timer1_Tick;
            mnuImportCSV.Click += MnuImportCSV_Click;
            mnuExportCSV.Click += MnuExportCSV_Click;
            mnuExit.Click += MnuExit_Click;
            this.FormClosing += Form1_FormClosing;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                productList = new BindingList<Product>();
                productBindingSource = new BindingSource { DataSource = productList };

                SetupDataGridView(dgvProducts);
                dgvProducts.DataSource = productBindingSource;

                timer1.Start();

                UpdateStatus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi khởi tạo form: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetupDataGridView(DataGridView grid)
        {
            grid.AutoGenerateColumns = false;
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grid.ReadOnly = true;
            grid.AllowUserToAddRows = false;
            grid.Columns.Clear();

            grid.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Id", HeaderText = "Mã SP", Width = 80 });
            grid.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Name", HeaderText = "Tên SP", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            grid.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Category", HeaderText = "Loại", Width = 100 });
            grid.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Price", HeaderText = "Đơn giá", DefaultCellStyle = new DataGridViewCellStyle { Format = "N0" } });
            grid.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Quantity", HeaderText = "SL", Width = 60 });
            grid.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "ImagePath", HeaderText = "Đường dẫn ảnh", Width = 200 });
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            lblClock.Text = "Thời gian: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
        }

        private void UpdateStatus()
        {
            int totalQty = 0;
            decimal totalValue = 0;
            foreach (var item in productList)
            {
                totalQty += item.Quantity;
                totalValue += item.Quantity * item.Price;
            }
            lblTotalQuantity.Text = $"Tổng SL: {totalQty}";
            lblTotalValue.Text = $"Tổng giá trị: {totalValue:N0} VNĐ";
        }

        private void BtnSelectImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files (*.jpg;*.png;*.bmp)|*.jpg;*.png;*.bmp";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    currentImagePath = ofd.FileName;
                    picProductImage.ImageLocation = currentImagePath;
                }
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtId.Text))
                {
                    MessageBox.Show("Vui lòng nhập Mã SP!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Product newProduct = new Product
                {
                    Id = txtId.Text.Trim(),
                    Name = txtName.Text.Trim(),
                    Category = cboCategory.SelectedItem?.ToString() ?? string.Empty,
                    Price = decimal.TryParse(txtPrice.Text, out decimal p) ? p : 0,
                    Quantity = (int)numQuantity.Value,
                    ImagePath = currentImagePath
                };

                productList.Add(newProduct);
                ClearInputs();
                UpdateStatus();
                MessageBox.Show("Thêm sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm sản phẩm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DgvProducts_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvProducts.CurrentRow != null && dgvProducts.CurrentRow.Index >= 0)
                {
                    Product selected = productBindingSource.Current as Product;
                    if (selected != null)
                    {
                        txtId.Text = selected.Id ?? string.Empty;
                        txtName.Text = selected.Name ?? string.Empty;
                        cboCategory.SelectedItem = selected.Category;
                        txtPrice.Text = selected.Price.ToString();
                        numQuantity.Value = selected.Quantity;
                        currentImagePath = selected.ImagePath ?? string.Empty;

                        if (!string.IsNullOrEmpty(currentImagePath) && File.Exists(currentImagePath))
                            picProductImage.ImageLocation = currentImagePath;
                        else
                            picProductImage.Image = null;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi chọn sản phẩm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (productBindingSource.Current == null)
                {
                    MessageBox.Show("Vui lòng chọn sản phẩm để cập nhật!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Product current = productBindingSource.Current as Product;
                if (current != null)
                {
                    current.Name = txtName.Text.Trim();
                    current.Category = cboCategory.SelectedItem?.ToString() ?? string.Empty;
                    current.Price = decimal.TryParse(txtPrice.Text, out decimal p) ? p : 0;
                    current.Quantity = (int)numQuantity.Value;
                    current.ImagePath = currentImagePath;

                    productBindingSource.ResetCurrentItem();
                    UpdateStatus();
                    MessageBox.Show("Cập nhật sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật sản phẩm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (productBindingSource.Current == null)
                {
                    MessageBox.Show("Vui lòng chọn sản phẩm để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (MessageBox.Show("Bạn có chắc chắn muốn xóa sản phẩm này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    productBindingSource.RemoveCurrent();
                    ClearInputs();
                    UpdateStatus();
                    MessageBox.Show("Xóa sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa sản phẩm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            ClearInputs();
        }

        private void ClearInputs()
        {
            txtId.Clear();
            txtName.Clear();
            txtPrice.Clear();
            numQuantity.Value = 0;
            cboCategory.SelectedIndex = -1;
            currentImagePath = string.Empty;
            picProductImage.Image = null;
        }

        private void MnuImportCSV_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chức năng Import CSV chưa được triển khai.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void MnuExportCSV_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chức năng Export CSV chưa được triển khai.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void MnuExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn thoát ứng dụng?", "Thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
            else
            {
                timer1?.Stop();
                timer1?.Dispose();
            }
        }
    }
}
