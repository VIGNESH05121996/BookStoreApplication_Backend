// <copyright file="BookStoreBookRL.cs" company="Book Store Application">
//     BookStoreBookRL copyright tag.
// </copyright>

namespace Repository.Services
{
    using CloudinaryDotNet;
    using CloudinaryDotNet.Actions;
    using Common.BookModel;
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.Configuration;
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
        /// <summary>
        /// The configuration
        /// </summary>
        private readonly IConfiguration config;

        public BookStoreBookRL(IConfiguration config)
        {
            this.config = config;
        }

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
                using (connection)
                {
                    SqlCommand command = new("spCreateBook", connection);
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
                            UserId = jwtUserId
                        };
                        return response;
                    }
                }
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
                using (connection)
                {
                    SqlCommand command = new("spUpdateBook", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@BookId", bookId);
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
                using (connection)
                {
                    SqlCommand command = new("spRatingsUpdate", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@BookId", bookId);
                    command.Parameters.AddWithValue("@TotalRating", model.TotalRating);
                    command.Parameters.AddWithValue("@NoOfPeopleRated", model.NoOfPeopleRated);
                    command.Parameters.AddWithValue("@UserId", jwtUserId);
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
                return null;
            }
            catch (Exception ex)
            {
                throw new KeyNotFoundException("Cannot Add Detail To DataBase Since BookId Wrong");
            }
        }

        /// <summary>
        /// Images the update.
        /// </summary>
        /// <param name="bookId">The book identifier.</param>
        /// <param name="bookImage"></param>
        /// <param name="jwtUserId">The JWT user identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.Collections.Generic.KeyNotFoundException"></exception>
        public BookResponseModel ImageUpdate(long bookId, IFormFile bookImage, long jwtUserId)
        {
            try
            {
                Account account = new Account(this.config["Cloudinary:CloudName"], this.config["Cloudinary:APIKey"], this.config["Cloudinary:APISecret"]);
                var imagePath = bookImage.OpenReadStream();
                Cloudinary cloudinary = new Cloudinary(account);
                ImageUploadParams imageParams = new ImageUploadParams()
                {
                    File = new FileDescription(bookImage.FileName, imagePath)
                };
                string uploadImage = cloudinary.Upload(imageParams).Url.ToString();
                using (connection)
                {
                    SqlCommand command = new SqlCommand("spBookImageUpdate", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@BookId", bookId);
                    command.Parameters.AddWithValue("@BookImage", uploadImage);
                    command.Parameters.AddWithValue("@UserId", jwtUserId);
                    this.connection.Open();
                    int result = command.ExecuteNonQuery();
                    this.connection.Close();
                    if (result >= 0)
                    {
                        BookResponseModel response = new()
                        {
                            BookId = bookId,
                            BookImage = uploadImage,
                            UserId = jwtUserId
                        };
                        return response;
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new KeyNotFoundException(ex.Message);
            }
        }
    }
}
