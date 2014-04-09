# nFMOD
###*A .NET wrapper for Firelight Studio's FMOD audio library.*

The official FMOD SDK comes with some C# examples, however .Net is clearly not the primary audience for the library and the C# examples largely read like a direct port of classic C code. Compared to something like [nAudio](http://naudio.codeplex.com/), the code for interacting with FMOD in the official SDK samples feels very... unrefined.

nFMOD is an attempt at "refinement".

At this point in time nFMOD focuses solely on Windows. While Mono-based cross platform support is possible, it's not a priority. If you require an example of using FMOD with platforms other than Winfows please look at [FmodSharp] (https://gitorious.org/fmodsharp) which appears to also use the same FMOD SDK base but has GTK+ / Mono samples working.

[![Send me a tweet](http://nathanchere.github.io/twitter_tweet.png)](https://twitter.com/intent/tweet?screen_name=nathanchere "Send me a tweet") [![Follow me](http://nathanchere.github.io/twitter_follow.png)](https://twitter.com/intent/user?screen_name=nathanchere "Follow me")

## Status

Branch | Status | Download | Description
------|-----|------|--------
master | [![Build status](https://ci.appveyor.com/api/projects/status/93dn556v0jw4q6la/branch/master)](https://ci.appveyor.com/project/nathanchere/nfmod) | [.zip](https://github.com/nathanchere/nFMOD/archive/master.zip) | for those who want to live on the bleeding edge
stable | [![Build status](https://ci.appveyor.com/api/projects/status/93dn556v0jw4q6la/branch/stable)](https://ci.appveyor.com/project/nathanchere/nfmod) | [.zip](https://github.com/nathanchere/nFMOD/archive/stable.zip) | latest released/numbered code

*CI generously provided by [Appveyor](http://appveyor.com)*

How I approach my public projects is explained on [my github home page](http://nathanchere.github.io).

## Release history

#### v?

* x64 support
* code for declared but not implemented extern methods
* implement appropriate events

#### vNext
* massive code clean-up and consolidation of class heirarchy

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

* go through and fix anything TODO
* get rid of most of the out and ref parameters
* Nuget distribution: better handle fmodex.dll deployment
* Go through and update comments from before v0.2 refactor which still
  reference C-style class names, structs etc

## Credits / thanks

* [Firelight Studios](http://firelightstudios.net/): for the underlying [FMOD](http://www.fmod.org/) library which is the real star of the show, and generously making FMOD freely available for non-commercial projects
* [Marc-Andre Ferland](https://github.com/madrang): for the [FmodSharp](https://gitorious.org/fmodsharp) project which demonstrates how to use FMOD with .Net for non-Windows platforms