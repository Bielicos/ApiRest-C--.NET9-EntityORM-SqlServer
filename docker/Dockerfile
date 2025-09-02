# docker/Dockerfile-api
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# copiar o .csproj (caminho relativo ao build context: ..)
COPY ["ApiRest-NET9.csproj", "./"]
RUN dotnet restore "ApiRest-NET9.csproj"

# copiar todo o resto do contexto
COPY . .

# se o projeto estiver na raiz, mantenha /src como workdir; se estiver em subpasta, ajuste
WORKDIR "/src"
RUN dotnet build "ApiRest-NET9.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "ApiRest-NET9.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ApiRest-NET9.dll"]
