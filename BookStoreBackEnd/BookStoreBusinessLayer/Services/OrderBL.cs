using System;
using System.Collections.Generic;
using System.Text;
using BookStoreBusinessLayer.Interface;
using BookStoreCommonLayer.Model;
using BookStoreRepositoryLayer.Interface;

namespace BookStoreBusinessLayer.Services
{
    public class OrderBL : IOrderBL
    {
        IOrderRL iOrderRL;

        public OrderBL(IOrderRL iOrderRL)
        {
            this.iOrderRL = iOrderRL;
        }
        public OrderModel AddOrder(OrderModel addorder, long Id)
        {
            try
            {
                return this.iOrderRL.AddOrder(addorder,Id);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<GetOrderModel> GetOrders()
        {
            try
            {
                return iOrderRL.GetOrders();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool CancelOrder(int OrdersId)
        {
            try
            {
                return iOrderRL.CancelOrder(OrdersId);
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}