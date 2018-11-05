FROM microsoft/aspnetcore:2.0 AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/aspnetcore-build:2.0 AS build
WORKDIR /src
COPY Feature.OHS.Web/Feature.OHS.Web.csproj Feature.OHS.Web/
RUN dotnet restore Feature.OHS.Web/Feature.OHS.Web.csproj
COPY . .
WORKDIR /src/Feature.OHS.Web
RUN dotnet build Feature.OHS.Web.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish Feature.OHS.Web.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Feature.OHS.Web.dll"]
