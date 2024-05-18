
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["TechChallengeFIAP.Api/TechChallengeFIAP.Api.csproj", "TechChallengeFIAP.Api/"]
COPY ["TechChallengeFIAP.Domain/TechChallengeFIAP.Domain.csproj", "TechChallengeFIAP.Domain/"]
COPY ["TechChallengeFiap.Integrations/TechChallengeFiap.Integrations.csproj", "TechChallengeFiap.Integrations/"]
COPY ["TechChallengeFIAP.Infra/TechChallengeFIAP.Infra.csproj", "TechChallengeFIAP.Infra/"]
RUN dotnet restore "./TechChallengeFIAP.Api/TechChallengeFIAP.Api.csproj"
COPY . .
WORKDIR "/src/TechChallengeFIAP.Api"
RUN dotnet build "./TechChallengeFIAP.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./TechChallengeFIAP.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
COPY EstruturaDataBase.sql /docker-entrypoint-initdb.d/EstruturaDataBase.sql
ENTRYPOINT ["dotnet", "TechChallengeFIAP.Api.dll"]