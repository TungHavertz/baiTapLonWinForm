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
            dgvHD.DataSource = table4;
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
            command.CommandText = "delete from quanLySP where MaSP = '"+tbMaSP.Text+"'";
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
            command.CommandText = "insert into quanLyKhachHang values('"+tbMaKH.Text+ "', N'"+tbTenKH.Text+ "', N'"+tbDC.Text+ "', '"+tbEM.Text+ "', '"+tbDT.Text+"' )";
            command.ExecuteNonQuery();
            loadData1();
            MessageBox.Show("Thêm khách hàng thành công!");
        }

        private void btXoaKH_Click(object sender, EventArgs e)
        {
            command = connection.CreateCommand();
            command.CommandText = "delete from quanLyKhachHang where MaKH = '"+tbMaKH.Text+"' ";
            command.ExecuteNonQuery();
            loadData1();
            MessageBox.Show("Xóa khách hàng thành công!");

        }

        private void btSuaKH_Click(object sender, EventArgs e)
        {
            command = connection.CreateCommand();
            command.CommandText = "update quanLyKhachHang set MaKH = '" + tbMaKH.Text + "', TenKH = N'"+tbTenKH.Text+"', DiaChi = N'"+tbDC.Text+"', Email = '"+tbEM.Text+"', Sdt = '"+tbDT.Text+"' where MaKH = '"+tbMaKH.Text+"' ";
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
            command.CommandText = "insert into quanLyNV values('" + tbMaNV.Text + "', N'" + tbTenNV.Text + "', '"+cbGTNV.Text+"', N'" + tbDCNV.Text + "', '" + tbDTNV.Text + "' )";
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
            i = dgvNV.CurrentRow.Index;
            tbMaHD.Text = dgvHD.Rows[i].Cells[0].Value.ToString();
            tbMaKH2.Text = dgvHD.Rows[i].Cells[1].Value.ToString();
            tbMaNV2.Text = dgvHD.Rows[i].Cells[1].Value.ToString();
            tbGia2.Text = dgvHD.Rows[i].Cells[3].Value.ToString();
            
        }

        private void btThemHoaDon_Click(object sender, EventArgs e)
        {
            command = connection.CreateCommand();
            command.CommandText = "insert into quanLyHD values('" + tbMaHD.Text + "', N'" + tbMaKH2.Text + "', '" + tbMaNV2.Text + "', N'" + tbGia2.Text + "' )";
            command.ExecuteNonQuery();
            loadData3();
            MessageBox.Show("Thêm hóa đơn thành công!");
        }

        //Doanh thu
        private void btLapBC_Click(object sender, EventArgs e)
        {
            command = connection.CreateCommand();
            command.CommandText = "insert into ThongKe values('" + tbDoanhThu.Text + "', N'" + tbDS.Text + "', '" +tbTK.Text + "' )";
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

        }

        private void label34_Click(object sender, EventArgs e)
        {

        }
    }
}
