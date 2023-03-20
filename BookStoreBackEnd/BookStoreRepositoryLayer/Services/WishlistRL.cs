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
    public class WishlistRL : IWishlistRL
    {
        string connectionString;

        public WishlistRL(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("BookStore");
        }

        public bool AddWishList(int Book_Id, int Id)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            try
            {
                using (sqlConnection)
                {
                    SqlCommand cmd = new SqlCommand("spAddToWishList", sqlConnection);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Book_Id ", Book_Id);
                    cmd.Parameters.AddWithValue("@Id ", Id);

                    sqlConnection.Open();
                    var result = cmd.ExecuteNonQuery();
                    sqlConnection.Close();

                    if (result > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                if (sqlConnection.State == ConnectionState.Open)
                {
                    sqlConnection.Close();
                }
            }
        }

        public bool DeleteWishList(int WishListId, int Id)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            try
            {
                using (sqlConnection)
                {
                    SqlCommand cmd = new SqlCommand("spDeleteWishList", sqlConnection);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@WishListId ", WishListId);
                    cmd.Parameters.AddWithValue("@Id ", Id);

                    sqlConnection.Open();
                    var result = cmd.ExecuteNonQuery();
                    sqlConnection.Close();

                    if (result > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                if (sqlConnection.State == ConnectionState.Open)
                {
                    sqlConnection.Close();
                }
            }
        }

        public IEnumerable<WishListModel> GetAllWishList(int Id)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            try
            {
                using (sqlConnection)
                {

                    List<WishListModel> wishlist = new List<WishListModel>();
                    SqlCommand cmd = new SqlCommand("spGetWishList", sqlConnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id ", Id);
                    sqlConnection.Open();
                    SqlDataReader sqlDataReader = cmd.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        wishlist.Add(new WishListModel()
                        {
                            WishListId = Convert.ToInt32(sqlDataReader["WishListId"]),
                            Book_Id = Convert.ToInt32(sqlDataReader["Book_Id"]),
                            Id = Convert.ToInt32(sqlDataReader["Id"]),
                            BookName = sqlDataReader["BookName"].ToString(),
                            OriginalPrice = Convert.ToInt32(sqlDataReader["OriginalPrice"]),
                            DiscountPrice = Convert.ToInt32(sqlDataReader["DiscountPrice"]),
                            BookImage = sqlDataReader["BookImage"].ToString(),
                        });
                    }
                    return wishlist;
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                if (sqlConnection.State == ConnectionState.Open)
                {
                    sqlConnection.Close();
                }
            }
        }

    }
}