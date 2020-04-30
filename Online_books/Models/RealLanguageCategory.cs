using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Online_books.Models
{
    public class RealLanguageCategory : LanguageCategory
    {
        private string name;
        [Key]
        public int Id { get; set; }
        public override string Name { get => name; set => name = value; }
        public List<Book> Books { get; set; }
    }
}
