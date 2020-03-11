# CompanyCOB

Versão do .Net Core: 3.1
Porta: 5000
Protocolo: HTTP

## API C#
* Configurar a string de conexão com o banco de dados em: /CompanyCob/backend/CompanyCob.Api/appsettings.json.
```
dotnet ef migrations add nome_migration -p CompanyCob.Repository\ComapnyCob.Repository.csproj
```

* A API está configurada para aplicar todas as migrations quando for executada. No Startup.cs:
```
context.Database.Migrate();
```

Para que isso fosse possível, o CobDbContext foi configurado na injeção de dependência como Transient (sempre instanciar um novo).
Uma aplicação que vai para produção não deve ter suas migrations executadas automaticamente, e removendo isso o CobDbContext pode usar a configuração default (Scoped).

* Caso opte por atualizar o banco de dados manualmente, certifique-se de estar no diretório **CompanyCob/backend** e digite:
Para instalar o dotnet-ef tool
```
dotnet tool install -g dotnet-ef --version 3.1.0
```
Para aplicar as migrations:
```
dotnet ef database update companycob -p CompanyCob.Api\CompanyCob.Api.csproj
```

* Para executar a API certifique-se de estar na pasta **CompanyCob/backend** e digite:

Windows:
```
dotnet run -p CompanyCob.Api\CompanyCob.Api.csproj
```
Linux/MAC:
```
dotnet run -p CompanyCob.Api/CompanyCob.Api.csproj
```

* Caso use o postman para testar a API, requisições de exemplo se encontram em: **/CompanyCob/backend/CompanyCob.Api/Samples/postman_collection.json**. Basta importar esse arquivo no postman e será criada uma collection chamada CompanyCob com as requisições de exemplo.

* A API está documentada através do swagger. Para acessar as configurações acesse a url:
```
http://localhost:5000/swagger
```

* Para executar os testes unitários das classes de cálculo das dívidas, certifique-se de estar na pasta **CompanyCob/backend** e digite:
```
dotnet test .\CompanyCob.Service.Test\CompanyCob.Service.Test.csproj -l trx
```
Será criado um arquivo com os resultados dos testes em: **CompanyCob/backend/CompanyCob.Service.Test/CompanyCob.Service.Test.csproj/TestResults**


## Frontend ReactJs

Versão do ReactJs: 16.12
Porta: 3000
Protocolo: HTTP

* Para iniciar o frontend, certifique-se de estar na pasta **CompanyCob/frontend** e instale as dependências com o gerenciador de pacotes de sua preferência:
```
npm i
-- or
yarn
```
* Após a resolução de todas as dependências, inicie a aplicação com:
```
npm start
-- or
yarn start
```
A configuração da API em c# se encontra em **CompanyCob/frontend/src/service/api.js**, onde é definida a baseURL como **http://localhost:5000**

## Autor

* **Bruno Oliveira** - [Github](https://github.com/bruno303)

## Licença

Este projeto está licenciado sob a licença MIT. Veja o arquivo [LICENSE](https://github.com/bruno303/CompanyCob/blob/master/LICENSE) para mais detalhes.