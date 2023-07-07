using WebAPI.Model;

namespace WebAPI.InfraStructure
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ConnectionContext _context = new ConnectionContext();
        
        public void Add(Employee employee)
        {
            // Adicionado
            _context.Employees.Add(employee);
            // Salvo
            _context.SaveChanges();
        }

        public List<Employee> Get()
        {
            return _context.Employees.ToList();
        }

        // Procura o usuario no banco e tras ele
        public Employee? Get(int id)
        {
            return _context.Employees.Find(id);
        }
    }
}
