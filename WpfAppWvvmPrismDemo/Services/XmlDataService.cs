using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using WpfAppWvvmPrismDemo.Models;

namespace WpfAppWvvmPrismDemo.Services
{
    class XmlDataService : IDataService
    {
        public List<Dish> GetAllDishes()
        {
            List<Dish> dishList = new List<Dish>();
            string xmlFileName = System.IO.Path.Combine(Environment.CurrentDirectory, @"Data\Dishes.xml");
            XDocument xDoc = XDocument.Load(xmlFileName);
            var dishes = xDoc.Descendants("Dish");
            foreach (var d in dishes)
            {
                Dish dish = new Dish();
                dish.Name = d.Element("Name").Value;
                dish.Category = d.Element("Category").Value;
                dish.Comment = d.Element("Comment").Value;
                dish.Score = double.Parse( d.Element("Score").Value);
                dishList.Add(dish);
            }
            return dishList;
        }

        public Restaurant GetRestaurant()
        {
            Restaurant restaurant = new Restaurant();
            restaurant.Name = "Crazy大象";
            restaurant.Address = "北京东路108号";
            restaurant.PhoneNumber = "8888-8888";

            return restaurant;
        }
    }
}
