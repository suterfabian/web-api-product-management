# ProductManagementApi

## Projektstruktur

```
ProductManagement.sln
├── src/
│   ├── ProductManagement.API/              // Präsentation: Web API
│   ├── ProductManagement.Application/      // Use Cases, Commands, Queries
│   ├── ProductManagement.Domain/           // Entitäten, Interfaces
│   ├── ProductManagement.Infrastructure/   // Repositories, Services, externe Anbindungen
└── tests/
    ├── ProductManagement.UnitTests/        // Unit Tests für Application + Domain
    └── ProductManagement.IntegrationTests/ // End-to-End + API + DB-Tests
```

