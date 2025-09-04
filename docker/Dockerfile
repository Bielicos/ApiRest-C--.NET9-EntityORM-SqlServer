# Base para rodar a aplicação
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 8080
ENV ASPNETCORE_URLS=http://+:8080

# Imagem para build
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# copiar o csproj e restaurar dependências
COPY ["ApiRest-NET9.csproj", "./"]
RUN dotnet restore "ApiRest-NET9.csproj"

# copiar o resto do código e compilar
COPY . .
RUN dotnet build "ApiRest-NET9.csproj" -c Release -o /app/build

# estágio para publish
FROM build AS publish
RUN dotnet publish "ApiRest-NET9.csproj" -c Release -o /app/publish /p:UseAppHost=false

# estágio final: runtime enxuto
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ApiRest-NET9.dll"]
