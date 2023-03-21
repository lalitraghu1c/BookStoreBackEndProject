using System;
using System.Collections.Generic;
using System.Text;
using BookStoreCommonLayer.Model;

namespace BookStoreRepositoryLayer.Interface
{
    public interface IFeedbackRL
    {
        public bool AddFeedback(FeedbackModel feedbackModel, int Id);
        public IEnumerable<GetAllFeedback> GetFeedback(int Book_Id);
    }
}
