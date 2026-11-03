using System;
using System.Data;
using System.Globalization;
using System.Windows.Forms;

namespace Lab10_DisconnectedData
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Lấy DataSet chứa các bảng
            DataSet ds = GetStudentDataset();

            // --- 4. LỌC VÀ SẮP XẾP BẰNG DATAVIEW ---
            // Tạo DataView từ bảng SinhVien
            DataView view = new DataView(ds.Tables["SinhVien"]);

            // Giả lập lọc theo mã khoa "CNTT" và điểm TB tối thiểu >= 8.0
            string maKhoa = "CNTT".Replace("'", "''");
            double minDiem = 8.0;

            // Thiết lập biểu thức lọc (RowFilter) và sắp xếp (Sort)
            view.RowFilter = string.Format("MaKhoa = '{0}' AND DiemTB >= {1}",
                                           maKhoa,
                                           minDiem.ToString(CultureInfo.InvariantCulture));

            view.Sort = "DiemTB DESC, HoTen ASC";

            // Gán DataView làm nguồn dữ liệu cho DataGridView để hiển thị
            dataGridView1.DataSource = view;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        // Hàm tạo DataSet gồm Khoa và SinhVien
        private DataSet GetStudentDataset()
        {
            DataSet ds = new DataSet("QLSinhVien");

            // --- Bảng 1: Khoa ---
            DataTable dtKhoa = new DataTable("Khoa");
            dtKhoa.Columns.Add("MaKhoa", typeof(string));
            dtKhoa.Columns.Add("TenKhoa", typeof(string));

            dtKhoa.Rows.Add("CNTT", "Công nghệ Thông tin");
            dtKhoa.Rows.Add("VT", "Điện tử Viễn thông");
            dtKhoa.Rows.Add("QT", "Quản trị Kinh doanh");

            // --- Bảng 2: SinhVien ---
            DataTable dtSinhVien = new DataTable("SinhVien");
            dtSinhVien.Columns.Add("MaSV", typeof(string));
            dtSinhVien.Columns.Add("HoTen", typeof(string));
            dtSinhVien.Columns.Add("NgaySinh", typeof(string));
            dtSinhVien.Columns.Add("GioiTinh", typeof(string));
            dtSinhVien.Columns.Add("MaKhoa", typeof(string));
            dtSinhVien.Columns.Add("DiemTB", typeof(double));
            dtSinhVien.Columns.Add("Email", typeof(string));

            dtSinhVien.Rows.Add("24001296", "Nguyễn Duy Hưng", "2006-01-01", "Nam", "CNTT", 8.5, "nguyenduyhung@gmail.com");
            dtSinhVien.Rows.Add("24001297", "Nguyễn Văn Hiếu", "2006-05-12", "Nam", "CNTT", 8.0, "hieu@gmail.com");
            dtSinhVien.Rows.Add("24001298", "Trần Văn An", "2006-03-20", "Nam", "VT", 6.5, "an@gmail.com");
            dtSinhVien.Rows.Add("24001299", "Lê Thị Mai", "2006-08-15", "Nữ", "QT", 7.5, "mai@gmail.com");

            ds.Tables.Add(dtKhoa);
            ds.Tables.Add(dtSinhVien);

            return ds;
        }
    }
}