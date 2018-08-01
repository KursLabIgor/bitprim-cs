using System;
using Bitprim.Native;

namespace Bitprim
{
    public class HashList : NativeList<byte[]>
    {
        private bool ownsNativeObject_;

        protected override IntPtr CreateNativeList()
        {
            ownsNativeObject_ = true;
            return HashListNative.chain_hash_list_construct_default();
        }

        protected override byte[] GetNthNativeElement(UInt64 n)
        {
            var managedHash = new hash_t();
            HashListNative.chain_hash_list_nth_out(NativeInstance, n, ref managedHash);
            return managedHash.hash;
        }

        protected override UInt64 GetCount()
        {
            return HashListNative.chain_hash_list_count(NativeInstance);
        }

        protected override void AddElement(byte[] element)
        {
            HashListNative.chain_hash_list_push_back(NativeInstance, element);
        }

        protected override void DestroyNativeList()
        {
            if(ownsNativeObject_)
            {
                HashListNative.chain_hash_list_destruct(NativeInstance);
            }
        }

        internal HashList(IntPtr nativeInstance, bool ownsNativeObject = true) : base(nativeInstance)
        {
            ownsNativeObject_ = ownsNativeObject;
        }
    }
    

}