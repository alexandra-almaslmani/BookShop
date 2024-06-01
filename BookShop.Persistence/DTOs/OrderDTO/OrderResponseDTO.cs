using BookShop.Persistence.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.Persistence.DTOs.OrderDTO
{
    public class OrderResponseDTO
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal Total_Price { get; set; }
        public int CustomerId { get; set; }
        public List<Book> Books { get; set; }
       
    }
}
