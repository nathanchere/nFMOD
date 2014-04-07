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
        public struct Properties
        {
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
            private float diffusion;
            private float density;
            private ReverbFlags flags;

            /// <summary>
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
            /// environment size in meters (win32 only)
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
            /// environment diffusion (win32/xbox)
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
            /// room effect level (at mid frequencies) (win32/xbox)
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
            /// relative room effect level at high frequencies (win32/xbox)
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
            /// relative room effect level at low frequencies (win32 only)
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
            /// reverberation decay time at mid frequencies (win32/xbox)
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
            /// high-frequency to mid-frequency decay time ratio (win32/xbox)
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
            /// low-frequency to mid-frequency decay time ratio (win32 only)
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
            /// early reflections level relative to room effect (win32/xbox)
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
            /// initial reflection delay time (win32/xbox)
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

            //TODO replace by Vector3

            /// <summary>
            /// early reflections panning vector (win32 only)
            /// </summary>
            public float[] ReflectionsPan
            {
                get { return this.reflectionsPan; }
                set { this.reflectionsPan = value; }
            }

            /// <summary>
            /// late reverberation level relative to room effect (win32/xbox)
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
            /// late reverberation delay time relative to initial reflection (win32/xbox)
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

            //TODO replace by Vector3

            /// <summary>
            /// late reverberation panning vector (win32 only)
            /// </summary>
            public float[] ReverbPan
            {
                get { return this.reverbPan; }
                set { this.reverbPan = value; }
            }

            /// <summary>
            /// echo time (win32 only)
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
            /// echo depth (win32 only)
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
            /// modulation time (win32 only)
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
            /// modulation depth (win32 only)
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
            /// change in level per meter at high frequencies (win32 only)
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
            /// reference high frequency (hz) (win32/xbox)
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
            /// reference low frequency (hz) (win32 only)
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
            /// like rolloffscale in System::set3DSettings but for reverb room size effect (win32)
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

            /// <summary>
            /// Value that controls the echo density in the late reverberation decay. (xbox only)
            /// </summary>
            public float Diffusion
            {
                get { return this.diffusion; }
                set
                {
                    this.CheckRange(value, 0.0, 100.0, "Diffusion");
                    this.diffusion = value;
                }
            }

            /// <summary>
            /// Value that controls the modal density in the late reverberation decay (xbox only)
            /// </summary>
            public float Density
            {
                get { return this.density; }
                set
                {
                    this.CheckRange(value, 0.0, 100.0, "Environment");
                    this.density = value;
                }
            }

            /// <summary>
            /// Modifies the behavior of above properties.
            /// (win32/ps2)
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

            #region Default Preset

            public static readonly Properties Generic = new Properties
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
                Diffusion = 100.0f,
                Density = 100.0f,
                Flags = ReverbFlags.Default
            };

            #endregion

        }
    }

}