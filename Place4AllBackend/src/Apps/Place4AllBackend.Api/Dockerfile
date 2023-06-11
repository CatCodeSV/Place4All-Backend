#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
#ENV ASPNETCORE_URLS=https://+:5006;http://+:5005
WORKDIR /app
EXPOSE 80
EXPOSE 433

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Apps/Place4AllBackend.Api/Place4AllBackend.Api.csproj", "src/Apps/Place4AllBackend.Api/"]
COPY ["src/Common/Place4AllBackend.Infrastructure/Place4AllBackend.Infrastructure.csproj", "src/Common/Place4AllBackend.Api.Infrastructure/"]
COPY ["src/Common/Place4AllBackend.Application/Place4AllBackend.Application.csproj", "src/Common/Place4AllBackend.Api.Application/"]
COPY ["src/Common/Place4AllBackend.Domain/Place4AllBackend.Domain.csproj", "src/Common/Place4AllBackend.Api.Domain/"]
RUN dotnet restore "src/Apps/Place4AllBackend.Api/Place4AllBackend.Api.csproj"
COPY . .
WORKDIR "/src/src/Apps/Place4AllBackend.Api"
RUN dotnet build "Place4AllBackend.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Place4AllBackend.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Place4AllBackend.Api.dll"]