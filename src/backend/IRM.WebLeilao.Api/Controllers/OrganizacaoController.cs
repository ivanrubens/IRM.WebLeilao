using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using IRM.WebLeilao.Api.Application.ViewModel;
using IRM.WebLeilao.Api.Domain.Models;
using IRM.WebLeilao.Api.Domain.Services;
using IRM.WebLeilao.Api.Infra.CrossCutting.Extensions;
using Microsoft.AspNetCore.Mvc;
using NetDevPack.Identity.Authorization;

namespace IRM.WebLeilao.Api.Controllers
{
    [ApiController]
    [Route("api/organizacao")]
    [CustomAuthorize("Cadastros", "True")]
    public class OrganizacaoController : ControllerBase
    {
        protected readonly IMapper _mapper;
        protected readonly OrganizacaoService _organizacaoService;

        public OrganizacaoController(IMapper mapper,
                                OrganizacaoService organizacaoService)
        {
            _mapper = mapper;
            _organizacaoService = organizacaoService;
        }

        [HttpPost("v1/incluir")]
        public async Task<ActionResult> IncluirAsync([FromBody] OrganizacaoViewModel organizacaoViewModel)
        {
            try
            {
                var organizacao = _mapper.Map<Organizacao>(organizacaoViewModel);
                organizacao.ValidarEntidade();
                if (organizacao.Notifications.Count > 0)
                {
                    return BadRequest(organizacao.Notifications);
                }

                var retorno = await _organizacaoService.Incluir(organizacao);
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
        public async Task<ActionResult> EditarAsync([FromBody] OrganizacaoViewModel organizacaoViewModel)
        {
            try
            {
                var organizacao = _mapper.Map<Organizacao>(organizacaoViewModel);
                organizacao.ValidarEntidade();
                if (organizacao.Notifications.Count > 0)
                {
                    return BadRequest(organizacao.Notifications);
                }
                
                var retorno = await _organizacaoService.Alterar(organizacao);
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
                var organizacao = await _organizacaoService.Excluir(id);
                if (organizacao.Notifications.Count > 0)
                {
                    return Ok(organizacao.Notifications);
                }

                return Ok(organizacao);
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
                var organizacao = await _organizacaoService.ObterPorId(id);
                return Ok(_mapper.Map<OrganizacaoViewModel>(organizacao));
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
                var organizacoes = await _organizacaoService.Obter();
                return Ok(_mapper.Map<IEnumerable<OrganizacaoViewModel>>(organizacoes));
            }
            catch (Exception ex)
            {
                var innerMessage = " [" + ex.InnerException.Message.NullToString() + "] ";
                return BadRequest(new { message = "Falha ao processar a requisição: " + ex.Message + innerMessage });
            }
        }

    }

}