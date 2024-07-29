namespace ControleDeVinil.Shared.Modelos.Modelos
{
    public class Evento
    {
        public int Id { get; set; }
        private string Nome { get; set; }
        private DateTime Data { get; set; }
		private string Cidade { get; set; }
		private string Estado { get; set; }
		private List<string> Imagens { get; set; }
		private List<Fornecedor> Fornecedores { get; set; }
		private List<Produtor> Produtores { get; set; }
		private Empresa Empresa { get; set; }
	}
}
