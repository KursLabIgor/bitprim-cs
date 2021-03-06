using System;
using System.Runtime.InteropServices;

namespace Bitprim.Native
{
    internal static class InputListNative
    {
        [DllImport(Constants.BITPRIM_C_LIBRARY)]
        public static extern IntPtr chain_input_list_construct_default();

        [DllImport(Constants.BITPRIM_C_LIBRARY)]
        public static extern IntPtr chain_input_list_nth(IntPtr list, UInt64 n);

        [DllImport(Constants.BITPRIM_C_LIBRARY)]
        public static extern UInt64 chain_input_list_count(IntPtr list);

        [DllImport(Constants.BITPRIM_C_LIBRARY)]
        public static extern void chain_input_list_destruct(IntPtr list);

        [DllImport(Constants.BITPRIM_C_LIBRARY)]
        public static extern void chain_input_list_push_back(IntPtr list, IntPtr input);
    }

}