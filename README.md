# CompanyCOB

Versão do .Net Core: 3.1

## API C#
* Configurar a string de conexão com o banco de dados em: /CompanyCob/backend/CompanyCob.Repository/Data/CobDbContext.cs
* A API está configurada para aplicar todas as migrations quando for executada. No Startup.cs:
```
context.Database.Migrate();
```
* Caso opte por atualizar o banco de dados manualmente:
```
dotnet tool install -g dotnet-ef --version 3.1.0
dotnet ef database update inicio -p CompanyCob.Repository\CompanyCob.Repository.csproj
dotnet ef database update aumentar_tamanho_cpf -p CompanyCob.Repository\CompanyCob.Repository.csproj
dotnet ef database update foreign_keys -p CompanyCob.Repository\CompanyCob.Repository.csproj
```

* Para executar a API certifique-se de estar na pasta **CompanyCob/backend** e digite:

- Windows:
```
dotnet run -p CompanyCob.Api\CompanyCob.Api.csproj
```
- Linux/MAC:
```
dotnet run -p CompanyCob.Api/CompanyCob.Api.csproj
```

* Caso use o postman para testar a API, requisições de exemplo se encontram em: **/CompanyCob/backend/CompanyCob.Api/Samples/postman_collection.json**. Basta importar esse arquivo no postman e será criada uma collection chamada CompanyCob com as requisições de exemplo.

* A API está documentada através do swagger. Para acessar as configurações acesse a url (considerado a rota default):
```
http://localhost:5000/swagger
```

* Para executar os testes unitários das classes de cálculo das dívidas, certifique-se de estar na pasta **CompanyCob/backend** e digite:
```
dotnet test .\CompanyCob.Service.Test\CompanyCob.Service.Test.csproj -l trx
```
Será criado um arquivo com os resultados dos testes em: **CompanyCob/backend/CompanyCob.Service.Test/CompanyCob.Service.Test.csproj/TestResults**