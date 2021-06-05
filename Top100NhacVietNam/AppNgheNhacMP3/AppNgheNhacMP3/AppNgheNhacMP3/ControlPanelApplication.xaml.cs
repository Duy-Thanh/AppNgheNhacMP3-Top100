using AppNgheNhacMP3;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace AppNgheNhacMP3Top100NhacVietNam
{
    /// <summary>
    /// Interaction logic for ToolBox.xaml
    /// </summary>
    public partial class ToolBox : Window
    {
        public ToolBox()
        {
            this.Title = "Bảng điều khiển ứng dụng AppNgheNhacMP3Top100NhacVietNam - Phiên bản: " + Application.ResourceAssembly.ImageRuntimeVersion;
            this.textVersion.Text = "Phiên bản ứng dụng: " + Application.ResourceAssembly.ImageRuntimeVersion;
            InitializeComponent();
        }

        private void btnShow_Click(object sender, RoutedEventArgs e)
        {
            var main = new MainWindow();
            main.Show();
            this.Close();
        }

        private void btnExitApp_Click(object sender, RoutedEventArgs e)
        {
            Process.GetProcessesByName("AppNgheNhacMP3Top100NhacVietNam.exe")[0].Close();
        }

        private void btnCheckUpdate_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.MessageBox.Show("Ứng dụng này đã ngừng hỗ trợ kể từ ngày 10/02/2019. Chúng tôi rất tiêc về việc này. Cảm ơn bạn trong thừi gian vừa qua đã tin tưởng, ủng hộ các sản phẩm của chúng tôi. Bạn vẫn có thể tiếp tục sử dụng ứng dụng này hoàn toàn bình thường ngay cả khi ứng dụng đã hết thời gian hỗ trợ, nhưng bạn sẽ không nhận được các phiên bản cập nhật mới hơn của ứng dụng này nữa. Hi vọng rằng bạn vẫn sẽ tiếp tục tin tưởng và ủng hộ các sản phẩm của chúng tôi. Hãy tiếp tục theo dõi vả sử dụng nhiều ứng dụng khác của chúng tôi trong tương lai nhé.", "Thông báo", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
            return;
        }
    }
}
