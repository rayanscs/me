using ME.Domain.Enums;
using ME.Domain.Interface;
using ME.Domain.Model;
using System.Linq;

namespace ME.Domain.Service
{
    public class StatusPedidoService : IStatusPedidoService
    {
        public RetornoMudancaStatusPedido DefinirStatusPedido(RetornoMudancaStatusPedido retornoPedido, ParametroMudancaStatusPedido parametroMudancaStatusPedido, ParametroMudancaStatusPedido calculoPersistido)
        {
            string statusValorAprovado = parametroMudancaStatusPedido.ValorAprovado switch
            {
                _ when ((double)parametroMudancaStatusPedido.ValorAprovado) < ((double)calculoPersistido.ValorAprovado) => EnumStatusPedido.AprovadoValorMenor.GetDescription(),
                _ when ((double)parametroMudancaStatusPedido.ValorAprovado) > ((double)calculoPersistido.ValorAprovado) => EnumStatusPedido.AprovadoValorMaior.GetDescription(),
                _ => string.Empty
            };

            string statusItensAprovados = parametroMudancaStatusPedido.ValorAprovado switch
            {
                _ when parametroMudancaStatusPedido.ItensAprovados < calculoPersistido.ItensAprovados => EnumStatusPedido.AprovadoQuantidadeMenor.GetDescription(),
                _ when parametroMudancaStatusPedido.ItensAprovados > calculoPersistido.ItensAprovados => EnumStatusPedido.AprovadoQuantidadeMaior.GetDescription(),
                _ => string.Empty
            };

            if (!string.IsNullOrWhiteSpace(statusValorAprovado))
            {
                retornoPedido.Status.Add(statusValorAprovado);
            }

            if (!string.IsNullOrWhiteSpace(statusItensAprovados))
            {
                retornoPedido.Status.Add(statusItensAprovados);
            }

            if (!retornoPedido.Status.Any())
            {
                retornoPedido.Status.Add(EnumStatusPedido.Aprovado.GetDescription());
            }

            return retornoPedido;
        }

    }
}
