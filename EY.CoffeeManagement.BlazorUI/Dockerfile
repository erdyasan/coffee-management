FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["EY.CoffeeManagement.BlazorUI/EY.CoffeeManagement.BlazorUI.csproj", "EY.CoffeeManagement.BlazorUI/"]
RUN dotnet restore "EY.CoffeeManagement.BlazorUI/EY.CoffeeManagement.BlazorUI.csproj"
COPY . .
WORKDIR "/src/EY.CoffeeManagement.BlazorUI"
RUN dotnet build "EY.CoffeeManagement.BlazorUI.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "EY.CoffeeManagement.BlazorUI.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EY.CoffeeManagement.BlazorUI.dll"]
