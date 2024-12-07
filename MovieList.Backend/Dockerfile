FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["MovieList.API/MovieList.API.csproj", "MovieList.API/"]
COPY ["MovieList.DAL/MovieList.DAL.csproj", "MovieList.DAL/"]
RUN dotnet restore "MovieList.API/MovieList.API.csproj"
COPY . .
WORKDIR /src/MovieList.API
RUN dotnet publish -c Release -o /app

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app .

COPY MovieList.API/.env /app/.env

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS migration
WORKDIR /app
COPY --from=build /app .

RUN dotnet ef database update --project /app/MovieList.DAL --startup-project /app/MovieList.API --no-build

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app .

ENV ASPNETCORE_ENVIRONMENT=Production

ENTRYPOINT ["dotnet", "MovieList.API.dll"]
