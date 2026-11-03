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
            LoadScoreTable();
        }

        // 6. Hàm tạo DataTable thủ công và thêm cột tính toán XếpLoại
        private void LoadScoreTable()
        {
            DataTable dtScore = new DataTable("BangDiem");

            // Tạo các cột cơ bản
            dtScore.Columns.Add("MaSV", typeof(string));
            dtScore.Columns.Add("HoTen", typeof(string));
            dtScore.Columns.Add("Diem", typeof(double));

            // Thêm cột tính toán "Xếp Loại" sử dụng biểu thức (Expression) của DataTable
            // Nếu điểm >= 8.0: Giỏi, >= 6.5: Khá, >= 5.0: Trung bình, còn lại: Yếu
            DataColumn colXepLoai = new DataColumn("XếpLoai", typeof(string));
            colXepLoai.Expression = "IIF(Diem >= 8.0, 'Giỏi', IIF(Diem >= 6.5, 'Khá', IIF(Diem >= 5.0, 'Trung bình', 'Yếu')))";
            dtScore.Columns.Add(colXepLoai);

            // Thêm dữ liệu mẫu vào bảng
            dtScore.Rows.Add("24001296", "Nguyễn Duy Hưng", 8.5);
            dtScore.Rows.Add("24001297", "Nguyễn Văn Hiếu", 7.8);
            dtScore.Rows.Add("24001298", "Trần Văn An", 4.5);
            dtScore.Rows.Add("24001299", "Lê Thị Mai", 6.0);

            // Gán nguồn dữ liệu cho DataGridView
            dataGridView1.DataSource = dtScore;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
    }
}