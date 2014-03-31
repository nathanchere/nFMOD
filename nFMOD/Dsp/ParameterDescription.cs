using System;
using System.Runtime.InteropServices;

namespace nFMOD.Dsp
{
	//TODO end submmary
	
	    /*
        <br>
        The step parameter tells the gui or application that the parameter has a certain granularity.<br>
        For example in the example of cutoff frequency with a range from 100.0 to 22050.0 you might only want the selection to be in 10hz increments.  For this you would simply use 10.0 as the step value.<br>
        For a boolean, you can use min = 0.0, max = 1.0, step = 1.0.  This way the only possible values are 0.0 and 1.0.<br>
        Some applications may detect min = 0.0, max = 1.0, step = 1.0 and replace a graphical slider bar with a checkbox instead.<br>
        A step value of 1.0 would simulate integer values only.<br>
        A step value of 0.0 would mean the full floating point range is accessable.<br>

        [PLATFORMS]
        Win32, Win64, Linux, Linux64, Macintosh, Xbox, Xbox360, PlayStation 2, GameCube, PlayStation Portable, PlayStation 3, Wii

        [SEE_ALSO]    
        System::createDSP
        System::getDSP
    ]
    */
    public struct ParameterDescription
    {
		/// <summary>
		/// Minimum value of the parameter.
		/// (ie 100.0)
		/// </summary>
        public float Min;
        
		/// <summary>
		/// Maximum value of the parameter.
		/// (ie 22050.0)
		/// </summary>
        public float Max;
        
		/// <summary>
		/// Default value of parameter.
		/// </summary>
        public float Defaultval;
        
		/// <summary>
		/// Name of the parameter to be displayed
		/// (ie "Cutoff frequency").
		/// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
		public char[] Name;
        
		/// <summary>
		/// Short string to be put next to value to denote the unit type.
		/// (ie "hz")
		/// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
		public char[] Label;
        
		/// <summary>
		/// Description of the parameter to be displayed as a help item / tooltip for this parameter.
		/// </summary>
        public string Description;
    }
}

