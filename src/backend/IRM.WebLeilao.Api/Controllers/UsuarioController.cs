using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using IRM.WebLeilao.Api.Domain.Models;
using IRM.WebLeilao.Api.Domain.Services;
using IRM.WebLeilao.Api.Infra.CrossCutting.Extensions;
using Microsoft.AspNetCore.Mvc;
using NetDevPack.Identity.Authorization;

namespace IRM.WebLeilao.Api.Controllers
{
    [ApiController]
    [Route("api/usuario")]
    [CustomAuthorize("Cadastros", "True")]
    public class UsuarioController : ControllerBase
    {
        protected readonly IMapper _mapper;
        protected readonly UsuarioService _usuarioService;

        public UsuarioController(IMapper mapper,
                                UsuarioService usuarioService)
        {
            _mapper = mapper;
            _usuarioService = usuarioService;
        }

        [HttpPost("v1/incluir")]
        public async Task<ActionResult> IncluirAsync([FromBody] Usuario usuario)
        {
            try
            {
                var retorno = await _usuarioService.Incluir(usuario);
                retorno.SetarId(usuario.Id);
                
                if (retorno.Notifications.Count > 0)
                {
                    return Ok(retorno.Notifications);
                }

                return Ok(retorno);
            }
            catch (Exception ex)
            {
                var innerMessage = " [" + ex.InnerException.Message.NullToString() + "] ";
                return BadRequest(new { message = "Falha ao processar a requisição: " + ex.Message + innerMessage });
            }
        }

        [HttpPut("v1/editar")]
        public async Task<ActionResult> EditarAsync([FromBody] Usuario usuario)
        {
            try
            {
                var retorno = await _usuarioService.Alterar(usuario);
                if (retorno.Notifications.Count > 0)
                {
                    return Ok(retorno.Notifications);
                }

                return Ok(retorno);
            }
            catch (Exception ex)
            {
                var innerMessage = " [" + ex.InnerException.Message.NullToString() + "] ";
                return BadRequest(new { message = "Falha ao processar a requisição: " + ex.Message + innerMessage });
            }
        }

        [HttpDelete("v1/excluir")]
        public async Task<ActionResult> ExcluirAsync([FromBody] Guid id)
        {
            try
            {
                var retorno = await _usuarioService.Excluir(id);
                if (retorno.Notifications.Count > 0)
                {
                    return Ok(retorno.Notifications);
                }

                return Ok(retorno);
            }
            catch (Exception ex)
            {
                var innerMessage = " [" + ex.InnerException.Message.NullToString() + "] ";
                return BadRequest(new { message = "Falha ao processar a requisição: " + ex.Message + innerMessage });
            }
        }

        [HttpGet("v1/obter-por-id")]
        public async Task<IActionResult> ObterPorId(Guid id)
        {
            try
            {
                var retorno = await _usuarioService.ObterPorId(id);
                return Ok(_mapper.Map<UsuarioViewModel>(retorno));
            }
            catch (Exception ex)
            {
                var innerMessage = " [" + ex.InnerException.Message.NullToString() + "] ";
                return BadRequest(new { message = "Falha ao processar a requisição: " + ex.Message + innerMessage });
            }
        }

        [HttpGet("v1/obter")]
        public async Task<IActionResult> Obter(Guid id)
        {
            try
            {
                var retorno = await _usuarioService.Obter();
                return Ok(_mapper.Map<IEnumerable<UsuarioViewModel>>(retorno));
            }
            catch (Exception ex)
            {
                var innerMessage = " [" + ex.InnerException.Message.NullToString() + "] ";
                return BadRequest(new { message = "Falha ao processar a requisição: " + ex.Message + innerMessage });
            }
        }

    }

    internal class UsuarioViewModel
    {
        public Guid Id { get; set; }
        public Pessoa Pessoa { get; set; }
        public Guid UserId { get; private set; }
    }

}