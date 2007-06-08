@echo off
setlocal
set WINSCP="%ProgramFiles%\WinSCP3\WinSCP3.com"

xcopy /D /Y /R changelog.txt WebSiteFiles
xcopy /D /Y /R readme.txt WebSiteFiles

%WINSCP% /script=UploadWebFiles.txt