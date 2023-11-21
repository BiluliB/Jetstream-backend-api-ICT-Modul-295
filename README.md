## Jetstream Backend API für ICT-Modul 295

## Disclaimer

Bitte beachten Sie, dass das Frontend der Jetstream Backend API derzeit in Bearbeitung ist und daher nur teilweise funktioniert. Ich arbeite mit Hochdruck daran, alle Funktionalitäten so schnell wie möglich vollständig bereitzustellen. Ich bitte um Ihr Verständnis und danken Ihnen für Ihre Geduld.

### Überblick

### Alle Dokumente des Projekts (Projektdokumentation, Präsentataion, SQL-Befehl, Connectin String) befinden sich im Projektordner -> Files

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
- Microsoft SQL Server oder ein äquivalenter Datenbankdienst.

## Projekt klonen oder herunterladen:

- Laden Sie das Projekt herunter oder klonen Sie es aus dem Repository.

## Abhängigkeiten installieren:

- Öffnen Sie die Kommandozeile oder das Terminal im Projektverzeichnis.
- Wenn Sie das `dotnet-ef`-Tool noch nicht auf Ihrem System installiert haben, führen Sie bitte zuerst den Befehl `dotnet tool install --global dotnet-ef` aus. Dies ermöglicht Ihnen, Entity Framework Core-bezogene Befehle wie das Erstellen von Migrations und das Aktualisieren der Datenbank auszuführen.
- Führen Sie den Befehl `dotnet restore` aus, um alle erforderlichen NuGet-Pakete zu installieren.

### Datenbankkonfiguration

Um die Datenbank für die Jetstream Backend API korrekt einzurichten und zu konfigurieren, befolgen Sie diese Schritte:

- Stellen Sie Microsoft SQL Management Studio so ein das SQL accounts zugelassen werden

1. **Anpassen der Verbindungszeichenfolge**:

   - Öffnen Sie die Datei `appsettings.json` in Ihrem Projektverzeichnis.
   - Ändern Sie die `ServiceRequestDbConnectionString` so, dass sie Ihre spezifische Datenbankkonfiguration widerspiegelt.
   - Beispiel für eine lokale Datenbankverbindung als root:
     ```json
     "ServiceRequestDbConnectionString": "Server=(localdb)\\mssqllocaldb;Database=JetStreamServiceRequest;Trusted_Connection=True;TrustServerCertificate=True;"
     ```

2. **Datenbankerstellung mit Entity Framework Core Migrations**:
   - Öffnen Sie die Kommandozeile oder das Terminal im Projektverzeichnis.
   - Führen Sie den Befehl `dotnet ef migrations add InitialCreate` aus, um eine Erstmigration für Ihre Datenbank zu erstellen.
   - Führen Sie anschließend den Befehl `dotnet ef database update` aus, um die Datenbank basierend auf der erstellten Migration zu initialisieren und zu erstellen.

### SQL-Nutzerkonfiguration

Nachdem die Datenbank erstellt wurde, führen Sie zusätzliche Schritte zur Konfiguration des Datenbanknutzers durch:

1. **Erstellen des Datenbanknutzers**:

   - Verwenden Sie SQL Server Management Studio (SSMS) oder eine andere SQL-Interface-Anwendung.
   - Führen Sie das bereitgestellte SQL-Skript `InitJohnyLoginAndDbAccess.sql` aus, um einen neuen Nutzer zu erstellen und ihm Zugriffsrechte zu erteilen.
   - Das Skript enthält Befehle zum Erstellen eines Logins und Nutzers sowie zum Gewähren von Zugriffsrechten:
     ```sql
     CREATE LOGIN [Johny] WITH PASSWORD = 'password';
     USE [JetStreamServiceRequest];
     CREATE USER [Johny] FOR LOGIN [Johny];
     GRANT SELECT, INSERT, UPDATE, DELETE TO [Johny];
     ```

2. **Aktualisieren der Verbindungszeichenfolge in `appsettings.json`**:
   - Ändern Sie die Verbindungszeichenfolge erneut, um den neu erstellten Nutzer `Johny` zu verwenden:
     ```json
     "ServiceRequestDbConnectionString": "Server=.\\;Database=JetStreamServiceRequest;User ID=Johny;Password=password;TrustServerCertificate=True;"
     ```

Durch diese Schritte wird sichergestellt, dass Ihre Datenbank korrekt konfiguriert ist und die Anwendung ordnungsgemäß mit ihr interagieren kann.

## Starten der Anwendung:

- Starten Sie die Anwendung mit `dotnet run`.
- Die API sollte nun auf dem standardmäßigen oder konfigurierten Port laufen und über einen Webbrowser oder einen API-Client wie Postman erreichbar sein.

## Testen der Jetstream Backend API

### Testen mit Postman

- **Postman Collection**: Eine Postman Collection wurde für die API erstellt, um die verschiedenen Endpunkte zu testen. Die Collection enthält vordefinierte Anfragen für die verschiedenen API-Funktionen.
- **Importieren der Collection**: Importieren Sie die bereitgestellte JSON-Datei die im Files Ordner liegt in Postman, um die Endpunkte schnell und effizient zu testen.

### Testen mit Swagger

- **Swagger-Integration**: Swagger ist in die API integriert und ermöglicht das Testen der Endpunkte über eine benutzerfreundliche Oberfläche.
- **API-Dokumentation**: Swagger bietet nicht nur eine Möglichkeit, die API zu testen, sondern stellt auch eine detaillierte Dokumentation der Endpunkte und ihrer Parameter zur Verfügung.
- **Zugriff auf Swagger**: Um Swagger zu nutzen, starten Sie die API und navigieren Sie im Webbrowser zur Swagger-UI-URL (normalerweise `https://localhost:<port>/swagger`).

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

#### JetstreamApi Abhängigkeiten

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

Neben den Abhängigkeiten des Hauptprojekts beinhaltet das Unittest-Projekt folgende spezifische Abhängigkeiten:

#### Unittest-Projekt Abhängigkeiten

- **Target Framework**: .NET 7.0
- **NuGet-Pakete**:
  - `Microsoft.NET.Test.Sdk` (Version 17.7.1)
  - `Moq` (Version 4.20.69)
  - `xunit` (Version 2.4.2)
  - `xunit.runner.visualstudio` (Version 2.4.5)Studio-Testumgebung ermöglicht.
  - `coverlet.collector` (Version 3.2.0)
- **Projektreferenzen**:
  - Verweis auf das Hauptprojekt (`JetstreamApi.csproj`), was für Integrationstests oder den Zugriff auf die Haupt-API-Komponenten notwendig ist.

### Hinweise

- Stellen Sie sicher, dass alle NuGet-Pakete auf die neueste kompatible Version aktualisiert sind.
- Überprüfen Sie die Kompatibilität der NuGet-Pakete mit dem .NET 7.0 Framework.
