#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["MealItem.API/MealItem.API.csproj", "MealItem.API/"]
RUN dotnet restore "MealItem.API/MealItem.API.csproj"
COPY . .
WORKDIR "/src/MealItem.API"
RUN dotnet build "MealItem.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MealItem.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MealItem.API.dll"]