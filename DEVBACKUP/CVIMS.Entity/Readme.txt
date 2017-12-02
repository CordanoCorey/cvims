Create database
1. Make sure the settings under appsettings.{configuration}.json point to the correct server with the desired database name. 
The current configuration can be found by right clicking the Api project in solution explorer and selecting properties.
Click the debug tab and look for the ASPNETCORE_ENVIRONMENT setting.  This is set to local by default.  
That means the server and the database name listed in the connection string from the appsettings.local.json will be used.

2. Open package manager console from the Tools menu => Nuget Package Manager.  
3. Select the Entity project in the dropdown of the console.
4. Type in the "Update-Database" commmand.


 add-migration init -Context CVIMSContext
 update-database  -Context CVIMSContext
