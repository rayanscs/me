using System.Collections.Generic;

namespace ME.Domain.Model
{
    public class RetornoMudancaStatusPedido
    {
        public RetornoMudancaStatusPedido()
        {
            Status = new List<string>();
        }

        public string Pedido { get; set; }
        public List<string> Status { get; set; }
    }
}
