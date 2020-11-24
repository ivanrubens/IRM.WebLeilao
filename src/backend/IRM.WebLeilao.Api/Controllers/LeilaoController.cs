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
    [Route("api/leilao")]
    [CustomAuthorize("Cadastros", "True")]
    public class LeilaoController : ControllerBase
    {
        protected readonly IMapper _mapper;
        protected readonly LeilaoService _leilaoService;

        public LeilaoController(IMapper mapper,
                                LeilaoService leilaoService)
        {
            _mapper = mapper;
            _leilaoService = leilaoService;
        }

        [HttpPost("v1/incluir")]
        public async Task<ActionResult> IncluirAsync([FromBody] Leilao leilao)
        {
            try
            {
                var retorno = await _leilaoService.Incluir(leilao);
                retorno.SetarId(leilao.Id);
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
        public async Task<ActionResult> EditarAsync([FromBody] Leilao leilao)
        {
            try
            {
                var retorno = await _leilaoService.Alterar(leilao);
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
                var retorno = await _leilaoService.Excluir(id);
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
                var retorno = await _leilaoService.ObterPorId(id);
                return Ok(_mapper.Map<LeilaoViewModel>(retorno));
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
                var retorno = await _leilaoService.Obter();
                return Ok(_mapper.Map<IEnumerable<LeilaoViewModel>>(retorno));
            }
            catch (Exception ex)
            {
                var innerMessage = " [" + ex.InnerException.Message.NullToString() + "] ";
                return BadRequest(new { message = "Falha ao processar a requisição: " + ex.Message + innerMessage });
            }
        }

    }

    internal class LeilaoViewModel
    {
        public Guid Id { get; set; }
        public string NomeLeilao { get; set; }
        public decimal ValorInicial { get; set; }
        public bool ItemUsado { get; set; }
        public string UsuarioResponsavel { get; set; }
        public DateTime DataAbertura { get; set; }
        public DateTime DataFinalizacao { get; set; }
        public bool Finalizado { get; set; }
    }

}