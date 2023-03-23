using Microsoft.EntityFrameworkCore;
using StudentAPI.Models;

namespace StudentAPI.Data
{
    public class ApiContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public ApiContext(DbContextOptions<ApiContext> options)
            :base (options)
        {
        --text
        }
    }
}
