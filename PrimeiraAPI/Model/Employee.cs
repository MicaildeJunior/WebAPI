using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Model;

[Table("Employee")]
public class Employee
{
    [Key]
    public int Id { get; private set; }
    public  string? Nome { get; private set; }
    public  int Idade { get; private set; }
    public  string? Foto { get; private set; }

    public Employee(string? nome, int idade, string? foto)
    {
        Nome = nome ?? throw new ArgumentNullException(nameof(nome));
        Idade = idade;
        Foto = foto;
    }
}
