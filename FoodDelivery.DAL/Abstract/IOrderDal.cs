﻿using FoodDelivery.DAL.Abstract.IRepository;
using FoodDelivery.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDelivery.DAL.Abstract
{
    public interface IOrderDal : IRepository<Order>
    {
        Order GetActiveOrderByUser(int id);

        ICollection<Order> GetOrdersByUserID(int id);
    }
}
