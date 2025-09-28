using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
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
    /// WindowAttributeConvert.xaml 的交互逻辑
    /// </summary>
    public partial class WindowAttributeConvert : Window
    {
        public WindowAttributeConvert()
        {
            InitializeComponent();
        }

        private void Btn1_Click(object sender, RoutedEventArgs e)
        {
            Human h = this.FindResource("human") as Human;
            if (h == null)
            {
                throw new Exception("FindResource_human, error}");
            }

            MessageBox.Show($"{h.Name}, child is {h.Child.Name}");
        }

        private void Btn2_Click(object sender, RoutedEventArgs e)
        {

        }
    }

    // 附加特性 Attribute
    // TypeConverter 在wpf中实现自动类型转换，自动调用对应类的转换函数
    //[TypeConverterAttribute(typeof(NameToHumanTypeConvert))]
    [TypeConverter(typeof(NameToHumanTypeConvert))]
    public class Human
    {
        public string Name { get; set; }
        public Human Child { get; set; }

    }

    public class NameToHumanTypeConvert:TypeConverter
    {
        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            string name = value.ToString();
            Human h = new Human();
            h.Name = name;
            return h;
        }
    }
}
