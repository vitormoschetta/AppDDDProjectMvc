# Estrutura

###### MVC:
```
AppDDDProject.AppMvc
```

###### ClassLib:
```
AppDDDProject.Shared
AppDDDProject.Domain
AppDDDProject.Infra
```

###### Test:
```
AppDDDProject.Tests 
```

#### Comandos CLI usados na criação dos projetos:
```
dotnet new mvc
dotnet new classlib
dotnet new mstest 
```


#### Adicionar uma solução na raiz: 
```
dotnet new sln
```


#### Vincular os projetos/domínios à solução:
```
dotnet sln add AppDDDProject.Shared/AppDDDProject.Shared.csproj
dotnet sln add AppDDDProject.Domain/AppDDDProject.Domain.csproj
dotnet sln add AppDDDProject.Infra/AppDDDProject.Infra.csproj
dotnet sln add AppDDDProject.Tests/AppDDDProject.Tests.csproj
dotnet sln add AppDDDProject.AppMvc/AppDDDProject.AppMvc.csproj
```


#### Adicionar referência entre os domínios:

- **Domain** faz referência a **Shared**.
- **Infra** faz referência ao **Domain**.
- **AppMvc** faz referência ao **Domain** e **Infra**.
- **Test** faz referência ao **Domain**.

Segue os comandos CLI:

###### Na pasta Domain:
```
dotnet add reference ../AppDDDProject.Shared/AppDDDProject.Shared.csproj
```

###### Na pasta Infra:
```
dotnet add reference ../AppDDDProject.Domain/AppDDDProject.Domain.csproj
```

###### Na pasta AppMvc:
```
dotnet add reference ../AppDDDProject.Domain/AppDDDProject.Domain.csproj
dotnet add reference ../AppDDDProject.Infra/AppDDDProject.Infra.csproj
```

###### Na pasta Teste:
```
dotnet add reference ../AppDDDProject.Domain/AppDDDProject.Domain.csproj
```



## Migrations

As Migrations são geradas a partir do projeto Asp.NET Core Mvc. Porém, para que a pasta Migrations fique localizada no domínio 'Infra', 
é preciso especificar no comando via CLI:

```
dotnet ef migrations add <NomeDaMigration> --project ../AppDDDProject.Infra/AppDDDProject.Infra.csproj
```

# Executar Aplicação:

Se ainda não possui o .NET Core SDK instalado, segue o [link](https://docs.microsoft.com/pt-br/dotnet/core/install/windows?tabs=netcore31) de suporte a instalação.


Obs: instale a versão 3.1

#### AppMvc
Restaurar dependências/pacotes (executar na raiz do projeto)
```
dotnet restore
```

Executar o projeto MVC com o seguinte comando (na pasta da AppMvc):
```
dotnet run
```
Abra a url informada no CLI.
A url é parecida com esta a baixo:
[https://localhost:5001](https://localhost:5001) 









