using System;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace Lab10_DisconnectedData
{
    public partial class Form1 : Form
    {
        private DataSet _ds;
        private DataTable _table;
        private string _xmlFilePath = "DataSinhVien.xml";
        private string _schemaFilePath = "DataSinhVien.xsd";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Khởi tạo dữ liệu mẫu ban đầu
            InitData();
        }

        private void InitData()
        {
            _ds = new DataSet("QLSV_DataSet");
            _table = new DataTable("SinhVien");

            _table.Columns.Add("MaSV", typeof(string));
            _table.Columns.Add("HoTen", typeof(string));
            _table.Columns.Add("DiemTB", typeof(double));

            _table.PrimaryKey = new DataColumn[] { _table.Columns["MaSV"] };

            _table.Rows.Add("24001296", "Nguyễn Duy Hưng", 8.5);
            _table.Rows.Add("24001297", "Nguyễn Văn Hiếu", 8.0);
            _table.Rows.Add("24001298", "Trần Văn An", 7.5);

            _ds.Tables.Add(_table);

            dataGridView1.DataSource = _table;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        // 9. Sự kiện nút: Ghi DataSet ra file XML kèm Schema
        private void btnSaveXml_Click(object sender, EventArgs e)
        {
            try
            {
                // Ghi cấu trúc (Schema) ra file .xsd
                _ds.WriteXmlSchema(_schemaFilePath);

                // Ghi dữ liệu ra file .xml (có kèm theo định dạng Schema nếu muốn, hoặc dùng WriteXml)
                _ds.WriteXml(_xmlFilePath, XmlWriteMode.WriteSchema);

                MessageBox.Show("Đã ghi DataSet ra file XML và Schema thành công!\nĐường dẫn lưu: " + Path.GetFullPath(_xmlFilePath),
                                "Thông báo Lưu XML", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi ghi XML: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 9. Sự kiện nút: Đọc lại dữ liệu từ file XML mà không cần CSDL
        private void btnReadXml_Click(object sender, EventArgs e)
        {
            try
            {
                if (File.Exists(_xmlFilePath))
                {
                    // Tạo một DataSet mới hoàn toàn độc lập
                    DataSet dsRead = new DataSet("QLSV_Read");

                    // Đọc file XML kèm theo Schema đã lưu trước đó
                    dsRead.ReadXml(_xmlFilePath, XmlReadMode.ReadSchema);

                    // Gán dữ liệu đọc được lên DataGridView để kiểm chứng
                    dataGridView1.DataSource = dsRead.Tables["SinhVien"];
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                    MessageBox.Show("Đọc dữ liệu từ file XML thành công (Không cần kết nối CSDL)!",
                                    "Thông báo Đọc XML", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Chưa tìm thấy file XML! Vui lòng bấm nút 'Lưu XML' trước.",
                                    "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi đọc XML: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}