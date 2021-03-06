using System;
using System.Runtime.InteropServices;

namespace Bitprim.Native
{
    internal static class HashListNative
    {
        [DllImport(Constants.BITPRIM_C_LIBRARY)]
        public static extern IntPtr core_hash_list_construct_default();

        [DllImport(Constants.BITPRIM_C_LIBRARY)]
        public static extern void core_hash_list_nth_out(IntPtr list, UInt64 n, ref hash_t out_hash);

        [DllImport(Constants.BITPRIM_C_LIBRARY)]
        public static extern UInt64 core_hash_list_count(IntPtr list);

        [DllImport(Constants.BITPRIM_C_LIBRARY)]
        public static extern void core_hash_list_destruct(IntPtr list);

        [DllImport(Constants.BITPRIM_C_LIBRARY)]
        public static extern void core_hash_list_push_back(IntPtr list, byte[] hash);
    }

}