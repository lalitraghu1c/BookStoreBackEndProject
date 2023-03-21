using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreCommonLayer.Model
{
    public class FeedbackModel
    {
        public string Ratings { get; set; }
        public string Comment { get; set; }
        public int Book_Id { get; set; }
    }
}

