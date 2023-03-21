using System;
using System.Collections.Generic;
using System.Text;
using BookStoreCommonLayer.Model;

namespace BookStoreBusinessLayer.Interface
{
    public interface IFeedbackBL
    {
        public bool AddFeedback(FeedbackModel feedbackModel, int Id);
        public IEnumerable<GetAllFeedback> GetFeedback(int Book_Id);
    }
}
