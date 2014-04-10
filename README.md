Telerik.Sitefinity.Samples.BugTracker
=====================================

## Bug Tracker sample

The Bug Tracker sample demonstrates how to use Sitefinity together with MVC and Razor web pages.


### Requirements

* Sitefinity 6.3 license

* .NET Framework 4

* Visual Studio 2012

* Microsoft SQL Server 2008R2 or later versions


### Prerequisites

You need to attach the database backup files to your SQL Server. To do this:

1. In SQL Management Studio, open the context menu of _Databases_ and click _Attach..._
2. Click the _Add..._ button and navigate to the _SitefinityWebApp_ -> *App_Data* folder.
3. Select the **SitefinityBugTrackerSample.mdf** file and click _OK_.
4. Click _OK_.


### Prerequisites

Clear the NuGet cache files. To do this:

1. In Windows Explorer, open the **%localappdata%\NuGet\Cache** folder.
2. Select all files and delete them.

### Installation instructions: SDK Samples from GitHub



1. In Solution Explorer, navigate to _SitefinityWebApp_ -> *App_Data* -> _Sitefinity_ -> _Configuration_ and select the **DataConfig.config** file. 
2. Modify the **connectionString** value to match your server address.
3. Build the solution.

The project refers to the following NuGet packages:

**SitefinityWebApp** library

*	Telerik.Sitefinity.All.nupkg

*	Telerik.Sitefinity.SDK.MVC.nupkg

You can find the packages in the official [Sitefinity Nuget Server](http://nuget.sitefinity.com).

### Login

To login to Sitefinity backend, use the following credentials: 

**Username:** admin

**Password:** password


### Additional resources

[Developers Guide](http://www.sitefinity.com/documentation/documentationarticles/developers-guide)

[Create a bug tracking application](http://www.sitefinity.com/documentation/documentationarticles/developers-guide/how-to/how-to-create-a-bug-tracking-application)
