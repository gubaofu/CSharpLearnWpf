using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppWvvmPrismDemo.Services
{
    interface ICustomerStore
    {
        List<string> GetAll();

    }
}
