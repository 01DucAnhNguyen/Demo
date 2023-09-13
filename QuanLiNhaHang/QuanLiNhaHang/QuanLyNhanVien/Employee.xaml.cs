using System.Data.SqlClient;
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
using System.Xml.Linq;
using System.Security.Cryptography;
using Microsoft.Win32;
using System.IO;
using System;
using static System.Net.Mime.MediaTypeNames;
using System.Collections.ObjectModel;
using Login.WindowView;
using System.Data.SqlTypes;
using System.Collections.Generic;
using System.Security;


namespace Login.Views
{
    /// <summary>
    /// Interaction logic for EmployeeView.xaml
    /// </summary>
    public partial class EmployeeView : UserControl
    {
        public EmployeeView()
        {
            InitializeComponent();
        }
        ObservableCollection<NhanVien> NhanViens = new ObservableCollection<NhanVien>();
        public class NhanVien
        {
            public bool IsSelected { get; set; }
            public string manv { get; set; }
            public string tennv { get; set; }
            public string tk { get; set; }
            public string trangthailv { get; set; }
            public string gt { get; set; }
            public string sdt { get; set; }
            public DateTime ngaysinh { get; set; }
            public float luong { get; set; }
            public byte[] anh { get; set; }
            public string mk { get; set; }
        }
        bool isNew = false;
        SqlConnection Conn = new SqlConnection();
        string ConnectionString = "";
        // Thực hiện đưa con trỏ chuột vào textBox đầu tiên và kiểm tra kết nối với SQl server


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cmbGioiTinh.Items.Add("Nam");
            cmbGioiTinh.Items.Add("Nữ");
            cmbTrangThaiLamViec.Items.Add("Receptionists");
            cmbTrangThaiLamViec.Items.Add("Staff");
            cmbTrangThaiLamViec.Items.Add("Chef");

            txtMaNhanVien.Focus();// Đưa con trỏ chuột đến ô TextBox đầu tiên
            // kiểm tra kết nối với SQL server
            defaultApp();
            try
            {
                ConnectionString = @"Data Source=DESKTOP-IKSFK82\SQLEXPRESS;Initial Catalog=QuanLyNhaHang;Integrated Security=True;";
                Conn.ConnectionString = ConnectionString;
                Conn.Open();
                NapDuLieuTuMayChu();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi mở kết nối" + ex.ToString());
            }
        }
        private void Key_UP(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                var element = Keyboard.FocusedElement as UIElement;
                if (element != null)
                {
                    element.MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
                }
                e.Handled = true;
            }
        }
        // Xử lí đầu vào
        //1. Mật khẩu
        public static string EncodeMD5(string InportData)
        {
            MD5 mh = MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(InportData);
            byte[] hash = mh.ComputeHash(inputBytes);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2").ToUpper());
            }
            return sb.ToString();
        }

        //2. Nạp data và xuất các trường thông tin từ sql server lên data grid
        private void NapDuLieuTuMayChu()
        {
            dgNhanVien.ItemsSource = null;
            NhanViens.Clear();
            if (Conn.State != ConnectionState.Open) return;
            SqlCommand command = new SqlCommand("SELECT * FROM tblNhanVien", Conn);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                NhanVien nv = new NhanVien();
                nv.IsSelected = false;
                nv.manv = reader.GetString(0);
                nv.tennv = reader.GetString(1);
                nv.tk = reader.GetString(2);
                nv.trangthailv = reader.GetString(3);
                nv.gt = reader.GetString(4);
                nv.sdt = reader.GetString(5);
                nv.ngaysinh = reader.GetDateTime(6);
                nv.luong = (float)reader.GetDouble(7);
                SqlBinary varbinaryData = reader.GetSqlBinary(8);
                nv.anh = varbinaryData.Value;
                nv.mk = reader.GetString(9);
                NhanViens.Add(nv);
            }
            reader.Close();
            dgNhanVien.ItemsSource = NhanViens;
            TotalNumberOfEmployees();
            //Totalnumberofmaleemployees();
        }
        // Tổng số nhân viên
        private void TotalNumberOfEmployees()
        {
            string sqlStr = "SELECT COUNT([Mã nhân viên]) FROM tblNhanVien";
            SqlCommand cmd = new SqlCommand(sqlStr, Conn);
            int employeeCount = (int)cmd.ExecuteScalar();
            txtTongNV.Text = employeeCount.ToString();
        }
        // Tổng số nhân viên nam
        //private void Totalnumberofmaleemployees()
        //{
        //    string sqlStr = "SELECT COUNT([Mã nhân viên]) FROM tblNhanVien WHERE [Giới tính] = 'Nam' ";
        //    SqlCommand cmd = new SqlCommand(sqlStr, Conn);
        //    int employeeCount = (int)cmd.ExecuteScalar();
        //    txtTongNam.Text = employeeCount.ToString();
        //}

        //private void Totalnumberofmaleemployees2()
        //{
        //    string sqlStr = "SELECT COUNT([Mã nhân viên]) FROM tblNhanVien WHERE [Giới tính] = 'Nữ' ";
        //    SqlCommand cmd = new SqlCommand(sqlStr, Conn);
        //    int employeeCount = (int)cmd.ExecuteScalar();
        //    txtTongNu.Text = employeeCount.ToString();
        //}

        //3.Chuyển định dạng ngày từ form / sang - phù hợp với SQL server
        private string toDate(string date)
        {
            string[] tokens = date.Split('/');
            Array.Reverse(tokens);
            string outputString = string.Join("-", tokens);
            return outputString;
        }
        //4.Đặt mặc định cho các trường thông tin
        private void defaultApp()
        {
            txtMaNhanVien.Text = "";
            txtTenTaiKhoan.Text = "";
            txtTenNhanVien.Text = "";
            txtMatKhau.Text = "";
            txtSoDienThoai.Text = "";
            cmbTrangThaiLamViec.SelectedItem = null;
            cmbGioiTinh.SelectedItem = null;
            txtNgaySinh.Text = null;
            txtLuong.Text = "";            pictureBoxSource.Source = null;
            pictureBox2Des.Source = null;
            passwordBox.Password = null;

            SetButtonsState(false);
        }
        private void SetButtonsState(bool Editing)
        {
            btOpen.IsEnabled = Editing;
            btSave.IsEnabled = Editing;
            btHuy.IsEnabled = Editing;
            txtMaNhanVien.IsEnabled = Editing;
            txtTenTaiKhoan.IsEnabled = Editing;
            txtTenNhanVien.IsEnabled = Editing;
            txtMatKhau.IsEnabled = Editing;
            txtSoDienThoai.IsEnabled = Editing;
            cmbTrangThaiLamViec.IsEnabled = Editing;
            cmbGioiTinh.IsEnabled = Editing;
            txtNgaySinh.IsEnabled = Editing;
            txtLuong.IsEnabled = Editing;
         
            Editing = !Editing;
            btAdd.IsEnabled = Editing;
            btDelete.IsEnabled = Editing;
            btUpdate.IsEnabled = Editing;
        }
        // Chuyển string sang float
        private float ConvertToFloat(string input)
        {
            string cleanedInput = input.Replace(",", "");
            float result = 0;
            if (float.TryParse(cleanedInput, out result))
            {
                return result;
            }
            else
            {
                return 0;
            }
        }
        // Xử lí button
        //1.Nút thêm
        private void btAdd_Click(object sender, RoutedEventArgs e)
        {
            //defaultApp();
            //SetButtonsState(true);
            //isNew = true;


            // mở cửa sổ mới và thực hiện thêm mới nhân viên
            AddEmployee addEmployee = new AddEmployee();
            addEmployee.ShowDialog();
            NapDuLieuTuMayChu();
        }
        private void btDelete_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa nhân viên đã chọn không?", "Xác nhận xóa", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                for (int i = 0; i < listCode.Count; i++)
                {
                    string sqlStr = "DELETE FROM tblNhanVien WHERE [Mã nhân viên] = N'" + listCode[i] + "'";
                    listCode.RemoveAt(i);
                    SqlCommand cmd = new SqlCommand(sqlStr, Conn);
                    cmd.ExecuteNonQuery();
                }
                NapDuLieuTuMayChu();
            }
        }
 //5.Nút chọn ảnh
        private void btOpenFile(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.png;*.jpeg)|*.png;*.jpeg|All files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == true)
            {
                string imagePath = openFileDialog.FileName;
                using (FileStream stream = new FileStream(imagePath, FileMode.Open))
                {
                    BitmapImage image = new BitmapImage();
                    image.BeginInit();
                    image.StreamSource = stream;
                    image.CacheOption = BitmapCacheOption.OnLoad;
                    image.EndInit();

                    pictureBoxSource.Source = image;
                }
            }
        }