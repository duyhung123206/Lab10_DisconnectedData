using System;
using System.Data;
using System.Windows.Forms;

namespace Lab10_DisconnectedData
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // Gọi hàm load dữ liệu khi form khởi chạy
            LoadData();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Tự động giãn cột cho bảng DataGridView để lấp đầy không gian
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        // Hàm tạo bảng dữ liệu mẫu trực tiếp (Không cần SQL Server)
        private DataTable GetStudentTable()
        {
            DataTable table = new DataTable("SinhVien");

            // Định nghĩa các cột cho bảng SinhVien
            table.Columns.Add("MaSV", typeof(string));
            table.Columns.Add("HoTen", typeof(string));
            table.Columns.Add("NgaySinh", typeof(string));
            table.Columns.Add("GioiTinh", typeof(string));
            table.Columns.Add("TenKhoa", typeof(string));
            table.Columns.Add("DiemTB", typeof(double));
            table.Columns.Add("Email", typeof(string));

            // Thêm dữ liệu mẫu vào bảng
            table.Rows.Add("24001296", "Nguyễn Duy Hưng", "2006-01-01", "Nam", "Công nghệ Thông tin", 8.5, "nguyenduyhung@gmail.com");
            table.Rows.Add("24001297", "Nguyễn Văn Hiếu", "2006-05-12", "Nam", "Công nghệ Thông tin", 8.0, "hieu@gmail.com");
            table.Rows.Add("24001298", "Trần Văn An", "2006-03-20", "Nam", "Điện tử Viễn thông", 6.5, "an@gmail.com");
            table.Rows.Add("24001299", "Lê Thị Mai", "2006-08-15", "Nữ", "Quản trị Kinh doanh", 7.5, "mai@gmail.com");

            return table;
        }

        // Hàm đổ dữ liệu lên DataGridView
        private void LoadData()
        {
            dataGridView1.DataSource = GetStudentTable();
        }
    }
}