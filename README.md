# Sports Tactics Board
Sports Tactics Board is a utility that allows coaches, trainers and officials to describe sports tactics, strategies and positioning using a magnetic or chalk-board style approach.

This project has been forked from https://sourceforge.net/projects/sportstacticsbd/ and is under the GNU General Public License v2 (see license.txt for further info).

The original readme can be found in Readme.original.txt.

## Goal
The goal of this fork is to provide portability and extend the current application. By portability I mean moving the project from Windows Forms to a multiplaftorm framework like Eto.Forms.

## Building
I decided to use [Cake](https://github.com/cake-build/cake) to script my building process. That way all you need to do is run:

	#Windows
	PS> .\build.windows.ps1
	
	#Linux
	$ ./build.linux.sh

## Running
Go into the Build folder and run `SportsTacticsBoard.exe`.

## Roadmap
- [ ] Read all of the source code and understand what is for what
- [ ] Migrate from Windows Forms to Eto.Forms
- [ ] Simplify current implementation if possible
- [ ] Prepare for extensibility
- [ ] Implement stuff from UnimplementedFeatureRequests.txt
