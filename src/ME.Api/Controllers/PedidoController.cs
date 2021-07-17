using ME.Application.Interface;
using ME.Application.MVVM;
using ME.Domain.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ME.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private IResponse _response;
        private readonly IPedidoAppService _pedidoAppService;

        public PedidoController(IResponse response,                          
                                IPedidoAppService pedidoAppService)
        {
            _response = response;   
            _pedidoAppService = pedidoAppService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        public async Task<IActionResult> Get(string pedidoId)
        {
            try
            {
                _response = _pedidoAppService.ObterPedido(pedidoId);

                if (!_response.Sucesso)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, _response);
                }

                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.SetMensagemPrincipal($"[ERRO][GET]");
                _response.AddNotification($"{ex.Message}");
                return BadRequest(_response);
            }           
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        public async Task<IActionResult> Post(ParametroMudancaStatusPedidoViewModel parametroMudancaStatusPedidoViewModel)
        {
            try
            {
                _response = _pedidoAppService.StatusPedido(parametroMudancaStatusPedidoViewModel);
                return StatusCode(StatusCodes.Status200OK, _response);
            }
            catch (Exception ex)
            {
                _response.SetMensagemPrincipal($"[ERRO][POST]");
                _response.AddNotification($"{ex.Message}");
                return BadRequest(_response);
            }   
        }

    }
}
