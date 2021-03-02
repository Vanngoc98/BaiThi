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

namespace QuanLyBangDia
{
    public partial class Form1 : Form
    {
        SqlConnection connection;
        SqlCommand command;
        string str = @"Data Source=DARK\DARK;Initial Catalog=QuanLyBangDia;Integrated Security=True";
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();
        void loaddata()
        {
            command = connection.CreateCommand();
            command.CommandText = "select * from BangDia";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            DGRW.DataSource = table;
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void BTThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            connection = new SqlConnection(str);
            connection.Open();
            loaddata();
        }

        private void DGRW_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            TBMBD.ReadOnly = true;
            int i;
            i = DGRW.CurrentRow.Index;
            TBMBD.Text = DGRW.Rows[i].Cells[0].Value.ToString();
            TBTBD.Text = DGRW.Rows[i].Cells[1].Value.ToString();
            TBSL.Text = DGRW.Rows[i].Cells[2].Value.ToString();
        }

        private void BTNhap_Click(object sender, EventArgs e)
        {
            command = connection.CreateCommand();
            command.CommandText = "insert into BangDia values('"+TBMBD.Text+ "',N'"+TBTBD.Text+"','" +TBSL.Text+"')";
            command.ExecuteNonQuery();
            loaddata();
        }
        private void BTSua_Click(object sender, EventArgs e)
        {
            command = connection.CreateCommand();
            command.CommandText = "update BangDia set TenBangDia ='"+TBTBD.Text+"',SoLuong='"+TBSL.Text+"'where MaBD ='"+TBMBD.Text+"'";
            command.ExecuteNonQuery();
            loaddata();
        }
        private void BTXoa_Click(object sender, EventArgs e)
        {
            command = connection.CreateCommand();
            command.CommandText = "delete from BangDia where MaBD ='"+TBMBD.Text +"'";
            command.ExecuteNonQuery();
            loaddata();
        }

     
    }
}
