@echo off
setlocal
set WINSCP="%ProgramFiles%\WinSCP\WinSCP.com"

%WINSCP% /script=UploadReleaseFiles.txt
