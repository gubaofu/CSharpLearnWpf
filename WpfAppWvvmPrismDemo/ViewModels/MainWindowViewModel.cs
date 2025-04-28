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
    class MainWindowViewModel:Prism.Mvvm.BindableBase
    {
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
