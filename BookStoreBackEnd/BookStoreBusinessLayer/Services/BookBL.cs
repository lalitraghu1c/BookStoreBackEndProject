using System;
using System.Collections.Generic;
using System.Text;
using BookStoreBusinessLayer.Interface;
using BookStoreCommonLayer.Model;
using BookStoreRepositoryLayer.Interface;

namespace BookStoreBusinessLayer.Services
{
    public class BookBL : IBookBL
    {
        IBookRL bookrl;

        public BookBL(IBookRL bookrl)
        {
            this.bookrl = bookrl;
        }

        public BookModel AddBook(BookModel bookModel)
        {
            try
            {
                return this.bookrl.AddBook(bookModel);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public BookModel UpdateBook(BookModel bookModel, long bookid)
        {
            try
            {
                return this.bookrl.UpdateBook(bookModel, bookid);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public bool DeleteBook(long bookid)
        {
            try
            {
                return this.bookrl.DeleteBook(bookid);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}