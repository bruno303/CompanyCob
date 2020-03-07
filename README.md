# CompanyCOB

Versão do .Net Core: 3.1

Para instalar a ferramenta *dotnet-ef* do .NET Core 3.1:
```
dotnet tool install -g dotnet-ef --version 3.1.0
```

* Para atualizar o DB:
```
dotnet ef database update inicio -p CompanyCob.Repository\CompanyCob.Repository.csproj
dotnet ef database update aumentar_tamanho_cpf -p CompanyCob.Repository\CompanyCob.Repository.csproj
```