using System.ComponentModel;

namespace ME.Domain.Enums
{
    public enum EnumStatusPedido
    {
        [Description("CODIGO_PEDIDO_INVALIDO")]
        Invalido = -1,
        [Description("REPROVADO")]
        Reprovado,
        [Description("APROVADO")]
        Aprovado,
        [Description("APROVADO_VALOR_A_MENOR")] 
        AprovadoValorMenor,
        [Description("APROVADO_VALOR_A_MAIOR")]
        AprovadoValorMaior,
        [Description("APROVADO_QTD_A_MENOR")]
        AprovadoQuantidadeMenor,
        [Description("APROVADO_QTD_A_MAIOR")]
        AprovadoQuantidadeMaior

    }
}
