# IRM.WebLeilao

ARQUITETURA
-----------

	- Back: .Net Core 3.1

		- Padroes
			- Entity
			- Domain
			- Validation
			- ModelView / ViewModel
			- Repository (generic)

		- Frameworks
			- EF Core
			- Flunt (validations)
			- Identity
			- JWT
			- NetDevPack
			- Dapper

		- Outros
			- Testes unidade (MS Test)
			- SOLID
			- Abordagem 'Dominio Rico' 
			- Banco de Dados: Postgres

	- Front: Angular 5


ESTRUTURA FISICA/LOGICA
-----------------------

	IRM.Leilao
		. src
			. back
				. IRM.Leilao.Api
				. IRM.Leilao.Identity
				
			. front
				. IRM.Leilao.Spa
			
			
MODULOS/FUNCIONALIDADES
-----------------------
	- Login
		. Autenticar (somente ativos)

	- Logout
		. Logoff

	- Cadastro de Leilao
		. Cadastrar
		. Visualizar
		. Editar
		. Excluir
	
	- Listagem de Leiloes
	
	