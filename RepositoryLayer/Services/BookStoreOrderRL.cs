// <copyright file="BookStoreOrderRL.cs" company="Book Store Application">
//     BookStoreOrderRL copyright tag.
// </copyright>

namespace Repository.Services
{
    using Common.BookModel;
    using Common.OrderModel;
    using Repository.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Book Store Order Repository
    /// </summary>
    public class BookStoreOrderRL : IBookStoreOrderRL
    {
        private static string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=BookStoreDataBase;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        private readonly SqlConnection connection = new(connectionString);

        /// <summary>
        /// Adds the order.
        /// </summary>
        /// <param name="bookId">The book identifier.</param>
        /// <param name="model">The model.</param>
        /// <param name="jwtUserId">The JWT user identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.Collections.Generic.KeyNotFoundException">Cannot Add Detail To DataBase Since No User Found</exception>
        public OrderResponse AddOrder(long bookId, AddOrderModel model, long jwtUserId)
        {
            try
            {
                SqlConnection sqlConnection = new(connectionString);
                string query = "select BookId,UserId from BookTable where BookId=@BookId and UserId=@UserId ";
                SqlCommand validateCommand = new(query, sqlConnection);
                BookValidationModel validationModel = new();

                sqlConnection.Open();
                validateCommand.Parameters.AddWithValue("@BookId", bookId);
                validateCommand.Parameters.AddWithValue("@UserId", jwtUserId);
                SqlDataReader reader = validateCommand.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        validationModel.BookId = Convert.ToInt32(reader["BookId"]);
                        validationModel.UserId = Convert.ToInt32(reader["UserId"]);
                    }
                    using (connection)
                    {
                        SqlCommand command = new("spAddOrder", connection);
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@BookId", validationModel.BookId);
                        command.Parameters.AddWithValue("@AddressId", model.AddressId);
                        command.Parameters.AddWithValue("@Quantity", model.Quantity);
                        command.Parameters.AddWithValue("@UserId", validationModel.UserId);
                        this.connection.Open();
                        int result = command.ExecuteNonQuery();
                        this.connection.Close();
                        if (result >= 0)
                        {
                            return GetOrderWithBookId(validationModel.BookId, validationModel.UserId);
                        }
                    }
                }
                sqlConnection.Close();
                return null;
            }
            catch (Exception ex)
            {
                throw new KeyNotFoundException("There is Issue while placing order");
            }
        }

        /// <summary>
        /// Gets the order with book identifier.
        /// </summary>
        /// <param name="bookId">The book identifier.</param>
        /// <param name="jwtUserId">The JWT user identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.Collections.Generic.KeyNotFoundException">Cannot fetch details because bookId is wrong</exception>
        public OrderResponse GetOrderWithBookId(long bookId, long jwtUserId)
        {
            try
            {
                OrderResponse responseModel = new();
                SqlCommand command = new("spGetOrderWithBookId", connection);
                command.CommandType = CommandType.StoredProcedure;

                this.connection.Open();
                command.Parameters.AddWithValue("@BookId", bookId);
                command.Parameters.AddWithValue("@UserId", jwtUserId);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        responseModel.OrderId = Convert.ToInt32(reader["OrderId"]);
                        responseModel.UserId = Convert.ToInt32(reader["UserId"]);
                        responseModel.AddressId = Convert.ToInt32(reader["AddressId"]);
                        responseModel.BookId = Convert.ToInt32(reader["BookId"]);
                        responseModel.Quantity = Convert.ToInt32(reader["Quantity"] == DBNull.Value ? default : reader["Quantity"]);
                        responseModel.TotalPrice = Convert.ToInt32(reader["Price"] == DBNull.Value ? default : reader["Price"]);
                        
                    }
                    return responseModel;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new KeyNotFoundException("Cannot fetch details because bookId is wrong");
            }
            finally
            {
                this.connection.Close();
            }
        }

        /// <summary>
        /// Gets all orders.
        /// </summary>
        /// <param name="jwtUserId">The JWT user identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.Collections.Generic.KeyNotFoundException">Cannot fetch orders</exception>
        public IEnumerable<GetAllOrdersResponseModel> GetAllOrders(long jwtUserId)
        {
            try
            {
                List<GetAllOrdersResponseModel> responseModel = new();
                SqlCommand command = new("spGetAllOrders", connection);
                command.CommandType = CommandType.StoredProcedure;

                this.connection.Open();
                command.Parameters.AddWithValue("@UserId", jwtUserId);
                SqlDataAdapter dataAdapter = new(command);
                DataTable dataTable = new();
                dataAdapter.Fill(dataTable);
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    responseModel.Add(
                         new GetAllOrdersResponseModel
                         {
                             OrderId = Convert.ToInt32(dataRow["OrderId"]),
                             UserId = Convert.ToInt32(dataRow["UserId"] == DBNull.Value ? default : dataRow["UserId"]),
                             AddressId = Convert.ToInt32(dataRow["AddressId"] == DBNull.Value ? default : dataRow["AddressId"]),
                             BookId = Convert.ToInt32(dataRow["BookId"] == DBNull.Value ? default : dataRow["BookId"]),
                             Quantity = Convert.ToInt32(dataRow["Quantity"]),
                             TotalPrice = Convert.ToInt32(dataRow["Price"]),
                             BookName = Convert.ToString(dataRow["BookName"]),
                             BookAuthor = Convert.ToString(dataRow["BookAuthor"]),
                             OriginalPrice = Convert.ToInt32(dataRow["OriginalPrice"] == DBNull.Value ? default : dataRow["OriginalPrice"]),
                             DiscountPrice = Convert.ToInt32(dataRow["DiscountPrice"] == DBNull.Value ? default : dataRow["DiscountPrice"]),
                             BookImage = Convert.ToString(dataRow["BookImage"]),
                             BookDetails = Convert.ToString(dataRow["BookDetails"]),
                             TypeId = Convert.ToInt32(dataRow["TypeId"]),
                             FullName = dataRow["FullName"].ToString(),
                             FullAddress = dataRow["FullAddress"].ToString(),
                             City = dataRow["City"].ToString(),
                             State = dataRow["State"].ToString()
                         }
                     );
                }
                return responseModel;
            }
            catch (Exception ex)
            {
                //throw new KeyNotFoundException("Cannot fetch orders");
                throw new KeyNotFoundException(ex.Message);
            }
            finally
            {
                this.connection.Close();
            }
        }
    }
}
