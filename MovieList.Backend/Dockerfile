# Use the .NET SDK image to build the application
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# Set working directory to /src
WORKDIR /src

# Copy the entire project into the container
COPY . .

# Restore dependencies for the application
RUN dotnet restore

# Publish the application in Release mode to /app
RUN dotnet publish -c Release -o /app

# Use the .NET runtime image to run the application
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime

# Set working directory to /app
WORKDIR /app

# Copy the published application from the build stage
COPY --from=build /app .

# Copy the .env file into the /app directory
COPY .env /app/.env

# Set environment variable for production (optional)
ENV ASPNETCORE_ENVIRONMENT=Production

# Run database migrations before starting the app
RUN dotnet ef database update --project /src/MovieList.DAL/MovieList.DAL.csproj --startup-project /src/MovieList.API/MovieList.API.csproj --no-build --environment Production

# Set the entrypoint for the container to run the API
ENTRYPOINT ["dotnet", "MovieList.API.dll"]
