namespace PracticalTest.Data
{
    using Microsoft.EntityFrameworkCore;
    using PracticalTest.Models;
    using System.Collections.Generic;

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Employee> Employee { get; set; }
    }

}
