FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Prohod.WebApi/Prohod.WebApi.csproj", "Prohod.WebApi/"]
RUN dotnet restore "Prohod.WebApi/Prohod.WebApi.csproj"
COPY . .
WORKDIR "/src/Prohod.WebApi"
RUN dotnet build "Prohod.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Prohod.WebApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Prohod.WebApi.dll"]
