nFMOD
=====

A .NET wrapper for Firelight Studio's FMOD audio library.

At this point in time nFMOD focuses solely on Windows. While Mono-based cross platform support is possible, it's not a priority.
If you require an example of using FMOD with Mono, including a GTK-based demo for Linux, please look at [FmodSharp](https://gitorious.org/fmodsharp).

Initial goals are to reduce requirements (currently .NET Framework 4.0, ideally 2.0), update to current FmodEx version, support FMOD x64, package for Nuget deployment, implement a more "managed"-style approach to better handle resource management concerns and provide more meaningful logging and exception handling.

Release history
---------------

####v0.2 [develop]

* update fmodex.dll version from 4.34.5 > 4.44.32
* minimum .Net Framework version lowered from 4.0 > 2.0
* refactor to simplify redundant class/namespace (eg "nFMOD.SoundSystem.SoundSystem")

####v0.1 [master]

* initial release to Nuget
* minimum .Net Framework version lowered from 4.0 > 2.0
* namespace restructuring

####v alpha

* initial release to GitHub

TODO
----

* Nuget distribution: better handle fmodex.dll deployment




Credits / thanks
----------------

[FMOD](http://www.fmod.org/): Firelight Studios (http://firelightstudios.net/) for the underlying tech and generously making FMOD freely available for non-commercial projects

[FmodSharp](https://gitorious.org/fmodsharp): Marc-Andre Ferland
