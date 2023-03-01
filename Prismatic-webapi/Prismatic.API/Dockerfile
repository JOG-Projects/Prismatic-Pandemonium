#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Prismatic.API/Prismatic.API.csproj", "Prismatic.API/"]
RUN dotnet restore "Prismatic.API/Prismatic.API.csproj"
COPY . .
WORKDIR "/src/Prismatic.API"
RUN dotnet build "Prismatic.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Prismatic.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Prismatic.API.dll"]