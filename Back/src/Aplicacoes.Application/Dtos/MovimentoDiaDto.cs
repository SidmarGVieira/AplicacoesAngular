using System;
using System.Collections.Generic;

namespace Aplicacoes.Application.Dtos
{
    public class MovimentoDiaDto
    {
		public MovimentoDiaDto()
		{
			CompraVendaAcoesDTO = new List<CompraVendaAcaoDto>();
		}

		public long Id { get; set; }
		public DateTime DataMovimento { get; set; }
		public Decimal? CustoDia { get; set; }

		public List<CompraVendaAcaoDto> CompraVendaAcoesDTO { get; set; }        
    }
}

