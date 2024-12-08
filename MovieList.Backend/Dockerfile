FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY . . 
RUN dotnet restore
RUN dotnet publish -c Release -o /app

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app . 

COPY .env /app/.env

RUN dotnet ef database update --project MovieList.DAL--startup-project MovieList.API --no-build --environment Production

ENTRYPOINT ["dotnet", "MovieList.API.dll"]
