# lib1a
# Library Web Api
  - Ett Web Api skapat för hantera ett biblioteks bokhantering så som, lägga till böcker, utlåningar, retur av böcker.
```
csharp kod
teex här
o här
```
![alt text](https://github.com/adam-p/markdown-here/raw/master/src/common/images/icon48.png "Logo Title Text 1")
# Verktyg
Dessa program nedan kommer behövas installeras för att få allt fungera samt kunna hantera saker på ett bra sätt.

<br>
<img align="center" width="100" height="100" src="https://raw.githubusercontent.com/devicons/devicon/c5378d6c2510ffa0b3e4475af95618a8048d6cf1/icons/visualstudio/visualstudio-plain.svg">
<br>[Microsoft Visual Studio 2019](https://visualstudio.microsoft.com/downloads/)


<br>
<br> <img align="center" width="100" height="100" src="https://camo.githubusercontent.com/40f52e7903eb1010972f70deb72558ffe8df896a757e115225d23aea0222774c/68747470733a2f2f6d656d6f61673075332e626c6f622e636f72652e77696e646f77732e6e65742f696d672f323031372f31312f417a7572652d53514c2d44617461626173652d67656e657269632e706e67">


[Management Studio Microsoft SQL Management Studio 18](https://docs.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms?view=sql-server-ver15)



<br> <img align="center" width="100" height="100" src="https://camo.githubusercontent.com/c4a6bfa3c24b9de8d42bbbc16fb7a3d6500198c142bf03990f00758da85ffe14/68747470733a2f2f7365656b6c6f676f2e636f6d2f696d616765732f502f706f73746d616e2d6c6f676f2d463433333735413245422d7365656b6c6f676f2e636f6d2e706e67">
<br>
[Postman](https://www.postman.com/downloads/) 


Kom igång med Microsoft Visual Studio VS
Klona Git-repot via hemsidan eller kommandotolken och placera projektet där den önskas.

För att kunna använda 'dotnet' kommand-linjen så måste .NET Core CLI installeras. Det görs via inbyggda kommandotolken i Visual Studio genom att skriva:

dotnet tool install --global dotnet-ef

Kom igång med Microsoft SQL Management Studio Management Studio
I Management Studio, logga in på den lokala databasen '(localdb)\MSSQLLocalDB'.
Skapa en tom databas kallad 'librarywebapi'.
Skapa en ny användare med namn 'guest', och lösenord 'password'.
Kryssa i rutan 'SQL Server Authentication', och kryssa ur rutan 'Enforce Password Policy'.
Sätt 'default database' till 'librarywebapi' och spara sedan användaren.
Öppna projektet i Visual Studio och bygg det.
Öppna 'Package Manager Console', genom sökfältet eller under 'View > Other Windows > Package Manager Console'.
Lokalisera till projektets directory och skriv in 'dotnet ef migrations add init'.
När kommandot är klart, skriv 'dotnet ef database update' i samma konsolfönster.
Tryck 'refresh' på databasmappen i Management Studio och resultatet dyker upp.
Ifall databas, databasnamn, användarnamn, eller lösenord önskas att ändras, så går att göra i applikationens 'appsettings.json fil som nedan. Alla detaljer måste stämma överens i Management Studio och Visual Studio för att applikationen ska fungera.

{ "ConnectionStrings": { "DefaultConnection": "Server=(localdb)\MSSQLLocalDB; Database=librarywebapi; Trusted_Connection=true; User Id=guest; Password=password" },

Använd API:et med Postman Management Studio
I Postman, klicka på plustecknet under titeln 'My Workspace'.
Starta applikationen i Visual Studio och kopiera url:en från webbläsaren som öppnas.
Klistra in url:en i sökfältet i Postman.
Genvägar
I slutet av url:en, klistra in dessa för att få snabb åtkomst till vissa av API:ets funktioner. Entiteternas properties går att komma åt genom ett 'Get' anrop, eller i 'Models' mappen i Visual Studio.

/api/books -- Hämta, uppdatera, lägg till, och ta bort böcker.
/api/authors -- Hämta, uppdatera, lägg till, och ta bort författare.
/api/customers -- Hämta, uppdatera, lägg till, och ta bort kunder.
/api/rentbooks -- Hämta, uppdatera, lägg till, och ta bort bokuthyrningar.

I dessa behövs 'CustomerId' och 'BookId' av kund och bok bytas ut mot motsvarande Id:n.

/api/customers/(CustomerId)/rentbook/(BookId) -- Skapa nya uthyrning och uppdatera lagersaldot i realtid.
/api/customers/(CustomerId)/returnbook/(BookId) -- Lämna in uthyrningar och uppdatera lagersaldot i realtid.

Använda verktyg
ASP.Net Core
Entity Framework
Microsoft Management Studio 18
Postman
Visual Paradigm
Visual Studio 2019

Använda paket
Microsoft ASP.Net Core MVC NewtonsoftJson
Microsoft Entity Framework Core
Microsoft Entity Framework Core Design
Microsoft Entity Framework Core SQLite
Microsoft Entity Framework Core SQLServer
Microsoft Entity Framework Core Tools
Microsoft Visual Web CodeGeneration Design
