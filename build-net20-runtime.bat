@echo off
PATH=%PATH%;%SystemRoot%\Microsoft.NET\Framework\v2.0.50727
msbuild SportsTacticsBoard\SportsTacticsBoard.csproj /p:Configuration=Release %1 %2 %3
