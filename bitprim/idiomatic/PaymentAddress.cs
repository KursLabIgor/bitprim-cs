using System;
using Bitprim.Native;

namespace Bitprim
{
    /// <summary>
    /// Represents a Bitcoin wallet address.
    /// </summary>
    public class PaymentAddress : IDisposable
    {
        private readonly IntPtr nativeInstance_;
        private readonly bool ownsNativeObject_;

        /// <summary>
        /// Create an address from its hex string representation.
        /// </summary>
        /// <param name="hexString"></param>
        public PaymentAddress(string hexString)
        {
            nativeInstance_ = PaymentAddressNative.wallet_payment_address_construct_from_string(hexString);
            ownsNativeObject_ = true;
        }

        internal PaymentAddress(IntPtr nativeInstance)
        {
            nativeInstance_ = nativeInstance;
            ownsNativeObject_ = false;
        }

        ~PaymentAddress()
        {
            Dispose(false);
        }

        /// <summary>
        /// Returns true iif this is a valid Base58 address.
        /// </summary>
        public bool IsValid => PaymentAddressNative.wallet_payment_address_is_valid(nativeInstance_) != 0;

        /// <summary>
        /// Address version.
        /// </summary>
        public byte Version => PaymentAddressNative.wallet_payment_address_version(nativeInstance_);

        /// <summary>
        /// Human readable representation.
        /// </summary>
        public string Encoded
        {
            get
            {
                using ( var addressString = new NativeString(PaymentAddressNative.wallet_payment_address_encoded(nativeInstance_)) )
                {
                    return addressString.ToString();
                }
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        internal IntPtr NativeInstance => nativeInstance_;

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                //Release managed resources and call Dispose for member variables
            }
            //Release unmanaged resources
            if (ownsNativeObject_)
            {
                PaymentAddressNative.wallet_payment_address_destruct(nativeInstance_);
            }
        }
    }

}