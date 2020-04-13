using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lempelziv.library
{
    public class Compressor : ICompressor
    {
        private Encoding encoding;

        public Compressor(Encoding encoding)
        {
            this.encoding = encoding;
        }

        public async Task<byte[]> Compress(string toCompress)
        {
            var toCompressBytes = encoding.GetBytes(toCompress);

            return await Compress(toCompressBytes);
        }

        public async Task<byte[]> Compress(byte[] toCompress)
        {
            var table = GetTable();

            var result = new List<byte>();

            var current = toCompress[0];

            var previous = current;

            var i = 0;

            while (i < toCompress.Length)
            {
                if (table.Contains(current))
                {
                    previous = current;

                    i++;

                    current += toCompress[i];

                    continue;
                }

                result.Add(table[previous]);

                table.Add(current);

                current = toCompress[i];

                previous = current;
            }

            return new byte[0];
        }

        private IList<byte> GetTable()
        {
            byte last = 255;

            var result = new List<byte>();

            while(last > 0)
            {
                result.Add(last);

                last--;
            }

            return result;
        }
    }
}
