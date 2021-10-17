using System;
using System.Collections.Generic;
using System.Linq;

namespace Aplicacoes.Domain
{
    public class MovimentoDia //: IAggregateRoot
	{
		public MovimentoDia()
		{
			CompraVendaAcoes = new List<CompraVendaAcao>();
		}

		public MovimentoDia(long id, DateTime dataMovimento, Decimal? custoDia) : this()
		{
			Id = id;
			DataMovimento = dataMovimento;
			CustoDia = custoDia;
		}

		public long Id { get; set; }
		public DateTime DataMovimento { get; set; }
		public Decimal? CustoDia { get; set; }

		public ICollection<CompraVendaAcao> CompraVendaAcoes { get; set; }

		public void AddCompraVendaAcao(CompraVendaAcao compraVendaAcao)
		{
			if (compraVendaAcao == null) throw new ArgumentException("Compra ou venda null.");

			CompraVendaAcoes.Add(compraVendaAcao);
		}

		public void UpdateCompraVendaAcao(CompraVendaAcao compraVendaAcao)
		{
			if (compraVendaAcao == null) throw new ArgumentException("Compra ou venda null.");
			if (compraVendaAcao.Id == 0) throw new ArgumentException("Compra ou venda com Id igual a zero (update).");

			var registro = CompraVendaAcoes.FirstOrDefault(x => x.Id == compraVendaAcao.Id);

			registro.IdMovimentoDia = compraVendaAcao.IdMovimentoDia;
			registro.IdPapel = compraVendaAcao.IdPapel;
			registro.FlCompra = compraVendaAcao.FlCompra;
			registro.Quantidade = compraVendaAcao.Quantidade;
			registro.VlrUnitario = compraVendaAcao.VlrUnitario;
			registro.Sequencia = compraVendaAcao.Sequencia;
		}

		public void RemoverCompraVendaAcao(CompraVendaAcao compraVendaAcao)
		{
			if (compraVendaAcao == null) throw new ArgumentException("Código da compra ou venda null.");

			CompraVendaAcoes.Remove(compraVendaAcao);
		}
	}
}
