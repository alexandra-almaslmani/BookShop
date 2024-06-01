﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.Persistence.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal Total_Price { get; set; }
        public status Status { get; set; }
        public Customer Customer { get; set; }
        public int CustomerId { get; set; }
        public List<Book> Books { get; set; }
        public enum status
        {
            Cancelled,
            Delivered,
            Shipped,
            Processing,
            Pending
        }
    }
}
