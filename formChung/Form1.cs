using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace formChung
{
    public partial class Form1 : Form
    {
        SqlConnection connection;
        SqlCommand command;
        string str = @"Data Source=ILHP\SQLEXPRESS;Initial Catalog=quanLyCuaHangĐTh;Integrated Security=True;";

        //Quản lý sản phẩm
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();

        //quản lý khách hàng
        SqlDataAdapter adapter1 = new SqlDataAdapter();
        DataTable table1 = new DataTable();

        //quản lý nhân viên
        SqlDataAdapter adapter2 = new SqlDataAdapter();
        DataTable table2 = new DataTable();

        //Quản lý hóa đơn
        SqlDataAdapter adapter3 = new SqlDataAdapter();
        DataTable table3 = new DataTable();

        //Thống kê
        SqlDataAdapter adapter4 = new SqlDataAdapter();
        DataTable table4 = new DataTable();

        //Nhà cung cấp
        SqlDataAdapter adapter5 = new SqlDataAdapter();
        DataTable table5 = new DataTable();

        void loadData()
        {
            command = connection.CreateCommand();
            command.CommandText = "select * from quanLySP";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            dgvSP.DataSource = table;
        }

        void loadData1()
        {
            command = connection.CreateCommand();
            command.CommandText = "select * from quanLyKhachHang";
            adapter1.SelectCommand = command;
            table1.Clear();
            adapter1.Fill(table1);
            dgvKH.DataSource = table1;
        }

        void loadData2()
        {
            command = connection.CreateCommand();
            command.CommandText = "select * from quanLyNV";
            adapter2.SelectCommand = command;
            table2.Clear();
            adapter2.Fill(table2);
            dgvNV.DataSource = table2;
        }

        void loadData3()
        {
            command = connection.CreateCommand();
            command.CommandText = "select * from quanLyHD";
            adapter3.SelectCommand = command;
            table3.Clear();
            adapter3.Fill(table3);
            dgvHD.DataSource = table3;
        }

        void loadData4()
        {
            command = connection.CreateCommand();
            command.CommandText = "select * from ThongKe";
            adapter4.SelectCommand = command;
            table4.Clear();
            adapter4.Fill(table4);
            dgvDT.DataSource = table4;
        }

        void loadData5()
        {
            command = connection.CreateCommand();
            command.CommandText = "select * from quanLyNCC";
            adapter5.SelectCommand = command;
            table5.Clear();
            adapter5.Fill(table5);
            dgvNCC.DataSource = table5;
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBox19_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox24_TextChanged(object sender, EventArgs e)
        {

        }

        private void tabPage8_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

            connection = new SqlConnection(str);
            connection.Open();
            loadData();
            loadData1();
            loadData2();
            loadData3();
            loadData4();
        }

        private void btThemSP_Click(object sender, EventArgs e)
        {

        }

        private void dgvSP_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btXoaSP_Click(object sender, EventArgs e)
        {
            command = connection.CreateCommand();
            command.CommandText = "delete from quanLySP where MaSP = '" + tbMaSP.Text + "'";
            command.ExecuteNonQuery();
            loadData();
            MessageBox.Show("Xóa sản phẩm thành công!");

        }

        private void dgvSP_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            tbMaSP.ReadOnly = true;
            int i;
            i = dgvSP.CurrentRow.Index;
            tbMaSP.Text = dgvSP.Rows[i].Cells[0].Value.ToString();
            tbTenSP.Text = dgvSP.Rows[i].Cells[1].Value.ToString();
            tbGiaSP.Text = dgvSP.Rows[i].Cells[2].Value.ToString();
        }

        private void btThemSP_Click_1(object sender, EventArgs e)
        {
            command = connection.CreateCommand();
            command.CommandText = "insert into quanLySP values('" + tbMaSP.Text + "', '" + tbTenSP.Text + "', '" + tbGiaSP.Text + "')";
            command.ExecuteNonQuery();
            loadData();
            MessageBox.Show("Thêm sản phẩm thành công!");

        }

        private void tabSP_Click(object sender, EventArgs e)
        {

        }

        private void btSuaSP_Click(object sender, EventArgs e)
        {
            command = connection.CreateCommand();
            command.CommandText = "update quanLySP set MaSP = '" + tbMaSP.Text + "', TenSP = N'" + tbTenSP.Text + "', Gia = '" + tbGiaSP.Text + "' where MaSP = '" + tbMaSP.Text + "' ";
            command.ExecuteNonQuery();
            loadData();
            MessageBox.Show("Sửa sản phẩm thành công!");


        }

        //Quản lý khách hàng
        private void dgvKH_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            tbMaKH.ReadOnly = true;
            int i;
            i = dgvKH.CurrentRow.Index;
            tbMaKH.Text = dgvKH.Rows[i].Cells[0].Value.ToString();
            tbTenKH.Text = dgvKH.Rows[i].Cells[1].Value.ToString();
            tbDC.Text = dgvKH.Rows[i].Cells[2].Value.ToString();
            tbEM.Text = dgvKH.Rows[i].Cells[3].Value.ToString();
            tbDT.Text = dgvKH.Rows[i].Cells[4].Value.ToString();
        }

        private void btThemKH_Click(object sender, EventArgs e)
        {
            command = connection.CreateCommand();
            command.CommandText = "insert into quanLyKhachHang values('" + tbMaKH.Text + "', N'" + tbTenKH.Text + "', N'" + tbDC.Text + "', '" + tbEM.Text + "', '" + tbDT.Text + "' )";
            command.ExecuteNonQuery();
            loadData1();
            MessageBox.Show("Thêm khách hàng thành công!");
        }

        private void btXoaKH_Click(object sender, EventArgs e)
        {
            command = connection.CreateCommand();
            command.CommandText = "delete from quanLyKhachHang where MaKH = '" + tbMaKH.Text + "' ";
            command.ExecuteNonQuery();
            loadData1();
            MessageBox.Show("Xóa khách hàng thành công!");

        }

        private void btSuaKH_Click(object sender, EventArgs e)
        {
            command = connection.CreateCommand();
            command.CommandText = "update quanLyKhachHang set MaKH = '" + tbMaKH.Text + "', TenKH = N'" + tbTenKH.Text + "', DiaChi = N'" + tbDC.Text + "', Email = '" + tbEM.Text + "', Sdt = '" + tbDT.Text + "' where MaKH = '" + tbMaKH.Text + "' ";
            command.ExecuteNonQuery();
            loadData1();
            MessageBox.Show("Sửa khách hàng thành công!");

        }



        //Quản lý nhân viên
        private void dgvNV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            tbMaNV.ReadOnly = true;
            int i;
            i = dgvNV.CurrentRow.Index;
            tbMaNV.Text = dgvNV.Rows[i].Cells[0].Value.ToString();
            tbTenNV.Text = dgvNV.Rows[i].Cells[1].Value.ToString();
            cbGTNV.Text = dgvNV.Rows[i].Cells[1].Value.ToString();
            tbDCNV.Text = dgvNV.Rows[i].Cells[3].Value.ToString();
            tbDTNV.Text = dgvNV.Rows[i].Cells[4].Value.ToString();


        }

        private void btThemNV_Click(object sender, EventArgs e)
        {
            command = connection.CreateCommand();
            command.CommandText = "insert into quanLyNV values('" + tbMaNV.Text + "', N'" + tbTenNV.Text + "', '" + cbGTNV.Text + "', N'" + tbDCNV.Text + "', '" + tbDTNV.Text + "' )";
            command.ExecuteNonQuery();
            loadData2();
            MessageBox.Show("Thêm nhân viên thành công!");

        }

        private void btXoaNV_Click(object sender, EventArgs e)
        {
            command = connection.CreateCommand();
            command.CommandText = "delete from quanLyNV where MaNV = '" + tbMaNV.Text + "' ";
            command.ExecuteNonQuery();
            loadData2();
            MessageBox.Show("Xóa nhân viên thành công!");

        }

        private void dgvDT_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btSuaNV_Click(object sender, EventArgs e)
        {
            command = connection.CreateCommand();
            command.CommandText = "update quanLyNV set MaNV = '" + tbMaNV.Text + "', TenNV = N'" + tbTenNV.Text + "', GioiTinh = N'" + cbGTNV.Text + "', DiaChi = N'" + tbDCNV.Text + "', Sdt = '" + tbDTNV.Text + "' where MaNV = '" + tbMaNV.Text + "' ";
            command.ExecuteNonQuery();
            loadData2();
            MessageBox.Show("Sửa nhân viên thành công!");

        }

        //Quản lý hóa đơn
        private void dgvHD_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            tbMaHD.ReadOnly = true;
            int i;
            i = dgvHD.CurrentRow.Index;
            tbMaHD.Text = dgvHD.Rows[i].Cells[0].Value.ToString();
            tbMaKH2.Text = dgvHD.Rows[i].Cells[1].Value.ToString();
            tbMaSP2.Text = dgvHD.Rows[i].Cells[1].Value.ToString();
            tbGia2.Text = dgvHD.Rows[i].Cells[3].Value.ToString();

        }

        private void btThemHoaDon_Click(object sender, EventArgs e)
        {
            command = connection.CreateCommand();
            command.CommandText = "insert into quanLyHD values('" + tbMaHD.Text + "', N'" + tbMaKH2.Text + "', '" + tbMaSP2.Text + "', N'" + tbGia2.Text + "' )";
            command.ExecuteNonQuery();
            loadData3();
            MessageBox.Show("Thêm hóa đơn thành công!");
        }

        //Doanh thu
        private void btLapBC_Click(object sender, EventArgs e)
        {
            command = connection.CreateCommand();
            command.CommandText = "insert into ThongKe values('"+tbMaTK.Text+"', '" + tbDoanhThu.Text + "', N'" + tbDS.Text + "', '" + tbTK.Text + "', '"+dtpNL.Text+"' )";
            command.ExecuteNonQuery();
            loadData4();
            MessageBox.Show("Báo cáo đã được gửi!");
        }

        private void label28_Click(object sender, EventArgs e)
        {

        }

        private void tbTK_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            tbMaTK.ReadOnly = true;
            int i;
            i = dgvDT.CurrentRow.Index;
            tbMaTK.Text = dgvDT.Rows[i].Cells[0].Value.ToString();
            tbDoanhThu.Text = dgvDT.Rows[i].Cells[1].Value.ToString();
            tbDS.Text = dgvDT.Rows[i].Cells[1].Value.ToString();
            tbTK.Text = dgvDT.Rows[i].Cells[3].Value.ToString();
            dtpNL.Text = dgvDT.Rows[i].Cells[4].Value.ToString();

        }

        private void label34_Click(object sender, EventArgs e)
        {

        }

        private void tabPage14_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tbMaNV_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Lấy thông tin tìm kiếm từ textBox tbTimKiemKH
            string keyword = tbTKNV.Text.Trim();

            // Kiểm tra xem từ khóa tìm kiếm có rỗng không
            if (keyword != "")
            {
                // Thực hiện truy vấn SQL để lấy thông tin khách hàng thỏa mãn điều kiện
                command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM quanLyNV WHERE MaNV LIKE @keyword or TenNV LIKE @keyword or GioiTinh LIKE @keyword or DiaChi LIKE @keyword or Sdt LIKE @keyword";
                command.Parameters.AddWithValue("@keyword", "%" + keyword + "%");

                // Xóa dữ liệu cũ trong bảng table1
                table2.Clear();

                // Thực hiện truy vấn và điền dữ liệu vào bảng table1
                adapter2.SelectCommand = command;
                adapter2.Fill(table2);

                // Hiển thị kết quả lên dataGridView dgvKH
                dgvNV.DataSource = table2;
            }
            else
            {
                // Nếu từ khóa tìm kiếm rỗng, hiển thị toàn bộ dữ liệu
                loadData2();
            }
        }

        private void btQLKH_Click(object sender, EventArgs e)
        {
            // Lấy thông tin tìm kiếm từ textBox tbTimKiemKH
            string keyword = tbTKKH.Text.Trim();

            // Kiểm tra xem từ khóa tìm kiếm có rỗng không
            if (keyword != "")
            {
                // Thực hiện truy vấn SQL để lấy thông tin khách hàng thỏa mãn điều kiện
                command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM quanLyKhachHang WHERE TenKH LIKE @keyword";
                command.Parameters.AddWithValue("@keyword", "%" + keyword + "%");

                // Xóa dữ liệu cũ trong bảng table1
                table1.Clear();

                // Thực hiện truy vấn và điền dữ liệu vào bảng table1
                adapter1.SelectCommand = command;
                adapter1.Fill(table1);

                // Hiển thị kết quả lên dataGridView dgvKH
                dgvKH.DataSource = table1;
            }
            else
            {
                // Nếu từ khóa tìm kiếm rỗng, hiển thị toàn bộ dữ liệu
                loadData1();
            }
        }

        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        //Tìm kiếm sản phẩm
        private void btTKSP_Click(object sender, EventArgs e)
        {
            // Lấy thông tin tìm kiếm từ textBox tbTKSP
            string keyword = tbTKSP.Text.Trim();

            // Kiểm tra xem từ khóa tìm kiếm có rỗng không
            if (keyword != "")
            {
                // Thực hiện truy vấn SQL để lấy thông tin khách hàng thỏa mãn điều kiện
                command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM quanLySP WHERE MaSP LIKE @keyword or TenSP LIKE @keyword or Gia LIKE @keyword";
                command.Parameters.AddWithValue("@keyword", "%" + keyword + "%");

                // Xóa dữ liệu cũ trong bảng table1
                table.Clear();

                // Thực hiện truy vấn và điền dữ liệu vào bảng table1
                adapter.SelectCommand = command;
                adapter.Fill(table);

                // Hiển thị kết quả lên dataGridView dgvSP
                dgvSP.DataSource = table;
            }
            else
            {
                // Nếu từ khóa tìm kiếm rỗng, hiển thị toàn bộ dữ liệu
                loadData();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            command = connection.CreateCommand();
            command.CommandText = "update ThongKe set MaThongKe = '"+tbMaTK.Text+"', DoanhThu = '" + tbDoanhThu.Text + "', DoanhSo = N'" + tbDS.Text + "', TonKho = '" + tbTK.Text + "', NgayLap = '"+dtpNL.Text+"' where MaThongKe = '" + tbMaTK.Text + "' ";
            command.ExecuteNonQuery();
            loadData4();
            MessageBox.Show("Sửa báo cáo thành công");
        }

        private void btXoaHD_Click(object sender, EventArgs e)
        {
            command = connection.CreateCommand();
            command.CommandText = "delete from quanLyHD where MaHD = '" + tbMaHD.Text + "'  ";
            command.ExecuteNonQuery();
            loadData3();
            MessageBox.Show("Xóa hóa đơn thành công");
        }

        private void btXoaBC_Click(object sender, EventArgs e)
        {
            command = connection.CreateCommand();
            command.CommandText = "delete from ThongKe where MaThongKe = '" + tbMaTK.Text + "'  ";
            command.ExecuteNonQuery();
            loadData4();
            MessageBox.Show("Xóa báo cáo thành công!");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Lấy thông tin tìm kiếm từ textBox tbTKHD
            string keyword = tbTKDT.Text.Trim();

            // Kiểm tra xem từ khóa tìm kiếm có rỗng không
            if (keyword != "")
            {
                // Thực hiện truy vấn SQL để lấy thông tin sản phẩm thỏa mãn điều kiện
                command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM ThongKe WHERE MaThongKe LIKE @keyword or DoanhThu LIKE @keyword or DoanhSo LIKE @keyword or TonKho LIKE @keyword or NgayLap LIKE @keyword";
                command.Parameters.AddWithValue("@keyword", "%" + keyword + "%");

                // Xóa dữ liệu cũ trong bảng table3
                table4.Clear();

                // Thực hiện truy vấn và điền dữ liệu vào bảng table3
                adapter4.SelectCommand = command;
                adapter4.Fill(table4);

                // Hiển thị kết quả lên dataGridView dgvHD
                dgvDT.DataSource = table4;
            }
            else
            {
                // Nếu từ khóa tìm kiếm rỗng, hiển thị toàn bộ dữ liệu
                loadData3();
            }
        }

        //Sửa hóa đơn
        private void btSuaHD_Click(object sender, EventArgs e)
        {
            command = connection.CreateCommand();
            command.CommandText = "update quanLyHD set MaHD = '" + tbMaHD.Text + "', MaKH = N'" + tbMaKH2.Text + "', MaSP = '" + tbMaSP2.Text + "', ThanhTien = '"+tbGia2.Text+"' where MaHD = '" + tbMaHD.Text + "' ";
            command.ExecuteNonQuery();
            loadData3();
            MessageBox.Show("Sửa hóa đơn thành công!");
        }

        //Tìm kiếm hóa đơn
        private void btTKHD_Click(object sender, EventArgs e)
        {
            // Lấy thông tin tìm kiếm từ textBox tbTKHD
            string keyword = tbTKHD.Text.Trim();

            // Kiểm tra xem từ khóa tìm kiếm có rỗng không
            if (keyword != "")
            {
                // Thực hiện truy vấn SQL để lấy thông tin sản phẩm thỏa mãn điều kiện
                command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM quanLyHD WHERE MaHD LIKE @keyword or MaKH LIKE @keyword or MaSP LIKE @keyword or ThanhTien LIKE @keyword";
                command.Parameters.AddWithValue("@keyword", "%" + keyword + "%");

                // Xóa dữ liệu cũ trong bảng table3
                table3.Clear();

                // Thực hiện truy vấn và điền dữ liệu vào bảng table3
                adapter3.SelectCommand = command;
                adapter3.Fill(table3);

                // Hiển thị kết quả lên dataGridView dgvHD
                dgvHD.DataSource = table3;
            }
            else
            {
                // Nếu từ khóa tìm kiếm rỗng, hiển thị toàn bộ dữ liệu
                loadData3();
            }
        }

        private void tbTKDT_TextChanged(object sender, EventArgs e)
        {

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        { 

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void dgvNCC_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            tbMaNCC.ReadOnly = true;
            int i;
            i = dgvNCC.CurrentRow.Index;
            tbMaNCC.Text = dgvNCC.Rows[i].Cells[0].Value.ToString();
            tbTenNCC.Text = dgvNCC.Rows[i].Cells[1].Value.ToString();
            tbDTNCC.Text = dgvNCC.Rows[i].Cells[1].Value.ToString();
            tbGC.Text = dgvNCC.Rows[i].Cells[3].Value.ToString();
        }

        private void btThemNCC_Click(object sender, EventArgs e)
        {
            command = connection.CreateCommand();
            command.CommandText = "insert into quanLyNCC values('" + tbMaNCC.Text + "', '" + tbTenNCC.Text + "', N'" + tbDTNCC.Text + "', '" + tbGC.Text + "' )";
            command.ExecuteNonQuery();
            loadData5();
            MessageBox.Show("Đã thêm nhà cung cấp");
        }

        private void btSuaNCC_Click(object sender, EventArgs e)
        {
            command = connection.CreateCommand();
            command.CommandText = "update quanLyNCC set MaNCC = '" + tbMaNCC.Text + "', TenNCC = '" + tbTenNCC.Text + "', Sdt = N'" + tbDTNCC.Text + "', GhiChu = '" + tbGC.Text + "' where MaNCC = '" + tbMaNCC.Text + "' ";
            command.ExecuteNonQuery();
            loadData5();
            MessageBox.Show("Sửa nhà cung cấp thành công");
        }

        private void btXoaNCC_Click(object sender, EventArgs e)
        {
            command = connection.CreateCommand();
            command.CommandText = "delete from quanLyNCC where MaNCC = '" + tbMaNCC.Text + "'  ";
            command.ExecuteNonQuery();
            loadData5();
            MessageBox.Show("Xóa nhà cung cấp thành công!");
        }

        private void btTKNCC_Click(object sender, EventArgs e)
        {
            // Lấy thông tin tìm kiếm từ textBox tbTKNCC
            string keyword = tbTKNCC.Text.Trim();

            // Kiểm tra xem từ khóa tìm kiếm có rỗng không
            if (keyword != "")
            {
                // Thực hiện truy vấn SQL để lấy thông tin sản phẩm thỏa mãn điều kiện
                command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM quanLyNCC WHERE MaNCC LIKE @keyword or TenNCC LIKE @keyword or Sdt LIKE @keyword or GhiChu LIKE @keyword ";
                command.Parameters.AddWithValue("@keyword", "%" + keyword + "%");

                // Xóa dữ liệu cũ trong bảng table5
                table5.Clear();

                // Thực hiện truy vấn và điền dữ liệu vào bảng table5
                adapter5.SelectCommand = command;
                adapter5.Fill(table5);

                // Hiển thị kết quả lên dataGridView dgvHD
                dgvDT.DataSource = table4;
            }
            else
            {
                // Nếu từ khóa tìm kiếm rỗng, hiển thị toàn bộ dữ liệu
                loadData5();
            }
        }
    }
}
