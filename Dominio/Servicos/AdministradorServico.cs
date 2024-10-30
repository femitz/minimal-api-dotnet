using minimal_api.DTOs;
using minimal_api.Entities;
using minimal_api.Infraestrutura.Db;

namespace minimal_api.Dominio.Interfaces;

public class AdministradorServico : IAdministradorServicos
{
    private readonly DBContext _context;
    public AdministradorServico(DBContext DbContext) { _context = DbContext; }


    public Administrador Login(LoginDTO loginDTO)
    {
        var adm = _context.Administradores.Where(a => a.Email == loginDTO.Email && a.Senha == loginDTO.Senha).FirstOrDefault();
        return adm;
    }

    public Administrador Incluir(Administrador administrador)
    {
        _context.Administradores.Add(administrador);
        _context.SaveChanges();
        return administrador;
    }


    public List<Administrador> Todos(int? pagina)
    {
        var query = _context.Administradores.AsQueryable();

        int itensPorPagina = 10;

        if (pagina != null)
            query = query.Skip((int)(pagina - 1) * itensPorPagina).Take(itensPorPagina);

        return query.ToList();
    }
    
#nullable enable
    public Administrador? BuscaPorId(int id)
    {
        return _context.Administradores.Where(v => v.Id == id).FirstOrDefault();
    }
}