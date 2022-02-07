// <copyright file="BookStoreUserRL.cs" company="Book Store Application">
//     BookStoreUserRL copyright tag.
// </copyright>

namespace RepositoryLayer.Services
{
    using Common.UserModel;
    using CommonLayer.UserModel;
    using Microsoft.Extensions.Configuration;
    using Microsoft.IdentityModel.Tokens;
    using Repository.ExceptionHandling;
    using RepositoryLayer.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.IdentityModel.Tokens.Jwt;
    using System.Linq;
    using System.Net;
    using System.Security.Claims;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Repository layer
    /// </summary>
    /// <seealso cref="RepositoryLayer.Interfaces.IBookStoreUserRL" />
    public class BookStoreUserRL : IBookStoreUserRL
    {
        public readonly IConfiguration config;

        public BookStoreUserRL(IConfiguration config)
        {
            this.config = config;
        }

        public static string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=BookStoreDataBase;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        SqlConnection connection = new SqlConnection(connectionString);

        /// <summary>
        /// JWTs the token generate.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        /// <exception cref="Repository.ExceptionHandling.CustomException">Cannot generate json web token since claims not added</exception>
        public string JwtTokenGenerate(string email)
        {
            try
            {
                var loginTokenHandler = new JwtSecurityTokenHandler();
                var loginTokenKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(this.config[("Jwt:key")]));
                var loginTokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim(ClaimTypes.Email, email),
                    }),
                    Expires = DateTime.UtcNow.AddMinutes(15),
                    SigningCredentials = new SigningCredentials(loginTokenKey, SecurityAlgorithms.HmacSha256Signature)
                };
                var token = loginTokenHandler.CreateToken(loginTokenDescriptor);
                return loginTokenHandler.WriteToken(token);
            }
            catch (Exception ex)
            {
                throw new CustomException(HttpStatusCode.BadRequest, "Cannot generate json web token since claims not added");
            }
        }

        /// <summary>
        /// Users the signup.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public SignUpResponse UserSignup(SignUpModel model)
        {
            try
            {
                using (connection)
                {
                    SqlCommand command = new SqlCommand("spAddUser", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@FullName", model.FullName);
                    command.Parameters.AddWithValue("@EmailID", model.EmailId);
                    command.Parameters.AddWithValue("@Password", model.Password);
                    command.Parameters.AddWithValue("@MobileNumber", model.MobileNumber);
                    this.connection.Open();
                    int result = command.ExecuteNonQuery();
                    this.connection.Close();
                    if (result >= 0)
                    {
                        SignUpResponse response = new()
                        {
                            FullName = model.FullName,
                            EmailId = model.EmailId,
                            MobileNumber = model.MobileNumber
                        };
                        return response;
                    }
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new CustomException(HttpStatusCode.BadRequest, "Cannot Add Detail To DataBase");
            }
        }

        /// <summary>
        /// Logins the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        /// <exception cref="System.Collections.Generic.KeyNotFoundException"></exception>
        public string Login(LoginModel model)
        {
            try
            {
                using (connection)
                {
                    UserTableDetails detail = new UserTableDetails();
                    string query = "select EmailId,Password from UserTable where EmailId=@EmailId and Password=@Password";
                    SqlCommand command = new SqlCommand(query, connection);

                    this.connection.Open();
                    command.Parameters.AddWithValue("@EmailID", model.EmailId);
                    command.Parameters.AddWithValue("@Password", model.Password);

                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while(reader.Read())
                        {
                            detail.EmailId = Convert.ToString(reader["EmailID"] == DBNull.Value ? default : reader["EmailID"]);
                            detail.Password = Convert.ToString(reader["Password"] == DBNull.Value ? default : reader["Password"]);
                        }
                        string token = JwtTokenGenerate(detail.EmailId);
                        return token;
                    }
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new KeyNotFoundException(ex.Message);
            }
            finally
            {
                this.connection.Close();
            }
        }
    }
}
