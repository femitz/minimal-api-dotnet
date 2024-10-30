using minimal_api.DTOs;
using minimal_api.Entities;

namespace minimal_api;

public interface IAdministradorServicos
{
#nullable enable
    Administrador? Login(LoginDTO loginDTO);
    Administrador Incluir(Administrador administrador);
    List<Administrador> Todos(int? pagina);
    Administrador? BuscaPorId(int id);
}
