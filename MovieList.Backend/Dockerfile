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
WORKDIR /app
COPY --from=build /app .

ENV ASPNETCORE_ENVIRONMENT=Production

CMD ["sh", "-c", "dotnet MovieList.API.dll || echo 'Runtime Error: $?'"]

ENTRYPOINT ["dotnet", "MovieList.API.dll"]
