// <copyright file="IBookStoreBookRL.cs" company="Book Store Application">
//     IBookStoreBookRL copyright tag.
// </copyright>

namespace Repository.Interfaces
{
    using Common.BookModel;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Book Store Repository Layer Interface
    /// </summary>
    public interface IBookStoreBookRL
    {
        BookResponseModel CreateBookDetails(CreateBookModel model,long jwtUserId);
        BookResponseModel UpdateBookDetails(long bookId, UpdateBookModel model, long jwtUserId);
    }
}
