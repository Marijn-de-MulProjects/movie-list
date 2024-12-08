FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /src
COPY ["MovieList.Backend/MovieList.API/MovieList.API.csproj", "MovieList.API/"]
RUN dotnet restore "MovieList.API/MovieList.API.csproj"

COPY . .
WORKDIR "/src/MovieList.API"
RUN dotnet publish -c Release -o /app

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime

WORKDIR /app

COPY --from=build /app .

COPY MovieList.Backend/MovieList.API/.env /app/.env

ENV ASPNETCORE_ENVIRONMENT=Production

RUN dotnet ef database update --project /src/MovieList.DAL/MovieList.DAL.csproj --startup-project /src/MovieList.API/MovieList.API.csproj --no-build

ENTRYPOINT ["dotnet", "MovieList.API.dll"]
