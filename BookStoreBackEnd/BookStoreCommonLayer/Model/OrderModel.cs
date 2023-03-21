using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreCommonLayer.Model
{
    public class OrderModel
    {
        public long Id { get; set; }
        public int AddressId { get; set; }
        public long Book_Id { get; set; }
        public int TotalQuantity { get; set; }
    }
}
