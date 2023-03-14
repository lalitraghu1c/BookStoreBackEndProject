using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BookStoreCommonLayer.Modal;
using BookStoreCommonLayer.Model;
using BookStoreRepositoryLayer.Interface;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace BookStoreRepositoryLayer.Services
{
    public class UserRL : IUserRL
    {
        string connectionString;
        private readonly string _secret;
        private readonly string _expDate;

        public UserRL(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("BookStore");
            _secret = configuration.GetSection("JwtConfig").GetSection("secret").Value;
            _expDate = configuration.GetSection("JwtConfig").GetSection("expirationInMinutes").Value;
        }

        public UserRegistration UserRegister(UserRegistration userRegistration)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            try
            {
                using (sqlConnection)
                {
                    SqlCommand cmd = new SqlCommand("SPBookStoreUser", sqlConnection);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Full_Name", userRegistration.Full_Name);
                    cmd.Parameters.AddWithValue("@Email_Id", userRegistration.Email_Id);
                    cmd.Parameters.AddWithValue("@Password", userRegistration.Password);
                    cmd.Parameters.AddWithValue("@Mobile_Number", userRegistration.Mobile_Number);
                    sqlConnection.Open();
                    int result = cmd.ExecuteNonQuery();
                    if (result >= 1)
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
        public string LoginUser(UserLogin userLogin)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            try
            {
                using (sqlConnection)
                {
                    SqlCommand cmd = new SqlCommand("SPUserLogin", sqlConnection);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Email_Id", userLogin.Email_Id);
                    cmd.Parameters.AddWithValue("@Password", userLogin.Password);
                    sqlConnection.Open();
                    var result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        var Id = cmd.ExecuteScalar();
                        var Token = GenerateSecurityToken(userLogin.Email_Id, Id.ToString());
                        return Token;
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

        public string GenerateSecurityToken(string email, string Id)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Email, email),
                    new Claim("Id", Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddMinutes(double.Parse(_expDate)),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
        public string ForgetPassword(string Email_Id)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            using (sqlConnection)
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("SPUserForgotPassword", sqlConnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Email_Id", Email_Id);
                    sqlConnection.Open();
                    SqlDataReader rd = cmd.ExecuteReader();
                    if (rd.HasRows)
                    {
                        while (rd.Read())
                        {
                            var Id = Convert.ToInt32(rd["Id"] == DBNull.Value ? default : rd["Id"]);
                            var token = this.GenerateSecurityToken(Email_Id, Id.ToString());
                            MSMQModel msmq = new MSMQModel();
                            msmq.sendData2Queue(token);
                            return token;
                        }

                    }
                    sqlConnection.Close();
                    return null;
                }
                catch (Exception)
                {
                    throw;
                }
            }

        }
    }
}