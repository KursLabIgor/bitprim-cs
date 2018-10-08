using System;

namespace Bitprim
{
    public interface IUtxo
    {
        /// <summary>
        /// Output destination address.
        /// </summary>
        string Address { get; }

        /// <summary>
        /// Output parent tx hash in 32 byte array format.
        /// </summary>
        byte[] TxHash { get; }

        /// <summary>
        /// Output index inside its parent transaction.
        /// </summary>
        UInt32 Index { get; }

        /// <summary>
        /// Output amount, in coin units.
        /// </summary>
        UInt64 Amount { get; }

        /// <summary>
        /// Output script.
        /// </summary>
        IScript Script { get; }
    }
}