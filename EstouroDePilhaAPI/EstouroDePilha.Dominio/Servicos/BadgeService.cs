﻿using EstouroDePilha.Dominio.Repositórios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EstouroDePilha.Dominio.Entidades;

namespace EstouroDePilha.Dominio.Servicos
{
    public class BadgeService : IBadgeService
    {
        private readonly IUsuarioRepositorio usuarioRepositorio;
        private readonly IBadgeRepositorio badgeRepositorio;

        private static readonly int ID_BADGE_GURI = 7;
        private static readonly int ID_BADGE_FACEIRO = 8;
        private static readonly int ID_BADGE_AMARGO = 9;
        private static readonly int ID_BADGE_TRAMPOSO = 12;
        private static readonly int ID_BADGE_ESGUALEPADO = 13;
        private static readonly int ID_BADGE_PELEADOR = 14;
        private static readonly int ID_BADGE_ENTREVERO = 15;
        private static readonly int ID_BADGE_DE_VEREDA = 16;
        private static readonly int ID_BADGE_PAPUDO = 17;
        private static readonly int ID_BADGE_BAITA_PERGUNTA = 19;
        private static readonly int ID_BADGE_GAUDERIO = 20;
        //private static readonly int ID_BADGE_EMBRETADO = 0;
        private static readonly int ID_BADGE_GURI_APARTAMENTO = 11;
        private static readonly int ID_BADGE_GALO_VEIO = 21;

        public BadgeService(IUsuarioRepositorio usuarioRepositorio, 
                IBadgeRepositorio badgeRepositorio)
        {
            this.usuarioRepositorio = usuarioRepositorio;
            this.badgeRepositorio = badgeRepositorio;
        }

        public void UsuarioRecebeuUpVoteResposta(Usuario usuario, int idPergunta)
        {
            Badge badgeGuri = badgeRepositorio.ObterPorId(ID_BADGE_GURI);
            usuario.AdicionarBadgeGuri(badgeGuri);
            Badge badgePeleador = badgeRepositorio.ObterPorId(ID_BADGE_PELEADOR);
            usuario.AdicionarBadgePeleador(badgePeleador, idPergunta);
            Badge badgeGauderio = badgeRepositorio.ObterPorId(ID_BADGE_GAUDERIO);
            usuario.AdicionarBadgeGauderio(badgeGauderio);
            Badge badgeEsgualepado = badgeRepositorio.ObterPorId(ID_BADGE_ESGUALEPADO);
            usuario.AdicionarBadgeEsgualepado(badgeEsgualepado);

            usuarioRepositorio.Alterar(usuario);
        }

        public void UsuarioRecebeuUpVotePergunta(Usuario usuario, int idPergunta)
        {
            Badge badgeBaitaPergunta = badgeRepositorio.ObterPorId(ID_BADGE_BAITA_PERGUNTA);
            usuario.AdicionarBadgeBaitaPergunta(badgeBaitaPergunta, idPergunta);
            Badge badgeGauderio = badgeRepositorio.ObterPorId(ID_BADGE_GAUDERIO);
            usuario.AdicionarBadgeGauderio(badgeGauderio);
            Badge badgeEsgualepado = badgeRepositorio.ObterPorId(ID_BADGE_ESGUALEPADO);
            usuario.AdicionarBadgeEsgualepado(badgeEsgualepado);

            usuarioRepositorio.Alterar(usuario);
        }

        public void UsuarioRecebeuDownVote(Usuario usuario)
        {
            Badge badgeEsgualepado = badgeRepositorio.ObterPorId(ID_BADGE_ESGUALEPADO);
            usuario.AdicionarBadgeEsgualepado(badgeEsgualepado);

            usuarioRepositorio.Alterar(usuario);
        }

        public void UsuarioDeuUpVote(Usuario usuario)
        {
            Badge badgeFaceiro = badgeRepositorio.ObterPorId(ID_BADGE_FACEIRO);
            List<UpVotePergunta> upVotesPergunta = 
                usuarioRepositorio.ObterUpVotesPerguntaPorUsuario(usuario);
            List<UpVoteResposta> upVotesResposta =
                usuarioRepositorio.ObterUpVotesRespostaPorUsuario(usuario);
            usuario.AdicionarBadgeFaceiro(badgeFaceiro, upVotesPergunta, upVotesResposta);

            usuarioRepositorio.Alterar(usuario);
        }

        public void UsuarioDeuDownVote(Usuario usuario)
        {
            Badge badgeAmargo = badgeRepositorio.ObterPorId(ID_BADGE_AMARGO);
            int quantidadeDownVotes = usuarioRepositorio.QuantidadeDownVotesUsuario(usuario);
            usuario.AdicionarBadgeAmargo(badgeAmargo, quantidadeDownVotes);

            usuarioRepositorio.Alterar(usuario);
        }

        public void UsuarioMarcouRespostaCorreta(Usuario usuario, int idPergunta)
        {
            Badge badgeTramposo = badgeRepositorio.ObterPorId(ID_BADGE_TRAMPOSO);
            Badge badgeDeVereda = badgeRepositorio.ObterPorId(ID_BADGE_DE_VEREDA);
            usuario.AdicionarBadgeDeVereda(badgeDeVereda, idPergunta);
            usuario.AdicionarBadgeTramposo(badgeTramposo);

            usuarioRepositorio.Alterar(usuario);
        }

        public void UsuarioRecebeuResposta(Usuario usuario, int idPergunta)
        {
            Badge badgeEntrevero = badgeRepositorio.ObterPorId(ID_BADGE_ENTREVERO);
            usuario.AdicionarBadgeEntrevero(badgeEntrevero, idPergunta);

            usuarioRepositorio.Alterar(usuario);
        }

        public void UsuarioFezPergunta(Usuario usuario)
        {
            Badge badgePapudo = badgeRepositorio.ObterPorId(ID_BADGE_PAPUDO);
            usuario.AdicionarBadgePapudo(badgePapudo);

            usuarioRepositorio.Alterar(usuario);
        }

        public void UsuarioSeCadastrouHaUmAno(Usuario usuario)
        {            
            var totalVotos = usuarioRepositorio.QuantidadeUpVotesUsuario(usuario)
                    + usuarioRepositorio.QuantidadeDownVotesUsuario(usuario);
            Badge badgeGuriApartamento = badgeRepositorio.ObterPorId(ID_BADGE_GURI_APARTAMENTO);
            usuario.AdicionarbadgeGuriDeApartamento(badgeGuriApartamento, totalVotos);

            usuarioRepositorio.Alterar(usuario);
        }

        public void UsuarioSeCadastrouHaTresAnos(Usuario usuario)
        {
            Badge badgeGaloVeio = badgeRepositorio.ObterPorId(ID_BADGE_GALO_VEIO);
            usuario.AdicionarBadgeGaloVeio(badgeGaloVeio);

            usuarioRepositorio.Alterar(usuario);
        }
    }
}