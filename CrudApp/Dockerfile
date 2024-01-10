FROM mcr.microsoft.com/dotnet/sdk:8.0 as build

WORKDIR /CrudApp
COPY ["/CrudApp.csproj", "./"]
RUN dotnet restore "./CrudApp.csproj"
COPY . .
RUN dotnet publish "CrudApp.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS final

RUN apt-get update && apt-get install -y git

RUN git clone https://github.com/vishnubob/wait-for-it.git

RUN dotnet tool install --global dotnet-ef
ENV PATH="$PATH:/root/.dotnet/tools"

WORKDIR /app

COPY --from=build /app/publish .
COPY . /app/source


COPY migrations.sh /migrations.sh

