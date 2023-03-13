using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using BookStoreCommonLayer.Modal;
using BookStoreRepositoryLayer.Interface;
using Microsoft.Extensions.Configuration;

namespace BookStoreRepositoryLayer.Services
{
    public class UserRL : IUserRL
    {
        string connectionString;
        public UserRL(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("BookStore");
        }

        public UserRegistration UserRegister(UserRegistration userRegistration)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            try
            {
                using (sqlConnection)
                {
                    SqlCommand cmd = new SqlCommand("SPBookStoreUser",sqlConnection);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Full_Name", userRegistration.Full_Name);
                    cmd.Parameters.AddWithValue("@Email_Id", userRegistration.Email_Id);
                    cmd.Parameters.AddWithValue("@Password", userRegistration.Password);
                    cmd.Parameters.AddWithValue("@Mobile_Number", userRegistration.Mobile_Number);
                    sqlConnection.Open();
                    int result = cmd.ExecuteNonQuery();
                    if(result >=1)
                    {
                        return userRegistration;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}