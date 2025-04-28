using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppWvvmPrismDemo.Services
{
    public interface IOrderSevice
    {
        void OrderDishes(List<string> dishes);
    }
}
