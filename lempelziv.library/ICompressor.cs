using System.Threading.Tasks;

namespace lempelziv.library
{
    public interface ICompressor
    {
        Task<byte[]> Compress(string toCompress);

        Task<byte[]> Compress(byte[] toCompress);
    }
}
