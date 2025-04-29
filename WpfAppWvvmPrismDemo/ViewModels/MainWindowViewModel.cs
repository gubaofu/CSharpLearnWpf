using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfAppWvvmPrismDemo.Views;

namespace WpfAppWvvmPrismDemo.ViewModels
{
    /* 其中有一个Customers属性绑定到用户界面中的ListView上;
     * 还有一个SelectedCustomer绑定到ListView中的当前选择项上。
     * 
     * 实现ICommand接口的CommandLoad对象，它有一个Execute方法，会在每当用户点击按钮时调用。
     * Prism使用了DelegateCommand类实现了ICommand接口，它允许传递委托来处理实现ICommand接口。
     * 在CommandLoad这种情况中，CommandLoadExecute函数会作为委托传入，于是现在每当WPF绑定系统尝试执行ICommand.Execute时，CommandLoadExecute都会被调用。
     */

    /* 使用ViewModelLocator
    现在有一个视图和一个视图模型，但它们是如何链接在一起的？该功能开箱即用，因为Prism有一个ViewModelLocator，它使用约定来确定视图模型的正确类，用其依赖关系实例化它，并将其附加到视图的DataContext。

    默认约定是将所有视图放在Views文件夹中，将视图模型放在ViewModels文件夹中。

    WpfApp1.Views.MainWindow => WpfApp1.ViewModels.MainWindowViewModel
    WpfApp1.Views.OtherView => WpfApp1.ViewModels.OtherViewModel
    这是可配置的，并且可以添加不同的解析逻辑。

    为此，视图和视图模型必须正确地位于其正确的名称空间中。

        MainWindow.xaml通过prism:ViewModelLocator.AutoWireViewModel="True"属性自动绑定了MainWindowViewModel。
             */
    class MainWindowViewModel :Prism.Mvvm.BindableBase
    {
        /* MainWindowViewModel依赖于ICustomerStore接口，因此该接口必须在App.RegisterTypes中注册，以便其实现可以由依赖容器处理。
         */
        public MainWindowViewModel(Services.ICustomerStore customerStore)
        {
            _customerStore = customerStore; // 使用技术：依赖注入

            //this.AddCommand = new DelegateCommand(new Action(this.Add));
            // 简化
            this.AddCommand = new DelegateCommand(this.Add);
            OpenRestCommand = new DelegateCommand(OpenRestaurant);
        }

        // 3个数据属性 ====================
        private int _input1;

        public int Input1
        {
            get { return _input1; }
            set
            {
                SetProperty(ref _input1, value);
            }
        }

        private int _input2;

        public int Input2
        {
            get { return _input2; }
            set
            {
                SetProperty(ref _input2, value);
            }
        }

        private int _result;

        public int Result
        {
            get { return _result; }
            set
            {
                SetProperty(ref _result, value);
            }
        }

        
        private Services.ICustomerStore _customerStore = null;

        public ObservableCollection<string> Customers { get; private set; } = new ObservableCollection<string>();


        private string _selectedCustomer = null;
        public string SelectedCustomer
        {
            get => _selectedCustomer;
            set
            {
                if (SetProperty<string>(ref _selectedCustomer, value))
                {
                    Debug.WriteLine(_selectedCustomer ?? "no customer selected");
                }
            }
        }


        // 2个命令属性 =================
        public DelegateCommand AddCommand { get; }
        private void Add()
        {
            // 执行响应事件的具体操作，也可以调用Model里的功能来完成操作；
            this.Result = this.Input1 + this.Input2;
        }

        public DelegateCommand OpenRestCommand { get; }
        private void OpenRestaurant()
        {
            var window = new RestaurantWindow();
            window.Show();
        }

        private DelegateCommand _commandLoad = null;
        public DelegateCommand CommandLoad => _commandLoad ?? (_commandLoad = new DelegateCommand(CommandLoadExecute));


        private void CommandLoadExecute()
        {
            Customers.Clear();
            List<string> list = _customerStore.GetAll();
            foreach (string item in list) Customers.Add(item);
        }
    }
}
