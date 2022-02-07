// <copyright file="BookStoreUserRL.cs" company="Book Store Application">
//     BookStoreUserRL copyright tag.
// </copyright>

namespace RepositoryLayer.Services
{
    using Common.UserModel;
    using CommonLayer.UserModel;
    using Microsoft.Extensions.Configuration;
    using Repository.ExceptionHandling;
    using RepositoryLayer.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Repository layer
    /// </summary>
    /// <seealso cref="RepositoryLayer.Interfaces.IBookStoreUserRL" />
    public class BookStoreUserRL : IBookStoreUserRL
    {
        public static string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=BookStoreDataBase;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        SqlConnection connection = new SqlConnection(connectionString);
        
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
                    connection.Open();
                    int result = command.ExecuteNonQuery();
                    connection.Close();
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
    }
}
