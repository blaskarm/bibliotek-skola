using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos
{
    public class BookDto
    {
        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; } = null!;
        public int AuthorId { get; set; }
    }
}
