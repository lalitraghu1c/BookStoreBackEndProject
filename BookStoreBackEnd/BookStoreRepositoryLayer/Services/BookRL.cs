using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using BookStoreCommonLayer.Model;
using Microsoft.Extensions.Configuration;
using BookStoreRepositoryLayer.Interface;
using DocumentFormat.OpenXml.Math;
using static System.Net.Mime.MediaTypeNames;
using Microsoft.AspNetCore.Http;
using System.Net;
using CloudinaryDotNet;

namespace BookStoreRepositoryLayer.Services
{
    public class BookRL : IBookRL
    {
        string connectionString;
        IConfiguration configuration; //image configuration

        public BookRL(IConfiguration configuration)
        {
            this.connectionString = configuration.GetConnectionString("BookStore");
            this.configuration = configuration;
        }
        public BookModel AddBook(BookModel bookModel)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            try
            {
                using (sqlConnection)
                {
                    SqlCommand cmd = new SqlCommand("SPAddBook", sqlConnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@BookName", bookModel.BookName);
                    cmd.Parameters.AddWithValue("@AuthorName", bookModel.AuthorName);
                    cmd.Parameters.AddWithValue("@Rating", bookModel.Rating);
                    cmd.Parameters.AddWithValue("@TotalCountRating", bookModel.TotalCountRating);
                    cmd.Parameters.AddWithValue("@DiscountPrice", bookModel.DiscountPrice);
                    cmd.Parameters.AddWithValue("@OriginalPrice", bookModel.OriginalPrice);
                    cmd.Parameters.AddWithValue("@Detail", bookModel.Detail);
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
                    SqlCommand cmd = new SqlCommand("SPUpdate", sqlConnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Book_Id", bookid);
                    cmd.Parameters.AddWithValue("@BookName", bookModel.BookName);
                    cmd.Parameters.AddWithValue("@AuthorName", bookModel.AuthorName);
                    cmd.Parameters.AddWithValue("@Rating", bookModel.Rating);
                    cmd.Parameters.AddWithValue("@TotalCountRating", bookModel.TotalCountRating);
                    cmd.Parameters.AddWithValue("@DiscountPrice", bookModel.DiscountPrice);
                    cmd.Parameters.AddWithValue("@OriginalPrice", bookModel.OriginalPrice);
                    cmd.Parameters.AddWithValue("@Detail", bookModel.Detail);
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
                                Detail = rd["Detail"].ToString(),
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
        public object GetBookDetail(long bookid)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("SPGetBookByBook_Id", sqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Book_Id", bookid);
            sqlConnection.Open();
            BookModel bookmodel = new BookModel();
            SqlDataReader rd = cmd.ExecuteReader();
            if (rd.HasRows)
            {
                while (rd.Read())
                {
                    bookmodel.Book_Id = Convert.ToInt32(rd["Book_Id"]);
                    bookmodel.BookName = rd["BookName"].ToString();
                    bookmodel.AuthorName = rd["AuthorName"].ToString();
                    bookmodel.Rating = rd["Rating"].ToString();
                    bookmodel.TotalCountRating = Convert.ToInt32(rd["TotalCountRating"]);
                    bookmodel.DiscountPrice = Convert.ToInt32(rd["DiscountPrice"]);
                    bookmodel.OriginalPrice = Convert.ToInt32(rd["OriginalPrice"]);
                    bookmodel.Detail = rd["Detail"].ToString();
                    bookmodel.BookImage = rd["BookImage"].ToString();
                    bookmodel.BookCount = Convert.ToInt32(rd["BookCount"]);
                }
                return bookmodel;
            }
            return null;
        }
        public bool BookImageUpdate(ImageUploadModel imageUploadModel)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            using (sqlConnection)
            {
                try
                {
                    string uploadImagePath = ImageUploadOnCloudinary(imageUploadModel.ImgFile);
                    SqlCommand cmd = new SqlCommand("SPBookImageUpload", sqlConnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Book_Id", imageUploadModel.Book_Id);
                    cmd.Parameters.AddWithValue("@BookImage", uploadImagePath);
                    sqlConnection.Open();
                    var result = cmd.ExecuteNonQuery();
                    if (result >= 1)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    sqlConnection.Close();
                }
            }
        }
        public string ImageUploadOnCloudinary(IFormFile imageFile)
        {
            try
            {
                Account account = new Account(
                    this.configuration["CloudinarySettings:CloudName"],
                    this.configuration["CloudinarySettings:APIKey"],
                    this.configuration["CloudinarySettings:APISecret"]
                    );
                Cloudinary cloudinary = new Cloudinary(account);
                var uploadParams = new CloudinaryDotNet.Actions.ImageUploadParams()
                {
                    File = new FileDescription(imageFile.FileName, imageFile.OpenReadStream()),
                };
                var uploadResult = cloudinary.Upload(uploadParams);
                string imagePath = uploadResult.Url.ToString();
                return imagePath;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}