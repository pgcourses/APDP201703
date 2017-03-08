# APDP201703
(Program)Tervezési minták és ellenpéldák

## Előkészületek 

### [Chocolatey](https://chocolatey.org) telepítése
Admin parancssorból lefuttatni a következő parancsot:

**@powershell -NoProfile -ExecutionPolicy Bypass -Command "iex ((New-Object System.Net.WebClient).DownloadString('https://chocolatey.org/install.ps1'))" && SET "PATH=%PATH%;%ALLUSERSPROFILE%\chocolatey\bin"**

Ezzel van csomagkezelőnk.

## Visual Studio 2015 Community telepítése

**cinst visualstudio2015community** (kb 35 perc)

## SQL Server Express telepítése

**cinst sql-server-express** (nagyjából 10 perc)

## SQL Server Management Studio

**cinst sql-server-management-studio** (nagyjából 15 perc)
