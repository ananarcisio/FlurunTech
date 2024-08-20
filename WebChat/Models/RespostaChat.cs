using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace WebChat.Models
{
    [Table("RespostaChat")]
    public class RespostaChat
    {
        [Column("Id")]
        [Display(Name = "codigo")]
        public int Id { get; set; }

        [Column("Resposta")]
        [Display(Name = "Pergunta")]
        public int Resposta { get; set; }

        [Column("Mensagem")]
        [Display(Name = "Mensagem")]
        public int Mensagem { get; set; }
    }
}
