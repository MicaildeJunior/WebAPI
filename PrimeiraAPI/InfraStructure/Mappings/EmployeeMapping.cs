using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebAPI.Model;

namespace WebAPI.InfraStructure.Mappings;

public class EmployeeMapping : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.ToTable("Employee");

        // public int Id {get; set;}
        builder.HasKey(lbda => lbda.Id);

        // public string Name { get; set; }
        builder.Property(lbda => lbda.Nome)
          .HasColumnType("varchar(80)")
          .IsRequired();

        // public int Idade { get; set; }
        builder.Property(lbda => lbda.Idade)
            .HasColumnType("int(3)")
            .IsRequired(); 
    }
}
