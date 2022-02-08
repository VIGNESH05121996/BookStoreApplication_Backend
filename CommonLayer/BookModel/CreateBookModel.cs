// <copyright file="CreateBookModel.cs" company="Book Store Application">
//     CreateBookModel copyright tag.
// </copyright>

namespace Common.BookModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Create Book Model
    /// </summary>
    public class CreateBookModel
    {
        /// <summary>
        /// Gets or sets the book identifier.
        /// </summary>
        /// <value>
        /// The book identifier.
        /// </value>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long BookId { get; set; }

        /// <summary>
        /// Gets or sets the name of the book.
        /// </summary>
        /// <value>
        /// The name of the book.
        /// </value>
        [Display(Name = "BookName")]
        [DataType(DataType.Text)]
        public string BookName { get; set; }

        /// <summary>
        /// Gets or sets the book author.
        /// </summary>
        /// <value>
        /// The book author.
        /// </value>
        [Display(Name = "BookAuthor")]
        [DataType(DataType.Text)]
        public string BookAuthor { get; set; }


        /// <summary>
        /// Gets or sets the original price.
        /// </summary>
        /// <value>
        /// The original price.
        /// </value>
        [Display(Name = "OriginalPrice")]
        public long OriginalPrice { get; set; }

        /// <summary>
        /// Gets or sets the discount price.
        /// </summary>
        /// <value>
        /// The discount price.
        /// </value>
        [Display(Name = "DiscountPrice")]
        public long DiscountPrice { get; set; }

        /// <summary>
        /// Gets or sets the book quantity.
        /// </summary>
        /// <value>
        /// The book quantity.
        /// </value>
        [Display(Name = "BookQuantity")]
        public long BookQuantity { get; set; }

        /// <summary>
        /// Gets or sets the created at.
        /// </summary>
        /// <value>
        /// The created at.
        /// </value>
        [Display(Name = "BookDetails")]
        [DataType(DataType.Text)]
        public string BookDetails { get; set; }

    }   
}
