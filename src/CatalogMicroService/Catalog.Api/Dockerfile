#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/CatalogMicroService/Catalog.Api/Catalog.Api.csproj", "src/CatalogMicroService/Catalog.Api/"]
COPY ["src/CatalogMicroService/Catalog.Application/Catalog.Application.csproj", "src/CatalogMicroService/Catalog.Application/"]
COPY ["src/CatalogMicroService/Catalog.Domain/Catalog.Domain.csproj", "src/CatalogMicroService/Catalog.Domain/"]
COPY ["src/CatalogMicroService/Catalog.Infastructure/Catalog.Infastructure.csproj", "src/CatalogMicroService/Catalog.Infastructure/"]
RUN dotnet restore "./src/CatalogMicroService/Catalog.Api/./Catalog.Api.csproj"
COPY . .
WORKDIR "/src/src/CatalogMicroService/Catalog.Api"
RUN dotnet build "./Catalog.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Catalog.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Catalog.Api.dll"]