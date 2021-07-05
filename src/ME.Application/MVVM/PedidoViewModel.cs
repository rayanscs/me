using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel;

namespace ME.Application.MVVM
{
    public class PedidoViewModel
    {
        [DisplayName("pedido")]
        public string Pedido { get; set; }

        [JsonProperty("itens")]
        public List<ItemViewModel> Itens { get; set; }
    }
}
