using Microsoft.EntityFrameworkCore;
using UniversityData.Models;

namespace UniversityData.Context;

public class UniversityDbContext : DbContext
{
    public UniversityDbContext(DbContextOptions<UniversityDbContext> options) : base(options)
    {
    }
    public DbSet<Student> Students { get; set; }
}
