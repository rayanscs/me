using System.Collections.Generic;

namespace ME.Domain.Model
{
    public class ParametroMudancaStatusPedido
    {
        public string PedidoId { get; set; }
        public int ItensAprovados { get; set; }
        public decimal ValorAprovado { get; set; }
        public string Status { get; set; }
    }
}
