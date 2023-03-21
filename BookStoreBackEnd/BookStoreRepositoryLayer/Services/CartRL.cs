using System;
using System.Data.SqlClient;
using System.Data;
using BookStoreCommonLayer.Model;
using Microsoft.Extensions.Configuration;
using BookStoreRepositoryLayer.Interface;
using System.Collections.Generic;

namespace BookStoreRepositoryLayer.Services
{
    public class CartRL : ICartRL
    {
        string connectionString;
        IConfiguration cofiguration;
        public CartRL(IConfiguration cofiguration)
        {
            this.connectionString = cofiguration.GetConnectionString("BookStore");
            this.cofiguration = cofiguration;
        }
        public CartModel AddCart(CartModel cartModel, long UserId)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            try
            {
                using (sqlConnection)
                {
                    SqlCommand cmd = new SqlCommand("Sp_AddtoCart", sqlConnection);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Book_Id ", cartModel.Book_Id);
                    cmd.Parameters.AddWithValue("@BookCount ", cartModel.BookCount);
                    cmd.Parameters.AddWithValue("@Id ", UserId);

                    sqlConnection.Open();
                    var result = cmd.ExecuteNonQuery();
                    sqlConnection.Close();
                    if (result != null)
                    {
                        return cartModel;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public bool RemoveCart(int CartId)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            try
            {
                using (sqlConnection)
                {
                    SqlCommand cmd = new SqlCommand("Sp_DeleteCart", sqlConnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CartId ", CartId);

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
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public CartModel UpdateCart(long CartId, CartModel cartModel, long UserId)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            try
            {
                using (sqlConnection)
                {
                    SqlCommand cmd = new SqlCommand("Sp_UpdateCart", sqlConnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CartId ", CartId);
                    cmd.Parameters.AddWithValue("@BookCount ", cartModel.BookCount);

                    sqlConnection.Open();
                    var result = cmd.ExecuteNonQuery();
                    sqlConnection.Close();

                    if (result != 0)
                    {
                        return cartModel;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public IEnumerable<GetCartByUser> GetCartByUserId(CartByUser cartByUser)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            try
            {
                sqlConnection = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand("spGetCartByUserId", sqlConnection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Id", cartByUser.Id);

                sqlConnection.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                if (!rdr.HasRows)
                {
                    return null;
                }
                List<GetCartByUser> GetCartOfUserList = new List<GetCartByUser>();

                while (rdr.Read())
                {
                    GetCartByUser getCartByUser = new GetCartByUser();

                    getCartByUser.CartId = Convert.ToInt32(rdr["CartId"]);
                    getCartByUser.Id = Convert.ToInt32(rdr["Id"]);
                    getCartByUser.Book_Id = Convert.ToInt32(rdr["Book_Id"]);
                    getCartByUser.BookCount = Convert.ToInt32(rdr["BookCount"]);
                    GetCartOfUserList.Add(getCartByUser);
                }
                sqlConnection.Close();
                return GetCartOfUserList;
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

        public IEnumerable<GetCartByUser> GetCartByCartId(int Id, int CartId)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            try
            {
                sqlConnection = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand("SP_GetCartByCartId", sqlConnection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Id", Id);
                cmd.Parameters.AddWithValue("@CartId", CartId);

                sqlConnection.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                if (!rdr.HasRows)
                {
                    return null;
                }
                List<GetCartByUser> GetCartOfUserList = new List<GetCartByUser>();

                while (rdr.Read())
                {
                    GetCartByUser getCartByUser = new GetCartByUser();

                    getCartByUser.CartId = Convert.ToInt32(rdr["CartId"]);
                    getCartByUser.Id = Convert.ToInt32(rdr["Id"]);
                    getCartByUser.Book_Id = Convert.ToInt32(rdr["Book_Id"]);
                    getCartByUser.BookCount = Convert.ToInt32(rdr["BookCount"]);
                    GetCartOfUserList.Add(getCartByUser);
                }
                sqlConnection.Close();
                return GetCartOfUserList;
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
