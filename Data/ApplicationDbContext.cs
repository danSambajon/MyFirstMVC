using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyFirstMVC.Models;

namespace MyFirstMVC.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext(options)
    {
        public DbSet<MyFirstMVC.Models.Cards> Cards { get; set; } = default!;
        public DbSet<MyFirstMVC.Models.Subjects> Subjects { get; set; } = default!;
    }
}
