using AutoMapper;
using ME.Application.MVVM;
using ME.Domain.Model;

namespace ME.Application
{
    public class CustomResolver : IValueResolver<Item, PedidoViewModel, int>
    {
        public int Resolve(Item source, PedidoViewModel destination, int PedidoId, ResolutionContext context)
        {
            return source.PedidoId;
        }
    }
}
