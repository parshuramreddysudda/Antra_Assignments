FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Product/Product.csproj", "Product/"]
COPY ["Product.ApplicationCore/Product.ApplicationCore.csproj", "Product.ApplicationCore/"]
COPY ["Product.Infrastructure/Product.Infrastructure.csproj", "Product.Infrastructure/"]
RUN dotnet restore "Product/Product.csproj"
COPY . .
WORKDIR "/src/Product"
RUN dotnet build "Product.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Product.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Product.dll"]
