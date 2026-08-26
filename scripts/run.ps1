$ErrorActionPreference = "Stop"
$project = Join-Path $PSScriptRoot "..\src\Crypto-Portfolio-Tracker-Wallet\Crypto-Portfolio-Tracker-Wallet.csproj"
dotnet run --project $project -- @args
