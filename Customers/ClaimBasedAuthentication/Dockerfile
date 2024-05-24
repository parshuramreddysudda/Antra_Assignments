FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["ClaimBasedAuthentication/ClaimBasedAuthentication.csproj", "ClaimBasedAuthentication/"]
COPY ["ApplicationCore/ApplicationCore.csproj", "ApplicationCore/"]
COPY ["Claim.Helper/Claim.Helper.csproj", "Claim.Helper/"]
COPY ["Claim.DTO/Claim.DTO.csproj", "Claim.DTO/"]
COPY ["Claim.Service/Claim.Service.csproj", "Claim.Service/"]
COPY ["Claim.Common/Claim.Common.csproj", "Claim.Common/"]
RUN dotnet restore "ClaimBasedAuthentication/ClaimBasedAuthentication.csproj"
COPY . .
WORKDIR "/src/ClaimBasedAuthentication"
RUN dotnet build "ClaimBasedAuthentication.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "ClaimBasedAuthentication.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ClaimBasedAuthentication.dll"]
