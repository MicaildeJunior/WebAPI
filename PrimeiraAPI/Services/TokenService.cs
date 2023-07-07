using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebAPI.Model;

namespace WebAPI.Services;

public class TokenService 
{
    public static object GenerateToken(Employee employee)
    {
        var key = Encoding.ASCII.GetBytes(Key.Secret);

        // Salvar dentro do meu token o id do funcionario
        var tokenConfig = new SecurityTokenDescriptor
        {
            Subject = new System.Security.Claims.ClaimsIdentity(new Claim[]
            {
                new Claim("employeeId", employee.Id.ToString()),
            }),
            Expires = DateTime.UtcNow.AddHours(3),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        // Criando o token
        var token = tokenHandler.CreateToken(tokenConfig);
        // Escreve o token
        var tokenString = tokenHandler.WriteToken(token);

        return new
        {
            token = tokenString
        };
    }
}
