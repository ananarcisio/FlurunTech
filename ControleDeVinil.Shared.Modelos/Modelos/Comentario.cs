namespace ControleDeVinil.Shared.Modelos.Modelos
{
    public class Comentario
	{
        private int Id { get; set; }
		private string Titulo { get; set; }
		private string Conteudo { get; set; }
		private Empresa Empresa { get; set; }
		private IAvaliacao Alvo { get; set; }
		private string CargoCriador { get; set; }

	}
}
