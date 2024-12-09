FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["MovieList.API/MovieList.API.csproj", "MovieList.API/"]
COPY ["MovieList.DAL/MovieList.DAL.csproj", "MovieList.DAL/"]
RUN dotnet restore "MovieList.API/MovieList.API.csproj"

COPY . .
WORKDIR /src/MovieList.API
RUN dotnet publish "MovieList.API.csproj" -c Release -o /app

RUN ls /app

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime

RUN apt-get update \
    && apt-get install -y wget ca-certificates gnupg \
    && wget https://packages.microsoft.com/config/ubuntu/20.04/prod.list -O /etc/apt/sources.list.d/microsoft-prod.list \
    && wget -q https://packages.microsoft.com/keys/microsoft.asc -O- | apt-key add - \
    && apt-get update \
    && apt-get install -y dotnet-sdk-8.0

WORKDIR /app
COPY --from=build /app .

ENV ASPNETCORE_ENVIRONMENT=Production

ENTRYPOINT ["dotnet", "MovieList.API.dll"]





