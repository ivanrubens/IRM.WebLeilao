﻿// <auto-generated />
using System;
using IRM.WebLeilao.Api.Infra.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace IRM.WebLeilao.Api.Infra.Data.Migrations
{
    [DbContext(typeof(WebLeilaoContext))]
    partial class WebLeilaoContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("webleilao")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("IRM.WebLeilao.Api.Domain.Models.Leilao", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnName("id")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("AlteracaoTimestamp")
                        .HasColumnName("alteracao_timestamp")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid?>("AlteracaoUsuarioId")
                        .HasColumnName("alteracao_usuario_id")
                        .HasColumnType("uuid");

                    b.Property<bool>("Ativo")
                        .HasColumnName("ativo")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("DataAbertura")
                        .HasColumnName("data_abertura")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("DataFinalizacao")
                        .HasColumnName("data_finalizacao")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("ExclusaoTimestamp")
                        .HasColumnName("exclusao_timestamp")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid?>("ExclusaoUsuarioId")
                        .HasColumnName("exclusao_usuario_id")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("InclusaoTimestamp")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("inclusao_timestamp")
                        .HasColumnType("timestamp without time zone")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<Guid>("InclusaoUsuarioId")
                        .HasColumnName("inclusao_usuario_id")
                        .HasColumnType("uuid");

                    b.Property<bool>("ItemUsado")
                        .HasColumnName("item_usado")
                        .HasColumnType("boolean");

                    b.Property<Guid?>("UsuarioResponsavelId")
                        .HasColumnType("uuid");

                    b.Property<decimal>("ValorInicial")
                        .HasColumnName("valor_inicial")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.HasIndex("Ativo");

                    b.HasIndex("InclusaoTimestamp");

                    b.HasIndex("UsuarioResponsavelId");

                    b.ToTable("leilao");
                });

            modelBuilder.Entity("IRM.WebLeilao.Api.Domain.Models.Organizacao", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnName("id")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("AlteracaoTimestamp")
                        .HasColumnName("alteracao_timestamp")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid?>("AlteracaoUsuarioId")
                        .HasColumnName("alteracao_usuario_id")
                        .HasColumnType("uuid");

                    b.Property<bool>("Ativo")
                        .HasColumnName("ativo")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("ExclusaoTimestamp")
                        .HasColumnName("exclusao_timestamp")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid?>("ExclusaoUsuarioId")
                        .HasColumnName("exclusao_usuario_id")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("InclusaoTimestamp")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("inclusao_timestamp")
                        .HasColumnType("timestamp without time zone")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<Guid>("InclusaoUsuarioId")
                        .HasColumnName("inclusao_usuario_id")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("Ativo");

                    b.HasIndex("InclusaoTimestamp");

                    b.ToTable("organizacao");
                });

            modelBuilder.Entity("IRM.WebLeilao.Api.Domain.Models.Pessoa", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnName("id")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("AlteracaoTimestamp")
                        .HasColumnName("alteracao_timestamp")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid?>("AlteracaoUsuarioId")
                        .HasColumnName("alteracao_usuario_id")
                        .HasColumnType("uuid");

                    b.Property<bool>("Ativo")
                        .HasColumnName("ativo")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("ExclusaoTimestamp")
                        .HasColumnName("exclusao_timestamp")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid?>("ExclusaoUsuarioId")
                        .HasColumnName("exclusao_usuario_id")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("InclusaoTimestamp")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("inclusao_timestamp")
                        .HasColumnType("timestamp without time zone")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<Guid>("InclusaoUsuarioId")
                        .HasColumnName("inclusao_usuario_id")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("Ativo");

                    b.HasIndex("InclusaoTimestamp");

                    b.ToTable("pessoa");
                });

            modelBuilder.Entity("IRM.WebLeilao.Api.Domain.Models.Usuario", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnName("id")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("AlteracaoTimestamp")
                        .HasColumnName("alteracao_timestamp")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid?>("AlteracaoUsuarioId")
                        .HasColumnName("alteracao_usuario_id")
                        .HasColumnType("uuid");

                    b.Property<bool>("Ativo")
                        .HasColumnName("ativo")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("ExclusaoTimestamp")
                        .HasColumnName("exclusao_timestamp")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid?>("ExclusaoUsuarioId")
                        .HasColumnName("exclusao_usuario_id")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("InclusaoTimestamp")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("inclusao_timestamp")
                        .HasColumnType("timestamp without time zone")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<Guid>("InclusaoUsuarioId")
                        .HasColumnName("inclusao_usuario_id")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("PessoaId")
                        .HasColumnType("uuid");

                    b.Property<string>("SessaoId")
                        .HasColumnName("sessao_id")
                        .HasColumnType("character varying(150)")
                        .HasMaxLength(150);

                    b.Property<Guid>("UserId")
                        .HasColumnName("user_id")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("Ativo");

                    b.HasIndex("InclusaoTimestamp");

                    b.HasIndex("PessoaId");

                    b.HasIndex("SessaoId");

                    b.HasIndex("UserId");

                    b.ToTable("usuario");
                });

            modelBuilder.Entity("IRM.WebLeilao.Api.Domain.Models.Leilao", b =>
                {
                    b.HasOne("IRM.WebLeilao.Api.Domain.Models.Usuario", "UsuarioResponsavel")
                        .WithMany()
                        .HasForeignKey("UsuarioResponsavelId");

                    b.OwnsOne("IRM.WebLeilao.Api.Domain.ValueObjects.NomeGeral", "NomeLeilao", b1 =>
                        {
                            b1.Property<Guid>("LeilaoId")
                                .HasColumnType("uuid");

                            b1.Property<string>("Nome")
                                .HasColumnType("text");

                            b1.HasKey("LeilaoId");

                            b1.ToTable("leilao");

                            b1.WithOwner()
                                .HasForeignKey("LeilaoId");
                        });
                });

            modelBuilder.Entity("IRM.WebLeilao.Api.Domain.Models.Organizacao", b =>
                {
                    b.OwnsOne("IRM.WebLeilao.Api.Domain.ValueObjects.CNPJ", "CNPJ", b1 =>
                        {
                            b1.Property<Guid>("OrganizacaoId")
                                .HasColumnType("uuid");

                            b1.Property<string>("Numero")
                                .HasColumnType("text");

                            b1.HasKey("OrganizacaoId");

                            b1.ToTable("organizacao");

                            b1.WithOwner()
                                .HasForeignKey("OrganizacaoId");
                        });

                    b.OwnsOne("IRM.WebLeilao.Api.Domain.ValueObjects.NomeFantasia", "NomeFantasia", b1 =>
                        {
                            b1.Property<Guid>("OrganizacaoId")
                                .HasColumnType("uuid");

                            b1.Property<string>("Nome")
                                .HasColumnType("text");

                            b1.HasKey("OrganizacaoId");

                            b1.ToTable("organizacao");

                            b1.WithOwner()
                                .HasForeignKey("OrganizacaoId");
                        });

                    b.OwnsOne("IRM.WebLeilao.Api.Domain.ValueObjects.RazaoSocial", "RazaoSocial", b1 =>
                        {
                            b1.Property<Guid>("OrganizacaoId")
                                .HasColumnType("uuid");

                            b1.Property<string>("Nome")
                                .HasColumnType("text");

                            b1.HasKey("OrganizacaoId");

                            b1.ToTable("organizacao");

                            b1.WithOwner()
                                .HasForeignKey("OrganizacaoId");
                        });
                });

            modelBuilder.Entity("IRM.WebLeilao.Api.Domain.Models.Pessoa", b =>
                {
                    b.OwnsOne("IRM.WebLeilao.Api.Domain.ValueObjects.CPF", "CPF", b1 =>
                        {
                            b1.Property<Guid>("PessoaId")
                                .HasColumnType("uuid");

                            b1.Property<string>("Numero")
                                .HasColumnType("text");

                            b1.HasKey("PessoaId");

                            b1.ToTable("pessoa");

                            b1.WithOwner()
                                .HasForeignKey("PessoaId");
                        });

                    b.OwnsOne("IRM.WebLeilao.Api.Domain.ValueObjects.NomePessoa", "Nome", b1 =>
                        {
                            b1.Property<Guid>("PessoaId")
                                .HasColumnType("uuid");

                            b1.Property<string>("PrimeiroNome")
                                .HasColumnType("text");

                            b1.Property<string>("SobreNome")
                                .HasColumnType("text");

                            b1.HasKey("PessoaId");

                            b1.ToTable("pessoa");

                            b1.WithOwner()
                                .HasForeignKey("PessoaId");
                        });
                });

            modelBuilder.Entity("IRM.WebLeilao.Api.Domain.Models.Usuario", b =>
                {
                    b.HasOne("IRM.WebLeilao.Api.Domain.Models.Pessoa", "Pessoa")
                        .WithMany()
                        .HasForeignKey("PessoaId");
                });
#pragma warning restore 612, 618
        }
    }
}
