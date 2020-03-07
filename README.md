# CompanyCOB

Versão do .Net Core: 3.1

## Para iniciar a API
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

* Agora basta subir a API (assumindo que a pasta atual é: /CompanyCob/backend ):

- Windows:
```
dotnet run -p CompanyCob.Api\CompanyCob.Api.csproj
```
- Linux/MAC:
```
dotnet run -p CompanyCob.Api/CompanyCob.Api.csproj
```

* Caso use o postman para testar a API, requisições de exemplo se encontram em: **/CompanyCob/backend/CompanyCob.Api/Samples/postman_collection.json**. Basta importar esse arquivo no postman e será criada uma collection chamada CompanyCob com as requisições de exemplo.