namespace ME.Domain.Model
{
    public class Item
    {
        public int ItemId { get; set; }
        public string Descricao { get; set; }
        public decimal PrecoUnitario { get; set; }
        public int Quantidade { get; set; }
        public int PedidoId { get; set; }
    }
}
