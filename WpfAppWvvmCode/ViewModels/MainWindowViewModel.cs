using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfAppWvvmCode.Commands;

namespace WpfAppWvvmCode.ViewModels
{
    class MainWindowViewModel:NotificationObject
    {
        // 3个数据属性 ====================
        private int input1;

        public int Input1
        {
            get { return input1; }
            set
            {
                input1 = value;
                this.RaisePropertyChanged("Input1");
            }
        }

        private int input2;

        public int Input2
        {
            get { return input2; }
            set
            {
                input2 = value;
                this.RaisePropertyChanged("Input2");
            }
        }

        private int result;

        public int Result
        {
            get { return result; }
            set
            {
                result = value;
                this.RaisePropertyChanged("Result");
            }
        }

        // 2个命令属性 =================
        public DelegateCommand AddCommand { get; set; }
        private void Add(object parameter)
        {
            // 执行响应事件的具体操作，也可以调用Model里的功能来完成操作；
            this.Result = this.Input1 + this.Input2;
        }

        public MainWindowViewModel()
        {
            this.AddCommand = new DelegateCommand();
            this.AddCommand.ExcuteAction = new Action<object>(this.Add); 
            //this.AddCommand.ExcuteAction = this.Add;
        }
    }
}
