Sports Tactics Board
--------------------

http://sportstacticsbd.sourceforge.net/
http://sourceforge.net/projects/sportstacticsbd/

Sports Tactics Board is a utility that allows coaches, trainers and 
officials to describe sports tactics, strategies and positioning using 
a magnetic or chalk-board style approach.


Table of Contents
-----------------
1. Copyrights
2. License
3. Supported Platforms
 3.2 Requirements
4. Compiling From Source Code
 4.1 Requirements
 4.2 Procedure
  4.2.1 No Development Environment on Windows with .NET 2.0 Runtime Installed
  4.2.2 Visual Studio (any version supporting C#)
  4.2.3 .NET Framework SDK or Windows SDK


1. Copyrights
-------------

Copyright (C) 2006-2007 Robert Turner


2. License
----------

This program is free software; you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation; either version 2 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License along
with this program; if not, write to the Free Software Foundation, Inc.,
51 Franklin Street, Fifth Floor, Boston, MA 02110-1301 USA.


3. Supported Platforms
----------------------

- Windows XP SP2
- Windows Server 2003 SP1
- Windows Vista


3.2 Requirements
----------------

Microsoft .NET Framework 2.0 must be installed. It can be downloaded using
Windows Update or Microsoft Update, or directly from Microsoft from:

http://www.microsoft.com/downloads/details.aspx?FamilyID=0856eacb-4362-4b0d-8edd-aab15c5e04f5&displaylang=en


4. Compiling From Source Code
-----------------------------

Source code can be obtained from SourceForge.net. See the following URLs and 
follow standard SourceForge process for obtaining source code:

  http://sportstacticsbd.sourceforge.net/
  http://sourceforge.net/projects/sportstacticsbd/


4.1 Requirements
----------------

There is no need for any special development environment to compile or
build this program from source code. If you have any supported Windows
platform with the .NET 2.0 runtime installed, you can compile this 
program from source code.

The following development tools can also be used to modify and compile
the program:

  - Visual Studio 2005 Professional 
      Commerical product available from Microsoft and resellers.
      For more information see: 
         http://msdn.microsoft.com/vstudio/default.aspx

  - Visual C# 2005 Express Edition
      No-cost product available from Microsoft.
      For more information see:
         http://msdn.microsoft.com/vstudio/express/visualcsharp/

  - Microsoft .NET Framework 2.0 SDK
      No-cost development .NET development SDK.
      Downloadable from:
         http://www.microsoft.com/downloads/details.aspx?familyid=fe6f2099-b7b4-4f47-a244-c96d69c35dec&displaylang=en

  - Microsoft Windows SDK for Windows Vista
      No-cost SDK for Windows and .NET development (may require Microsoft 
      Genuine Advantage validation to download)
      Downloadable from:
         http://www.microsoft.com/downloads/details.aspx?FamilyId=7614FE22-8A64-4DFB-AA0C-DB53035F40A0&displaylang=en
        OR
         http://www.microsoft.com/downloads/details.aspx?FamilyId=C2B1E300-F358-4523-B479-F53D234CDCCF&displaylang=en

It may be possible to compile under the most recent versions of Mono. 
You will need support for System.Windows.Forms for this program to work.
The original author has not tried this yet.


4.2 Procedure
-------------

See the appropriate section below that corresponds to the environment you have.

4.2.1 No Development Environment on Windows with .NET 2.0 Runtime Installed
---------------------------------------------------------------------------

1. Open a command shell:
     Start | Run...
   Type: "cmd", hit OK
2. Change working directories to the folder with the complete 
   source tree extracted to.
    e.g.:   CD /D C:\SportsTacticsBoard-src
3. Run build-net20-runtime.bat by typing:
     build-net20-runtime
   in the command shell and hitting enter.

4.2.2 Visual Studio (any version supporting C#)
-----------------------------------------------

1. Open the solution file (.SLN file) from the root folder of the 
   repository.
2. Build the project using normal build procedures (either Build 
   Solution or Batch Build from the Build menu).


4.2.3 .NET Framework SDK or Windows SDK
---------------------------------------

1. Open an "SDK Command Prompt" or "CMD Shell" window from 
     Start | Programs | Microsoft .NET Framework SDK v2.0
   OR
     Start | Programs | Microsoft Windows SDK
2. Change working directories to the folder with the complete 
   source tree extracted to.
    e.g.:   CD /D C:\SportsTacticsBoard-src
3. Run MSBuild for the targets you wish to compile.
    e.g.:   msbuild /p:Configuration=Release

