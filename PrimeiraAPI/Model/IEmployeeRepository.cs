namespace WebAPI.Model;

public interface IEmployeeRepository
{
    // Adiciona funcionarios
    void Add(Employee employee);

    // Retorna uma lista de funcionarios
    List<Employee> Get();

    // Retorna apenas um usuario
    Employee? Get(int id);
}
