using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreCommonLayer.Model
{
    public class BookModel
    {
        public int Book_Id { get; set; }
        public string BookName { get; set; }
        public string AuthorName { get; set; }
        public string Rating { get; set; }
        public int TotalCountRating { get; set; }
        public int DiscountPrice { get; set; }
        public int OriginalPrice { get; set; }
        public string Detail { get; set; }
        public string BookImage { get; set; }
        public int BookCount { get; set; }

    }
}
