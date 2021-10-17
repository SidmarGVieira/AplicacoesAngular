namespace Aplicacoes.Application.Dtos
{
    public class CompraVendaAcaoDto
    {
		public long Id { get; set; }
		public long IdMovimentoDia { get; set; }
		public long IdPapel { get; set; }
		public bool FlCompra { get; set; }
		public int Quantidade { get; set; }
		public decimal VlrUnitario { get; set; }
		public int Sequencia { get; set; }
		public PapelDto Papel { get; set; }
		public MovimentoDiaDto MovimentoDia { get; set; }
    }
}

