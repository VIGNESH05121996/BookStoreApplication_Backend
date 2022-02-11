// <copyright file="BookStoreWishListRL.cs" company="Book Store Application">
//     BookStoreWishListRL copyright tag.
// </copyright>

namespace Repository.Services
{
    using Common.BookModel;
    using Common.WishListModel;
    using Repository.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Repository layer for Wish List
    /// </summary>
    public class BookStoreWishListRL : IBookStoreWishListRL
    {
        private static string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=BookStoreDataBase;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        private readonly SqlConnection connection = new(connectionString);

        /// <summary>
        /// Adds the wish list.
        /// </summary>
        /// <param name="bookId">The book identifier.</param>
        /// <param name="jwtUserId">The JWT user identifier.</param>
        /// <returns></returns>
        public bool AddWishList(long bookId, long jwtUserId)
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
                        SqlCommand command = new("spAddWishList", connection);
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@BookId", bookId);
                        command.Parameters.AddWithValue("@UserId", jwtUserId);
                        this.connection.Open();
                        int result = command.ExecuteNonQuery();
                        this.connection.Close();
                        if (result >= 0)
                        {
                            return true;
                        }
                    }
                }
                sqlConnection.Close();
                return false;
            }
            catch (Exception ex)
            {
                throw new KeyNotFoundException("Cannot Add Detail To DataBase Since No User Found");
            }
        }

        /// <summary>
        /// Deletes the wish list with wish list identifier.
        /// </summary>
        /// <param name="wishListId">The wish list identifier.</param>
        /// <param name="jwtUserId">The JWT user identifier.</param>
        /// <returns></returns>
        public bool DeleteWishListWithWishListId(long wishListId, long jwtUserId)
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
                    SqlCommand command = new("spDeleteWishListWithWishListtId", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@UserId", jwtUserId);
                    command.Parameters.AddWithValue("@WishListId", wishListId);
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
                throw new KeyNotFoundException("Cannot Delete WiahList from DataBase Since No User Found");
            }
        }

        /// <summary>
        /// Gets all wish list.
        /// </summary>
        /// <param name="jwtUserId">The JWT user identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.Collections.Generic.KeyNotFoundException">Cannot fetch details because userId is wrong</exception>
        public IEnumerable<WishListResponseModel> GetAllWishList(long jwtUserId)
        {
            try
            {
                List<WishListResponseModel> responseModel = new();
                SqlCommand command = new("spGetAllWishList", connection);
                command.CommandType = CommandType.StoredProcedure;

                this.connection.Open();
                command.Parameters.AddWithValue("@UserId", jwtUserId);
                SqlDataAdapter dataAdapter = new(command);
                DataTable dataTable = new();
                dataAdapter.Fill(dataTable);
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    responseModel.Add(
                         new WishListResponseModel
                         {
                             WishListId = Convert.ToInt32(dataRow["WishListId"]),
                             BookId = Convert.ToInt32(dataRow["BookId"]),
                             UserId = Convert.ToInt32(dataRow["UserId"]),
                             BookName = dataRow["BookName"].ToString(),
                             BookAuthor = dataRow["BookAuthor"].ToString(),
                             OriginalPrice = Convert.ToInt32(dataRow["OriginalPrice"]),
                             DiscountPrice = Convert.ToInt32(dataRow["DiscountPrice"]),
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
    }
}
