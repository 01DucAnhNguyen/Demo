using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Shapes;

namespace QuanLiNhaHang.QuanLyNhanVien
{
    /// <summary>
    /// Interaction logic for Emloyee.xaml
    /// </summary>
    public partial class Emloyee : Window
    {
        public Emloyee()
        {
            InitializeComponent();
        }

        private void tbnSearch_GotFocus(object sender, RoutedEventArgs e) {}

        private void btSearch(object sender, RoutedEventArgs e) { }

        private void btUpdate_Click(object sender, RoutedEventArgs e) { }

        private void btAdd_Click(object sender, RoutedEventArgs e) { }

        private void btDelete_Click(object sender, RoutedEventArgs e) { }

        private void btThongKe_Click(object sender, RoutedEventArgs e) { }

        private void btSave_Click(object sender, RoutedEventArgs e) { }

        private void btHuy_Click(object sender, RoutedEventArgs e) { }

        //5.Nút chọn ảnh
        private void btOpenFile(object sender, RoutedEventArgs e)
        {
            //OpenFileDialog openFileDialog = new OpenFileDialog();
            //openFileDialog.Filter = "Image files (*.png;*.jpeg)|*.png;*.jpeg|All files (*.*)|*.*";

            //if (openFileDialog.ShowDialog() == true)
            //{
            //    string imagePath = openFileDialog.FileName;
            //    using (FileStream stream = new FileStream(imagePath, FileMode.Open))
            //    {
            //        BitmapImage image = new BitmapImage();
            //        image.BeginInit();
            //        image.StreamSource = stream;
            //        image.CacheOption = BitmapCacheOption.OnLoad;
            //        image.EndInit();

            //        pictureBoxSource.Source = image;
            //    }
            //}
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

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            // Sao chép giá trị của PasswordBox vào TextBox
            txtMatKhau.Text = passwordBox.Password;
            // Ẩn PasswordBox
            passwordBox.IsHitTestVisible = false;
            passwordBox.Visibility = Visibility.Collapsed;
            // Hiển thị TextBox
            txtMatKhau.IsHitTestVisible = true;
            txtMatKhau.Visibility = Visibility.Visible;
        }
        // function 2
        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            // Sao chép giá trị của TextBox vào PasswordBox
            passwordBox.Password = txtMatKhau.Text;
            // Ẩn TextBox
            txtMatKhau.IsHitTestVisible = false;
            txtMatKhau.Visibility = Visibility.Collapsed;
            // Hiển thị PasswordBox
            passwordBox.IsHitTestVisible = true;
            passwordBox.Visibility = Visibility.Visible;
        }


        private void txtLuong_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtLuong.Text.Length == 0) return;

            long num = 0;
            bool success = long.TryParse(txtLuong.Text.Replace(",", ""), out num);

            if (success)
            {
                txtLuong.Text = string.Format("{0:#,##0}", num);
                txtLuong.SelectionStart = txtLuong.Text.Length;
                txtLuong.IsEnabled = true;
            }
            else
            {
                txtLuong.Text = txtLuong.Text.Substring(0, txtLuong.Text.Length - 1);
                txtLuong.SelectionStart = txtLuong.Text.Length;
                txtLuong.IsEnabled = true;
            }
        }

        private void txtMaNhanVien_KeyUp(object sender, KeyEventArgs e)
        {
            Key_UP(sender, e);
        }
        private void txtTenTaiKhoan_KeyUp(object sender, KeyEventArgs e)
        {
            Key_UP(sender, e);
        }
        private void txtTenNhanVien_KeyUp(object sender, KeyEventArgs e)
        {
            Key_UP(sender, e);
        }
        private void txtMatKhau_KeyUp(object sender, KeyEventArgs e)
        {
            Key_UP(sender, e);
        }
        private void cmbGioiTinh_KeyUp(object sender, KeyEventArgs e)
        {
            Key_UP(sender, e);
        }
        private void txtNgaySinh_KeyUp(object sender, KeyEventArgs e)
        {
            Key_UP(sender, e);
        }
        private void txtDiaChi_KeyUp(object sender, KeyEventArgs e)
        {
            Key_UP(sender, e);
        }
        private void txtSoDienThoai_KeyUp(object sender, KeyEventArgs e)
        {
            Key_UP(sender, e);
        }
        private void txtSoCMND_KeyUp(object sender, KeyEventArgs e)
        {
            Key_UP(sender, e);
        }
        private void txtNoiCapCMND_KeyUp(object sender, KeyEventArgs e)
        {
            Key_UP(sender, e);
        }
        private void txtLuong_KeyUp(object sender, KeyEventArgs e)
        {
            Key_UP(sender, e);
        }
    }

   
}
