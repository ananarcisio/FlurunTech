namespace ControleDeVinil.Shared.Modelos.Modelos
{
	public class Produtor
	{
		public int Id { get; set; }
		public string Nome { get; set; }
		public Empresa Empresa { get; set; }
		public string Email { get; set; }
		public string Cargo { get; set; }
		public int Telefone { get; set; }
		public List<Produtor> Conexoes { get; set; }
		public List<Fornecedor> FornecedoresContratados { get; set; }

	}
}
