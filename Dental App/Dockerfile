# Multi stage Docker Image Build

# Build Stage
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /source
COPY . .
RUN dotnet restore "./Dental App.csproj" --disable-parallel
COPY . ./
RUN dotnet publish "./Dental App.csproj" -c release -o /app

# Serve Stage
FROM mcr.microsoft.com/dotnet/sdk:7.0
WORKDIR /app
COPY --from=build /app ./

EXPOSE 5000


ENTRYPOINT ["dotnet", "Dental App.dll"]

