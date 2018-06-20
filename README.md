Progress.Sitefinity.Samples.BugTracker
=====================================

>**Latest supported version**: Sitefinity CMS 11.0.6700.0

### Overview

The Bug Tracker sample demonstrates how to use Sitefinity CMS together with MVC and Razor web pages.

### Prerequisites

- You must have a Sitefinity CMS license.
- Your setup must comply with the system requirements.  
 For more information, see the [System requirements](https://docs.sitefinity.com/system-requirements) for the  respective Sitefinity CMS version.

### Installation

1. Attach the database.  
 a. In SQL Management Studio, open the context menu of _Databases_ and click _Attach..._  
 b. Click the _Add..._ button and navigate to the `~\SitefinityWebApp\App_Data` folder.  
 c. Select the `SitefinityBugTrackerSample.mdf` file and click _OK_.  
 d. Click _OK_.
2. Modify the connection string.  
 a. Open the downloaded project in Visual Studio.  
 b. In the _Solution Explorer_, navigate to _SitefinityWebApp >> App_Data >> Sitefinity >> Configuration_.  
 b. Open the `DataConfig.config` file and modify the `connectionString` value to match your server address.  
 c. Build the solution.
2. Clear the NuGet cache files.  
 a. Open the `BugTracker` solution file in Visual Studio.  
 b. In the toolbar, navigate to _Tools >> NuGet Package Manager >> Package Manager Settings_.  
 c. In the left pane, navigate to _NuGet Package Manager >> General_.  
 d. Click _Clear All NuGet Cache(s)_.
3. Restore the NuGet packages in the solution.  
   
   >**NOTE**: The solution in this repository relies on NuGet packages with automatic package restore while the build procedure takes place.   
   >For a full list of the referenced packages and their versions see the [packages.config](https://github.com/Sitefinity-SDK/Telerik.Sitefinity.Samples.BugTracker/blob/master/SitefinityWebApp/packages.config) file.    
   >For a history and additional information related to package versions on different releases of this repository, see the [Releases page](https://github.com/Sitefinity-SDK/Telerik.Sitefinity.Samples.BugTracker/releases).
   >  
   a. Navigate to _Tools >> NuGet Package Manager >> Package Manager Console_.  
   b. In _Source_, select Sitefinity CMS NuGet Repository.  
   c. Click _Restore_ button.

### Login

1. In the context menu of SitefinityWebApp, click _View >> View in Browser_.  
 After the project initializes, the _License activation_ page appears.
2. Activate your license.  
 For more information, see [Activate a license](http://docs.sitefinity.com/activate-a-license).
3. To login into the Sitefinity CMS backend, use the following credentials:  
 **Username:** admin  
 **Password:** password

### Additional resources
Progress Sitefinity CMS Documentation:  
* [Develop: Use and extend Sitefinity CMS functionality](http://docs.sitefinity.com/develop-create-and-manage-website-content)
* [Tutorial: Create a bug tracker application](http://docs.sitefinity.com/tutorial-create-a-bug-tracker-application)
