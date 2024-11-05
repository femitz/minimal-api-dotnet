using Microsoft.EntityFrameworkCore;
using minimal_api.Dominio.Entities;

namespace minimal_api.Infraestrutura.Db;

public class DBContext : DbContext
{
    private readonly IConfiguration _configuracaoAppSettings;
    public DBContext(IConfiguration configuracaoAppSettings)
    {
        _configuracaoAppSettings = configuracaoAppSettings;
    }

    // Tabelas
    public DbSet<Administrador> Administradores { get; set; } = default;
    public DbSet<Veiculo> Veiculos { get; set; } = default;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Administrador>().HasData(
            new Administrador
            {
                Id = 1,
                Email = "adm@teste.com",
                Senha = "123456",
                Perfil = "Adm"
            }
        );
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var stringConexao = _configuracaoAppSettings.GetConnectionString("MySql")?.ToString();

            if (!string.IsNullOrEmpty(stringConexao))
                optionsBuilder.UseMySql(stringConexao, ServerVersion.AutoDetect(stringConexao));
        }
    }
}