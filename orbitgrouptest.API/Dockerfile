#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["orbitgrouptest.API/orbitgrouptest.API.csproj", "orbitgrouptest.API/"]
RUN dotnet restore "orbitgrouptest.API/orbitgrouptest.API.csproj"
COPY . .
WORKDIR "/src/orbitgrouptest.API"
RUN dotnet build "orbitgrouptest.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "orbitgrouptest.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "orbitgrouptest.API.dll"]