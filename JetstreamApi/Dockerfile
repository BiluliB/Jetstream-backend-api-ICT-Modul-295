# Verwenden Sie das .NET 7.0 SDK-Image, um die Anwendung zu bauen
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env
WORKDIR /app

# Kopieren Sie die csproj-Datei und stellen Sie die NuGet-Pakete wieder her
COPY ["JetstreamApi.csproj", "./"]
RUN dotnet restore "./JetstreamApi.csproj"

# Kopieren Sie den gesamten Quellcode in den Container
COPY . ./

# Kompilieren und Bauen der Anwendung
RUN dotnet build "JetstreamApi.csproj" -c Release -o /app/build

FROM build-env AS publish
RUN dotnet publish "JetstreamApi.csproj" -c Release -o /app/publish

# Das finale Image basiert auf dem .NET 7.0 Runtime-Image
FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app
COPY --from=publish /app/publish .
COPY ./entrypoint.sh .
ENTRYPOINT ["./entrypoint.sh"]
