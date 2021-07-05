using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ME.Domain.Model
{
    public class Pedido
    {
        public int PedidoId { get; set; }
        public DateTime DataInclusao { get; set; }
        public List<Item> Itens { get; set; }
    }
}
