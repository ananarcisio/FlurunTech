using System.ComponentModel.DataAnnotations;

namespace InVents.Models
{
    public class Empresa
    {
        [Key]
        public int Id { get; set; }
        public string? NomeFantasia { get; set; }
        public string? RazaoSocial { get; set; }
        public string? CNPJ { get; set; }
        public List<Produtor>? Funcionarios { get; set; }
        public List<Fornecedor>? FornecedoresContratados { get; set; }
        public List<Evento>? EventosRealizados { get; set; }

    }
}
