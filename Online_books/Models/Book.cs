using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Online_books.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DisplayName("Book Name")]
        public string Name { get; set; }

        [Required]
        public string Auther { get; set; }

        public DateTime CreationDate { get; set; }


        [DisplayName("Pdf File")]
        public string Url { get; set; }


        [DisplayName("Book Image")]
        public string ImgUrl { get; set; }

        public string Description { get; set; }


        [ForeignKey(nameof(Category))]
        [DisplayName("Category")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        [DisplayName("Language Category")]
        [ForeignKey(nameof(LanguageCategory))]
        public int LangCategoryId { get; set; }
        public RealLanguageCategory LanguageCategory { get; set; }
    }
}
