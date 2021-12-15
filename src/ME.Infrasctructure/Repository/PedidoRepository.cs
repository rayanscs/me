using Dapper;
using ME.Domain.Interface;
using ME.Domain.Model;
using ME.Domain.Model.Http;
using System;
using System.Data;

namespace ME.Infrasctructure.Repository
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly IDbConnection _conn;

        public PedidoRepository(IDbConnection conn)
        {
            _conn = conn;
        }

        public string QuerySelectAll => $@"SELECT PEDIDO_ID {nameof(Pedido.PedidoId)}
                                                    FROM ME.PEDIDOS ";
        public string QuerySelect => $@"SELECT  i.ItemId {nameof(Item.ItemId)},
                                                i.Descricao {nameof(Item.Descricao)}, 
                                                i.PrecoUnitario {nameof(Item.PrecoUnitario)}, 
                                                i.Quantidade {nameof(Item.Quantidade)},
                                                i.PedidoId {nameof(Item.PedidoId)}
                                        FROM ITEM i
                                        INNER JOIN Pedido p ON i.PedidoId = p.PedidoId
                                        WHERE p.PedidoId = @PEDIDO_ID
                                        ORDER BY i.ItemId ";


        public string QueryInsert => $@"";
        public string QueryUpdate => $@"";

        public IResponse ObterStatusPedido()
        {
            var _response = new Response();
            try
            {
                var result = _conn.Query<Pedido>(QueryInsert, new Pedido { });
                _response.SetData(result);
            }
            catch (Exception ex)
            {
                _response.AddNotification($"{ex.GetBaseException().Message}");
            }

            return _response;
        }

        public IResponse ObterPedido(int pedidoId)
        {
            var _response = new Response();

            try
            {
                var result = _conn.Query<Item>(QuerySelect, new { PEDIDO_ID = pedidoId });
                _response.SetData(result);
            }
            catch (Exception ex)
            {
                _response.AddNotification($"{ex.GetBaseException().Message}");
                throw;
            }

            return _response;
        }
    }
}
