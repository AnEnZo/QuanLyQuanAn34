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

namespace QuanLyQuanAn34
{
    public partial class Form1 : Form
    {
       SqlConnection connection;
       SqlCommand  command;
       string str = @"Data Source=LAPTOP-DFVUFD44;Initial Catalog=QuanLyQuanAn3;Integrated Security=True";
       SqlDataAdapter adapter = new SqlDataAdapter();
       DataTable table = new DataTable();

        void loaddata()
        {
            command = connection.CreateCommand();
            command.CommandText = "select * from ThongTinNhanVien3 ";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            dgv.DataSource = table;
        }


        public Form1()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            command = connection.CreateCommand();
            command.CommandText = "Insert into ThongTinNhanVien3 values(@manv, @tennv, @gioitinh, @ngaysinh, @chucvu)";
            command.Parameters.AddWithValue("@manv", tbmanv.Text);
            command.Parameters.AddWithValue("@tennv", tbtennv.Text);
            command.Parameters.AddWithValue("@gioitinh", cbgioitinh.Text);
            command.Parameters.AddWithValue("@ngaysinh", dtpngaysinh.Value); // Sử dụng Value thay vì Text
            command.Parameters.AddWithValue("@chucvu", tbchucvu.Text);
            command.ExecuteNonQuery();
            loaddata();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            connection = new SqlConnection(str);
            connection.Open();
            loaddata();
        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dgv.CurrentRow.Index;
            tbmanv.Text = dgv.Rows[i].Cells[0].Value.ToString();
            tbtennv.Text = dgv.Rows[i].Cells[1].Value.ToString();
            cbgioitinh.Text= dgv.Rows[i].Cells[2].Value.ToString();
            dtpngaysinh.Text = dgv.Rows[i].Cells[3].Value.ToString();
            tbchucvu.Text= dgv.Rows[i].Cells[4].Value.ToString();
            
        }

        private void dtpngaysinh_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            command = connection.CreateCommand();
            command.CommandText = "delete from ThongTinNhanVien3 where MaNv = @manv";
            command.Parameters.AddWithValue("@manv", tbmanv.Text);
            command.ExecuteNonQuery();
            loaddata();
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            command = connection.CreateCommand();
            command.CommandText = "update ThongTinNhanVien3 set MaNv= @manv , TenNv= @tennv, GioiTinh= @gioitinh,NgaySinh= @ngaysinh,ChucVu= @chucvu where MaNV= @manv";
            command.Parameters.AddWithValue("@manv", tbmanv.Text);
            command.Parameters.AddWithValue("@tennv", tbtennv.Text);
            command.Parameters.AddWithValue("@gioitinh", cbgioitinh.Text);
            command.Parameters.AddWithValue("@ngaysinh", dtpngaysinh.Value);
            command.Parameters.AddWithValue("@chucvu", tbchucvu.Text);
            command.ExecuteNonQuery();
            loaddata();
        }

        private void btnreset_Click(object sender, EventArgs e)
        {
            tbmanv.Text = "";
            tbtennv.Text = "";
            cbgioitinh.Text = "";
            dtpngaysinh.Text = "02/02/2000";
            tbchucvu.Text = "";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            command = connection.CreateCommand();
            command.CommandText = "select * from ThongTinNhanVien3 where TenNv like '%"+tbtimkiem.Text+"%' ";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            dgv.DataSource = table;
        }

        private void btntimkiem_Click(object sender, EventArgs e)
        {
            command = connection.CreateCommand();
            command.CommandText = "select * from ThongTinNhanVien3 where TenNv like '%" + tbtimkiem.Text + "%' ";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            dgv.DataSource = table;
        }

        private void btnhienthi_Click(object sender, EventArgs e)
        {
            loaddata();
        }
    }
}
