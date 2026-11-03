using System;
using System.Data;
using System.Windows.Forms;

namespace Lab10_DisconnectedData
{
    public partial class Form1 : Form
    {
        private DataTable _table;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        // Hàm nạp dữ liệu chuẩn cho bảng SinhVien
        private void LoadData()
        {
            _table = new DataTable("SinhVien");

            _table.Columns.Add("MaSV", typeof(string));
            _table.Columns.Add("HoTen", typeof(string));
            _table.Columns.Add("NgaySinh", typeof(string));
            _table.Columns.Add("GioiTinh", typeof(string));
            _table.Columns.Add("MaKhoa", typeof(string));
            _table.Columns.Add("DiemTB", typeof(double));
            _table.Columns.Add("Email", typeof(string));

            _table.PrimaryKey = new DataColumn[] { _table.Columns["MaSV"] };

            _table.Rows.Add("24001296", "Nguyễn Duy Hưng", "2006-01-01", "Nam", "CNTT", 8.5, "nguyenduyhung@gmail.com");
            _table.Rows.Add("24001297", "Nguyễn Văn Hiếu", "2006-05-12", "Nam", "CNTT", 8.0, "hieu@gmail.com");
            _table.Rows.Add("24001298", "Trần Văn An", "2006-03-20", "Nam", "VT", 6.5, "an@gmail.com");
            _table.Rows.Add("24001299", "Lê Thị Mai", "2006-08-15", "Nữ", "QT", 7.5, "mai@gmail.com");

            dataGridView1.DataSource = _table;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        // Sự kiện nút Lưu thay đổi (btnLưu)
        private void btnLưu_Click(object sender, EventArgs e)
        {
            dataGridView1.EndEdit();

            try
            {
                DataTable changes = _table.GetChanges();
                if (changes != null)
                {
                    int rows = changes.Rows.Count;
                    _table.AcceptChanges();
                    MessageBox.Show("Đã cập nhật " + rows + " thay đổi thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Không có thay đổi nào được ghi nhận.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi cập nhật: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}