using System;
using System.Runtime.InteropServices;

namespace Bitprim.Native
{
    internal static class Platform
    {
        [DllImport(Constants.BITPRIM_C_LIBRARY)]
        public static extern void platform_free(IntPtr nativePtr);
    }

}