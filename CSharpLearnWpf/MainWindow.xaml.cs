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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CSharpLearnWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            WindowDraw window = new WindowDraw();
            window.Show();
        }

        private void Button3_Click(object sender, RoutedEventArgs e)
        {
            WindowAttributeConvert window = new WindowAttributeConvert();
            window.Show();
        }

        private void Button4_Click(object sender, RoutedEventArgs e)
        {
            WindowAttributeFlagExtension window = new WindowAttributeFlagExtension();
            window.Show();
        }

        private void Button5_Click(object sender, RoutedEventArgs e)
        {
            WindowEventHandler window = new WindowEventHandler();
            window.Show();
        }

        private void Button6_Click(object sender, RoutedEventArgs e)
        {
            var window = new WindowUserControl();
            window.Show();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
