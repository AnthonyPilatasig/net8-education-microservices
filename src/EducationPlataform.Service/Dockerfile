FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["EducationPlataform.Service.csproj", "."]
RUN dotnet restore "EducationPlataform.Service.csproj"
COPY . .
RUN dotnet build "EducationPlataform.Service.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "EducationPlataform.Service.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EducationPlataform.Service.dll"]