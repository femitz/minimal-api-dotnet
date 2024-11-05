using Microsoft.EntityFrameworkCore;
using minimal_api.Dominio.DTOs;
using minimal_api.Dominio.Entities;
using minimal_api.Dominio.Interfaces;
using minimal_api.Infraestrutura.Db;

namespace minimal_api.Dominio.Servicos;

public class VeiculoServico : IVeiculoServico
{
    private readonly DBContext _context;
    public VeiculoServico(DBContext DbContext) { _context = DbContext; }

    public void Apagar(Veiculo veiculo)
    {
        _context.Veiculos.Remove(veiculo);
        _context.SaveChanges();
    }

    public void Atualizar(Veiculo veiculo)
    {
        _context.Veiculos.Update(veiculo);
        _context.SaveChanges();
    }

#nullable enable
    public Veiculo? BuscaPorId(int id)
    {
        return _context.Veiculos.Where(v => v.Id == id).FirstOrDefault();
    }

    public void Incluir(Veiculo veiculo)
    {
        _context.Veiculos.Add(veiculo);
        _context.SaveChanges();
    }

    public List<Veiculo> Todos(int? pagina = 1, string nome = null, string marca = null)
    {
        var query = _context.Veiculos.AsQueryable();
        if (!string.IsNullOrEmpty(nome))
        {
            query = query.Where(v => EF.Functions.Like(v.Nome.ToLower(), $"%{nome.ToLower()}%"));
        }

        int itensPorPagina = 10;

        if (pagina != null)
            query = query.Skip((int)(pagina - 1) * itensPorPagina).Take(itensPorPagina);

        return query.ToList();
    }
}