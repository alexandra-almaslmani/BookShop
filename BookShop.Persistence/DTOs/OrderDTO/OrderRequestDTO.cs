using BookShop.Persistence.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.Persistence.DTOs.OrderDTO
{
    public class OrderRequestDTO
    {
        public List<Book> Books { get; set; }
        public int CustomerId { get; set; }
    }
}
