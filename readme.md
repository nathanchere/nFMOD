# nFMOD
###*A .NET wrapper for Firelight Studio's FMOD audio library.*

The official FMOD SDK comes with some C# examples, however .Net is clearly not the primary audience for the library and the C# examples largely read like a direct port of classic C code. Compared to something like [nAudio](http://naudio.codeplex.com/), the code for interacting with FMOD in the official SDK samples feels very... unrefined.

nFMOD is an attempt at "refinement".

At this point in time nFMOD focuses solely on Windows. While Mono-based cross platform support is possible, it's not a priority. If you require an example of using FMOD with platforms other than Winfows please look at [FmodSharp] (https://gitorious.org/fmodsharp) which appears to also use the same FMOD SDK base but has GTK+ / Mono samples working.

##### Contact

[![Send me a tweet](http://nathanchere.github.io/twitter_tweet.png)](https://twitter.com/intent/user?screen_name=nathanchere "Send me a tweet") [![Follow me](http://nathanchere.github.io/twitter_follow.png)](https://twitter.com/intent/user?screen_name=nathanchere "Follow me")

[My GitHub home page](http://nathanchere.github.io)

## Release history

#### vNext

* code clean-up
* x64 support
* more consolidation of class heirarchy

####v0.3 (2014-04-07)

* Basic x64 support ground work (largely untested)
* add support for missing and new-since-4.32 functionality
* restructure / consolidate class heirarchy
* expose more FMOD functionality internally
* cull more code specific to non-Windows platforms (eg PS2, Xbox)
* mark code which can't be removed (eg interop struct fields) as Obsolete

####v0.2 (2014-04-04)

* update fmodex.dll version from 4.34.5 > 4.44.32
* minimum .Net Framework version lowered from 4.0 > 2.0
* proper exceptions for all unmanaged error codes
* handler for converting ErrorCodes to Exceptions
* simplify redundant class/namespace (eg "nFMOD.SoundSystem.SoundSystem")
* fix crash when calling GetLevel/SetLevel with non-debug build of fmodex.dll

####v0.1 (2014-04-01)

* initial release to Nuget
* minimum .Net Framework version lowered from 4.0 > 2.0
* namespace restructuring

####vAlpha (2014-03-31)

* initial release to GitHub

#### TODO (one day)

* Nuget distribution: better handle fmodex.dll deployment
* Go through and update comments from before v0.2 refactor which still
  reference C-style class names, structs etc
* update minimum version constant after regression testing

## About the repository

As with any of my projects intended for public consumption, the two main branches are:

* **master**: for those who want to live on the bleeding edge
* **stable**: only updated with numbered releases

*CI generously provided by [Appveyor](http://appveyor.com)*

Branch | Status | Download
------|-----|------
master | [![Build status](https://ci-beta.appveyor.com/api/projects/status/rgra2l9lhf8281v6/branch/master)](https://ci-beta.appveyor.com/project/nathanchere/coverttweeter) | [.zip](https://github.com/nathanchere/CovertTweeter/archive/master.zip)
stable | [![Build status](https://ci-beta.appveyor.com/api/projects/status/rgra2l9lhf8281v6/branch/stable)](https://ci-beta.appveyor.com/project/nathanchere/coverttweeter) | [.zip](https://github.com/nathanchere/CovertTweeter/archive/stable.zip)

## Credits / thanks

* [Firelight Studios](http://firelightstudios.net/): for the underlying [FMOD](http://www.fmod.org/) library which is the real star of the show, and generously making FMOD freely available for non-commercial projects
* [Marc-Andre Ferland](https://github.com/madrang): for the [FmodSharp](https://gitorious.org/fmodsharp) project which demonstrates how to use FMOD with .Net for non-Windows platforms