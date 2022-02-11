// <copyright file="BookStoreAddressRL.cs" company="Book Store Application">
//     BookStoreAddressRL copyright tag.
// </copyright>

namespace Repository.Services
{
    using Common.AddressModel;
    using Common.BookModel;
    using Repository.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Book Store Repository Layer
    /// </summary>
    public class BookStoreAddressRL : IBookStoreAddressRL
    {
        private static string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=BookStoreDataBase;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        private readonly SqlConnection connection = new(connectionString);

        /// <summary>
        /// Adds the address.
        /// </summary>
        /// <param name="typeId">The type identifier.</param>
        /// <param name="model">The model.</param>
        /// <param name="jwtUserId">The JWT user identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public AddressResponseModel AddAddress(long typeId, AddAdressModel model, long jwtUserId)
        {
            try
            {
                SqlConnection sqlConnection = new(connectionString);
                string query = "select UserId from UserTable where UserId=@UserId ";
                SqlCommand validateCommand = new(query, sqlConnection);
                BookValidationModel validationModel = new();

                sqlConnection.Open();
                validateCommand.Parameters.AddWithValue("@UserId", jwtUserId);
                SqlDataReader reader = validateCommand.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        validationModel.UserId = Convert.ToInt32(reader["UserId"]);
                    }
                    using (connection)
                    {
                        SqlCommand command = new("spAddAddress", connection);
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@TypeId", typeId);
                        command.Parameters.AddWithValue("@FullName", model.FullName);
                        command.Parameters.AddWithValue("@FullAddress", model.FullAddress);
                        command.Parameters.AddWithValue("@City", model.City);
                        command.Parameters.AddWithValue("@State", model.State);
                        command.Parameters.AddWithValue("@UserId", validationModel.UserId);
                        this.connection.Open();
                        int result = command.ExecuteNonQuery();
                        this.connection.Close();
                        if (result >= 0)
                        {
                            AddressResponseModel response = new()
                            {
                                TypeId = typeId,
                                FullName = model.FullName,
                                FullAddress = model.FullAddress,
                                City = model.City,
                                State = model.State,
                                UserId = validationModel.UserId
                            };
                            return response;
                        }
                    }
                }
                sqlConnection.Close();
                return null;
            }
            catch (Exception ex)
            {
                throw new KeyNotFoundException("Cannot Add Detail To DataBase Since No User Found");
            }
        }
    }
}
