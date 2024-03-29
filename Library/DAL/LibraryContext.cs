﻿using Library.Models.Entity;
using Microsoft.EntityFrameworkCore;

namespace Library.DAL
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options): base(options)
        { 
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Book> Catalog { get; set; }
    }
}
