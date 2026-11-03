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

        private void btnSaveXml_Click(object sender, EventArgs e)
        {
            try
            {
                _ds.WriteXmlSchema(_schemaFilePath);
                _ds.WriteXml(_xmlFilePath, XmlWriteMode.WriteSchema);
                MessageBox.Show("Đã ghi DataSet ra file XML thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReadXml_Click(object sender, EventArgs e)
        {
            try
            {
                if (File.Exists(_xmlFilePath))
                {
                    DataSet dsRead = new DataSet("QLSV_Read");
                    dsRead.ReadXml(_xmlFilePath, XmlReadMode.ReadSchema);
                    dataGridView1.DataSource = dsRead.Tables["SinhVien"];
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    MessageBox.Show("Đọc dữ liệu từ file XML thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Chưa tìm thấy file XML!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}