using lempelziv.library;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace lempelziv.tests
{
    public class CompressorTests
    {
        private readonly Encoding encoding = Encoding.UTF32;

        private readonly ICompressor compressor;

        private readonly IDecompressor decompressor;

        public CompressorTests()
        {
            compressor = new Compressor(encoding);
        }

        [Theory]
        [InlineData("BABAABAAA", new byte[] { 66, 65 })]
        public async Task Should_Compress(string entry, byte[] expectedResult)
        {
            var compressedEntry = await compressor.Compress(entry);

            Assert.Equal(expectedResult.Length, compressedEntry.Length);

            for(var i = 0; i < compressedEntry.Length; i++)
            {
                Assert.Equal(expectedResult[i], compressedEntry[i]);
            }
        }

        [Fact]
        public async Task Decompress_Should_Match_Entry()
        {
            var entry = "BABAABAAA";

            var compressedEntry = await compressor.Compress(entry);

            var decompressed = await decompressor.DecompressString(compressedEntry);

            Assert.Equal(entry, decompressed);
        }
    }
}
