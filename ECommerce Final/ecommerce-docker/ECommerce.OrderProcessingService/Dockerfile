FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base
USER $APP_UID
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["ECommerce.OrderProcessingService/ECommerce.OrderProcessingService.csproj", "ECommerce.OrderProcessingService/"]
RUN dotnet restore "ECommerce.OrderProcessingService/ECommerce.OrderProcessingService.csproj"
COPY . .
WORKDIR "/src/ECommerce.OrderProcessingService"
RUN dotnet build "ECommerce.OrderProcessingService.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "ECommerce.OrderProcessingService.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ECommerce.OrderProcessingService.dll"]
