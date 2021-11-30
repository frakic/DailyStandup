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

# Set the locale
FROM postgres:14.1 AS postgres
RUN localedef -i hr_HR -c -f UTF-8 -A /usr/share/locale/locale.alias hr_HR.UTF-8
ENV LANG hr_HR.UTF-8  
ENV LANGUAGE hr_HR:hr  
ENV LC_ALL hr_HR.UTF-8

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
# ENTRYPOINT ["dotnet", "DailyStandup.Api.dll"]
CMD ASPNETCORE_URLS=http://*:$PORT dotnet DailyStandup.Api.dll