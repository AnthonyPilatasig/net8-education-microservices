FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["CompetencyMapping.Service/CompetencyMapping.Service.csproj", "CompetencyMapping.Service/"]
COPY ["BuildingBlocks.IntegrationEvents/BuildingBlocks.IntegrationEvents.csproj", "BuildingBlocks.IntegrationEvents/"]
RUN dotnet restore "CompetencyMapping.Service/CompetencyMapping.Service.csproj"
COPY . .
WORKDIR "/src/CompetencyMapping.Service"
RUN dotnet build "CompetencyMapping.Service.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CompetencyMapping.Service.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CompetencyMapping.Service.dll"]
