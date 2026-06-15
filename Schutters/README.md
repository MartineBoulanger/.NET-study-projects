# Schutters - 3-lagenmodel (ASP.NET Core MVC)

## Projectstructuur

- **SchuttersData** (datalaag, class library)
  - `Models/Club.cs`, `Models/Lid.cs` — entiteiten
  - `Models/SchuttersDbContext.cs` — EF Core context voor de Schutters-database
  - `Repositories/` — `IClubRepository`, `ILidRepository` en hun SQL-implementaties

- **SchuttersServices** (servicelaag, class library)
  - `ClubService.cs`, `LidService.cs` — business logic, gebruikt de repositories uit SchuttersData

- **SchuttersWeb** (presentatielaag, ASP.NET Core MVC web app)
  - Controllers, Views, Identity (security database)
  - Gebruikt de services uit SchuttersServices

## Twee databases

1. **Security database** (`aspnet-SchuttersWeb`, connectionstring `DefaultConnection`)
   ASP.NET Core Identity: `AspNetUsers`, `AspNetRoles`, ...

2. **Schutters database** (`Schutters`, connectionstring `SchuttersConnection`)
   Tabellen `Clubs` en `Leden` (zie `createMVCSchutters.sql`).

## Setup stappen

### 1. Client-side libraries herstellen
Open de solution in Visual Studio. Klik met de rechtermuisknop op `libman.json` in
`SchuttersWeb` en kies **Restore Client-Side Libraries** (of dit gebeurt automatisch
bij build). Dit haalt bootstrap, jquery en jquery-validation binnen in `wwwroot/lib`.

### 2. Schutters-database aanmaken
Voer het script `createMVCSchutters.sql` uit in SQL Server Management Studio. Dit
maakt de database `Schutters` aan met de tabellen `Clubs` en `Leden`, inclusief
data en de FK-constraint met `ON DELETE CASCADE`.

Omdat de database al via dit script wordt aangemaakt, is er **geen EF migration**
nodig voor `SchuttersDbContext`. Indien je toch een migration wil aanmaken (bv. om
later wijzigingen te kunnen migreren), voer dan vanuit de map `Schutters` (waar
`Schutters.sln` staat) uit:

```
dotnet ef --startup-project SchuttersWeb/SchuttersWeb.csproj migrations add InitialCreate -p SchuttersData/SchuttersData.csproj --context SchuttersDbContext
```

Voer **geen** `database update` uit voor deze context als de database al via het
SQL-script bestaat (dit zou een conflict geven). Gebruik in dat geval
`dotnet ef migrations add ... --context SchuttersDbContext` enkel als startpunt
voor toekomstige migraties (en markeer de migration eventueel als reeds toegepast
met `dotnet ef database update InitialCreate` pas NA controle, of gebruik
`Add-Migration` met een lege up/down als je enkel het model wil "bevestigen").

### 3. Security database aanmaken (Identity)
Voer vanuit de map `Schutters` uit:

```
dotnet ef --startup-project SchuttersWeb/SchuttersWeb.csproj migrations add InitialIdentity -p SchuttersWeb/SchuttersWeb.csproj --context ApplicationDbContext
dotnet ef --startup-project SchuttersWeb/SchuttersWeb.csproj database update --context ApplicationDbContext
```

Dit maakt de database `aspnet-SchuttersWeb` aan met de Identity-tabellen
(`AspNetUsers`, `AspNetRoles`, `AspNetUserRoles`, ...).

### 4. Rollen en gebruikers toevoegen
Voer daarna `eindoefening_securityscript.sql` uit op de database `aspnet-SchuttersWeb`
(pas de `USE [aspnet-...]` regel aan naar de juiste databasenaam, bv.
`USE [aspnet-SchuttersWeb]`). Dit voegt de rollen `Admin` en `Leden` toe, en de
testgebruikers met hun wachtwoorden (zie commentaar onderaan het script).

### 5. Connectionstrings controleren
Controleer in `SchuttersWeb/appsettings.json` of de databasenamen overeenkomen met
wat je in stap 2-4 hebt gebruikt.

## Beveiliging / rollen

- Niet ingelogd: enkel de Homepagina is toegankelijk (Club- en Lid-controllers
  hebben `[Authorize]`).
- Ingelogd (eender welke rol): clublijst en -details (`ClubController`
  Index/Details).
- Rol **Leden** (en Admin): ledenlijst, -details en de zoekpagina
  (`LidController` heeft `[Authorize(Roles = "Leden,Admin")]`).
- Rol **Admin**: Create/Edit/Delete voor zowel Clubs als Leden.

## Validatie

- Verplichte velden en maximale lengtes via data annotations op de modellen
  (`Club`, `Lid`, `LidFormViewModel`).
- Stamnummer/lidnummer-uniciteit wordt enkel gecontroleerd in de **Create**-actions
  via `ModelState.AddModelError`, zoals aangegeven in de opdracht (tip).
- Bij Edit is het stamnummer/lidnummer een disabled veld (visueel) met een
  bijhorend hidden field zodat de waarde toch wordt doorgestuurd.
- Verwijderen van een club verwijdert automatisch de bijhorende leden via de
  `ON DELETE CASCADE` constraint in de database (`Leden$ClubsLeden`).

## Zoekpagina leden

`LidController.Search` (GET en POST) — zoekt op (een deel van) voornaam, naam,
geslacht, niveau en/of clubnaam. Toegankelijk voor rollen Leden en Admin.