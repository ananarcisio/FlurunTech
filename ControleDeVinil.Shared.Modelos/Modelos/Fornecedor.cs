namespace ControleDeVinil.Shared.Modelos.Modelos
{
    public class Fornecedor
    {
		public int Id { get; set; }
        private string NomeFantasia { get; set; }
        private string RazaoSocial { get; set; }
        private int CNPJ { get; set; }
        private string Endereco { get; set; }
        private int Numero { get; set; }
        private string Complemento { get; set; }
        private string Bairro { get; set; }
        private string Cidade { get; set; }
        private string Estado { get; set; }
        private string Setor { get; set; }
        private List<Evento> EventosFornecidos{ get; set; }

	}
}
