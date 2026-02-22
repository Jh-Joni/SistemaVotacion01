FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 10000
ENV ASPNETCORE_URLS=http://+:10000

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["SistemaVotacion.API/SistemaVotacion.API.csproj", "SistemaVotacion.API/"]
COPY ["SistemaVotacion01/SistemaVotacion01.csproj", "SistemaVotacion01/"]
RUN dotnet restore "SistemaVotacion.API/SistemaVotacion.API.csproj"
COPY . .
WORKDIR "/src/SistemaVotacion.API"
RUN dotnet build "SistemaVotacion.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SistemaVotacion.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SistemaVotacion.API.dll"]