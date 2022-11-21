# Multi stage Docker Image Build
#----------------------------   1   ----------------------------#


FROM mcr.microsoft.com/dotnet/sdk:6.0.402 AS build-env

WORKDIR /app

COPY *.csproj ./

RUN dotnet restore

COPY . ./

RUN dotnet publish -c Release -o out

#----------------------------   2   ----------------------------#

FROM mcr.microsoft.com/dotnet/sdk:7.0

WORKDIR /app

COPY --from=build-env /app/out .

ENTRYPOINT ["dotnet", "aspnetcoreapp.dll"]

