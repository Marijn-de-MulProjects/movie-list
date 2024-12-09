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
RUN apt-get update && apt-get install -y wget
RUN wget https://dotnet.microsoft.com/download/dotnet/thank-you/sdk-8.0-linux-x64-binaries -O dotnet-sdk-8.0.tar.gz
RUN tar -xvf dotnet-sdk-8.0.tar.gz -C /usr/share/dotnet
ENV PATH="/usr/share/dotnet:${PATH}"
WORKDIR /app
COPY --from=build /app .
ENV ASPNETCORE_ENVIRONMENT=Production
ENTRYPOINT ["dotnet", "MovieList.API.dll"]




