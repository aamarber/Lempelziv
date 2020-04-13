using lempelziv.library;
using System;
using System.Text;

namespace lempelziv.app
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var compressor = new Compressor(Encoding.UTF8);

            compressor.Compress("ABBABBBA");
        }
    }
}
