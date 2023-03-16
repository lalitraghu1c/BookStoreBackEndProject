using System;
using System.Collections.Generic;
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
    public class AdminRL : IAdminRL
    {
        private readonly string _secret;
        private readonly string _expDate;
        string connectionString;

        public AdminRL(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("BookStore"); //connect with db
            _secret = configuration.GetSection("JwtConfig").GetSection("secret").Value;
            _expDate = configuration.GetSection("JwtConfig").GetSection("expirationInMinutes").Value;
        }

        public string AdminLogin(AdminLogin adminLogin)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            using (sqlConnection)
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("SPAdminLogin", sqlConnection);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Email", adminLogin.Email);
                    cmd.Parameters.AddWithValue("@Password", adminLogin.Password);

                    sqlConnection.Open();

                    SqlDataReader rd = cmd.ExecuteReader();
                    while (rd.Read())
                    {
                        AdminCredential adminCredential = new AdminCredential();
                        adminCredential.Admin_Id = Convert.ToInt32(rd["Admin_Id"]);
                        adminCredential.Email_Id = rd["Email_Id"].ToString();

                        if (adminCredential.Email_Id != null)
                        {
                            sqlConnection.Close();
                            return GenerateSecurityToken(adminCredential.Email_Id, adminCredential.Admin_Id);
                        }
                        sqlConnection.Close();
                        return null;
                    }
                    return null;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public string GenerateSecurityToken(string email, int UserId)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Role, "Admin"),
                    new Claim(ClaimTypes.Email, email),
                    new Claim("UserId", UserId.ToString())
                }),
                Expires = DateTime.UtcNow.AddMinutes(double.Parse(_expDate)),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }

    }
}