# Build the app
FROM mcr.microsoft.com/dotnet/sdk:8.0 as build

WORKDIR /CrudApp
COPY ["/CrudApp.csproj", "./"]
RUN dotnet restore "./CrudApp.csproj"
COPY . .
RUN dotnet publish "CrudApp.csproj" -c Release -o /app/publish

# Run the app
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final

WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "CrudApp.dll"]