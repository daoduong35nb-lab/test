using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Bai_3
{
    public partial class frmProductCatalog : Form
    {
        private BindingList<Product> productList = new();
        private BindingSource productBindingSource = new();
        private string currentImagePath = string.Empty;

        // Controls
        private DataGridView dgvProducts = new();
        private TextBox txtId = new(), txtName = new(), txtPrice = new();
        private ComboBox cboCategory = new();
        private NumericUpDown numQuantity = new();
        private Button btnAdd = new(), btnUpdate = new(), btnDelete = new(), btnClear = new(), btnSelectImage = new();
        private PictureBox picProductImage = new();
        private Label lblClock = new(), lblTotalQuantity = new(), lblTotalValue = new();
        private System.Windows.Forms.Timer timer1 = new();

        public frmProductCatalog()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Text = "Quản lý sản phẩm";
            this.ClientSize = new Size(900, 550);
            this.StartPosition = FormStartPosition.CenterParent;

            // DataGridView
            dgvProducts = new DataGridView
            {
                Location = new Point(10, 10),
                Size = new Size(560, 450),
                Name = "dgvProducts",
                AutoGenerateColumns = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                ReadOnly = true,
                AllowUserToAddRows = false
            };
            dgvProducts.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Id", HeaderText = "Mã SP", Width = 80 });
            dgvProducts.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Name", HeaderText = "Tên SP", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dgvProducts.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Category", HeaderText = "Loại", Width = 100 });
            dgvProducts.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Price", HeaderText = "Đơn giá", DefaultCellStyle = new DataGridViewCellStyle { Format = "N0" } });
            dgvProducts.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Quantity", HeaderText = "SL", Width = 60 });

            // Input Controls - Left side
            Label lbl1 = new Label { Text = "Mã SP:", Location = new Point(580, 25), AutoSize = true };
            txtId = new TextBox { Location = new Point(650, 20), Width = 220 };

            Label lbl2 = new Label { Text = "Tên SP:", Location = new Point(580, 65), AutoSize = true };
            txtName = new TextBox { Location = new Point(650, 60), Width = 220 };

            Label lbl3 = new Label { Text = "Loại:", Location = new Point(580, 105), AutoSize = true };
            cboCategory = new ComboBox { Location = new Point(650, 100), Width = 220, DropDownStyle = ComboBoxStyle.DropDownList };
            cboCategory.Items.AddRange(new string[] { "Điện thoại", "Laptop", "Linh kiện", "Phụ kiện" });

            Label lbl4 = new Label { Text = "Đơn giá:", Location = new Point(580, 145), AutoSize = true };
            txtPrice = new TextBox { Location = new Point(650, 140), Width = 220 };

            Label lbl5 = new Label { Text = "SL:", Location = new Point(580, 185), AutoSize = true };
            numQuantity = new NumericUpDown { Location = new Point(650, 180), Width = 100, Minimum = 0, Maximum = 100000 };

            // Buttons
            btnAdd = new Button { Text = "Thêm", Location = new Point(580, 220), Width = 70 };
            btnUpdate = new Button { Text = "Cập nhật", Location = new Point(660, 220), Width = 70 };
            btnDelete = new Button { Text = "Xóa", Location = new Point(740, 220), Width = 70 };
            btnClear = new Button { Text = "Clear", Location = new Point(820, 220), Width = 50 };

            btnSelectImage = new Button { Text = "Chọn ảnh", Location = new Point(580, 260), Width = 80 };
            picProductImage = new PictureBox
            {
                Location = new Point(670, 260),
                Size = new Size(200, 120),
                BorderStyle = BorderStyle.FixedSingle,
                SizeMode = PictureBoxSizeMode.Zoom
            };

            // Status Labels
            lblClock = new Label { Text = "Thời gian:", Location = new Point(580, 400), AutoSize = true };
            lblTotalQuantity = new Label { Text = "Tổng SL: 0", Location = new Point(580, 430), AutoSize = true };
            lblTotalValue = new Label { Text = "Tổng giá trị: 0 VNĐ", Location = new Point(580, 460), AutoSize = true };

            this.Controls.AddRange(new Control[] 
            { 
                dgvProducts, lbl1, txtId, lbl2, txtName, lbl3, cboCategory, lbl4, txtPrice, lbl5, numQuantity,
                btnAdd, btnUpdate, btnDelete, btnClear, btnSelectImage, picProductImage, 
                lblClock, lblTotalQuantity, lblTotalValue 
            });

            timer1.Interval = 1000;
            timer1.Tick += (object? s, EventArgs e) => lblClock.Text = "Thời gian: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            
            this.Load += (object? s, EventArgs e) => {
                productBindingSource.DataSource = productList;
                dgvProducts.DataSource = productBindingSource;
                timer1.Start();
            };

            btnAdd.Click += BtnAdd_Click;
            btnUpdate.Click += BtnUpdate_Click;
            btnDelete.Click += BtnDelete_Click;
            btnClear.Click += (object? s, EventArgs e) => ClearInputs();
            btnSelectImage.Click += BtnSelectImage_Click;
            dgvProducts.SelectionChanged += DgvProducts_SelectionChanged;
        }

        private void BtnAdd_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtId.Text)) return;
            productList.Add(new Product {
                Id = txtId.Text,
                Name = txtName.Text,
                Category = cboCategory.Text,
                Price = decimal.TryParse(txtPrice.Text, out decimal p) ? p : 0,
                Quantity = (int)numQuantity.Value,
                ImagePath = currentImagePath
            });
            UpdateStatus();
            ClearInputs();
        }

        private void BtnUpdate_Click(object? sender, EventArgs e)
        {
            if (productBindingSource.Current is Product p)
            {
                p.Name = txtName.Text;
                p.Category = cboCategory.Text;
                p.Price = decimal.TryParse(txtPrice.Text, out decimal price) ? price : 0;
                p.Quantity = (int)numQuantity.Value;
                p.ImagePath = currentImagePath;
                productBindingSource.ResetCurrentItem();
                UpdateStatus();
            }
        }

        private void BtnDelete_Click(object? sender, EventArgs e)
        {
            if (productBindingSource.Current != null)
            {
                productBindingSource.RemoveCurrent();
                UpdateStatus();
                ClearInputs();
            }
        }

        private void BtnSelectImage_Click(object? sender, EventArgs e)
        {
            using OpenFileDialog ofd = new();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                currentImagePath = ofd.FileName;
                picProductImage.ImageLocation = currentImagePath;
            }
        }

        private void DgvProducts_SelectionChanged(object? sender, EventArgs e)
        {
            if (productBindingSource.Current is Product p)
            {
                txtId.Text = p.Id;
                txtName.Text = p.Name;
                cboCategory.Text = p.Category;
                txtPrice.Text = p.Price.ToString();
                numQuantity.Value = p.Quantity;
                currentImagePath = p.ImagePath;
                picProductImage.ImageLocation = File.Exists(p.ImagePath) ? p.ImagePath : null;
            }
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

        private void ClearInputs()
        {
            txtId.Clear(); txtName.Clear(); txtPrice.Clear();
            numQuantity.Value = 0; cboCategory.SelectedIndex = -1;
            picProductImage.Image = null; currentImagePath = "";
        }
    }
}
