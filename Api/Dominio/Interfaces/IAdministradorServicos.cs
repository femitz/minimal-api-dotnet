using minimal_api.Dominio.DTOs;
using minimal_api.Dominio.Entities;

namespace minimal_api.Dominio.Interfaces;

public interface IAdministradorServicos
{
#nullable enable
    Administrador? Login(LoginDTO loginDTO);
    Administrador Incluir(Administrador administrador);
    List<Administrador> Todos(int? pagina);
    Administrador? BuscaPorId(int id);
}
