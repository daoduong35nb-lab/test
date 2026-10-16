using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Bai_1
{
    public partial class Form1 : Form
    {
        private BindingList<Device> deviceList;
        private BindingSource deviceBindingSource;
        private int idCounter = 1;

        public Form1()
        {
            InitializeComponent(); // Nếu dòng này báo lỗi, hãy đảm bảo bạn không đổi tên Form1 trong file Form1.designer.cs
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // 1. Khởi tạo danh sách và BindingSource
            deviceList = new BindingList<Device>();
            deviceBindingSource = new BindingSource();
            deviceBindingSource.DataSource = deviceList;

            // 2. Khởi tạo ComboBox
            cboCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            cboCategory.Items.AddRange(new string[] { "Laptop", "Điện thoại", "Máy tính bảng", "Phụ kiện" });

            // 3. Cấu hình DataGridView
            SetupDataGridView();
            dgvDevices.DataSource = deviceBindingSource;

            // 4. Thiết lập thuộc tính cơ bản
            txtDeviceId.ReadOnly = true;
            GenerateNewId();

            // 5. Gắn sự kiện (Event) bằng code (để bạn không cần phải click đúp trên giao diện)
            //btnAdd.Click += btnAdd_Click;
            //btnUpdate.Click += btnUpdate_Click;
            //btnDelete.Click += btnDelete_Click;
            //btnClear.Click += btnClear_Click;
            //dgvDevices.SelectionChanged += dgvDevices_SelectionChanged;
        }

        private void SetupDataGridView()
        {
            dgvDevices.AutoGenerateColumns = false;
            dgvDevices.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDevices.ReadOnly = true;
            dgvDevices.AllowUserToAddRows = false;
            dgvDevices.Columns.Clear(); // Xóa cột cũ nếu có

            dgvDevices.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "Id",
                HeaderText = "Mã TB",
                Name = "colId",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            });

            dgvDevices.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "Name",
                HeaderText = "Tên thiết bị",
                Name = "colName",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            dgvDevices.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "Category",
                HeaderText = "Loại thiết bị",
                Name = "colCategory",
                Width = 120
            });

            dgvDevices.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "Price",
                HeaderText = "Đơn giá",
                Name = "colPrice",
                DefaultCellStyle = new DataGridViewCellStyle { Format = "N0" } // Định dạng số có dấu phẩy
            });

            dgvDevices.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "Quantity",
                HeaderText = "SL Tồn",
                Name = "colQuantity",
                Width = 80
            });
        }

        private bool ValidateData()
        {
            errorProvider1.Clear();
            bool isValid = true;

            if (string.IsNullOrWhiteSpace(txtDeviceName.Text))
            {
                errorProvider1.SetError(txtDeviceName, "Tên thiết bị không được để trống.");
                isValid = false;
            }

            if (cboCategory.SelectedIndex == -1)
            {
                errorProvider1.SetError(cboCategory, "Vui lòng chọn loại thiết bị.");
                isValid = false;
            }

            if (!decimal.TryParse(txtPrice.Text, out decimal price) || price < 0)
            {
                errorProvider1.SetError(txtPrice, "Đơn giá phải là số và không được nhỏ hơn 0.");
                isValid = false;
            }

            return isValid;
        }

        private void GenerateNewId()
        {
            txtDeviceId.Text = "TB" + idCounter.ToString("D3");
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (ValidateData())
            {
                Device newDevice = new Device
                {
                    Id = txtDeviceId.Text,
                    Name = txtDeviceName.Text,
                    Category = cboCategory.SelectedItem.ToString(),
                    Price = decimal.Parse(txtPrice.Text),
                    Quantity = (int)numQuantity.Value
                };

                deviceList.Add(newDevice);
                idCounter++;
                btnClear_Click(sender, e);
            }
        }

        private void dgvDevices_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvDevices.CurrentRow != null && dgvDevices.CurrentRow.Index >= 0)
            {
                Device selectedDevice = (Device)deviceBindingSource.Current;
                if (selectedDevice != null)
                {
                    txtDeviceId.Text = selectedDevice.Id;
                    txtDeviceName.Text = selectedDevice.Name;
                    cboCategory.SelectedItem = selectedDevice.Category;
                    txtPrice.Text = selectedDevice.Price.ToString();
                    numQuantity.Value = selectedDevice.Quantity;
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (deviceBindingSource.Current != null && ValidateData())
            {
                Device currentDevice = (Device)deviceBindingSource.Current;

                currentDevice.Name = txtDeviceName.Text;
                currentDevice.Category = cboCategory.SelectedItem.ToString();
                currentDevice.Price = decimal.Parse(txtPrice.Text);
                currentDevice.Quantity = (int)numQuantity.Value;

                deviceBindingSource.ResetCurrentItem();
                MessageBox.Show("Cập nhật thành công!", "Thông báo");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (deviceBindingSource.Current != null)
            {
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa thiết bị này không?",
                                                      "Xác nhận xóa",
                                                      MessageBoxButtons.YesNo,
                                                      MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    deviceBindingSource.RemoveCurrent();
                    btnClear_Click(sender, e);
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            GenerateNewId();
            txtDeviceName.Clear();
            cboCategory.SelectedIndex = -1;
            txtPrice.Clear();
            numQuantity.Value = 0;
            errorProvider1.Clear();
            dgvDevices.ClearSelection();
        }
    }
}