ASP.NET Core 5.0 + Angular + Electron.NET
=========================================

- Client (Angular 11.1.2)  
Benötigt Node.js + Angular CLI (npm i @angular/cli -g)
Im Client Ordner `npm install` ausführen.

- Server (ASP.NET Core 5.0 - Web Api)  
Benötigt .NET 5 SDK
Im Server Ordner `dotnet restore` ausführen.

Electron.NET für Linux Build mit Docker.
Image erzeugen aus Dockerfile beim Server Ordner: `docker build -t electronnet-builder .`  
Container mit CMD.exe starten und builden: `docker run --rm -v %cd%:/project -w /project electronnet-builder ../tmp/electronize build /target linux`  


Weitere Infos im Video.