FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release


WORKDIR /src
COPY ["CompanyApi/CompanyApi.csproj", "CompanyApi/"]
COPY ["Application.UnitTests/Application.UnitTests.csproj", "Application.UnitTests/"]

RUN dotnet restore "CompanyApi/CompanyApi.csproj"
COPY . .
WORKDIR "/src/CompanyApi"
RUN dotnet build "CompanyApi.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS test
WORKDIR "/src/Application.UnitTests"
RUN dotnet test "Application.UnitTests.csproj" -c $BUILD_CONFIGURATION

FROM test AS publish
WORKDIR "/src/CompanyApi"
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "CompanyApi.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CompanyApi.dll"]
