using System;
using System.Runtime.InteropServices;

#if KEOKEN

namespace Bitprim.Native.Keoken
{
    internal static class GetAssetsByAddressDataListNative  
    {
        [DllImport(Constants.BITPRIM_C_LIBRARY)]
        public static extern IntPtr keoken_get_assets_by_address_list_construct_default(IntPtr getAssetByAddressDataList);

        [DllImport(Constants.BITPRIM_C_LIBRARY)]
        public static extern void keoken_get_assets_by_address_list_push_back(IntPtr getAssetByAddressDataList, IntPtr getAssetByAddressData);
       
        [DllImport(Constants.BITPRIM_C_LIBRARY)]
        public static extern IntPtr keoken_get_assets_by_address_list_destruct(IntPtr getAssetByAddressDataList);

        [DllImport(Constants.BITPRIM_C_LIBRARY)]
        public static extern UInt64 keoken_get_assets_by_address_list_count(IntPtr getAssetByAddressDataList);

        [DllImport(Constants.BITPRIM_C_LIBRARY)]
        public static extern IntPtr keoken_get_assets_by_address_list_nth(IntPtr getAssetByAddressDataList, UInt64 index);
    }
}

#endif