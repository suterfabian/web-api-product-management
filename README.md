# AccessHub

**AccessHub** ist ein Authentifizierungs- und Autorisierungsdienst, der als zentrale Login-Schnittstelle für weitere Anwendungen dient.  
Benutzer können sich mit einem Benutzernamen und Passwort anmelden und erhalten ein JWT-Token zur Authentifizierung gegenüber geschützten Endpunkten.

---

## Ziel der Anwendung

AccessHub stellt ein sicheres Login-System bereit, das:
- moderne JWT-basierte Authentifizierung nutzt,
- mit Clean Architecture nach SOLID-Prinzipien strukturiert ist,
- durch CQRS und MediatR einfach wart- und erweiterbar bleibt,
- testgetrieben entwickelt werden kann,
- langfristig um Benutzer-Registrierung, Rollenverwaltung und Datenbankanbindung (z. B. EF Core) erweitert wird.

---

## Architektur (Clean Architecture)

Die Lösung ist in vier Kernschichten unterteilt:

- **Domain**  
  Enthält alle fachlichen Entitäten (`User`, `Email`) sowie Interfaces (`IUserRepository`, `IPasswordHasher`).  
  Diese Schicht kennt keine technische Infrastruktur.

- **Application**  
  Beinhaltet die Business-Logik in Form von UseCases wie `LoginUserCommand`.  
  Abhängigkeiten zur Domain, aber keine Kenntnis von Datenbanken, Web oder Frameworks.

- **Infrastructure**  
  Technische Implementierungen z. B. von `IUserRepository`, Passwort-Hashing mit BCrypt oder JWT-Token-Erzeugung.  
  Kennt Application und Domain.

- **API**  
  Präsentationsschicht – stellt REST-Endpunkte bereit (`POST /auth/login`).  
  Registriert alle Abhängigkeiten und verarbeitet Anfragen.

---

## Projektstruktur

```
AccessHub.sln
├── src/
│ ├── AccessHub.API/ // WebAPI Projekt (Presentation Layer)
│ ├── AccessHub.Application/ // Business Logik + UseCases
│ ├── AccessHub.Domain/ // Entitäten + Interfaces
│ ├── AccessHub.Infrastructure/ // Datenzugriff, Auth, EF Core, externe Services
└── tests/
├── AccessHub.UnitTests/ // Unit-Tests für UseCases & Domain
└── AccessHub.IntegrationTests/ // End-to-End & Schnittstellentests
```

