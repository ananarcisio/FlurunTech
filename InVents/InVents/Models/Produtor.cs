using System.ComponentModel.DataAnnotations;

namespace InVents.Models
{
    public class Produtor
    {
        [Key]
        public int Id { get; set; }
        public string? Nome { get; set; }
        public int? EmpresaId { get; set; }
        public string? Email { get; set; }
        public string? Cargo { get; set; }
        public int? Telefone { get; set; }
        public List<int>? FornecedoresContratados { get; set; }
    }
}
