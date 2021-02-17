#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["src/Ordering/Ordering.Api/Ordering.Api.csproj", "src/Ordering/Ordering.Api/"]
COPY ["src/Ordering/Ordering.Application/Ordering.Application.csproj", "src/Ordering/Ordering.Application/"]
COPY ["src/Common/EventBusRabbitMq/EventBusRabbitMq.csproj", "src/Common/EventBusRabbitMq/"]
COPY ["src/Ordering/Ordering.Core/Ordering.Core.csproj", "src/Ordering/Ordering.Core/"]
COPY ["src/Common/Ordering.Infrastructure/Ordering.Infrastructure.csproj", "src/Common/Ordering.Infrastructure/"]
RUN dotnet restore "src/Ordering/Ordering.Api/Ordering.Api.csproj"
COPY . .
WORKDIR "/src/src/Ordering/Ordering.Api"
RUN dotnet build "Ordering.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Ordering.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Ordering.Api.dll"]
