using minimal_api.Dominio.Entities;

namespace Test.Domain.Entidades;

[TestClass]
public class VeiculoTest
{
    [TestMethod]
    public void TestGetSetPropriedades()
    {
        // Arrange 
        var veiculo = new Veiculo();
        
        // Act
        veiculo.Id = 1;
        veiculo.Nome = "testNome";
        veiculo.Marca = "testMarca";
        veiculo.Ano = 2000;
        
        // Assert
        Assert.AreEqual(1, veiculo.Id);
        Assert.AreEqual("testNome", veiculo.Nome);
        Assert.AreEqual("testMarca", veiculo.Marca);
        Assert.AreEqual(2000, veiculo.Ano);

    }   
}