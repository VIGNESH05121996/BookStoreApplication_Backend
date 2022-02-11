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

        /// <summary>
        /// Gets all address.
        /// </summary>
        /// <param name="jwtUserId">The JWT user identifier.</param>
        /// <returns></returns>
        public IEnumerable<AddressResponseModel> GetAllAddress(long jwtUserId)
        {
            try
            {
                List<AddressResponseModel> responseModel = new();
                SqlCommand command = new("spGetAllAddress", connection);
                command.CommandType = CommandType.StoredProcedure;

                this.connection.Open();
                command.Parameters.AddWithValue("@UserId", jwtUserId);
                SqlDataAdapter dataAdapter = new(command);
                DataTable dataTable = new();
                dataAdapter.Fill(dataTable);
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    responseModel.Add(
                         new AddressResponseModel
                         {
                             TypeId = Convert.ToInt32(dataRow["TypeId"]),
                             FullName = dataRow["FullName"].ToString(),
                             FullAddress = dataRow["FullAddress"].ToString(),
                             City = dataRow["City"].ToString(),
                             State = dataRow["State"].ToString(),
                             UserId = Convert.ToInt32(dataRow["UserId"])
                         }
                     );
                }
                return responseModel;
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
        /// Gets the cart with identifier.
        /// </summary>
        /// <param name="addressId">The address identifier.</param>
        /// <param name="jwtUserId">The JWT user identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.Collections.Generic.KeyNotFoundException">Cannot fetch details because addressId is wrong</exception>
        public UpdateResponseModel GetAddressWithId(long addressId, long jwtUserId)
        {
            try
            {
                UpdateResponseModel responseModel = new();
                SqlCommand command = new("spGetAddressWithAddressId", connection);
                command.CommandType = CommandType.StoredProcedure;

                this.connection.Open();
                command.Parameters.AddWithValue("@AddressId", addressId);
                command.Parameters.AddWithValue("@UserId", jwtUserId);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        responseModel.AddressId = Convert.ToInt32(reader["addressId"]);
                        responseModel.TypeId = Convert.ToInt32(reader["TypeId"]);
                        responseModel.FullName = reader["FullName"].ToString();
                        responseModel.FullAddress = reader["FullAddress"].ToString();
                        responseModel.City = reader["City"].ToString();
                        responseModel.State = reader["State"].ToString();
                        responseModel.UserId = Convert.ToInt32(reader["UserId"]);
                    }
                    return responseModel;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new KeyNotFoundException("Cannot fetch details because addressId is wrong");
            }
            finally
            {
                this.connection.Close();
            }
        }
        /// <summary>
        /// Updates the address.
        /// </summary>
        /// <param name="addressId">The address identifier.</param>
        /// <param name="model">The model.</param>
        /// <param name="jwtUserId">The JWT user identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.Collections.Generic.KeyNotFoundException">Cannot Add Detail To DataBase Since No User Found</exception>
        public UpdateResponseModel UpdateAddress(long addressId, UpdateAddressModel model, long jwtUserId)
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
                        SqlCommand command = new("spUpdateAddress", connection);
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@AddressId", addressId);
                        command.Parameters.AddWithValue("@TypeId", model.TypeId);
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
                            return GetAddressWithId(addressId, jwtUserId);
                        }
                    }
                }
                sqlConnection.Close();
                return null;
            }
            catch (Exception ex)
            {
                throw new KeyNotFoundException("Cannot Update Detail To DataBase Since No User Found");
            }
        }

        /// <summary>
        /// Deletes the address with address identifier.
        /// </summary>
        /// <param name="addressId">The address identifier.</param>
        /// <param name="jwtUserId">The JWT user identifier.</param>
        /// <returns></returns>
        public bool DeleteAddressWithAddressId(long addressId, long jwtUserId)
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
                    SqlCommand command = new("spDeleteAddressWithAddressId", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@UserId", validationModel.UserId);
                    command.Parameters.AddWithValue("@AddressId", addressId);
                    this.connection.Open();
                    int result = command.ExecuteNonQuery();
                    this.connection.Close();
                    if (result >= 0)
                    {
                        return true;
                    }
                }
                sqlConnection.Close();
                return false;
            }
            catch (Exception ex)
            {
                throw new KeyNotFoundException("Cannot Delete Address from DataBase Since No User Found");
            }
        }
    }
}

