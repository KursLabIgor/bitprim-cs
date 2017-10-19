using BitprimCs;
using System;
using System.Text;
using System.Threading;
using Xunit;

namespace BitprimCs.Tests
{
    public class ChainTest : IClassFixture<ExecutorFixture>
    {
        private ExecutorFixture executorFixture_;

        public ChainTest(ExecutorFixture fixture)
        {
            executorFixture_ = fixture;
        }

        [Fact]
        public void TestFetchLastHeight()
        {
            var handlerDone = new AutoResetEvent(false);
            int error = 0;
            UInt64 height = 0;
            Action<int,UInt64> handler = delegate(int theError, UInt64 theHeight)
            {
                error = theError;
                height = theHeight;
                handlerDone.Set();
            };
            executorFixture_.Executor.Chain.FetchLastHeight(handler);
            handlerDone.WaitOne();
            Assert.Equal(error, 0);
        }

        [Fact]
        public void TestFetchBlockHeaderByHeight()
        {
            var handlerDone = new AutoResetEvent(false);
            int error = 0;
            Header header = null;

            Action<int, Header> handler = delegate(int theError, Header theHeader)
            {
                error = theError;
                header = theHeader;
                handlerDone.Set();
            };
            executorFixture_.Executor.Chain.FetchBlockHeaderByHeight(0, handler);
            handlerDone.WaitOne();

            Assert.Equal(error, 0);
            Assert.NotNull(header);
            //Assert.Equal(header.Height, 0);
            Assert.Equal(ByteArrayToHexString(header.Hash), "000000000019d6689c085ae165831e934ff763ae46a2a6c172b3f1b60a8ce26f");
            Assert.Equal(ByteArrayToHexString(header.Merkle), "4a5e1e4baab89f3a32518a88c31bc87f618f76673e2cc77ab2127b7afdeda33b");
            Assert.Equal(ByteArrayToHexString(header.PreviousBlockHash), "0000000000000000000000000000000000000000000000000000000000000000");
            Assert.Equal<UInt32>(header.Version, 1);
            Assert.Equal<UInt32>(header.Bits, 486604799);
            Assert.Equal<UInt32>(header.Nonce, 2083236893);
            
            DateTime utcTime = DateTimeOffset.FromUnixTimeSeconds(header.Timestamp).DateTime;
            Assert.Equal(utcTime.ToString("%Y-%m-%d %H:%M:%S"), "2009-01-03 18:15:05");
        }

        public static string ByteArrayToHexString(byte[] ba)
        {
            StringBuilder hexString = new StringBuilder(ba.Length * 2);
            foreach (byte b in ba)
            {
                hexString.AppendFormat("{0:x2}", b);
            }
            return hexString.ToString();
        }

    }
}
