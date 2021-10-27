#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["order/order.Api.csproj", "order/"]
COPY ["src/Common/EventBusRabbitMQ/EventBusRabbitMQ.csproj", "src/Common/EventBusRabbitMQ/"]
COPY ["order.infrastructure/order.infrastructure.csproj", "order.infrastructure/"]
COPY ["order.core/order.core.csproj", "order.core/"]
COPY ["order.Application/order.Application.csproj", "order.Application/"]
RUN dotnet restore "order/order.Api.csproj"
COPY . .
WORKDIR "/src/order"
RUN dotnet build "order.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "order.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "order.Api.dll"]
