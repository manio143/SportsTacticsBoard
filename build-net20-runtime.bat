@echo off
PATH=%PATH%;%SystemRoot%\Microsoft.NET\Framework\v2.0.50727
msbuild /p:Configuration=Release %1 %2 %3
