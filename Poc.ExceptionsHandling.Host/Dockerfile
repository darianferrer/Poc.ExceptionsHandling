#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Poc.ExceptionsHandling.Host/Poc.ExceptionsHandling.Host.csproj", "Poc.ExceptionsHandling.Host/"]
RUN dotnet restore "Poc.ExceptionsHandling.Host/Poc.ExceptionsHandling.Host.csproj"
COPY . .
WORKDIR "/src/Poc.ExceptionsHandling.Host"
RUN dotnet build "Poc.ExceptionsHandling.Host.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Poc.ExceptionsHandling.Host.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Poc.ExceptionsHandling.Host.dll"]