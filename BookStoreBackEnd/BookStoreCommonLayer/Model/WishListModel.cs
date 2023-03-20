using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreCommonLayer.Model
{
    public class WishListModel
    {
        public long WishListId { get; set; }
        public long Book_Id { get; set; }
        public long Id { get; set; }
        public string BookName { get; set; }
        public string AuthorName { get; set; }
        public int OriginalPrice { get; set; }
        public int DiscountPrice { get; set; }
        public string BookImage { get; set; }
    }
}

