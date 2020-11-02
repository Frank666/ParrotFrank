# ParrotFrank

Parrot Challenge

## Requirements
Visual Studio 2019
.Net Core 3.1
MySQL DB Engine
MySQL Workbench
ASP.NET Core 3.1 Runtime (v3.1.9)
IIS Server

## Installation
WinForms APP
AppInstaller.rar
MSI installer for windows forms app, once the app was installed, please check and review the app.config file to set the correct API endpoint 

API
Create a website app inside IIS with name "ParrotFrankAPI" and set the directory inside wwwroot folder -C:\inetpub\wwwroot\ParrotFrankAPI-.
Swagger API documentation: servername/ParrotFrankAPI/swagger

```bash
1) Clone the repo and open the solution file on Visual Studio 
2) Run the schema.sql script to create the DB with some example data
3) Build the solution in order to install the dependencies 
4) By Default the solution will launch a Windows Forms project and also a Web API project
5) In the schema.sql file you can find an example of users to login 
```

## Contributing
Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.

## License
[MIT](https://choosealicense.com/licenses/mit/)
