using System;
using System.Collections.Generic;
using System.Text;
using BookStoreCommonLayer.Model;

namespace BookStoreRepositoryLayer.Interface
{
    public interface IOrderRL
    {
        public OrderModel AddOrder(OrderModel orderModel, long Id);
        public List<GetOrderModel> GetOrders();
        public bool CancelOrder(int OrdersId);
    }
}
