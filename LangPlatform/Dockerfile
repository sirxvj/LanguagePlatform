# Задаем базовый образ
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 as build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

COPY ["LangPlatform.WebApi/LangPlatform.WebApi.csproj","LangPlatform.WebApi/"]
COPY ["LangPlatform.Domain/LangPlatform.Domain.csproj","LangPlatform.Domain/"]
COPY ["LangPlatform.Infrastructure/LangPlatform.Infrastructure.csproj","LangPlatform.Infrastructure/"]
COPY ["LangPlatform.Application/LangPlatform.Application.csproj","LangPlatform.Application/"]

RUN dotnet restore "LangPlatform.WebApi/LangPlatform.WebApi.csproj"
COPY . .
WORKDIR "/src/LangPlatform.WebApi"
RUN dotnet build "LangPlatform.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "LangPlatform.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT [ "dotnet", "LangPlatform.WebApi.dll"]