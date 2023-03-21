using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreCommonLayer.Model
{
    public class GetOrderModel
    {
        public int OrdersId { get; set; }
        public long Id { get; set; }
        public long Book_Id { get; set; }
        public int AddressId { get; set; }
        public int TotalPrice { get; set; }
        public string OrderDate { get; set; }
    }
}
