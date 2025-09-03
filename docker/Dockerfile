# imagem runtime (final)
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 8080
ENV ASPNETCORE_URLS=http://+:8080

# imagem com SDK usada apenas para compilar/publish
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# copiar o csproj primeiro para aproveitar cache do docker
COPY ["ApiRest-NET9.csproj", "./"]
RUN dotnet restore "ApiRest-NET9.csproj"

# copiar restante do código e publicar (sempre Release)
COPY . .
RUN dotnet publish "ApiRest-NET9.csproj" -c Release -o /app/publish /p:UseAppHost=false

# imagem final apenas com runtime
FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "ApiRest-NET9.dll"]
