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
            LoadDataAndTrackRowState();
        }

        // 7. Hàm nạp dữ liệu và theo dõi RowState
        private void LoadDataAndTrackRowState()
        {
            _table = new DataTable("SinhVien");

            // Định nghĩa các cột
            _table.Columns.Add("MaSV", typeof(string));
            _table.Columns.Add("HoTen", typeof(string));
            _table.Columns.Add("DiemTB", typeof(double));

            _table.PrimaryKey = new DataColumn[] { _table.Columns["MaSV"] };

            // Thêm dữ liệu ban đầu
            _table.Rows.Add("24001296", "Nguyễn Duy Hưng", 8.5);
            _table.Rows.Add("24001297", "Nguyễn Văn Hiếu", 8.0);
            _table.AcceptChanges(); // Đưa trạng thái về Unchanged

            // Mô phỏng các trạng thái thay đổi
            _table.Rows.Add("24001298", "Trần Văn An", 7.5);         // Added
            _table.Rows[0]["HoTen"] = "Nguyễn Duy Hưng (Đã sửa)";  // Modified
            _table.Rows[1].Delete();                               // Deleted

            // Hiển thị lên DataGridView
            dataGridView1.DataSource = _table;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Gọi hàm kiểm tra trạng thái dòng
            CheckRowStates(_table);
        }

        // Hàm kiểm tra RowState an toàn bằng cách duyệt qua bảng 'changes'
        private void CheckRowStates(DataTable table)
        {
            // Lấy danh sách các dòng thực sự có thay đổi
            DataTable changes = table.GetChanges();

            if (changes != null)
            {
                string info = "--- DANH SÁCH CÁC DÒNG THAY ĐỔI (RowState) ---\n\n";

                // Duyệt qua bảng changes để tránh lỗi truy xuất dòng đã xóa
                foreach (DataRow row in changes.Rows)
                {
                    DataRowState state = row.RowState;
                    string maSV = "";
                    string hoTen = "";

                    // Nếu dòng bị xóa, lấy dữ liệu từ phiên bản Original
                    if (state == DataRowState.Deleted)
                    {
                        maSV = row["MaSV", DataRowVersion.Original].ToString();
                        hoTen = row["HoTen", DataRowVersion.Original].ToString();
                    }
                    else
                    {
                        maSV = row["MaSV"].ToString();
                        hoTen = row["HoTen"].ToString();
                    }

                    info += $"- Mã SV: {maSV} | Họ Tên: {hoTen} | Trạng thái: {state}\n";
                }

                MessageBox.Show(info, "Theo dõi RowState (Bài 7)", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Không có thay đổi nào được ghi nhận.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}