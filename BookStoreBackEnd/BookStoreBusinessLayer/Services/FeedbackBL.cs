using System;
using System.Collections.Generic;
using System.Text;
using BookStoreBusinessLayer.Interface;
using BookStoreCommonLayer.Model;
using BookStoreRepositoryLayer.Interface;

namespace BookStoreBusinessLayer.Services
{
    public class FeedbackBL : IFeedbackBL
    {
        IFeedbackRL iFeedbackRL;
        public FeedbackBL(IFeedbackRL iFeedbackRL)
        {
            this.iFeedbackRL = iFeedbackRL;
        }

        public bool AddFeedback(FeedbackModel feedbackModel, int Id)
        {
            try
            {
                return iFeedbackRL.AddFeedback(feedbackModel, Id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<GetAllFeedback> GetFeedback(int Book_Id)
        {
            try
            {
                return iFeedbackRL.GetFeedback(Book_Id);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
