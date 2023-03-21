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
    public class OrderRL : IOrderRL
    {
        string connectionString;
        IConfiguration cofiguration;
        public OrderRL(IConfiguration cofiguration)
        {
            this.connectionString = cofiguration.GetConnectionString("BookStore");
            this.cofiguration = cofiguration;
        }
        public OrderModel AddOrder(OrderModel orderModel, long Id)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            try
            {
                using (sqlConnection)
                {
                    SqlCommand cmd = new SqlCommand("SP_AddOrder", sqlConnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    sqlConnection.Open();
                    cmd.Parameters.AddWithValue("@Id", Id);
                    cmd.Parameters.AddWithValue("@AddressId", orderModel.AddressId);
                    cmd.Parameters.AddWithValue("@Book_Id", orderModel.Book_Id);
                    cmd.Parameters.AddWithValue("@TotalQuantity", orderModel.TotalQuantity);
                    var result = cmd.ExecuteNonQuery();
                    if (result != 0)
                    {
                        return orderModel;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally { sqlConnection.Close(); }
        }
        public List<GetOrderModel> GetOrders()
        {
            List<GetOrderModel> getAllOrderModel = new List<GetOrderModel>();
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("SP_GetOrder", sqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;

            sqlConnection.Open();
            SqlDataReader sqlDataReader = cmd.ExecuteReader();
            while (sqlDataReader.Read())
            {
                GetOrderModel getOrderModel = new GetOrderModel();
                getOrderModel.OrdersId = Convert.ToInt32(sqlDataReader["OrdersId"]);
                getOrderModel.Id = Convert.ToInt32(sqlDataReader["Id"]);
                getOrderModel.Book_Id = Convert.ToInt32(sqlDataReader["Book_Id"]);
                getOrderModel.AddressId = Convert.ToInt32(sqlDataReader["AddressId"]);
                getOrderModel.TotalPrice = Convert.ToInt32(sqlDataReader["TotalPrice"]);
                getOrderModel.OrderDate = sqlDataReader["OrderDate"].ToString();

                getAllOrderModel.Add(getOrderModel);
            }
            sqlConnection.Close();
            return getAllOrderModel;
        }
        public bool CancelOrder(int OrdersId)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            try
            {
                SqlCommand cmd = new SqlCommand("SPCancelOrder", sqlConnection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                sqlConnection.Open();

                cmd.Parameters.AddWithValue("@OrdersId", OrdersId);

                int result = cmd.ExecuteNonQuery();
                if (result > 0)
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
            finally { sqlConnection.Close(); }
        }
    }
}