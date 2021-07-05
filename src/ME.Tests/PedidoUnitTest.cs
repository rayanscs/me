using ME.Domain.Enums;
using ME.Domain.Service;
using ME.Tests.Factory;
using Xunit;

namespace ME.Tests
{
    public class PedidoUnitTest
    {

        [Fact]
        [Trait("Pedido", "Aprovado")]
        public void DeveRetornarStatusAprovado()
        {
            #region Arrange
            var pedidoId = "123456";
            var status = EnumStatusPedido.Aprovado.GetDescription();
            var itensAprovados = 3;
            decimal valorAprovado = 20;

            var parametroMudancaStatusPedido = PedidoFactory.CreatePedido(pedidoId, status, itensAprovados, valorAprovado);
            var retornoPedido = PedidoFactory.CreateRetornoPedido(pedidoId);
            var calculoPersistido = PedidoFactory.CreateCalculoPersistido(pedidoId, itensAprovados, valorAprovado);    
            var statusPedidosService = new StatusPedidoService();
            #endregion

            #region Act
            var retorno = statusPedidosService.DefinirStatusPedido(retornoPedido, parametroMudancaStatusPedido, calculoPersistido);
            #endregion

            #region Assert
            Assert.Contains(EnumStatusPedido.Aprovado.GetDescription(), retorno.Status);
            #endregion
        }

        [Fact]
        [Trait("Pedido", "Aprovado Valor Menor")]
        public void DeveRetornarStatusAprovadoValorMenor()
        {
            #region Arrange
            var pedidoId = "123456";
            var status = EnumStatusPedido.Aprovado.GetDescription();
            var itensAprovados = 3;
            decimal valorAprovado = 5;
            var itensAprovadosPersistido = 3;
            decimal valorAprovadoPersistido = 20;

            var parametroMudancaStatusPedido = PedidoFactory.CreatePedido(pedidoId, status, itensAprovados, valorAprovado);
            var retornoPedido = PedidoFactory.CreateRetornoPedido(pedidoId);
            var calculoPersistido = PedidoFactory.CreateCalculoPersistido(pedidoId, itensAprovadosPersistido, valorAprovadoPersistido);
            var statusPedidosService = new StatusPedidoService();
            #endregion

            #region Act
            var retorno = statusPedidosService.DefinirStatusPedido(retornoPedido, parametroMudancaStatusPedido, calculoPersistido);
            #endregion

            #region Assert
            Assert.Contains(EnumStatusPedido.AprovadoValorMenor.GetDescription(), retorno.Status);
            #endregion

        }

        [Fact]
        [Trait("Pedido", "Aprovado Quantidade Menor")]
        public void DeveRetornarStatusAprovadoQuantidaderMenor()
        {
            #region Arrange
            var pedidoId = "123456";
            var status = EnumStatusPedido.Aprovado.GetDescription();
            var itensAprovados = 1;
            decimal valorAprovado = 20;
            var itensAprovadosPersistido = 3;
            decimal valorAprovadoPersistido = 20;

            var parametroMudancaStatusPedido = PedidoFactory.CreatePedido(pedidoId, status, itensAprovados, valorAprovado);
            var retornoPedido = PedidoFactory.CreateRetornoPedido(pedidoId);
            var calculoPersistido = PedidoFactory.CreateCalculoPersistido(pedidoId, itensAprovadosPersistido, valorAprovadoPersistido);
            var statusPedidosService = new StatusPedidoService();
            #endregion

            #region Act
            var retorno = statusPedidosService.DefinirStatusPedido(retornoPedido, parametroMudancaStatusPedido, calculoPersistido);
            #endregion

            #region Assert
            Assert.Contains(EnumStatusPedido.AprovadoQuantidadeMenor.GetDescription(), retorno.Status);
            #endregion
        }

        [Fact]
        [Trait("Pedido", "Aprovado Valor Maior")]
        public void DeveRetornarStatusAprovadoValorMaior()
        {
            #region Arrange
            var pedidoId = "123456";
            var status = EnumStatusPedido.Aprovado.GetDescription();
            var itensAprovados = 3;
            decimal valorAprovado = 30;
            var itensAprovadosPersistido = 3;
            decimal valorAprovadoPersistido = 20;

            var parametroMudancaStatusPedido = PedidoFactory.CreatePedido(pedidoId, status, itensAprovados, valorAprovado);
            var retornoPedido = PedidoFactory.CreateRetornoPedido(pedidoId);
            var calculoPersistido = PedidoFactory.CreateCalculoPersistido(pedidoId, itensAprovadosPersistido, valorAprovadoPersistido);
            var statusPedidosService = new StatusPedidoService();
            #endregion

            #region Act
            var retorno = statusPedidosService.DefinirStatusPedido(retornoPedido, parametroMudancaStatusPedido, calculoPersistido);
            #endregion

            #region Assert
            Assert.Contains(EnumStatusPedido.AprovadoValorMaior.GetDescription(), retorno.Status);
            #endregion
        }

        [Fact]
        [Trait("Pedido", "Aprovado Quantidade Maior")]
        public void DeveRetornarStatusAprovadoQuantidaderMaior()
        {
            #region Arrange
            var pedidoId = "123456";
            var status = EnumStatusPedido.Aprovado.GetDescription();
            var itensAprovados = 10;
            decimal valorAprovado = 20;
            var itensAprovadosPersistido = 3;
            decimal valorAprovadoPersistido = 20;

            var parametroMudancaStatusPedido = PedidoFactory.CreatePedido(pedidoId, status, itensAprovados, valorAprovado);
            var retornoPedido = PedidoFactory.CreateRetornoPedido(pedidoId);
            var calculoPersistido = PedidoFactory.CreateCalculoPersistido(pedidoId, itensAprovadosPersistido, valorAprovadoPersistido);
            var statusPedidosService = new StatusPedidoService();
            #endregion

            #region Act
            var retorno = statusPedidosService.DefinirStatusPedido(retornoPedido, parametroMudancaStatusPedido, calculoPersistido);
            #endregion

            #region Assert
            Assert.Contains(EnumStatusPedido.AprovadoQuantidadeMaior.GetDescription(), retorno.Status);
            #endregion
        }





    }
}
