using System.ComponentModel.DataAnnotations;

namespace InVents.Models
{
    public class Evento
    {
        [Key]
        public int Id { get; set; }
        public string? Nome { get; set; }
        public DateTime? Data { get; set; }
        public string? Cidade { get; set; }
        public string? Estado { get; set; }
        public List<string>? Imagens { get; set; }
        public List<Fornecedor>? Fornecedores { get; set; }
        public List<Produtor>? Produtores { get; set; }
        public Empresa? Empresa { get; set; }
    }
}
