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
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Lấy DataSet chứa nhiều bảng
            DataSet ds = GetStudentDataset();

            // Kiểm tra số lượng bảng và tên bảng trong DataSet để xác thực
            MessageBox.Show($"DataSet chứa {ds.Tables.Count} bảng:\n- Bảng 1: {ds.Tables[0].TableName}\n- Bảng 2: {ds.Tables[1].TableName}",
                            "Thông báo DataSet", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Gán dữ liệu bảng SinhVien lên DataGridView
            dataGridView1.DataSource = ds.Tables["SinhVien"];
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        // 2. Hàm nạp Khoa và SinhVien vào cùng một DataSet với tên bảng rõ ràng
        private DataSet GetStudentDataset()
        {
            // Khởi tạo DataSet với tên rõ ràng
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
            dtSinhVien.Columns.Add("TenKhoa", typeof(string));
            dtSinhVien.Columns.Add("DiemTB", typeof(double));
            dtSinhVien.Columns.Add("Email", typeof(string));

            dtSinhVien.Rows.Add("24001296", "Nguyễn Duy Hưng", "2006-01-01", "Nam", "Công nghệ Thông tin", 8.5, "nguyenduyhung@gmail.com");
            dtSinhVien.Rows.Add("24001297", "Nguyễn Văn Hiếu", "2006-05-12", "Nam", "Công nghệ Thông tin", 8.0, "hieu@gmail.com");
            dtSinhVien.Rows.Add("24001298", "Trần Văn An", "2006-03-20", "Nam", "Điện tử Viễn thông", 6.5, "an@gmail.com");
            dtSinhVien.Rows.Add("24001299", "Lê Thị Mai", "2006-08-15", "Nữ", "Quản trị Kinh doanh", 7.5, "mai@gmail.com");

            // Thêm các bảng vào DataSet thông qua tên bảng thay vì chỉ số (Index) giúp truy cập ổn định hơn
            ds.Tables.Add(dtKhoa);
            ds.Tables.Add(dtSinhVien);

            return ds;
        }
    }
}