using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfAppWvvmPrismDemo.Models;

namespace WpfAppWvvmPrismDemo.ViewModels
{
    class DishItemViewModel:Prism.Mvvm.BindableBase
    {
        public Dish Dish { get; set; }
        private bool _isSelected;

        public DishItemViewModel(Dish dish)
        {
            Dish = dish;
        }

        public bool IsSelected
        {
            get { return _isSelected; }
            set { SetProperty(ref _isSelected, value); }
        }



    }
}
