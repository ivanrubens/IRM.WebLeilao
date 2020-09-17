using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using IRM.WebLeilao.Api.Domain.Models;
using IRM.WebLeilao.Api.Domain.Services;
using IRM.WebLeilao.Api.Domain.ValueObjects;
using IRM.WebLeilao.Api.Infra.CrossCutting.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IRM.WebLeilao.Api.Controllers
{
    [ApiController]
    [Route("api/pessoa")]
    [Authorize("Admin,Cadastro")]
    public class PessoaController : ControllerBase
    {
        protected readonly IMapper _mapper;
        protected readonly PessoaService _pessoaService;

        public PessoaController(IMapper mapper,
                                PessoaService pessoaService)
        {
            _mapper = mapper;
            _pessoaService = pessoaService;
        }

        [HttpPost("v1/incluir")]
        public async Task<ActionResult> IncluirAsync([FromBody] Pessoa pessoa)
        {
            try
            {
                var retorno = await _pessoaService.Incluir(pessoa);
                if (retorno.Notifications.Count > 0)
                {
                    return Ok(retorno.Notifications);
                }

                return Ok(retorno);
            }
            catch (Exception ex)
            {
                var innerMessage = " [" + ex.Message.NullToString() + "] ";
                return BadRequest(new { message = "Falha ao processar a requisição: " + ex.Message + innerMessage });
            }
        }

        [HttpPut("v1/editar")]
        public async Task<ActionResult> EditarAsync([FromBody] Pessoa pessoa)
        {
            try
            {
                var retorno = await _pessoaService.Alterar(pessoa);
                if (retorno.Notifications.Count > 0)
                {
                    return Ok(retorno.Notifications);
                }

                return Ok(retorno);
            }
            catch (Exception ex)
            {
                var innerMessage = " [" + ex.Message.NullToString() + "] ";
                return BadRequest(new { message = "Falha ao processar a requisição: " + ex.Message + innerMessage });
            }
        }

        [HttpDelete("v1/excluir")]
        public async Task<ActionResult> ExcluirAsync([FromBody] Guid id)
        {
            try
            {
                var retorno = await _pessoaService.Excluir(id);
                if (retorno.Notifications.Count > 0)
                {
                    return Ok(retorno.Notifications);
                }

                return Ok(retorno);
            }
            catch (Exception ex)
            {
                var innerMessage = " [" + ex.Message.NullToString() + "] ";
                return BadRequest(new { message = "Falha ao processar a requisição: " + ex.Message + innerMessage });
            }
        }

        [HttpGet("v1/obter-por-id")]
        public async Task<IActionResult> ObterPorId(Guid id)
        {
            try
            {
                var retorno = await _pessoaService.ObterPorId(id);
                return Ok(_mapper.Map<PessoaViewModel>(retorno));
            }
            catch (Exception ex)
            {
                var innerMessage = " [" + ex.Message.NullToString() + "] ";
                return BadRequest(new { message = "Falha ao processar a requisição: " + ex.Message + innerMessage });
            }
        }

        [HttpGet("v1/obter")]
        public async Task<IActionResult> Obter(Guid id)
        {
            try
            {
                var retorno = await _pessoaService.Obter();
                return Ok(_mapper.Map<IEnumerable<PessoaViewModel>>(retorno));
            }
            catch (Exception ex)
            {
                var innerMessage = " [" + ex.Message.NullToString() + "] ";
                return BadRequest(new { message = "Falha ao processar a requisição: " + ex.Message + innerMessage });
            }
        }

    }

    internal class PessoaViewModel
    {
        public Guid Id { get; set; }
        public CNPJ CNPJ { get; set; }
        public RazaoSocial RazaoSocial { get; set; }
        public NomeFantasia NomeFantasia { get; set; }
    }

}