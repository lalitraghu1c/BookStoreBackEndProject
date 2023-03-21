using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreCommonLayer.Model
{
    public class GetAllFeedback
    {
        public int Id { get; set; }
        public int FeedbackId { get; set; }
        public string Ratings { get; set; }
        public string Comment { get; set; }
        public int Book_Id { get; set; }
        public string Full_Name { get; set; }
    }
}
