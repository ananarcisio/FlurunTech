using System.ComponentModel.DataAnnotations;

namespace InVents.Models
{
    public class Nota
    {
        [Key]
        public int Id { get; set; }
        public int? NotaValor { get; set; }
        public int? FornecedorId { get; set; }
        public int? ProdutorId { get; set; }
        public int? EmpresaId { get; set; }


    }
}
