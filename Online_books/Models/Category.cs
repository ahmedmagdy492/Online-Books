using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_books.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]        
        public string Name { get; set; }
        public List<Book> Books { get; set; }        
    }
}
