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

namespace WpfControlLibraryGbf
{
    /// <summary>
    /// Interaction logic for SalaryCalculator.xaml
    /// </summary>
    public partial class SalaryCalculator : UserControl
    {
        public SalaryCalculator()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int value1 = 0, value2 = 0;

            int.TryParse(this.txt1.Text, out value1);
            int.TryParse(this.txt2.Text, out value2);

            this.txt3.Text = (value1 + value2).ToString();
        }
    }
}
