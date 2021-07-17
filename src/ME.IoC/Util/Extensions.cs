using System.Collections.Generic;
using System.Text;

namespace ME.IoC.Util
{
    public static class Extensions
    {
        public static string ConcatMensagemErros(List<object> lista)
        {
            StringBuilder listaBuilder = new StringBuilder();

            foreach (var l in lista)
            {
                var msg = $"{l} ";
                listaBuilder.Append(msg);
            }

            var stringCompleta = listaBuilder.ToString();
            return stringCompleta;
        }
    }
}
