$ErrorActionPreference = "Stop"
$sln = Join-Path $PSScriptRoot "..\Crypto-Portfolio-Tracker-Wallet.sln"
dotnet test $sln --configuration Release --verbosity normal
