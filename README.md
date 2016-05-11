# Project User Administration

## Introduction

This is a test project. ASP.NET 5 MVC 6 just released with Visual Studio 2015 and Visual Studio Code.
So for testing the new features of MVC 6, I create an application in MVC 6.

This is a Web interface, very simple to :

* Add users
* Remove users
* Modify users
* Get the lists of users


## Prerequisite

### Windows
* Install Visual Studio 2015 Community / Enterprise

### Mac
* Install dnvm

For more explication : http://docs.asp.net/en/latest/getting-started/index.html

## Architecture

The projects is splited in two :


### Web API (Backend)

* MVC 6 / ASP.NET 5

### Front-End
* jQuery
* Knockout JS
* BootStrap
* HTML 5 / CSS

### Unit Test
* Unit test for the back-end


## Usage

### Add an user

To add an user, fill the form and click on new.

### Modify an existing user

Select an user on the table and click on the magnifying glass icon (modify icon).
The user information will be display on the form and button change to "modify". 
After you click "modify", it will come back to "Add" form.

### Delete an user

Click on the delete icon next to selected user.


## Install Project

### Runing on Windows
Running on windows is simple, just restore package with nuget. Visual Studio will download the bower package and the npm package. The gulp task is not neccessary but it will be downloaded anyway but VS2015.

The UNIT TEST don't work on Visual studio. Since Xunit 2.5+ is still on beta, so it is too early to try Unit Test on visual studio. Maybe it will work if you use dnx directly on command-line.

### Running on Mac

Running on mac

#### Compile the website
Go the project source : [SolutionDir]/src/UserAdminitration

```
sudo nom -g instakll
bower install
dnu restore
dnu build
```

#### Run the website
Go the project source : [SolutionDir]/src/UserAdminitration

```
dnx web
```

#### Run Unit Test
Go the project test source : [SolutionDir]/test/UserAdminitration.UnitTests

```
dnx test
```


