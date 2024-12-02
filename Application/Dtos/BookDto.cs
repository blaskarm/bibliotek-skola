using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos
{
    public class BookDto
    {
        public string Title { get; set; } = null!;
        public int AuthorId { get; set; }
    }
}
