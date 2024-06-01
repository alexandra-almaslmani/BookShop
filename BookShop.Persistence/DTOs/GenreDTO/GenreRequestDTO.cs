using BookShop.Persistence.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.Persistence.DTOs.GenreDTO
{
    public class GenreRequestDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
