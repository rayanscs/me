using ME.Domain.Interface;
using System;
using System.Linq;

namespace ME.Domain.Service
{
    public class ValidacaoService : IValidacaoService
    {
        public bool ValidaSomenteNumeros(string texto)
        {
            if (texto.All(c => Char.IsDigit(c))) return true;

            return false;
        }
    }
}
