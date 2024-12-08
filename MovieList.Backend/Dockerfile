FROM mcr.microsoft.com/dotnet/aspnet:8.0-bullseye-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:8.0-bullseye AS build
WORKDIR /src
COPY ["MovieList.Backend/MovieList.sln", "MovieList.Backend/"]
RUN dotnet restore "MovieList.Backend/MovieList.sln"
COPY . .
WORKDIR "/src/MovieList.Backend"
RUN dotnet publish "MovieList.sln" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "MovieList.Backend.dll"]
