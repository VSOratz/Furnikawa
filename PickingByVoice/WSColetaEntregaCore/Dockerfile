FROM mcr.microsoft.com/dotnet/core/aspnet:2.1-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.1-stretch AS build
WORKDIR /src
COPY ["WSColetaEntregaCore/WSColetaEntregaCore.csproj", "WSColetaEntregaCore/"]
RUN dotnet restore "WSColetaEntregaCore/WSColetaEntregaCore.csproj"
COPY . .
WORKDIR "/src/WSColetaEntregaCore"
RUN dotnet build "WSColetaEntregaCore.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "WSColetaEntregaCore.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "WSColetaEntregaCore.dll"]