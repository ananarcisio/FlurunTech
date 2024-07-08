namespace ControleDeVinil.Shared.Modelos.Modelos
{
    public class Empresa
    {
		private int Id { get; set; }
		private string NomeFantasia { get; set; }
		private string RazaoSocial { get; set; }
		private int CNPJ { get; set; }
		private List<Produtor> Funcionarios { get; set; }
		private List<Fornecedor> FornecedoresContratados { get; set; }
		private List<Evento> EventosRealizados { get; set; }

	}
}
