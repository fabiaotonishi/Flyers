#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Flyers.Api/Flyers.Api.Autenticacao/Flyers.Api.Autenticacao.csproj", "Flyers.Api/Flyers.Api.Autenticacao/"]
RUN dotnet restore "Flyers.Api/Flyers.Api.Autenticacao/Flyers.Api.Autenticacao.csproj"
COPY . .
WORKDIR "/src/Flyers.Api/Flyers.Api.Autenticacao"
RUN dotnet build "Flyers.Api.Autenticacao.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Flyers.Api.Autenticacao.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Flyers.Api.Autenticacao.dll"]