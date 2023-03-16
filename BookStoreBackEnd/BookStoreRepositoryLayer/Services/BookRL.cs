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
                    SqlCommand cmd = new SqlCommand("SPAddNewBook", sqlConnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@BookName", bookModel.BookName);
                    cmd.Parameters.AddWithValue("@AuthorName", bookModel.AuthorName);
                    cmd.Parameters.AddWithValue("@Rating", bookModel.Rating);
                    cmd.Parameters.AddWithValue("@TotalCountRating", bookModel.TotalCountRating);
                    cmd.Parameters.AddWithValue("@DiscountPrice", bookModel.DiscountPrice);
                    cmd.Parameters.AddWithValue("@OriginalPrice", bookModel.OriginalPrice);
                    cmd.Parameters.AddWithValue("@Detail", bookModel.Deetail);
                    cmd.Parameters.AddWithValue("@BookImage", bookModel.BookImage);
                    cmd.Parameters.AddWithValue("@BookCount", bookModel.BookCount);
                    sqlConnection.Open();
                    cmd.ExecuteNonQuery();
                    sqlConnection.Close();
                    return bookModel;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public BookModel UpdateBook(BookModel bookModel, long bookid)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            try
            {
                using (sqlConnection)
                {
                    SqlCommand cmd = new SqlCommand("SPUpdateBook", sqlConnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Book_Id", bookid);
                    cmd.Parameters.AddWithValue("@BookName", bookModel.BookName);
                    cmd.Parameters.AddWithValue("@AuthorName", bookModel.AuthorName);
                    cmd.Parameters.AddWithValue("@Rating", bookModel.Rating);
                    cmd.Parameters.AddWithValue("@TotalCountRating", bookModel.TotalCountRating);
                    cmd.Parameters.AddWithValue("@DiscountPrice", bookModel.DiscountPrice);
                    cmd.Parameters.AddWithValue("@OriginalPrice", bookModel.OriginalPrice);
                    cmd.Parameters.AddWithValue("@Detail", bookModel.Deetail);
                    cmd.Parameters.AddWithValue("@BookImage", bookModel.BookImage);
                    cmd.Parameters.AddWithValue("@BookCount", bookModel.BookCount);
                    sqlConnection.Open();
                    int i = cmd.ExecuteNonQuery();
                    sqlConnection.Close();
                    if (i >= 1)
                    {
                        return bookModel;
                    }
                    return null;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public bool DeleteBook(long bookid)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("SPDeleteBook", sqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Book_Id", bookid);
            sqlConnection.Open();
            int i = cmd.ExecuteNonQuery();
            sqlConnection.Close();
            if (i >= 1)
            {
                return true;
            }
            return false;
        }
        public List<BookModel> GetAllBooks()
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            using (sqlConnection)
                try
                {
                    List<BookModel> addBook = new List<BookModel>();
                    SqlCommand cmd = new SqlCommand("SPGetAllBooks", sqlConnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    sqlConnection.Open();
                    dataAdapter.Fill(dt);
                    foreach (DataRow rd in dt.Rows)
                    {
                        addBook.Add(
                            new BookModel
                            {
                                Book_Id = Convert.ToInt32(rd["Book_Id"]),
                                BookName = rd["BookName"].ToString(),
                                AuthorName = rd["AuthorName"].ToString(),
                                Rating = rd["Rating"].ToString(),
                                TotalCountRating = Convert.ToInt32(rd["TotalCountRating"]),
                                DiscountPrice = Convert.ToInt32(rd["DiscountPrice"]),
                                OriginalPrice = Convert.ToInt32(rd["OriginalPrice"]),
                                Deetail = rd["Deetail"].ToString(),
                                BookImage = rd["BookImage"].ToString(),
                                BookCount = Convert.ToInt32(rd["BookCount"]),
                            }
                            );
                    }
                    return addBook;
                }
                catch (Exception)
                {
                    throw;
                }
        }
    }
}
