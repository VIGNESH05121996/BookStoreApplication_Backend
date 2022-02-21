// <copyright file="BookStoreFeedBackRL.cs" company="Book Store Application">
//     BookStoreFeedBackRL copyright tag.
// </copyright>

namespace Repository.Services
{
    using Common.BookModel;
    using Common.FeedBackModel;
    using Repository.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Book Store Feed Back Of Repository Layer
    /// </summary>
    public class BookStoreFeedBackRL : IBookStoreFeedBackRL
    {
        public static string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=BookStoreDataBase;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        private readonly SqlConnection connection = new(connectionString);

        /// <summary>
        /// Adds the feed back.
        /// </summary>
        /// <param name="bookId">The book identifier.</param>
        /// <param name="model">The model.</param>
        /// <param name="jwtUserId">The JWT user identifier.</param>
        /// <returns></returns>
        public FeedBackResponseModel AddFeedBack(long bookId, AddFeedBackModel model, long jwtUserId)
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
                        SqlCommand command = new("spAddFeedBack", connection);
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@BookId", validationModel.BookId);
                        command.Parameters.AddWithValue("@FeedBack", model.FeedBack);
                        command.Parameters.AddWithValue("@Ratings", model.Ratings);
                        command.Parameters.AddWithValue("@UserId", validationModel.UserId);
                        this.connection.Open();
                        int result = command.ExecuteNonQuery();
                        this.connection.Close();
                        if (result >= 0)
                        {
                            FeedBackResponseModel response = new()
                            {
                                BookId = validationModel.BookId,
                                FeedBack = model.FeedBack,
                                Ratings = model.Ratings,
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
        /// Gets all wish list.
        /// </summary>
        /// <param name="bookId">The book identifier.</param>
        /// <param name="jwtUserId">The JWT user identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.Collections.Generic.KeyNotFoundException">Cannot fetch details because userId is wrong</exception>
        public IEnumerable<GetAllFeedBackModel> GetAllWishList(long bookId, long jwtUserId)
        {
            try
            {
                SqlConnection sqlConnection = new(connectionString);
                string query = "select BookId,UserId from FeedBackTable where BookId=@BookId and UserId=@UserId ";
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
                    List<GetAllFeedBackModel> responseModel = new();
                    SqlCommand command = new("spGetAllFeedBack", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    this.connection.Open();
                    command.Parameters.AddWithValue("@BookId", bookId);
                    command.Parameters.AddWithValue("@UserId", jwtUserId);
                    SqlDataAdapter dataAdapter = new(command);
                    DataTable dataTable = new();
                    dataAdapter.Fill(dataTable);
                    foreach (DataRow dataRow in dataTable.Rows)
                    {
                        responseModel.Add(
                             new GetAllFeedBackModel
                             {
                                 FeedBackId = Convert.ToInt32(dataRow["FeedBackId"]),
                                 BookId = Convert.ToInt32(dataRow["BookId"]),
                                 UserId = Convert.ToInt32(dataRow["UserId"]),
                                 FeedBack = dataRow["FeedBack"].ToString(),
                                 Ratings = Convert.ToInt32(dataRow["Ratings"]),
                                 FullName = dataRow["FullName"].ToString(),
                             }
                         );
                    }
                    return responseModel;
                }
                sqlConnection.Close();
                return null;
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
    }
}
