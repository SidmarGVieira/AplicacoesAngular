namespace Aplicacoes.Domain
{
    public class ValorResultado //: IIdentificavel
    {
        public long Id { get; set; }

        public long IdCompraVendaAcao  { get; set; }
        public decimal ValorOperacao { get; set; }
        public decimal RateioCusto { get; set; }
        public decimal TotalLiquido { get; set; }
        public decimal? ValorCustoLiq { get; set; }
        public int? QtdDayTrade { get; set; }
        public decimal? ValorOperDayTrade { get; set; }
        public decimal? ValorLucroDayTrade { get; set; }
        public int? QtdSwingTrade { get; set; }
        public decimal? ValorOperSwingTrade { get; set; }
        public decimal? ValorLucroSwingTrade { get; set; }
        public decimal? ValorCustoMedio { get; set; }
        public CompraVendaAcao CompraVendaAcao { get; set; }

    }
}
