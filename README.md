# Library Web Api
  - Ett Web Api skapat för hantera ett biblioteks bokhantering så som, lägga till böcker, utlåningar, retur av böcker.
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

<br>
<h1> Kom igång med Microsoft Visual Studio</h1><br>

Klona Git-repot via hemsidan eller kommandotolken och placera projektet där den önskas. <br>

För att kunna använda 'dotnet' kommand-linjen så måste .NET Core CLI installeras. Det görs via inbyggda kommandotolken i Visual Studio genom att skriva: <br>

```
dotnet tool install --global dotnet-ef 
```
<br>
<br>
<h1> Kom igång med Microsoft SQL Management Studio Management Studio </h1> 
I Management Studio, logga in på den lokala databasen '(localdb)\MSSQLLocalDB'.<br>
<br Skapa en tom databas kallad 'lib1'. <br>
Skapa en ny användare med namn 'lib', och lösenord '123'.<br>
Kryssa i rutan 'SQL Server Authentication', och kryssa ur rutan 'Enforce Password Policy'. <br>
Sätt 'default database' till 'librarywebapi' och spara sedan användaren. <br>
Öppna projektet i Visual Studio och bygg det. <br>
Öppna 'Package Manager Console', genom sökfältet eller under 'View > Other Windows > Package Manager Console'. <br>
Lokalisera till projektets directory och skriv in 'dotnet ef migrations add init'.   <br>
När kommandot är klart, skriv 'dotnet ef database update' i samma konsolfönster. <br>
Tryck 'refresh' på databasmappen i Management Studio och resultatet dyker upp. <br>
Ifall databas, databasnamn, användarnamn, eller lösenord önskas att ändras, så går att göra i applikationens 'appsettings.json fil som nedan. Alla detaljer måste stämma överens i Management Studio och Visual Studio för att applikationen ska fungera.  <br>

```
{ "ConnectionStrings": { "DefaultConnection": "Server=(localdb)\MSSQLLocalDB; Database=lib1; Trusted_Connection=true; User Id=lib1; Password=123" }, <br>
```

<h1> Använd API:et med Postman</h1> <br>
I Postman, klicka på plustecknet under titeln 'My Workspace'. <br>
Starta programet som startats  i Visual Studio och kopiera url:en från webbläsaren som öppnas. <br>
Klistra in url:en i sökfältet i Postman. (i detta fall, http://localhost:4070/overdues) <br> 
Genvägar <br>
I slutet av url:en, klistra in dessa för att få snabb åtkomst till vissa av API:ets funktioner. Entiteternas properties går att komma åt genom ett 'Get' anrop, eller i 'Models' mappen i Visual Studio. <br>

/api/books -- Hämta, uppdatera, lägg till, och ta bort böcker. <br>
/api/authors -- Hämta, uppdatera, lägg till, och ta bort författare. <br>
/api/members -- Hämta, uppdatera, lägg till, och ta bort kunder. <br>
/api/rentals -- Hämta, uppdatera, lägg till, och ta bort bokuthyrningar. <br>

I dessa behövs 'CustomerId' och 'BookId' av kund och bok bytas ut mot motsvarande Id:n. <br>

/api/members/(membersid)/rentbook/(BookId) -- 
http://localhost:4070/api/Members/1/rentbook/1       = Skapar ny uthyrning, medlem 1, lånar bok 1

/api/members/(membersid)/returnbook/(BookId) -- Lämna in uthyrningar och uppdatera lagersaldot i realtid. <br>
Exempel: http://localhost:4070/api/Members/1/returnbook/1     =   medlem 1, returnerar bok 1. 

Använda paket <br>
Microsoft ASP.Net Core MVC NewtonsoftJson <br>
Microsoft Entity Framework Core <br>
Microsoft Entity Framework Core Design <br>
Microsoft Entity Framework Core SQLite <br>
Microsoft Entity Framework Core SQLServer <br>
Microsoft Entity Framework Core Tools <br>
Microsoft Visual Web CodeGeneration Design <br>
