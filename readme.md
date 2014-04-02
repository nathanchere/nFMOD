nFMOD
=====

A .NET wrapper for Firelight Studio's FMOD audio library.

At this point in time nFMOD focuses solely on Windows. While Mono-based cross platform support is possible, it's not a priority.
If you require an example of using FMOD with Mono, including a GTK-based demo for Linux, please look at [FmodSharp](https://gitorious.org/fmodsharp).

Release history
---------------

####v0.2 (2014-04-02) [develop]

* update fmodex.dll version from 4.34.5 > 4.44.32
* minimum .Net Framework version lowered from 4.0 > 2.0
* proper exceptions for all unmanaged error codes
* handler for converting ErrorCodes to Exceptions
* simplify redundant class/namespace (eg "nFMOD.SoundSystem.SoundSystem")
* fix crash when calling GetLevel/SetLevel with non-debug build of fmodex.dll

####v0.1 (2014-04-01) [master]

* initial release to Nuget
* minimum .Net Framework version lowered from 4.0 > 2.0
* namespace restructuring

####v alpha (2014-03-31)

* initial release to GitHub

TODO
----

* Nuget distribution: better handle fmodex.dll deployment


Credits / thanks
----------------

[FMOD](http://www.fmod.org/): Firelight Studios (http://firelightstudios.net/) for the underlying tech and generously making FMOD freely available for non-commercial projects

[FmodSharp](https://gitorious.org/fmodsharp): Marc-Andre Ferland
