using System.ComponentModel.DataAnnotations;

namespace InVents.Models
{
    public class Fornecedor
    {
        [Key]
        public int Id { get; set; }
        public string? NomeFantasia { get; set; }
        public string? RazaoSocial { get; set; }
        public int? CNPJ { get; set; }
        public string? Endereco { get; set; }
        public int? Numero { get; set; }
        public string? Complemento { get; set; }
        public string? Bairro { get; set; }
        public string? Cidade { get; set; }
        public string? Estado { get; set; }
        public string? Setor { get; set; }
        public string? Email { get; set; }

        public string? Imagem { get; set; }

        public double MediaNota { get; set; }

        public List<Evento>? EventosFornecidos { get; set; }
    }
}
