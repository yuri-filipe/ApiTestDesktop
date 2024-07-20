Add-Migration InitialCreate
Update-Database
Add-Migration InitialCreate -StartupProject ApiTest.Desktop -Project ApiTest.Domain

Update-Database -StartupProject ApiTest.Desktop -Project ApiTest.Domain