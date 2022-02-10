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
        public CartResponseModel GetCartWithId(long bookId, long cartId, long jwtUserId)
        {
            try
            {
                CartResponseModel responseModel = new();
                SqlCommand command = new("spGetCartWithCartId", connection);
                command.CommandType = CommandType.StoredProcedure;

                this.connection.Open();
                command.Parameters.AddWithValue("@CartId", cartId);
                command.Parameters.AddWithValue("@BookId", bookId);
                command.Parameters.AddWithValue("@UserId", jwtUserId);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        responseModel.BookId = Convert.ToInt32(reader["CartId"]);
                        responseModel.BookId = Convert.ToInt32(reader["Quantity"]);
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
        public AddCartResponse AddCart(long bookId, AddCartModel model, long jwtUserId)
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
