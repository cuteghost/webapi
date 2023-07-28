FROM mcr.microsoft.com/dotnet/aspnet:7.0 as base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
COPY . /src
WORKDIR /src

# Pass the secrets as build-time ARGs
ARG DB_SERVER_ARG
ARG DB_NAME_ARG
ARG DB_USER_ARG
ARG DB_PASSWORD_ARG

# Copy the source code
COPY . .

# Use ARGs to set the environment variables
ENV DB_SERVER=$DB_SERVER_ARG
ENV DB_NAME=$DB_NAME_ARG
ENV DB_USER=$DB_USER_ARG
ENV DB_PASSWORD=$DB_PASSWORD_ARG

RUN ls
RUN dotnet build "webapi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "webapi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "webapi.dll"]