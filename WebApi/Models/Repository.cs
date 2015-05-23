using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using WebApi.Controllers.api;

namespace WebApi.Models
{
    public class Repository
    {
        private ObservableCollection<Orders> orderList = new ObservableCollection<Orders>();
        private int id = 1;
        private readonly string filePath;

        public ObservableCollection<Orders> OrderList
        {
            get { return orderList; }
        }

        public Repository(string filePath1)
        {
            filePath = filePath1;
            LoadData();
            OrderList.CollectionChanged += (sender, args) =>
            {
                var output = JsonConvert.SerializeObject(orderList);
                using (var json = new StreamWriter(filePath, false))
                {
                    json.Write(output);
                }
            };
        }

        public void LoadData()
        {
            using (var r = new StreamReader(filePath))
            {
                string json = r.ReadToEnd();
                orderList = JsonConvert.DeserializeObject<ObservableCollection<Orders>>(json);
            }
        }


        public Orders AddOrder(Orders order)
        {
            order.Id = id++;
            orderList.Add(order);
            return order;
        }

        public bool DeleteOrder(int id)
        {
            var orderToDelete = orderList.First(order => order.Id == id);
            return orderToDelete != null && orderList.Remove(orderToDelete);
        }


    }
}