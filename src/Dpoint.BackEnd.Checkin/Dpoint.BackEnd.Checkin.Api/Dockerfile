#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Dpoint.BackEnd.Checkin.Api/Dpoint.BackEnd.Checkin.Api.csproj", "Dpoint.BackEnd.Checkin.Api/"]
COPY ["Dpoint.BackEnd.Checkin.Services/Dpoint.BackEnd.Checkin.Services.csproj", "Dpoint.BackEnd.Checkin.Services/"]
COPY ["Dpoint.BackEnd.Checkin.Common/Dpoint.BackEnd.Checkin.Common.csproj", "Dpoint.BackEnd.Checkin.Common/"]
COPY ["Dpoint.BackEnd.Checkin.Domain/Dpoint.BackEnd.Checkin.Domain.csproj", "Dpoint.BackEnd.Checkin.Domain/"]
RUN dotnet restore "./Dpoint.BackEnd.Checkin.Api/Dpoint.BackEnd.Checkin.Api.csproj"
COPY . .
WORKDIR "/src/Dpoint.BackEnd.Checkin.Api"
RUN dotnet build "./Dpoint.BackEnd.Checkin.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Dpoint.BackEnd.Checkin.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Dpoint.BackEnd.Checkin.Api.dll"]