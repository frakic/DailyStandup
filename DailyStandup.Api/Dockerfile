# Dockerfile

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["DailyStandup.Api/DailyStandup.Api.csproj", "DailyStandup.Api/"]
RUN dotnet restore "DailyStandup.Api/DailyStandup.Api.csproj"

COPY . .
WORKDIR "/src/DailyStandup.Api"
RUN dotnet build "DailyStandup.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DailyStandup.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DailyStandup.Api.dll"]