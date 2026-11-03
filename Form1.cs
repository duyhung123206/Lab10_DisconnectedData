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
            // Lấy DataSet chứa các bảng
            DataSet ds = GetStudentDataset();

            // --- 3. THIẾT LẬP DATARELATION KHOA - SINHVIEN ---
            try
            {
                DataRelation relation = new DataTableRelationTest().CreateRelation(ds);

                // Lấy dòng khoa đầu tiên (Ví dụ: Khoa CNTT)
                DataRow khoa = ds.Tables["Khoa"].Rows[0];

                // Lấy danh sách các dòng sinh viên con thuộc khoa này thông qua mối quan hệ
                DataRow[] sinhVienList = khoa.GetChildRows("FK_Khoa_SinhVien");

                string message = $"Danh sách sinh viên thuộc khoa '{khoa["TenKhoa"]}':\n";
                foreach (DataRow row in sinhVienList)
                {
                    message += $"- {row["HoTen"]} (Mã SV: {row["MaSV"]})\n";
                }

                MessageBox.Show(message, "Kết quả DataRelation Bài 3", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tạo quan hệ: " + ex.Message);
            }

            // Gán dữ liệu bảng SinhVien lên DataGridView để hiển thị giao diện
            dataGridView1.DataSource = ds.Tables["SinhVien"];
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        // Hàm tạo DataSet gồm Khoa và SinhVien (Đã bổ sung cột MaKhoa cho bảng SinhVien để khớp quan hệ)
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

            // --- Bảng 2: SinhVien (Có thêm cột MaKhoa để liên kết) ---
            DataTable dtSinhVien = new DataTable("SinhVien");
            dtSinhVien.Columns.Add("MaSV", typeof(string));
            dtSinhVien.Columns.Add("HoTen", typeof(string));
            dtSinhVien.Columns.Add("NgaySinh", typeof(string));
            dtSinhVien.Columns.Add("GioiTinh", typeof(string));
            dtSinhVien.Columns.Add("MaKhoa", typeof(string)); // Khóa ngoại liên kết với bảng Khoa
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

    // Helper class để cấu hình quan hệ theo mẫu bài lab
    public class DataTableRelationTest
    {
        public DataRelation CreateRelation(DataSet ds)
        {
            DataRelation relation = new DataRelation(
                "FK_Khoa_SinhVien",
                ds.Tables["Khoa"].Columns["MaKhoa"],
                ds.Tables["SinhVien"].Columns["MaKhoa"]);

            ds.Relations.Add(relation);
            return relation;
        }
    }
}