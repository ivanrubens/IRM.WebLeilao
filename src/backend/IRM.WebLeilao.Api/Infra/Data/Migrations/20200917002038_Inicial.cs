using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IRM.WebLeilao.Api.Infra.Data.Migrations
{
    public partial class Inicial : Migration
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
                name: "pessoa",
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
                    CPF_Numero = table.Column<string>(nullable: true),
                    Nome_PrimeiroNome = table.Column<string>(nullable: true),
                    Nome_SobreNome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pessoa", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "usuario",
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
                    PessoaId = table.Column<Guid>(nullable: true),
                    user_id = table.Column<Guid>(nullable: false),
                    sessao_id = table.Column<string>(maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuario", x => x.id);
                    table.ForeignKey(
                        name: "FK_usuario_pessoa_PessoaId",
                        column: x => x.PessoaId,
                        principalSchema: "webleilao",
                        principalTable: "pessoa",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "leilao",
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
                    NomeLeilao_Nome = table.Column<string>(nullable: true),
                    valor_inicial = table.Column<decimal>(nullable: false),
                    item_usado = table.Column<bool>(nullable: false),
                    UsuarioResponsavelId = table.Column<Guid>(nullable: true),
                    data_abertura = table.Column<DateTime>(nullable: false),
                    data_finalizacao = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_leilao", x => x.id);
                    table.ForeignKey(
                        name: "FK_leilao_usuario_UsuarioResponsavelId",
                        column: x => x.UsuarioResponsavelId,
                        principalSchema: "webleilao",
                        principalTable: "usuario",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_leilao_ativo",
                schema: "webleilao",
                table: "leilao",
                column: "ativo");

            migrationBuilder.CreateIndex(
                name: "IX_leilao_inclusao_timestamp",
                schema: "webleilao",
                table: "leilao",
                column: "inclusao_timestamp");

            migrationBuilder.CreateIndex(
                name: "IX_leilao_UsuarioResponsavelId",
                schema: "webleilao",
                table: "leilao",
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
                name: "IX_pessoa_ativo",
                schema: "webleilao",
                table: "pessoa",
                column: "ativo");

            migrationBuilder.CreateIndex(
                name: "IX_pessoa_inclusao_timestamp",
                schema: "webleilao",
                table: "pessoa",
                column: "inclusao_timestamp");

            migrationBuilder.CreateIndex(
                name: "IX_usuario_ativo",
                schema: "webleilao",
                table: "usuario",
                column: "ativo");

            migrationBuilder.CreateIndex(
                name: "IX_usuario_inclusao_timestamp",
                schema: "webleilao",
                table: "usuario",
                column: "inclusao_timestamp");

            migrationBuilder.CreateIndex(
                name: "IX_usuario_PessoaId",
                schema: "webleilao",
                table: "usuario",
                column: "PessoaId");

            migrationBuilder.CreateIndex(
                name: "IX_usuario_sessao_id",
                schema: "webleilao",
                table: "usuario",
                column: "sessao_id");

            migrationBuilder.CreateIndex(
                name: "IX_usuario_user_id",
                schema: "webleilao",
                table: "usuario",
                column: "user_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "leilao",
                schema: "webleilao");

            migrationBuilder.DropTable(
                name: "organizacao",
                schema: "webleilao");

            migrationBuilder.DropTable(
                name: "usuario",
                schema: "webleilao");

            migrationBuilder.DropTable(
                name: "pessoa",
                schema: "webleilao");
        }
    }
}
