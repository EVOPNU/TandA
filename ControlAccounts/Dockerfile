#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ControlAccounts.csproj ControlAccounts.csproj
RUN dotnet restore ControlAccounts.csproj
COPY . .
WORKDIR /src
RUN dotnet build ControlAccounts.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish ControlAccounts.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "ControlAccounts.dll"]