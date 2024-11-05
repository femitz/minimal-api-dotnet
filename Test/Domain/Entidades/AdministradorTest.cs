using minimal_api.Dominio.Entities;

namespace Test.Domain.Entidades;

[TestClass]
public class AdministradorTest
{
    [TestMethod]
    public void TestGetSetPropriedades()
    {
        // Arrange 
        var adm = new Administrador();
        
        // Act
        adm.Id = 1;
        adm.Email = "test@test.com";
        adm.Senha = "test";
        adm.Perfil = "Adm";
        
        // Assert
        Assert.AreEqual(1, adm.Id);
        Assert.AreEqual("test@test.com", adm.Email);
        Assert.AreEqual("test", adm.Senha);
        Assert.AreEqual("Adm", adm.Perfil);

    }   
}