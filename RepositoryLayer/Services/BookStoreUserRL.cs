﻿// <copyright file="BookStoreUserRL.cs" company="Book Store Application">
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

        private readonly SqlConnection connection = new(connectionString);

        /// <summary>
        /// JWTs the token generate.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        /// <exception cref="Repository.ExceptionHandling.CustomException">Cannot generate json web token since claims not added</exception>
        public string JwtTokenGenerate(string email,long userId)
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
                        new Claim("UserId",userId.ToString())
                    }),
                    Expires = DateTime.UtcNow.AddHours(1),
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
        /// Encrypteds the password.
        /// </summary>
        /// <param name="password">The password.</param>
        /// <returns></returns>
        /// <exception cref="Repository.ExceptionHandling.CustomException">Password missing for encryption</exception>
        public static string EncryptedPassword(string password)
        {
            try
            {
                byte[] encptPass = new byte[password.Length];
                encptPass = Encoding.UTF8.GetBytes(password);
                string encrypted = Convert.ToBase64String(encptPass);
                return encrypted;
            }
            catch (Exception ex)
            {
                throw new CustomException(HttpStatusCode.BadRequest, "Password missing for encryption");
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
                    command.Parameters.AddWithValue("@Password", EncryptedPassword(model.Password));
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
        public LoginResponseModel Login(LoginModel model)
        {
            try
            {
                using (connection)
                {
                    LoginResponseModel detail = new ();
                    SqlCommand command = new SqlCommand("spLoginUser", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    this.connection.Open();
                    command.Parameters.AddWithValue("@EmailID", model.EmailId);
                    command.Parameters.AddWithValue("@Password", EncryptedPassword(model.Password));

                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while(reader.Read())
                        {
                            detail.UserId = Convert.ToInt32(reader["UserId"] == DBNull.Value ? default : reader["UserId"]);
                            detail.EmailId = Convert.ToString(reader["EmailID"] == DBNull.Value ? default : reader["EmailID"]);
                            detail.MobileNumber = Convert.ToString(reader["MobileNumber"] == DBNull.Value ? default : reader["MobileNumber"]);
                            detail.FullName = Convert.ToString(reader["FullName"] == DBNull.Value ? default : reader["FullName"]);
                        }
                        string token = JwtTokenGenerate(detail.EmailId,detail.UserId);
                        detail.JwtToken = token;
                        return detail;
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

        /// <summary>
        /// Forgets the password.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        /// <exception cref="System.Collections.Generic.KeyNotFoundException"></exception>
        public string ForgetPassword(ForgetPasswordModel model)
        {
            try
            {
                using (connection)
                {
                    UserTableDetails detail = new UserTableDetails();
                    SqlCommand command = new SqlCommand("spForgetPassword", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    this.connection.Open();
                    command.Parameters.AddWithValue("@EmailID", model.EmailId);

                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            detail.EmailId = Convert.ToString(reader["EmailID"] == DBNull.Value ? default : reader["EmailID"]);
                            detail.UserId = Convert.ToInt32(reader["UserId"] == DBNull.Value ? default : reader["UserId"]);
                        }
                        string token = JwtTokenGenerate(detail.EmailId,detail.UserId);
                        new MsmqModel().MsmqSender(token);
                        return token;
                    }
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new KeyNotFoundException("Cannot Validate details with database");
            }
            finally
            {
                this.connection.Close();
            }
        }

        /// <summary>
        /// Resets the password.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <param name="email">The email.</param>
        /// <returns></returns>
        /// <exception cref="System.Collections.Generic.KeyNotFoundException"></exception>
        public bool ResetPassword(ResetPasswordModel model, string email)
        {
            try
            {
                using (connection)
                {
                    if (model.NewPassword == model.ConfirmPassword)
                    {
                        SqlCommand command = new SqlCommand("spResetPassword", connection);
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@EmailID", email);
                        command.Parameters.AddWithValue("@NewPassword", EncryptedPassword(model.NewPassword));
                        this.connection.Open();
                        int result = command.ExecuteNonQuery();
                        this.connection.Close();
                        if (result >= 0)
                        {
                            return true;
                        }
                    }
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new KeyNotFoundException("Cannot Validate details with database");
            }
        }
    }
}
