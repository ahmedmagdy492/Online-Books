using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_books.Models
{
    public abstract class LanguageCategory
    {        
        [Required]
        public abstract string Name { get; set; }
    }
}
