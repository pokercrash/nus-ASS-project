# Multi-stage Dockerfile for building and running the .NET 10 application
# Build stage
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

# copy everything and restore
COPY . .
RUN dotnet restore

# Publish the first project found in a subdirectory (common pattern for solutions)
RUN dotnet publish -c Release -o /app/publish $(sh -c 'ls -1 */*.csproj | head -n 1')

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS runtime
WORKDIR /app

COPY --from=build /app/publish .

# create a non-root user and take ownership of /app
RUN groupadd -r app && useradd -r -g app app || true
RUN chown -R app:app /app
USER app

ENV ASPNETCORE_URLS=http://+:80
EXPOSE 80

# entrypoint script will locate the built dll and run it
COPY docker-entrypoint.sh /app/docker-entrypoint.sh
RUN chmod +x /app/docker-entrypoint.sh
ENTRYPOINT ["/app/docker-entrypoint.sh"]
