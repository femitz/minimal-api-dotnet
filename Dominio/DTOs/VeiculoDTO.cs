namespace minimal_api.DTOs;

public record VeiculoDTO
{
    public string Nome { get; set; }
    public string Marca { get; set; }
    public int Ano { get; set; }
}