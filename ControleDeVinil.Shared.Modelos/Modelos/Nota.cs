namespace ControleDeVinil.Shared.Modelos.Modelos
{
    public class Nota
	{
        public int Id { get; set; }
        private int NotaVal { get; set; }
		private string CargoCriador { get; set; }
		private IAvaliacao Alvo { get; set; }
	}
}
