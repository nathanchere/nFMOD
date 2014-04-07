using System;
using System.Runtime.InteropServices;

namespace nFMOD
{
    public partial class Reverb
    {                
        /// <summary>
        /// Structure defining a reverb environment.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct ReverbProperties
        {

            #region Variables
            private int instance;
            private int environment;
            private float envSize;
            private float envDiffusion;
            private int room;
            private int roomHF;
            private int roomLF;
            private float decayTime;
            private float decayHFRatio;
            private float decayLFRatio;
            private int reflections;
            private float reflectionsDelay;

            //TODO replace by Vector3
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)] private float[] reflectionsPan;

            private int reverb;
            private float reverbDelay;

            //TODO replace by Vector3
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)] private float[] reverbPan;

            private float echoTime;
            private float echoDepth;
            private float modulationTime;
            private float modulationDepth;
            private float airAbsorptionHF;
            private float hFReference;
            private float lFReference;
            private float roomRolloffFactor;

            [Obsolete("Xbox-only")]
            private readonly float diffusion;
            [Obsolete("Xbox-only")]
            private readonly float density;

            private ReverbFlags flags;
            #endregion

            #region Properties/// <summary>
            /// EAX4 only. Environment Instance.
            /// 3 seperate reverbs simultaneously are possible.
            /// This specifies which one to set.
            /// </summary>
            public int Instance
            {
                get { return this.instance; }
                set
                {
                    this.CheckRange(value, 0, 3, "Instance");
                    this.instance = value;
                }
            }

            /// <summary>
            /// Sets all listener properties
            /// </summary>
            public int Environment
            {
                get { return this.environment; }
                set
                {
                    this.CheckRange(value, -1, 25, "Environment");
                    this.environment = value;
                }
            }

            /// <summary>
            /// Environment size in meters
            /// </summary>
            public float EnvironmentSize
            {
                get { return this.envSize; }
                set
                {
                    this.CheckRange(value, 1.0, 100.0, "EnvironmentSize");
                    this.envSize = value;
                }
            }

            /// <summary>
            /// Environment diffusion
            /// </summary>
            public float EnvironmentDiffusion
            {
                get { return this.envDiffusion; }
                set
                {
                    this.CheckRange(value, 0.0, 1.0, "EnvironmentDiffusion");
                    this.envDiffusion = value;
                }
            }

            /// <summary>
            /// Room effect level at mid frequencies
            /// </summary>
            public int Room
            {
                get { return this.room; }
                set
                {
                    this.CheckRange(value, -10000, 0, "Room");
                    this.room = value;
                }
            }

            /// <summary>
            /// Relative room effect level at high frequencies
            /// </summary>
            public int RoomHighFrequencies
            {
                get { return this.roomHF; }
                set
                {
                    this.CheckRange(value, -10000, 0, "RoomHighFrequencies");
                    this.roomHF = value;
                }
            }

            /// <summary>
            /// Relative room effect level at low frequencies
            /// </summary>
            public int RoomLowFrequencies
            {
                get { return this.roomLF; }
                set
                {
                    this.CheckRange(value, -10000, 0, "RoomLowFrequencies");
                    this.roomLF = value;
                }
            }

            /// <summary>
            /// Reverb decay time at mid frequencies
            /// </summary>
            public float DecayTime
            {
                get { return this.decayTime; }
                set
                {
                    this.CheckRange(value, 0.1, 20.0, "DecayTime");
                    this.decayTime = value;
                }
            }

            /// <summary>
            /// High-frequency to mid-frequency decay time ratio
            /// </summary>
            public float DecayHighFrequencyRatio
            {
                get { return this.decayHFRatio; }
                set
                {
                    this.CheckRange(value, 0.1, 2.0, "DecayHighFrequencyRatio");
                    this.decayHFRatio = value;
                }
            }

            /// <summary>
            /// Low-frequency to mid-frequency decay time ratio
            /// </summary>
            public float DecayLowFrequencyRatio
            {
                get { return this.decayLFRatio; }
                set
                {
                    this.CheckRange(value, 0.1, 2.0, "DecayLowFrequencyRatio");
                    this.decayLFRatio = value;
                }
            }

            /// <summary>
            /// Early reflections level relative to room effect
            /// </summary>
            public int Reflections
            {
                get { return this.reflections; }
                set
                {
                    this.CheckRange(value, -10000, 1000, "Reflections");
                    this.reflections = value;
                }
            }

            /// <summary>
            /// Initial reflection delay time
            /// </summary>
            public float ReflectionsDelay
            {
                get { return this.reflectionsDelay; }
                set
                {
                    this.CheckRange(value, 0.0, 0.3, "ReflectionsDelay");
                    this.reflectionsDelay = value;
                }
            }            

            /// <summary>
            /// Early reflections panning vector
            /// </summary>
            public float[] ReflectionsPan //TODO replace by Vector3
            {
                get { return this.reflectionsPan; }
                set { this.reflectionsPan = value; }
            }

            /// <summary>
            /// Late reverb level relative to room effect
            /// </summary>
            public int Reverb
            {
                get { return this.reverb; }
                set
                {
                    this.CheckRange(value, -10000, 2000, "Reverb");
                    this.reverb = value;
                }
            }

            /// <summary>
            /// Late reverb delay time relative to initial reflection
            /// </summary>
            public float ReverbDelay
            {
                get { return this.reverbDelay; }
                set
                {
                    this.CheckRange(value, 0.0, 0.1, "ReverbDelay");
                    this.reverbDelay = value;
                }
            }
            
            /// <summary>
            /// Late reverb panning vector)
            /// </summary>
            public float[] ReverbPan //TODO replace by Vector3
            {
                get { return this.reverbPan; }
                set { this.reverbPan = value; }
            }

            /// <summary>
            /// Echo time
            /// </summary>
            public float EchoTime
            {
                get { return this.echoTime; }
                set
                {
                    this.CheckRange(value, 0.075, 0.25, "EchoTime");
                    this.echoTime = value;
                }
            }

            /// <summary>
            /// Echo depth
            /// </summary>
            public float EchoDepth
            {
                get { return this.echoDepth; }
                set
                {
                    this.CheckRange(value, 0.0, 1.0, "EchoDepth");
                    this.echoDepth = value;
                }
            }

            /// <summary>
            /// Modulation time
            /// </summary>
            public float ModulationTime
            {
                get { return this.modulationTime; }
                set
                {
                    this.CheckRange(value, 0.04, 4.0, "ModulationTime");
                    this.modulationTime = value;
                }
            }

            /// <summary>
            /// Modulation depth
            /// </summary>
            public float ModulationDepth
            {
                get { return this.modulationDepth; }
                set
                {
                    this.CheckRange(value, 0.0, 1.0, "ModulationDepth");
                    this.modulationDepth = value;
                }
            }

            /// <summary>
            /// Change in level per meter at high frequencies
            /// </summary>
            public float AirAbsorptionHighFrequencies
            {
                get { return this.airAbsorptionHF; }
                set
                {
                    this.CheckRange(value, -100.0, 0.0, "AirAbsorptionHighFrequencies");
                    this.airAbsorptionHF = value;
                }
            }

            /// <summary>
            /// Reference high frequency (hz)
            /// </summary>
            public float HighFrequencyReference
            {
                get { return this.hFReference; }
                set
                {
                    this.CheckRange(value, 1000.0, 20000.0, "HighFrequencyReference");
                    this.hFReference = value;
                }
            }

            /// <summary>
            /// Reference low frequency (hz)
            /// </summary>
            public float LowFrequencyReference
            {
                get { return this.lFReference; }
                set
                {
                    this.CheckRange(value, 20.0, 1000.0, "LowFrequencyReference");
                    this.lFReference = value;
                }
            }

            /// <summary>
            /// Like rolloffscale in System::set3DSettings but for reverb room size effect
            /// </summary>
            public float RoomRolloffFactor
            {
                get { return this.roomRolloffFactor; }
                set
                {
                    this.CheckRange(value, 0.0, 10.0, "RoomRolloffFactor");
                    this.roomRolloffFactor = value;
                }
            }

            #endregion

            /// <summary>
            /// Modifies the behavior of other reverb properties.
            /// </summary>
            public ReverbFlags Flags
            {
                get { return this.flags; }
                set { this.flags = value; }
            }

            private void CheckRange(double Value, double Min, double Max, string Param)
            {
                if (Value < Min || Value > Max)
                    throw new ArgumentOutOfRangeException(Param, Value,
                        string.Format("{0}: Tried to set the value [{1}], but only accept [{2} to {3}].", Param, Value,
                            Min, Max));
            }

            public static readonly ReverbProperties Generic = new ReverbProperties
            {
                Instance = 0,
                Environment = -1,
                EnvironmentSize = 7.5f,
                EnvironmentDiffusion = 1.0f,
                Room = -1000,
                RoomHighFrequencies = -100,
                RoomLowFrequencies = 0,
                DecayTime = 1.49f,
                DecayHighFrequencyRatio = 0.83f,
                DecayLowFrequencyRatio = 1.0f,
                Reflections = -2602,
                ReflectionsDelay = 0.007f,
                ReflectionsPan = new float[] {0.0f, 0.0f, 0.0f},
                Reverb = 200,
                ReverbDelay = 0.011f,
                ReverbPan = new float[] {0.0f, 0.0f, 0.0f},
                EchoTime = 0.25f,
                EchoDepth = 0.0f,
                ModulationTime = 0.25f,
                ModulationDepth = 0.0f,
                AirAbsorptionHighFrequencies = -5.0f,
                HighFrequencyReference = 5000.0f,
                LowFrequencyReference = 250.0f,
                RoomRolloffFactor = 0.0f,                
                Flags = ReverbFlags.Default
            };
        }
    }

}