FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY ["MovieList.API/MovieList.API.csproj", "MovieList.API/"]
COPY ["MovieList.DAL/MovieList.DAL.csproj", "MovieList.DAL/"]
RUN dotnet restore "MovieList.API/MovieList.API.csproj"

COPY . .
RUN dotnet publish "MovieList.API/MovieList.API.csproj" -c Release -o /app

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

COPY --from=build /app . 
COPY .env /app/.env

ENV ASPNETCORE_ENVIRONMENT=Production

RUN dotnet ef database update --project MovieList.DAL --startup-project MovieList.API --no-build

ENTRYPOINT ["dotnet", "MovieList.API.dll"]
