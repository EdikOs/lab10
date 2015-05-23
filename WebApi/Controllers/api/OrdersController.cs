using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using Microsoft.Ajax.Utilities;
using WebApi.Models;

namespace WebApi.Controllers.api
{
    public class OrdersController : ApiController
    {
        private static readonly Repository Repository = new Repository(HttpContext.Current.Server.MapPath("~/App_Data/orders.csv"));

        [HttpGet]
        public IEnumerable<Orders> GetAll()
        {
            return Repository.OrderList;
        }

        [HttpPost]
        public void Delete(int id)
        {
            if (!Repository.DeleteOrder(id))
                throw new HttpResponseException(HttpStatusCode.NotFound);
        }

        [HttpPost]
        public Orders Add(Orders order)
        {
            return Repository.AddOrder(order);
        }

    }
}
