#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["src/ApiGetway/OceletAPIGetway/OceletAPIGetway/OceletAPIGetway.csproj", "src/ApiGetway/OceletAPIGetway/OceletAPIGetway/"]
RUN dotnet restore "src/ApiGetway/OceletAPIGetway/OceletAPIGetway/OceletAPIGetway.csproj"
COPY . .
WORKDIR "/src/src/ApiGetway/OceletAPIGetway/OceletAPIGetway"
RUN dotnet build "OceletAPIGetway.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "OceletAPIGetway.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "OceletAPIGetway.dll"]
