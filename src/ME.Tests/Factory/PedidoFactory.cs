using Bogus;
using ME.Domain.Enums;
using ME.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ME.Tests.Factory
{
    public static class PedidoFactory
    {
        public static ParametroMudancaStatusPedido CreatePedido(string pedidoId, string status, int itensAprovados, decimal valorAprovado)
        {
            var pedido = new Faker<ParametroMudancaStatusPedido>()
                .RuleFor(c => c.PedidoId, f => pedidoId)
                .RuleFor(c => c.ItensAprovados, f => itensAprovados)
                .RuleFor(c => c.ValorAprovado, f => valorAprovado)
                .RuleFor(c => c.Status, f => status)
                .Generate();
            return pedido;
        }


        public static RetornoMudancaStatusPedido CreateRetornoPedido(string pedido)
        {
            var retorno = new Faker<RetornoMudancaStatusPedido>()
                .RuleFor(c => c.Pedido, f => pedido)
                .RuleFor(c => c.Status, f => new List<string>());

            return retorno;
        }

        public static ParametroMudancaStatusPedido CreateCalculoPersistido(string pedidoId, int itensAprovados, decimal valorAprovado)
        {
            var pedido = new Faker<ParametroMudancaStatusPedido>()
                .RuleFor(c => c.PedidoId, f => pedidoId)
                .RuleFor(c => c.ItensAprovados, f => itensAprovados)
                .RuleFor(c => c.ValorAprovado, f => valorAprovado)
                .RuleFor(c => c.Status, f => string.Empty)
                .Generate();
            return pedido;
        }

        public static RetornoMudancaStatusPedido CreateRetornoAprovado(string pedidoId)
        {
            var pedidoAprovado = new Faker<RetornoMudancaStatusPedido>()
                .RuleFor(c => c.Pedido, f => pedidoId)
                .RuleFor(c => c.Status, f => new List<string> { EnumStatusPedido.Aprovado.GetDescription() })
                .Generate();

            return pedidoAprovado;
        }

    }
}
