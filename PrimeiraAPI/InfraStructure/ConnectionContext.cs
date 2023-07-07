using Microsoft.EntityFrameworkCore;
using WebAPI.Model;

namespace WebAPI.InfraStructure;

public class ConnectionContext : DbContext
{
    // DbSet correspondem como se fossem tabelas
    public DbSet<Employee> Employees { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
          => optionsBuilder.UseSqlServer(
              "Server=LAPTOP-563RGJKO\\SQLEXPRESS;" +
              "Database=Aula-Youtube;" +
              "User Id=sa;" +
              "Password=@Sql2019;" +
              "TrustServerCertificate=True");
}
