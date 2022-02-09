// <copyright file="BookStoreBookRL.cs" company="Book Store Application">
//     BookStoreBookRL copyright tag.
// </copyright>

namespace Repository.Services
{
    using Common.BookModel;
    using Repository.ExceptionHandling;
    using Repository.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Book Store Business Layer
    /// </summary>
    public class BookStoreBookRL : IBookStoreBookRL
    {
        public static string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=BookStoreDataBase;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        SqlConnection connection = new SqlConnection(connectionString);

        /// <summary>
        /// Creates the book details.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public BookResponseModel CreateBookDetails(CreateBookModel model,long jwtUserId)
        {
            try
            {
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                string query = "select UserId from UserTable where UserId=@UserId ";
                SqlCommand validateCommand = new SqlCommand(query, sqlConnection);
                BookValidationModel validationModel = new BookValidationModel();

                sqlConnection.Open();
                validateCommand.Parameters.AddWithValue("@UserId", jwtUserId);
                SqlDataReader reader = validateCommand.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        validationModel.UserId = Convert.ToInt32(reader["UserId"] == DBNull.Value ? default : reader["UserId"]);
                    }
                    using (connection)
                    {
                        SqlCommand command = new SqlCommand("spCreateBook", connection);
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@BookName", model.BookName);
                        command.Parameters.AddWithValue("@BookAuthor", model.BookAuthor);
                        command.Parameters.AddWithValue("@OriginalPrice", model.OriginalPrice);
                        command.Parameters.AddWithValue("@DiscountPrice", model.DiscountPrice);
                        command.Parameters.AddWithValue("@BookQuantity", model.BookQuantity);
                        command.Parameters.AddWithValue("@BookDetails", model.BookDetails);
                        command.Parameters.AddWithValue("@UserId", jwtUserId);
                        this.connection.Open();
                        int result = command.ExecuteNonQuery();
                        this.connection.Close();
                        if (result >= 0)
                        {
                            BookResponseModel response = new()
                            {
                                BookName = model.BookName,
                                BookAuthor = model.BookAuthor,
                                OriginalPrice = model.OriginalPrice,
                                DiscountPrice = model.DiscountPrice,
                                BookQuantity = model.BookQuantity,
                                BookDetails = model.BookDetails,
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
        /// Update Book Details
        /// </summary>
        /// <param name="bookId"></param>
        /// <param name="model"></param>
        /// <param name="jwtUserId"></param>
        /// <returns></returns>
        public BookResponseModel UpdateBookDetails(long bookId, UpdateBookModel model, long jwtUserId)
        {
            try
            {
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                string query = "select BookId,UserId from BookTable where BookId=@BookId and UserId=@UserId ";
                SqlCommand validateCommand = new SqlCommand(query, sqlConnection);
                BookValidationModel validationModel = new BookValidationModel();

                sqlConnection.Open();
                validateCommand.Parameters.AddWithValue("@BookId", bookId);
                validateCommand.Parameters.AddWithValue("@UserId", jwtUserId);
                SqlDataReader reader = validateCommand.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        validationModel.BookId = Convert.ToInt32(reader["BookId"] == DBNull.Value ? default : reader["BookId"]);
                        validationModel.UserId = Convert.ToInt32(reader["UserId"] == DBNull.Value ? default : reader["UserId"]);
                    }
                    using (connection)
                    {
                        SqlCommand command = new SqlCommand("spUpdateBook", connection);
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@BookId", validationModel.BookId);
                        command.Parameters.AddWithValue("@BookName", model.BookName);
                        command.Parameters.AddWithValue("@BookAuthor", model.BookAuthor);
                        command.Parameters.AddWithValue("@OriginalPrice", model.OriginalPrice);
                        command.Parameters.AddWithValue("@DiscountPrice", model.DiscountPrice);
                        command.Parameters.AddWithValue("@BookQuantity", model.BookQuantity);
                        command.Parameters.AddWithValue("@BookDetails", model.BookDetails);
                        command.Parameters.AddWithValue("@UserId", validationModel.UserId);
                        this.connection.Open();
                        int result = command.ExecuteNonQuery();
                        this.connection.Close();
                        if (result >= 0)
                        {
                            BookResponseModel response = new()
                            {
                                BookId = bookId,
                                BookName = model.BookName,
                                BookAuthor = model.BookAuthor,
                                OriginalPrice = model.OriginalPrice,
                                DiscountPrice = model.DiscountPrice,
                                BookQuantity = model.BookQuantity,
                                BookDetails = model.BookDetails,
                                UserId = jwtUserId
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
                throw new KeyNotFoundException("Cannot Add Detail To DataBase Since BookId Wrong");
            }
        }

        /// <summary>
        /// Ratingses the update.
        /// </summary>
        /// <param name="bookId">The book identifier.</param>
        /// <param name="model">The model.</param>
        /// <param name="jwtUserId">The JWT user identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.Collections.Generic.KeyNotFoundException">Cannot Add Detail To DataBase Since BookId Wrong</exception>
        public BookResponseModel RatingsUpdate(long bookId, RatingsUpdateModel model, long jwtUserId)
        {
            try
            {
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                string query = "select BookId,UserId from BookTable where BookId=@BookId and UserId=@UserId ";
                SqlCommand validateCommand = new SqlCommand(query, sqlConnection);
                BookValidationModel validationModel = new BookValidationModel();

                sqlConnection.Open();
                validateCommand.Parameters.AddWithValue("@BookId", bookId);
                validateCommand.Parameters.AddWithValue("@UserId", jwtUserId);
                SqlDataReader reader = validateCommand.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        validationModel.BookId = Convert.ToInt32(reader["BookId"] == DBNull.Value ? default : reader["BookId"]);
                        validationModel.UserId = Convert.ToInt32(reader["UserId"] == DBNull.Value ? default : reader["UserId"]);
                    }
                    using (connection)
                    {
                        SqlCommand command = new SqlCommand("spRatingsUpdate", connection);
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@BookId", validationModel.BookId);
                        command.Parameters.AddWithValue("@TotalRating", model.TotalRating);
                        command.Parameters.AddWithValue("@NoOfPeopleRated", model.NoOfPeopleRated);
                        command.Parameters.AddWithValue("@UserId", validationModel.UserId);
                        this.connection.Open();
                        int result = command.ExecuteNonQuery();
                        this.connection.Close();
                        if (result >= 0)
                        {
                            BookResponseModel response = new()
                            {
                                BookId = bookId,
                                TotalRating = model.TotalRating,
                                NoOfPeopleRated = model.NoOfPeopleRated,
                                UserId = jwtUserId
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
                throw new KeyNotFoundException("Cannot Add Detail To DataBase Since BookId Wrong");
            }
        }
    }
}
