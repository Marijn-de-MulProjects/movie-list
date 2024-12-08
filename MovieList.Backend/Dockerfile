FROM mcr.microsoft.com/dotnet/sdk:8.0-arm64 AS build  
WORKDIR /app
COPY . .
RUN dotnet restore
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:8.0-arm64  
WORKDIR /app
COPY --from=build /app/out . 

CMD ["sh", "-c", "dotnet ef database update && dotnet DDT.Backend.API.dll"]
