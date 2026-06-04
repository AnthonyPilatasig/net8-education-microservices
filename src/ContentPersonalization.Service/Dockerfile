FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["ContentPersonalization.Service/ContentPersonalization.Service.csproj", "ContentPersonalization.Service/"]
COPY ["BuildingBlocks.IntegrationEvents/BuildingBlocks.IntegrationEvents.csproj", "BuildingBlocks.IntegrationEvents/"]
RUN dotnet restore "ContentPersonalization.Service/ContentPersonalization.Service.csproj"
COPY . .
WORKDIR "/src/ContentPersonalization.Service"
RUN dotnet build "ContentPersonalization.Service.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ContentPersonalization.Service.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ContentPersonalization.Service.dll"]
