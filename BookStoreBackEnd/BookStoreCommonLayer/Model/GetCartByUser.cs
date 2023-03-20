using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreCommonLayer.Model
{
    public class GetCartByUser
    {
        public int CartId { get; set; }
        public int Id { get; set; }
        public int Book_Id { get; set; }
        public int Book_Quantity { get; set; }
    }
}
