﻿FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["VariacaoAtivo.API/VariacaoAtivo.API.csproj", "VariacaoAtivo.API/"]
RUN dotnet restore "VariacaoAtivo.API/VariacaoAtivo.API.csproj"
COPY . .
WORKDIR "/src/VariacaoAtivo.API"
RUN dotnet build "VariacaoAtivo.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "VariacaoAtivo.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "VariacaoAtivo.API.dll"]
