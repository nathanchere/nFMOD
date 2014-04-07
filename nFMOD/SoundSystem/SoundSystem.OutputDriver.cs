using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Security;

namespace nFMOD
{
	public partial class SoundSystem
	{
        public struct OutputDriverDTO
	    {
		    internal int Id { get; set; }
		    public string Name { get; internal set; }
		    public Guid Guid { get; internal set; }
		    public Capabilities Capabilities { get; internal set; }
		    public int MinimumFrequency { get; internal set; }
		    public int MaximumFrequency { get; internal set; }
		    public SpeakerMode SpeakerMode { get; internal set; }
		
		    public override string ToString ()
		    {
			    return this.Name;
		    }
	    }

	}
}

