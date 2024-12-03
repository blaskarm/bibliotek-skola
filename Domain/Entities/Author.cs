﻿
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Domain.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
    }
}
