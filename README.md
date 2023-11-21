## Jetstream Backend API für ICT-Modul 295

### Überblick

Die Jetstream Backend API ist eine ASP.NET Core Web API, die speziell für das ICT-Modul 295 entwickelt wurde. Sie ermöglicht die effiziente Verwaltung von Serviceanfragen und Benutzerinteraktionen.

### Hauptfunktionen

- **Serviceanfragen**: Umfasst Funktionen zum Erstellen, Abrufen, Aktualisieren und Löschen von Serviceanfragen.
- **Benutzerverwaltung**: Bietet Funktionen für Benutzerregistrierung, Login und Authentifizierung.

### Technologie-Stack

- Verwendung von ASP.NET Core und Entity Framework Core.

# Setup und Installation der Jetstream Backend API

## Voraussetzungen:

- Installieren Sie .NET 7.0 SDK von der offiziellen [.NET-Website](https://dotnet.microsoft.com/download).
- Ein geeigneter Code-Editor, wie Visual Studio oder Visual Studio Code.
- SQL Server oder ein äquivalenter Datenbankdienst.

## Projekt klonen oder herunterladen:

- Laden Sie das Projekt herunter oder klonen Sie es aus dem Repository.

## Abhängigkeiten installieren:

- Öffnen Sie die Kommandozeile oder das Terminal im Projektverzeichnis.
- Führen Sie den Befehl `dotnet restore` aus, um alle erforderlichen NuGet-Pakete zu installieren.

## Datenbankkonfiguration:

- Passen Sie die Verbindungszeichenfolge in der Datei `appsettings.json` an, um Ihre Datenbankkonfiguration widerzuspiegeln.
- Verwenden Sie Entity Framework Core Migrations, um die Datenbank zu erstellen und zu initialisieren:
  - Führen Sie `dotnet ef migrations add InitialCreate` aus, um eine Erstmigration zu erstellen.
  - Führen Sie `dotnet ef database update` aus, um die Datenbank basierend auf den Migrationen zu erstellen.

## Starten der Anwendung:

- Starten Sie die Anwendung mit `dotnet run`.
- Die API sollte nun auf dem standardmäßigen oder konfigurierten Port laufen und über einen Webbrowser oder einen API-Client wie Postman erreichbar sein.

## Weitere Konfigurationen:

- Passen Sie die Einstellungen in `appsettings.json` und `appsettings.Development.json` für Entwicklung und Produktion an.
- Überprüfen Sie die Konfigurationen für Logging, Sicherheit und andere Services.

## Testen der Jetstream Backend API

### Testen mit Postman

- **Postman Collection**: Eine Postman Collection wurde für die API erstellt, um die verschiedenen Endpunkte zu testen. Die Collection enthält vordefinierte Anfragen für die verschiedenen API-Funktionen.
- **Importieren der Collection**: Importieren Sie die bereitgestellte JSON-Datei in Postman, um die Endpunkte schnell und effizient zu testen.

### Testen mit Swagger

- **Swagger-Integration**: Swagger ist in die API integriert und ermöglicht das Testen der Endpunkte über eine benutzerfreundliche Oberfläche.
- **API-Dokumentation**: Swagger bietet nicht nur eine Möglichkeit, die API zu testen, sondern stellt auch eine detaillierte Dokumentation der Endpunkte und ihrer Parameter zur Verfügung.
- **Zugriff auf Swagger**: Um Swagger zu nutzen, starten Sie die API und navigieren Sie im Webbrowser zur Swagger-UI-URL (normalerweise `http://localhost:<port>/swagger`).

### Unit-Tests

- **Login-Test**: Es wurde ein Unit-Test für die Überprüfung des Login-Vorgangs implementiert.
- **Eingeschränkte Testabdeckung**: Aufgrund von zeitlichen Einschränkungen wurde nur ein begrenzter Satz von Unit-Tests erstellt. Diese dienen zur Demonstration und sind ein Ausgangspunkt für eine umfassendere Testabdeckung in Zukunft.
- **Testausführung**: Führen Sie die Unit-Tests über Ihren Entwicklungsumgebung oder über die Kommandozeile mit `dotnet test` aus.

### Hinweis

- Es ist empfehlenswert, die Testabdeckung zu erweitern, um die Zuverlässigkeit und Stabilität der API zu gewährleisten. In zukünftigen Iterationen des Projekts sollte das Hinzufügen weiterer Unit-Tests und Integrationstests in Betracht gezogen werden.

### API-Endpunkte

#### Serviceanfragen

- `GET /api/ServiceRequests`: Abrufen aller Serviceanfragen.
- `GET /api/ServiceRequests/{id}`: Abrufen einer spezifischen Serviceanfrage.
- `POST /api/ServiceRequests`: Erstellen einer neuen Serviceanfrage.
- `PUT /api/ServiceRequests/{id}`: Aktualisieren einer Serviceanfrage.
- `DELETE /api/ServiceRequests/{id}`: Löschen einer Serviceanfrage.

#### Benutzer

- `POST /api/users/login`: Login für Benutzer.
- `POST /api/users/create`: Erstellung eines neuen Benutzers.

### Datenmodelle

- `ServiceRequest`: Modell für Serviceanfragen.
- `User`: Benutzermodell.

### Services

- `ServiceRequestService`: Verwaltung von Serviceanfragen.
- `UserService`: Verwaltung von Benutzerdaten.

### Sicherheit

Die Sicherheitsmaßnahmen in der Jetstream Backend API umfassen verschiedene Aspekte, die sich auf Authentifizierung, Autorisierung und allgemeine Sicherheitspraktiken beziehen.

#### Authentifizierung und Autorisierung

- **UsersController**: Verwaltet Benutzerregistrierung und Login.
- **TokenService**: Implementiert Token-basierte Authentifizierung, vermutlich mit JWT.
- **User-Modell**: Enthält möglicherweise Rollen- oder Berechtigungsinformationen für Autorisierungszwecke.

#### Sicherheitsbezogene Middleware

- **ExceptionHandlingMiddleware**: Hilft bei der sicheren Handhabung von Ausnahmen, um interne Details zu schützen.

#### Datenbankzugriff und -sicherheit

- **ApplicationDbContext**: Verwendet Entity Framework Core für sichere Datenbanktransaktionen und Abfragen.

#### API-Sicherheitspraktiken

- Sicherheitsüberprüfungen in den Controllern, um den Zugriff auf Ressourcen und Aktionen zu steuern.

#### Hinweise

- Korrekte Implementierung von Authentifizierungs- und Autorisierungsmechanismen ist essentiell.
- Verschlüsselung von sensiblen Daten und sichere Speicherung von Passwörtern sind wichtige Sicherheitsaspekte.

### Mitwirkende

Die Entwicklung der Jetstream Backend API wurde von:

- **BiluliB** - Entwickler und Projektleiter

erstellt.

### Framework- und NuGet-Abhängigkeiten

- **Target Framework**: .NET 7.0
- **NuGet-Pakete**:
  - `Microsoft.AspNetCore.Authentication.JwtBearer` (Version 7.0.14)
  - `Microsoft.AspNetCore.OpenApi` (Version 7.0.13)
  - `Microsoft.EntityFrameworkCore` (Version 7.0.13)
  - `Microsoft.EntityFrameworkCore.Design` (Version 7.0.13)
  - `Microsoft.EntityFrameworkCore.Proxies` (Version 7.0.13)
  - `Microsoft.EntityFrameworkCore.SqlServer` (Version 7.0.13)
  - `Microsoft.EntityFrameworkCore.Tools` (Version 7.0.13)
  - `Microsoft.IdentityModel.Tokens` (Version 7.0.3)
  - `Serilog.AspNetCore` (Version 7.0.0)
  - `Serilog.Settings.Configuration` (Version 7.0.1)
  - `Serilog.Sinks.File` (Version 5.0.0)
  - `Swashbuckle.AspNetCore` (Version 6.5.0)
  - `System.IdentityModel.Tokens.Jwt` (Version 7.0.3)

### Hinweise

- Stellen Sie sicher, dass alle NuGet-Pakete auf die neueste kompatible Version aktualisiert sind.
- Überprüfen Sie die Kompatibilität der NuGet-Pakete mit dem .NET 7.0 Framework.
