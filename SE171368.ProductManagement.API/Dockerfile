#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["SE171368.ProductManagement.API/SE171368.ProductManagement.API.csproj", "SE171368.ProductManagement.API/"]
COPY ["SE171368.ProductManagement.Repo/SE171368.ProductManagement.Repo.csproj", "SE171368.ProductManagement.Repo/"]
RUN dotnet restore "SE171368.ProductManagement.API/SE171368.ProductManagement.API.csproj"
COPY . .
WORKDIR "/src/SE171368.ProductManagement.API"
RUN dotnet build "SE171368.ProductManagement.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SE171368.ProductManagement.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SE171368.ProductManagement.API.dll"]