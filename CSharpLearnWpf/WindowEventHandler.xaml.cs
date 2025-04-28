using System;
using System.Collections.Generic;
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

namespace CSharpLearnWpf
{
    /// <summary>
    /// Interaction logic for WindowEventHandler.xaml
    /// </summary>
    public partial class WindowEventHandler : Window
    {
        public WindowEventHandler()
        {
            InitializeComponent();

            // 手动 订阅事件
            // 多个订阅处理，顺序执行
            this.btn2.Click += new RoutedEventHandler(Btn2_Click);
            this.btn2.Click += Btn2_Click_1;
        }
        
        private void Btn1_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Btn1_Click");
        }

        private void Btn2_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Btn2_Click");
        }


        private void Btn2_Click_1(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Btn2_Click_1");
        }
    }
}
