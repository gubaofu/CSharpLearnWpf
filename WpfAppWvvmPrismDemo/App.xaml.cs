using Prism.Ioc;
using Prism.Unity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WpfAppWvvmPrismDemo.Views;

/* 使用 prism 版本：
 *  安装Nuget包，Prism.Unity 选择版本 7.2.0.1422;
 *  只需要选择安装一个 Prism.Unity 包，其他依赖包会自动安装；
 */
namespace WpfAppWvvmPrismDemo
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        protected override Window CreateShell()
        {
            //return Container.Resolve<MainWindow>();
            return Container.Resolve<RestaurantWindow>();
        }

        // RegisterTypes function is here
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<Services.ICustomerStore, Services.DbCustomerStore>();
            //containerRegistry.Register<Services.ICustomerStore, Services.DbCustomerStore>();
            // register other needed services here
        }

    }
}
