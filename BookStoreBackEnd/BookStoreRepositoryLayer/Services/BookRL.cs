using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using BookStoreCommonLayer.Model;
using Microsoft.Extensions.Configuration;
using BookStoreRepositoryLayer.Interface;

namespace BookStoreRepositoryLayer.Services
{
    public class BookRL : IBookRL
    {
        string connectionString;
        private readonly string _secret;
        private readonly string _expDate;

        public BookRL(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("BookStore");
            _secret = configuration.GetSection("JwtConfig").GetSection("secret").Value;
            _expDate = configuration.GetSection("JwtConfig").GetSection("expirationInMinutes").Value;
        }
        public BookModel AddBook(BookModel bookModel)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            try
            {
                using (sqlConnection)
                {
                    SqlCommand com = new SqlCommand("SPAddNewBook", sqlConnection);
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.AddWithValue("@BookName", bookModel.BookName);
                    com.Parameters.AddWithValue("@AuthorName", bookModel.AuthorName);
                    com.Parameters.AddWithValue("@Rating", bookModel.Rating);
                    com.Parameters.AddWithValue("@TotalCountRating", bookModel.TotalCountRating);
                    com.Parameters.AddWithValue("@DiscountPrice", bookModel.DiscountPrice);
                    com.Parameters.AddWithValue("@OriginalPrice", bookModel.OriginalPrice);
                    com.Parameters.AddWithValue("@Detail", bookModel.Detail);
                    com.Parameters.AddWithValue("@BookImage", bookModel.BookImage);
                    com.Parameters.AddWithValue("@BookCount", bookModel.BookCount);
                    sqlConnection.Open();
                    com.ExecuteNonQuery();
                    sqlConnection.Close();
                    return bookModel;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
