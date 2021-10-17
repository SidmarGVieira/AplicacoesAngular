namespace Aplicacoes.Domain
{
    public class CompraVendaAcao // : IIdentificavel
	{
		public CompraVendaAcao(long id, long idMovimentoDia, long idPapel, bool flCompra, int quantidade, decimal vlrUnitario, int sequencia)
		{
			Id = id;
			IdMovimentoDia = idMovimentoDia;
			IdPapel = idPapel;
			FlCompra = flCompra;
			Quantidade = quantidade;
			VlrUnitario = vlrUnitario;
			Sequencia = sequencia;
		}

		public long Id { get; set; }
		public long IdMovimentoDia { get; set; }
		public long IdPapel { get; set; }
		public bool FlCompra { get; set; }
		public int Quantidade { get; set; }
		public decimal VlrUnitario { get; set; }
		public int Sequencia { get; set; }
		public Papel Papel { get; set; }
		public MovimentoDia MovimentoDia { get; set; }
	}
}
