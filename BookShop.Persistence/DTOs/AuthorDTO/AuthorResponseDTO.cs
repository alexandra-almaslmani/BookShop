using BookShop.Persistence.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.Persistence.DTOs.AuthorDTO
{
    public class AuthorResponseDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Bio { get; set; } // brief cv
        public DateTime BirthDate { get; set; }
    }
}
