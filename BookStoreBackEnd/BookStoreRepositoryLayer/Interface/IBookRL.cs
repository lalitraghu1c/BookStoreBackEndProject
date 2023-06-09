﻿using System;
using System.Collections.Generic;
using System.Text;
using BookStoreCommonLayer.Model;
using Microsoft.AspNetCore.Http;

namespace BookStoreRepositoryLayer.Interface
{
    public interface IBookRL
    {
        public BookModel AddBook(BookModel bookModel);
        public BookModel UpdateBook(BookModel bookModel, long bookid);
        public bool DeleteBook(long bookid);
        public List<BookModel> GetAllBooks();
        public object GetBookDetail(long bookid);
        public bool BookImageUpdate(ImageUploadModel imageUploadModel);
    }
}
