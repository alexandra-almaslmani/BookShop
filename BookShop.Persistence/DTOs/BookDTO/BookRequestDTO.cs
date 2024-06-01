using BookShop.Persistence.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.Persistence.DTOs.BookDTO
{
    public class BookRequestDTO
    {
        public string Title { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public int AuthorId { get; set; }
        public int GenreId { get; set; }
    }
}
