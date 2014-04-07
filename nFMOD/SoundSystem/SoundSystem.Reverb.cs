using System;
using System.Runtime.InteropServices;
using System.Security;

namespace nFMOD
{
    public partial class SoundSystem
    {


        public Reverb CreateReverb()
        {
            IntPtr ReverbHandle = IntPtr.Zero;
            Errors.ThrowIfError(CreateReverb(DangerousGetHandle(), ref ReverbHandle));
            return new Reverb(ReverbHandle);
        }

        public ReverbProperties ReverbProperties
        {
            get
            {
                var result = ReverbProperties.Generic;
                Errors.ThrowIfError(GetReverbProperties(DangerousGetHandle(), ref result));
                return result;
            }
            set { Errors.ThrowIfError(SetReverbProperties(DangerousGetHandle(), ref value)); } }

        public ReverbProperties ReverbAmbientProperties
        {
            get
            {
                var Val = ReverbProperties.Generic;
                Errors.ThrowIfError(GetReverbAmbientProperties(DangerousGetHandle(), ref Val));
                return Val;
            }

            set
            {
                Errors.ThrowIfError(SetReverbAmbientProperties(DangerousGetHandle(), ref value));
            }
        }
    }
}

