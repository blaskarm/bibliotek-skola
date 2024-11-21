﻿using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.CreateBook
{
    public class CreateBookCommand : IRequest<Book>
    {
        public CreateBookCommand(Book book)
        {
            Book = book;
        }

        public Book Book { get; }
    }
}
