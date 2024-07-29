namespace ControleDeVinil.Shared.Modelos.Modelos
{
	public class Produtor
	{
		public int Id { get; set; }
		private string Nome { get; set; }
        private Empresa Empresa { get; set; }
        private string Email { get; set; }
        private string Cargo { get; set; }
        private int Telefone { get; set; }
        private List<Produtor> Conexoes { get; set; }
        private List<Fornecedor> FornecedoresContratados { get; set; }

	}
}
