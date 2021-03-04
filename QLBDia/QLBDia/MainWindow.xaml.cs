using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel;
using System.Drawing;
using System.Data.SqlClient;
using System.Configuration;


namespace QLBDia
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Loadbang();

            try

            {

                using (SqlConnection connection = new SqlConnection(@"Data Source=DARK\DARK;Initial Catalog=QuanLyBangDia;Integrated Security=True"))

                {

                    connection.Open();

                }

                MessageBox.Show("Bạn Đã Kết nối Thành công !", " Wellcome To !");

            }

            catch (Exception ex)

            {

                MessageBox.Show("Loi khi mo ket noi: " + ex.Message);

            }
        }
        private void Loadbang()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["connBangDia"].ConnectionString;
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "Select * From [BangDia]";
            cmd.Connection = con;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable("BangDia");
            da.Fill(dt);
            dataGridView1.ItemsSource = dt.DefaultView;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult key = MessageBox.Show(
        "Bạn có muốn thoát?",
        "Thoát?",
        MessageBoxButton.YesNo,
        MessageBoxImage.Question,
        MessageBoxResult.No);
            if (key == MessageBoxResult.No)
            {
                return;
            }
            else
            {
                Application.Current.Shutdown();
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (textBox1.Text == string.Empty)
            {
                MessageBox.Show("Bạn phải nhập Mã Băng Đĩa", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
                textBox1.Focus();
                return;
            }
            if (textBox1.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập Tên Băng Đĩa", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
                textBox2.Focus();
                return;
            }
            if (textBox3.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập Số Lượng", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
                textBox3.Focus();
                return;
            }
            
                SqlConnection con = new SqlConnection(@"Data Source=DARK\DARK;Initial Catalog=QuanLyBangDia;Integrated Security=True");
                
                SqlCommand cmd = new SqlCommand("insert into BangDia(MaBD,Tenbangdia,Soluong) values('" + textBox1.Text + "',N'" + textBox2.Text + "','" + textBox3.Text + "' )", con);
                con.Open();

            try

            {
                cmd.ExecuteNonQuery(); 

            }

            catch (Exception ex)

            {

                MessageBox.Show("Loi khi mo ket noi: " + ex.Message);

            }


            con.Close();
                Loadbang();
            
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (textBox1.Text == string.Empty)
            {
                MessageBox.Show("Bạn phải nhập Mã Băng Đĩa", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
                textBox1.Focus();
                return;
            }
            if (textBox1.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập Tên Băng Đĩa", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
                textBox2.Focus();
                return;
            }
            if (textBox3.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập Số Lượng", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
                textBox3.Focus();
                return;
            }
          
                SqlConnection con = new SqlConnection(@"Data Source=DARK\DARK;Initial Catalog=QuanLyBangDia;Integrated Security=True");
                SqlCommand cmd = new SqlCommand("delete from BangDia  where MaBD='" + textBox1.Text + "'", con);
                con.Open(); 
                cmd.ExecuteNonQuery(); 
                con.Close();
                Loadbang();
            
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {

            if (textBox1.Text == string.Empty)
            {
                MessageBox.Show("Bạn phải nhập Mã Băng Đĩa", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
                textBox1.Focus();
                return;
            }
            if (textBox1.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập Tên Băng Đĩa", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
                textBox2.Focus();
                return;
            }
            if (textBox3.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập Số Lượng", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
                textBox3.Focus();
                return;
            }
     

                SqlConnection con = new SqlConnection(@"Data Source=DARK\DARK;Initial Catalog=QuanLyBangDia;Integrated Security=True");
                SqlCommand cmd = new SqlCommand("update BangDia set MaBD='" + textBox1.Text + "',Tenbangdia='" + textBox2.Text + "',Soluong='" + textBox3.Text + "' where MaBD='" + textBox1.Text + "'", con);
                con.Open();
                cmd.ExecuteNonQuery(); 
                con.Close();
                Loadbang();
            

        }

        private void dataGridView1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid gd = (DataGrid)sender;
            DataRowView row_selected = gd.SelectedItem as DataRowView;
            if(row_selected !=null)
            {
                textBox1.Text = row_selected["MaBD"].ToString();
                textBox2.Text = row_selected["Tenbangdia"].ToString();
                textBox3.Text = row_selected["Soluong"].ToString();

            }    
        }
    }
}
