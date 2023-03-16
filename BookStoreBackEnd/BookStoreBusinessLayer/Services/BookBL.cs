﻿using System;
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
    }
}