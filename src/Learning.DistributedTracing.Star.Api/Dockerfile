#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["src/Learning.DistributedTracing.Star.Api/Learning.DistributedTracing.Star.Api.csproj", "src/Learning.DistributedTracing.Star.Api/"]
COPY ["src/Learning.DistributedTracing.Abstraction/Learning.DistributedTracing.Abstraction.csproj", "src/Learning.DistributedTracing.Abstraction/"]
RUN dotnet restore "src/Learning.DistributedTracing.Star.Api/Learning.DistributedTracing.Star.Api.csproj"
COPY . .
WORKDIR "/src/src/Learning.DistributedTracing.Star.Api"
RUN dotnet build "Learning.DistributedTracing.Star.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Learning.DistributedTracing.Star.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Learning.DistributedTracing.Star.Api.dll"]