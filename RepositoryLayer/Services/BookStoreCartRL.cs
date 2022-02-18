// <copyright file="BookStoreCartRL.cs" company="Book Store Application">
//     BookStoreCartRL copyright tag.
// </copyright>

namespace Repository.Services
{
    using Common.BookModel;
    using Common.CartModel;
    using Repository.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Book Store Cart Repository Layer
    /// </summary>
    /// <seealso cref="IBookStoreCartRL" />
    public class BookStoreCartRL : IBookStoreCartRL
    {
        private static string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=BookStoreDataBase;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        private readonly SqlConnection connection = new(connectionString);

        /// <summary>
        /// Gets the cart with identifier.
        /// </summary>
        /// <param name="bookId">The book identifier.</param>
        /// <param name="cartId">The cart identifier.</param>
        /// <param name="jwtUserId">The JWT user identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.Collections.Generic.KeyNotFoundException">Cannot fetch details because bookId is wrong</exception>
        public CartResponseModel GetCartWithId(long cartId, long jwtUserId)
        {
            try
            {
                CartResponseModel responseModel = new();
                SqlCommand command = new("spGetCartWithCartId", connection);
                command.CommandType = CommandType.StoredProcedure;

                this.connection.Open();
                command.Parameters.AddWithValue("@CartId", cartId);
                command.Parameters.AddWithValue("@UserId", jwtUserId);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        responseModel.CartId = Convert.ToInt32(reader["CartId"]);
                        responseModel.Quantity = Convert.ToInt32(reader["Quantity"]);
                        responseModel.BookId = Convert.ToInt32(reader["BookId"]);
                        responseModel.UserId = Convert.ToInt32(reader["UserId"]);
                        responseModel.BookName = reader["BookName"].ToString();
                        responseModel.BookAuthor = reader["BookAuthor"].ToString();
                        responseModel.OriginalPrice = Convert.ToInt32(reader["OriginalPrice"]);
                        responseModel.DiscountPrice = Convert.ToInt32(reader["DiscountPrice"]);
                        responseModel.BookImage = reader["BookImage"].ToString();
                        responseModel.BookDetails = reader["BookDetails"].ToString();
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
        /// Adds the cart.
        /// </summary>
        /// <param name="bookId">The book identifier.</param>
        /// <param name="model">The model.</param>
        /// <param name="jwtUserId">The JWT user identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.Collections.Generic.KeyNotFoundException">Cannot Add Detail To DataBase Since No User Found</exception>
        public AddCartResponse AddCart(long bookId, long jwtUserId)
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
                        SqlCommand command = new("spAddCart", connection);
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@BookId", bookId);
                        command.Parameters.AddWithValue("@UserId", jwtUserId);
                        this.connection.Open();
                        int result = command.ExecuteNonQuery();
                        this.connection.Close();
                        if (result >= 0)
                        {
                            AddCartResponse response = new()
                            {
                                BookId = validationModel.BookId,
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
        /// Update Cart 
        /// </summary>
        /// <param name="cartId"></param>
        /// <param name="model"></param>
        /// <param name="jwtUserId"></param>
        /// <returns></returns>
        public CartResponseModel UpdateCart(long cartId, UpdateCartModel model, long jwtUserId)
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
                        SqlCommand command = new("spUpdateCart", connection);
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@CartId", cartId);
                        command.Parameters.AddWithValue("@Quantity", model.Quantity);
                        command.Parameters.AddWithValue("@UserId", jwtUserId);
                        this.connection.Open();
                        int result = command.ExecuteNonQuery();
                        this.connection.Close();
                        if (result >= 0)
                        {
                            AddCartResponse response = new()
                            {
                                BookId = validationModel.BookId,
                                Quantity = model.Quantity,
                                UserId = validationModel.UserId
                            };
                            return GetCartWithId(cartId, validationModel.UserId);
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
        /// Get All Cart
        /// </summary>
        /// <param name="jwtUserId"></param>
        /// <returns></returns>
        public IEnumerable<CartResponseModel> GetAllCart(long jwtUserId)
        {
            try
            {
                List<CartResponseModel> responseModel = new();
                SqlCommand command = new("spGetAllCart", connection);
                command.CommandType = CommandType.StoredProcedure;

                this.connection.Open();
                command.Parameters.AddWithValue("@UserId", jwtUserId);
                SqlDataAdapter dataAdapter = new(command);
                DataTable dataTable = new();
                dataAdapter.Fill(dataTable);
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    responseModel.Add(
                         new CartResponseModel
                         {
                             CartId = Convert.ToInt32(dataRow["CartId"]),
                             Quantity = Convert.ToInt32(dataRow["Quantity"] == DBNull.Value ? default : dataRow["Quantity"]),
                             BookId = Convert.ToInt32(dataRow["BookId"] == DBNull.Value ? default : dataRow["BookId"]),
                             UserId = Convert.ToInt32(dataRow["UserId"] == DBNull.Value ? default : dataRow["UserId"]),
                             BookName = dataRow["BookName"].ToString(),
                             BookAuthor = dataRow["BookAuthor"].ToString(),
                             OriginalPrice = Convert.ToInt32(dataRow["OriginalPrice"] == DBNull.Value ? default : dataRow["OriginalPrice"]),
                             DiscountPrice = Convert.ToInt32(dataRow["DiscountPrice"] == DBNull.Value ? default : dataRow["DiscountPrice"]),
                             BookImage = dataRow["BookImage"].ToString(),
                             BookDetails = dataRow["BookDetails"].ToString(),
                         }
                     );
                }
                return responseModel;
            }
            catch (Exception ex)
            {
                throw new KeyNotFoundException("Cannot fetch details because userId is wrong");
            }
            finally
            {
                this.connection.Close();
            }
        }

        public bool DeleteCartWithCartId(long cartId, long jwtUserId)
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
                    SqlCommand command = new("spDeleteCartWithCartId", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@CartId", cartId);
                    command.Parameters.AddWithValue("@UserId", jwtUserId);

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
                throw new KeyNotFoundException("Cannot delete Cart from DataBase Since No User Found");
            }
        }
    }
}
