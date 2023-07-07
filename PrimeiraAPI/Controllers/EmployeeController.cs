using Microsoft.AspNetCore.Mvc;
using WebAPI.Model;
using WebAPI.ViewModel;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/v1/employee")]
public class EmployeeController : ControllerBase
{
    private readonly IEmployeeRepository _employeeRepository;

    public EmployeeController(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

    // Adicionar Funcionarios
    [HttpPost]
    public IActionResult Adicionar([FromForm] EmployeeViewModel employeeView)
    {
        // Salvar o arquivo que esta na pasta no banco de dados
        var filePath = Path.Combine("Storage", employeeView.Foto.FileName);

        // salvando a foto na memoria
        using Stream fileStream = new FileStream(filePath, FileMode.Create);
        // colocando a foto dentro de fileStream
        employeeView.Foto.CopyTo(fileStream);

        var employee = new Employee(employeeView.Nome, employeeView.Idade, filePath);
        // Adicionando o employee no _employeeRepository
        _employeeRepository.Add(employee);

        return Ok("Funcionário cadastrado com sucesso!");
    }

    [HttpPost]
    [Route("{id}/download")]
    public IActionResult DownloadFoto(int id)
    {
        // Pegando o funcionario no banco de dados pelo id dele
        var employee = _employeeRepository.Get(id);

        /*
            Para retornar pro Front End a foto, precisa retornar em bytes,
            System.IO é uma classe que chama o Arquivo, em seguida ReadAllBytes
            le todos os bytes de employee.Foto
        */
        var dataBytes = System.IO.File.ReadAllBytes(employee.Foto);

        return File(dataBytes, "image/jpg"); 
    }


    // Listar Funcionarios
    [HttpGet]
    public IActionResult Get()
    {
        var employees = _employeeRepository.Get();

        return Ok(employees);
    }
}