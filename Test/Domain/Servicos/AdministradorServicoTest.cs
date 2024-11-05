using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using minimal_api.Dominio.Entities;
using minimal_api.Infraestrutura.Db;
using minimal_api.Dominio.Servicos;

namespace Test.Domain.Servico;

[TestClass]
public class AdministradorServicoTest
{
    private DBContext CriarContextoTest()
    {
        var assemblyPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        var path = Path.GetFullPath(Path.Combine(assemblyPath ?? "", "..", "..", ".."));
        // Configurar o ConfigurationBuilder 
        var builder = new ConfigurationBuilder()
            .SetBasePath(path?? Directory.GetCurrentDirectory() )
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddEnvironmentVariables();
        
        var configuration = builder.Build();
        
        return new DBContext(configuration);
    }

    [TestMethod]
    public void TestSalvarAdministrador()
    {
        // Arrange 
        var context = CriarContextoTest();
        context.Database.ExecuteSqlRaw("TRUNCATE TABLE Administradores");
        var adm = new Administrador();
        adm.Email = "test@test.com";
        adm.Senha = "test";
        adm.Perfil = "Adm";
        var administradorServico = new AdministradorServico(context);

        // Act
        administradorServico.Incluir(adm);

        // Assert
        Assert.AreEqual(1, administradorServico.Todos(1).Count());

    }

     [TestMethod]
    public void TestBuscaPorId()
    {
        // Arrange 
        var context = CriarContextoTest();
        context.Database.ExecuteSqlRaw("TRUNCATE TABLE Administradores");
        var adm = new Administrador();
        adm.Email = "test@test.com";
        adm.Senha = "test";
        adm.Perfil = "Adm";
        var administradorServico = new AdministradorServico(context);

        // Act
        administradorServico.Incluir(adm);
        var admDoBanco = administradorServico.BuscaPorId(adm.Id);

        // Assert
        Assert.AreEqual(1, admDoBanco.Id);

    }
}