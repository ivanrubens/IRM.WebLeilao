using System;
using System.Threading.Tasks;
using AutoMapper;
using Flunt.Notifications;
using IRM.WebLeilao.Api.Domain.Models;
using IRM.WebLeilao.Api.Infra.Data.Repositories;

namespace IRM.WebLeilao.Api.Domain.Services
{
    public class UsuarioService : Notifiable
    {
        private readonly IMapper _mapper;
        private readonly UsuarioRepository _usuarioRepository;

        public UsuarioService(IMapper mapper,
                              UsuarioRepository usuarioRepository)
        {
            _mapper = mapper;
            _usuarioRepository = usuarioRepository;
        }

        public async Task Incluir(Usuario entity)
        {
            await _usuarioRepository.Incluir(entity);
        }

        public async Task Alterar(Usuario entity)
        {
            await _usuarioRepository.Alterar(entity);
        }

        public async Task Excluir(Guid id)
        {
            await _usuarioRepository.Excluir(id);
        }

        public async Task<Usuario> ObterPorId(Guid id)
        {
            return await _usuarioRepository.ObterPorId(id);
        }

        public async Task<Usuario> Autenticar(Usuario usuario)
        {
            // TODO: Pendencia
            //var resul = await Task.Run(() => usuario.Autenticar());
            return null;
        }
    }
}