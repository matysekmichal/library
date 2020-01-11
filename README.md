# API Biblioteki

## Autorzy: Michał Matysek, Aleksander Kaczmarczyk

### Cel projektu
Stworzenie API dla biblioteki akademickiej, które będzie zintegrowanym systemem dla:
* Publikacje dostępne w bibliotece
* Informacje o rezerwującym
* Rezerwacje
* Gatunki publikacji
* Autorzy
* Wydawcy

### Uruchomienie projektu
W celu uruchomienia projektu należy pobrać zależności przy pomocy narzędzia NuGet. System wykorzystuje:
* AutoMapper
* AutoMapper.Extensions.Microsoft.DependencyInjection
* Bogus
* Microsoft.AspNetCore.Mvc.NewtonsoftJson
* Microsoft.EntityFrameworkCore
* Microsoft.EntityFrameworkCore.Design
* Microsoft.EntityFrameworkCore.Sqlite
* Microsoft.OpenApi
* Swashbuckle.AspNetCore

Po pobraniu zależności można uruchomić projekt komendą dotnet run, lub dotnet watch run. Projekt zostanie uruchomiony pod adresem localhost:5000. Szczegóły implementacji API są dostępne pod adresem localhost:5000/swagger/index.html. Implementacja API jest dostępna localhost:5000/api.

### Użyte technologie i rozwiązania
* Framework: ASP.NET Core 3.0
* Baza danych: SQLite
* ORM: Entity Framework Core

### Podsumowanie
Została utworzona podstawową funkcjonalność CRUD dla modeli występujących w systemie. Następnymi etapami projektu było by stworzenie mechanizmu uwierzytelnienia użytkownika oraz implementacji ich roli w systeme po przez określenie dostępu do danych. Do poprawienia zostają obiekty transferujące dane (DTO), oraz mapowanie danych.
