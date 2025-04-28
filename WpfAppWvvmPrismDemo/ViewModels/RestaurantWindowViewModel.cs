using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfAppWvvmPrismDemo.Models;
using WpfAppWvvmPrismDemo.Services;

namespace WpfAppWvvmPrismDemo.ViewModels
{
    class RestaurantWindowViewModel : Prism.Mvvm.BindableBase
    {
        public RestaurantWindowViewModel(Services.ICustomerStore customerStore)
        {
            LoadRestaurant();
            LoadDishMenu();

            OrderCommand = new DelegateCommand(OrderDishes);
            SelectMenuItemCommand = new DelegateCommand(SelectMenuItem);
        }

        private Restaurant _restaurant;

        public Restaurant Restaurant
        {
            get { return _restaurant; }
            set { SetProperty(ref _restaurant, value); }
        }
        
        private int _count;

        public int Count
        {
            get { return _count; }
            set { SetProperty(ref _count, value); }
        }


        private List<DishItemViewModel> _dishMenu;

        public List<DishItemViewModel> DishMenu
        {
            get { return _dishMenu; }
            set { SetProperty(ref _dishMenu, value); }
        }


        public DelegateCommand OrderCommand { get; set; }
        public DelegateCommand SelectMenuItemCommand { get; set; }

        private void LoadRestaurant()
        {
            IDataService service = new XmlDataService();
            this.Restaurant = service.GetRestaurant();
        }

        private void LoadDishMenu()
        {
            IDataService service = new XmlDataService();
            var dishes = service.GetAllDishes();

            List<DishItemViewModel> dishMenuList = new List<DishItemViewModel>();
            foreach (var dish in dishes)
            {
                DishItemViewModel item = new DishItemViewModel(dish);
                dishMenuList.Add(item);
            }
            DishMenu = dishMenuList;
        }

        private void OrderDishes()
        {
            List<string> selectedDishes = DishMenu.Where(i => i.IsSelected == true).Select(i => i.Dish.Name).ToList();

            IOrderSevice service = new Services.MockOrderService();
            service.OrderDishes(selectedDishes);
            MessageBox.Show("订餐成功");
        }

        private void SelectMenuItem()
        {
            Count = DishMenu.Count(i => i.IsSelected == true);
        }
    }
}
