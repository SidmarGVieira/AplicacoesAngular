import { CompraVendaAcao } from "./CompraVendaAcao";

export interface MovimentoDia {
  id: number;
	dataMovimento: Date;
	custoDia?: number;
	compraVendaAcoes: CompraVendaAcao[];
}
