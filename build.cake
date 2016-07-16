//Build script

var target = Argument("target", "Default");
var configuration = Argument("configuration", "Release");

// Define directories.
var buildDir = Directory("./Build");
var outputDir = Directory((string)buildDir + "/" + (string)configuration);
var solution = "./SportsTacticsBoard.sln";

Task("Clean")
	.WithCriteria(target == "Rebuild")
    .Does(() =>
{
		CleanDirectory(buildDir);
});

Task("Restore-NuGet-Packages")
    .IsDependentOn("Clean")
    .Does(() =>
{
    NuGetRestore(solution);
});

Task("Build")
    .IsDependentOn("Restore-NuGet-Packages")
    .Does(() =>
{
    if(IsRunningOnWindows())
    {
		MSBuild(solution, settings =>
			settings.SetConfiguration(configuration));
		CopyFileToDirectory("./tools/Eto.Platform.Windows/lib/net45/Eto.WinForms.dll",
							outputDir);
    }
    else
    {
		XBuild(solution, settings =>
			settings.SetConfiguration(configuration));
		CopyFileToDirectory("./tools/Eto.Platform.Gtk/lib/net45/Eto.Gtk2.dll",
							outputDir);
    }
});


Task("Default")
    .IsDependentOn("Build");

Task("Rebuild")
	.IsDependentOn("Build");

RunTarget(target);
