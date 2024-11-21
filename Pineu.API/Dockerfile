#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0-alpine AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0-alpine AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Pineu.API/Pineu.API.csproj", "Pineu.API/"]
COPY ["Pineu.Application/Pineu.Application.csproj", "Pineu.Application/"]
COPY ["Pineu.Domain/Pineu.Domain.csproj", "Pineu.Domain/"]
COPY ["Pineu.Infrastructure/Pineu.Infrastructure.csproj", "Pineu.Infrastructure/"]
COPY ["Pineu.Persistence/Pineu.Persistence.csproj", "Pineu.Persistence/"]
COPY ["Shared/Shared.csproj", "Shared/"]
RUN dotnet restore "./Pineu.API/Pineu.API.csproj"
COPY . .
WORKDIR "/src/Pineu.API"
RUN dotnet build "./Pineu.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Pineu.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Pineu.API.dll"]