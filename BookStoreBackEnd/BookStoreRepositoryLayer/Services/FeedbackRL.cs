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
    public class FeedbackRL : IFeedbackRL
    {
        string connectionString;
        public FeedbackRL(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("BookStore");
        }

        public bool AddFeedback(FeedbackModel feedbackModel, int Id)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            using (sqlConnection)
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("SPAddFeedback", sqlConnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Ratings", feedbackModel.Ratings);
                    cmd.Parameters.AddWithValue("@Comment", feedbackModel.Comment);
                    cmd.Parameters.AddWithValue("@Id", Id);
                    cmd.Parameters.AddWithValue("@Book_Id", feedbackModel.Book_Id);
                    sqlConnection.Open();
                    int result = cmd.ExecuteNonQuery();
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

        public IEnumerable<GetAllFeedback> GetFeedback(int Book_Id)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            using (sqlConnection)
            {
                try
                {
                    List<GetAllFeedback> getAllFeedbacks = new List<GetAllFeedback>();
                    SqlCommand cmd = new SqlCommand("SPGetFeedback", sqlConnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Book_Id ", Book_Id);

                    sqlConnection.Open();

                    SqlDataReader sqlDataReader = cmd.ExecuteReader();

                    while (sqlDataReader.Read())
                    {
                        getAllFeedbacks.Add(new GetAllFeedback()
                        {
                            FeedbackId = Convert.ToInt32(sqlDataReader["FeedbackId"]),
                            Ratings = sqlDataReader["Ratings"].ToString(),
                            Comment = sqlDataReader["Comment"].ToString(),
                            Book_Id = Convert.ToInt32(sqlDataReader["Book_Id"]),
                            Id = Convert.ToInt32(sqlDataReader["Id"]),
                            Full_Name = sqlDataReader["Full_Name"].ToString(),
                        });
                    }
                    return getAllFeedbacks;
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
    }
}