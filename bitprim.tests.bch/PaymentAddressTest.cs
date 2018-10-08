using Xunit;

namespace Bitprim.Tests
{
    public class PaymentAddressTest
    {
        [Fact]
        public void EmptyAddressShouldFail()
        {
            Assert.False(PaymentAddress.TryParse("", out PaymentAddress addr));
            Assert.Null(addr);
        }

        [Fact]
        public void WhitespaceAddressShouldFail()
        {
            Assert.False(PaymentAddress.TryParse(" ", out PaymentAddress addr));
            Assert.Null(addr);
        }

        [Fact]
        public void InvalidAddressShouldFail()
        {
            Assert.False(PaymentAddress.TryParse("abcd", out PaymentAddress addr));
            Assert.Null(addr);
        }

        [Fact]
        public void MainnetCashAddrAddressOK()
        {
            Assert.True(PaymentAddress.TryParse("bitcoincash:qrcuqadqrzp2uztjl9wn5sthepkg22majyxw4gmv6p", out PaymentAddress addr));
            Assert.NotNull(addr);
            Assert.True(addr.IsValid);
        }

        [Fact]
        public void MainnetCashAddrNoPrefixAddressOK()
        {
            Assert.True(PaymentAddress.TryParse("qrcuqadqrzp2uztjl9wn5sthepkg22majyxw4gmv6p", out PaymentAddress addr));
            Assert.NotNull(addr);
            Assert.True(addr.IsValid);
        }

        [Fact]
        public void MainnetLegacyAddressOK()
        {
            var a = new PaymentAddress("");

            Assert.True(PaymentAddress.TryParse("1P3GQYtcWgZHrrJhUa4ctoQ3QoCU2F65nz", out PaymentAddress addr));
            Assert.NotNull(addr);
            Assert.True(addr.IsValid);
        }

        // TODO A standalone testnet address is not considered valid by default; the node needs to be in testnet mode
        // Analyze removing this hidden dependency
    }
}