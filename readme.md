nFMOD
=====

A .NET wrapper for Firelight Studio's FMOD audio library.

The official FMOD SDK comes with some simple C# examples, however .Net is clearly not the primary audience for the library and the C# examples largely read like classic C code. Compared to something like nAudio, the code for interacting with FMOD in the official SDK samples felt... unrefined. nFMOD is an attempt at refinement.

At this point in time nFMOD focuses solely on Windows. While Mono-based cross platform support is possible, it's not a priority.
If you require an example of using FMOD with platforms other than Winfows please look at [FmodSharp](https://gitorious.org/fmodsharp) which appears to use the same FMOD SDK base but has working GTK / Mono sample code included.

Release history
---------------

####vNext

* x64 support
* add support for missing and new-since-4.32 functionality
* restructure / consolidate class heirarchy
* expose more FMOD functionality internally
* cull more code specific to non-Windows platforms (eg PS2, Xbox)

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

TODO
----

* Nuget distribution: better handle fmodex.dll deployment
* Go through and update comments from before v0.2 refactor which still
  reference C-style class names, structs etc
* update minimum version constant after regression testing


Credits / thanks
----------------

[FMOD](http://www.fmod.org/): Firelight Studios (http://firelightstudios.net/) for the underlying tech and generously making FMOD freely available for non-commercial projects
