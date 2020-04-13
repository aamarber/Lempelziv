using System.Threading.Tasks;

namespace lempelziv.library
{
    public interface IDecompressor
    {
        Task<string> DecompressString(byte[] compressed);

        Task<byte[]> Decompress(byte[] compressed);
    }
}
