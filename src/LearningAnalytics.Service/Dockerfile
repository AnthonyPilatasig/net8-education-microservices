FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["LearningAnalytics.Service/LearningAnalytics.Service.csproj", "LearningAnalytics.Service/"]
COPY ["BuildingBlocks.IntegrationEvents/BuildingBlocks.IntegrationEvents.csproj", "BuildingBlocks.IntegrationEvents/"]
RUN dotnet restore "LearningAnalytics.Service/LearningAnalytics.Service.csproj"
COPY . .
WORKDIR "/src/LearningAnalytics.Service"
RUN dotnet build "LearningAnalytics.Service.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "LearningAnalytics.Service.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LearningAnalytics.Service.dll"]
