using BookShop.Persistence.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.Persistence.DTOs.CustomerDTO
{
    public class CustomerRequestDTO
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public int PhoneNumber { get; set; }
    }
}
