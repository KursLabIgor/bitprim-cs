using System;
using System.Runtime.InteropServices;

#if KEOKEN

using Bitprim.Native.Keoken;

namespace Bitprim.Keoken
{
    /// <summary>
    /// TODO: Add docs
    /// </summary>
    public class GetAssetsData:IDisposable
    {
        private bool ownsNativeObject_;
        private readonly IntPtr nativeInstance_;

        public GetAssetsData(IntPtr nativeInstance)
        {
            nativeInstance_ = nativeInstance;
            ownsNativeObject_ = false;
        }

        ~GetAssetsData()
        {
            Dispose(false);
        }

        /// <summary>
        /// Release resources
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                //Release managed resources and call Dispose for member variables
            }
            //Release unmanaged resources
            if(ownsNativeObject_)
            {
                GetAssetsDataNative.keoken_get_assets_data_destruct(nativeInstance_);
            }
        }

        public UInt32 AssetId 
        {
            get 
            {
                return  GetAssetsDataNative.keoken_get_assets_data_asset_id(nativeInstance_);
            }
        }

        public string AssetName 
        {
            get 
            {
                using (NativeString native = new NativeString(GetAssetsDataNative.keoken_get_assets_data_asset_name(nativeInstance_)))
                {
                    return native.ToString();
                }
            }
        }

        public PaymentAddress AssetCreator
        {
            get 
            {
                return new PaymentAddress(GetAssetsDataNative.keoken_get_assets_data_asset_creator(nativeInstance_));
            }
        }

        public Int64 Amount 
        {
            get 
            {
                return GetAssetsDataNative.keoken_get_assets_data_amount(nativeInstance_);
            }
        }
    }
}

#endif  