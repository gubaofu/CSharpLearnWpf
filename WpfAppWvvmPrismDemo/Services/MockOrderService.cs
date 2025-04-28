using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppWvvmPrismDemo.Services
{
    public class MockOrderService : IOrderSevice
    {
        public void OrderDishes(List<string> dishes)
        {
            System.IO.File.WriteAllLines(@"order.txt", dishes.ToArray());
        }
    }
}
