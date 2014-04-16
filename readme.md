# nFMOD
###*A .NET wrapper for Firelight Studio's FMOD audio library.*

The official FMOD SDK comes with some C# examples, however .Net is clearly not the primary audience for the library and the C# examples largely read like a direct port of classic C code. Compared to something like [nAudio](http://naudio.codeplex.com/), the code for interacting with FMOD in the official SDK samples feels very... unrefined.

nFMOD is an attempt at "refinement".

At this point in time nFMOD focuses solely on Windows. While Mono-based cross platform support is possible, it's not a priority. If you require an example of using FMOD with platforms other than Winfows please look at [FmodSharp] (https://gitorious.org/fmodsharp) which appears to also use the same FMOD SDK base but has GTK+ / Mono samples working. nFMOD actually started out as a fork of FmodSharp before I realised similarity to the official FMOD SDK and decided to base off the latter for consistency.

[![Send me a tweet](http://nathanchere.github.io/twitter_tweet.png)](https://twitter.com/intent/tweet?screen_name=nathanchere "Send me a tweet") [![Follow me](http://nathanchere.github.io/twitter_follow.png)](https://twitter.com/intent/user?screen_name=nathanchere "Follow me")

## Documentation

nFMOD is still under heavy development and likely to change frequently and significantly enough to make documentation a fool's endeavour at this point. Planned to co-incide with the 1.0 release are 'tutorial' articles and sample projects.

A brief example of how easy it is to start adding sound to your application with nFMOD:

```C#
using (var fmod = new FmodSystem())
{
    fmod.Init();
    using (var audio = fmod.CreateSound("testfile.mp3"))
    {
        fmod.PlaySound(audio);
        Console.WriteLine("nFMOD test\nPlaying doowackadoo; press any key to exit");
        Console.ReadKey();
    }
    fmod.CloseSystem();
}
```

## Status

Branch | Status | Download | Description
------|-----|------|--------
master | [![Build status](https://ci.appveyor.com/api/projects/status/93dn556v0jw4q6la/branch/master)](https://ci.appveyor.com/project/nathanchere/nfmod) | [.zip](https://github.com/nathanchere/nFMOD/archive/master.zip) | for those who want to live on the bleeding edge
stable | [![Build status](https://ci.appveyor.com/api/projects/status/93dn556v0jw4q6la/branch/stable)](https://ci.appveyor.com/project/nathanchere/nfmod) | [.zip](https://github.com/nathanchere/nFMOD/archive/stable.zip) | latest released/numbered code

*CI generously provided by [Appveyor](http://appveyor.com)*

How I approach my public projects is explained on [my github home page](http://nathanchere.github.io).

## Release history

#### vNext
* Go through the TODO list
* Add internal ctors for main classes to take existing instance handle
* More sample code 
* FmodSYstem to track and manage additional resources (eg Channel)

#### v0.6 (2014-04-??)
* Fix CheckMinimumVersion bug causing crash instead of appropriate exception
* FmodSystem DSP methods deprecated in favour of strongly typed DSPs
* Relevant logic moved from FmodSystem to DSPs
* DSPs now tied to a specific FmodSystem instance
* FmodSystem.ReleaseHandle() now handles cleanup of relevant dependant resources
* DSP.Oscillator basic implementation
* Oscillator console demo
* Oscillator and spectrum visualisation demo

#### v0.5.1 (2014-04-14)
* Fix fmodex.dll extern declarations accidentally left public

#### v0.5 (2014-04-10)
* Enum cleanup
* Sort all extern aliases
* Add internal ctors for main classes to take existing instance handle
* Add nFMOD.Spikes project for answering some of the unknowns not covered by FMOD API documenation
* Spectrum analysis sample project
* More Channel and FmodSystem functionality exposed externally

#### v0.4.2 (2014-04-09)
* Add cleanup of DSP, ChannelGroup, Debug code which was missed in v0.4 release

#### v0.4 (2014-04-09)
* massive code clean-up and consolidation of class heirarchy
* minimum version supported updated to 4.44.32
* expose more FMOD functionality internally

####v0.3 (2014-04-07)

* Drop FmodSharp as base; replace with rewritten code with official FMOD SDK as reference
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

#### vTODO (one day)

* go through and fix anything TODO
* change methods like FmodSystem::GetWaveData to get rid of ref/out params
* get rid of most of the out and ref parameters
* Nuget distribution: better handle fmodex.dll deployment
* Go through and update comments from before v0.2 refactor which still
  reference C-style class names, structs etc
* thorough x64 support
* code for declared but not implemented extern methods
* implement appropriate events
* proper documentation - at the very least, map differences and guide on porting C/C++ code to nFMOD

## Credits / thanks

* [Firelight Studios](http://firelightstudios.net/): for the underlying [FMOD](http://www.fmod.org/) library which is the real star of the show, and generously making FMOD freely available for non-commercial projects
* [Marc-Andre Ferland](https://github.com/madrang): for the [FmodSharp](https://gitorious.org/fmodsharp) project which demonstrates how to use FMOD with .Net for non-Windows platforms.