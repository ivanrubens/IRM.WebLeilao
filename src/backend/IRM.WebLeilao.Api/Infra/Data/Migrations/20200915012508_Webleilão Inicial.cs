using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IRM.WebLeilao.Api.Infra.Data.Migrations
{
    public partial class WebleilãoInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "webleilao");

            migrationBuilder.CreateTable(
                name: "organizacao",
                schema: "webleilao",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    inclusao_timestamp = table.Column<DateTime>(nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    inclusao_usuario_id = table.Column<Guid>(nullable: false),
                    alteracao_timestamp = table.Column<DateTime>(nullable: true),
                    alteracao_usuario_id = table.Column<Guid>(nullable: true),
                    exclusao_timestamp = table.Column<DateTime>(nullable: true),
                    exclusao_usuario_id = table.Column<Guid>(nullable: true),
                    ativo = table.Column<bool>(nullable: false),
                    CNPJ_Numero = table.Column<string>(nullable: true),
                    RazaoSocial_Nome = table.Column<string>(nullable: true),
                    NomeFantasia_Nome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_organizacao", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Pessoa",
                schema: "webleilao",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    InclusaoTimestamp = table.Column<DateTime>(nullable: false),
                    InclusaoUsuarioId = table.Column<Guid>(nullable: false),
                    AlteracaoTimestamp = table.Column<DateTime>(nullable: true),
                    AlteracaoUsuarioId = table.Column<Guid>(nullable: true),
                    ExclusaoTimestamp = table.Column<DateTime>(nullable: true),
                    ExclusaoUsuarioId = table.Column<Guid>(nullable: true),
                    Ativo = table.Column<bool>(nullable: false),
                    CPF_Numero = table.Column<string>(nullable: true),
                    Nome_PrimeiroNome = table.Column<string>(nullable: true),
                    Nome_SobreNome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pessoa", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                schema: "webleilao",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    InclusaoTimestamp = table.Column<DateTime>(nullable: false),
                    InclusaoUsuarioId = table.Column<Guid>(nullable: false),
                    AlteracaoTimestamp = table.Column<DateTime>(nullable: true),
                    AlteracaoUsuarioId = table.Column<Guid>(nullable: true),
                    ExclusaoTimestamp = table.Column<DateTime>(nullable: true),
                    ExclusaoUsuarioId = table.Column<Guid>(nullable: true),
                    Ativo = table.Column<bool>(nullable: false),
                    PessoaId = table.Column<Guid>(nullable: true),
                    UserId = table.Column<Guid>(nullable: false),
                    SessaoId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuario_Pessoa_PessoaId",
                        column: x => x.PessoaId,
                        principalSchema: "webleilao",
                        principalTable: "Pessoa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Leilao",
                schema: "webleilao",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    InclusaoTimestamp = table.Column<DateTime>(nullable: false),
                    InclusaoUsuarioId = table.Column<Guid>(nullable: false),
                    AlteracaoTimestamp = table.Column<DateTime>(nullable: true),
                    AlteracaoUsuarioId = table.Column<Guid>(nullable: true),
                    ExclusaoTimestamp = table.Column<DateTime>(nullable: true),
                    ExclusaoUsuarioId = table.Column<Guid>(nullable: true),
                    Ativo = table.Column<bool>(nullable: false),
                    NomeLeilao_Nome = table.Column<string>(nullable: true),
                    ValorInicial = table.Column<decimal>(nullable: false),
                    ItemUsado = table.Column<bool>(nullable: false),
                    UsuarioResponsavelId = table.Column<Guid>(nullable: true),
                    DataAbertura = table.Column<DateTime>(nullable: false),
                    DataFinalizacao = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Leilao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Leilao_Usuario_UsuarioResponsavelId",
                        column: x => x.UsuarioResponsavelId,
                        principalSchema: "webleilao",
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Leilao_UsuarioResponsavelId",
                schema: "webleilao",
                table: "Leilao",
                column: "UsuarioResponsavelId");

            migrationBuilder.CreateIndex(
                name: "IX_organizacao_ativo",
                schema: "webleilao",
                table: "organizacao",
                column: "ativo");

            migrationBuilder.CreateIndex(
                name: "IX_organizacao_inclusao_timestamp",
                schema: "webleilao",
                table: "organizacao",
                column: "inclusao_timestamp");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_PessoaId",
                schema: "webleilao",
                table: "Usuario",
                column: "PessoaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Leilao",
                schema: "webleilao");

            migrationBuilder.DropTable(
                name: "organizacao",
                schema: "webleilao");

            migrationBuilder.DropTable(
                name: "Usuario",
                schema: "webleilao");

            migrationBuilder.DropTable(
                name: "Pessoa",
                schema: "webleilao");
        }
    }
}
