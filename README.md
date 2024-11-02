# Como Rodar o Projeto

Estamos utilizando **SQL Server** como banco de dados da aplicação. Você pode instalar o [**SQL Server 2022**](https://www.microsoft.com/pt-br/sql-server/sql-server-downloads) diretamente ou usar o [**Docker**](https://docs.docker.com/desktop/install/windows-install/). (mais fácil e foi o método que utilizei).

## Instalando o SQL Server com Docker

Para usar o Docker, basta executar o seguinte comando no terminal após a instalação:

```console
docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=,zrN^E4@@00K" -p 1433:1433 --name squad4 -d mcr.microsoft.com/mssql/server:2022-latest
```
Após executar o comando, entre na pasta do projeto (`Squad-4/CadastroCashback`) pelo terminal e execute o comando:

```console
dotnet ef database update
```

# Executando a Aplicação
Depois que o banco estiver em execução, basta iniciar a aplicação normalmente.
