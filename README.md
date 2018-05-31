Progress.Sitefinity.Samples.BugTracker
=====================================

### Latest supported version: Sitefinity CMS 11.0.6700.0

## Bug Tracker sample

The Bug Tracker sample demonstrates how to use Sitefinity CMS together with MVC and Razor web pages.


### Requirements

You must have a Sitefinity CMS license

For more information, see the [System requirements](https://docs.sitefinity.com/system-requirements) for the  respective Sitefinity CMS version.

### Prerequisites

You need to attach the database backup files to your SQL Server. To do this:

1. In SQL Management Studio, open the context menu of _Databases_ and click _Attach..._
2. Click the _Add..._ button and navigate to the _SitefinityWebApp_ -> *App_Data* folder.
3. Select the **SitefinityBugTrackerSample.mdf** file and click _OK_.
4. Click _OK_.

### Nuget package restoration
The solution in this repository relies on NuGet packages with automatic package restore while the build procedure takes place.   
For a full list of the referenced packages and their versions see the [packages.config](https://github.com/Sitefinity-SDK/Telerik.Sitefinity.Samples.BugTracker/blob/master/SitefinityWebApp/packages.config) file.    
For a history and additional information related to package versions on different releases of this repository, see the [Releases page](https://github.com/Sitefinity-SDK/Telerik.Sitefinity.Samples.BugTracker/releases).    

### Prerequisites

Clear the NuGet cache files. To do this:

1. In Windows Explorer, open the **%localappdata%\NuGet\Cache** folder.
2. Select all files and delete them.

### Installation instructions: SDK Samples from GitHub



1. In Solution Explorer, navigate to _SitefinityWebApp_ » *App_Data* » _Sitefinity_ » _Configuration_ and select the **DataConfig.config** file. 
2. Modify the **connectionString** value to match your server address.
3. Build the solution.

For version-specific details about the required Sitefinity CMS NuGet packages for this sample application, click on [Releases](https://github.com/Sitefinity-SDK/Telerik.Sitefinity.Samples.BugTracker/releases).


### Login

To login into the Sitefinity CMS backend, use the following credentials:  
**Username:** admin  
**Password:** password


### Additional resources
Progress Sitefinity CMS Documentation  
* [Develop: Use and extend Sitefinity CMS functionality](http://docs.sitefinity.com/develop-create-and-manage-website-content)
* [Tutorial: Create a bug tracker application](http://docs.sitefinity.com/tutorial-create-a-bug-tracker-application)
