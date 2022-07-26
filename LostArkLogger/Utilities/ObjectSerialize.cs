using System;
using System.IO;
using System.IO.Compression;
using System.Runtime.Serialization.Formatters.Binary;

namespace LostArkLogger
{
    // copy/paste https://stackoverflow.com/questions/36276851/serialize-and-deserialize-dictionary-to-binary
    public static class ObjectSerialize
    {
        public static byte[] Serialize(this Object obj)
        {
            if (obj == null) return null;
            using (var memoryStream = new MemoryStream())
            {
                var binaryFormatter = new BinaryFormatter();
                binaryFormatter.Serialize(memoryStream, obj);
                var compressed = Compress(memoryStream.ToArray());
                return compressed;
            }
        }

        public static Object Deserialize(this byte[] arrBytes)
        {
            using (var memoryStream = new MemoryStream())
            {
                var binaryFormatter = new BinaryFormatter();
                var decompressed = Decompress(arrBytes);
                memoryStream.Write(decompressed, 0, decompressed.Length);
                memoryStream.Seek(0, SeekOrigin.Begin);
                return binaryFormatter.Deserialize(memoryStream);
            }
        }

        public static byte[] Compress(byte[] input)
        {
            byte[] compressesData;

            using (var outputStream = new MemoryStream())
            {
                using (var zip = new GZipStream(outputStream, CompressionMode.Compress)) zip.Write(input, 0, input.Length);
                compressesData = outputStream.ToArray();
            }
            return compressesData;
        }

        public static byte[] Decompress(byte[] input)
        {
            byte[] decompressedData;
            using (var outputStream = new MemoryStream())
            {
                using (var inputStream = new MemoryStream(input))
                using (var zip = new GZipStream(inputStream, CompressionMode.Decompress))
                    zip.CopyTo(outputStream);
                decompressedData = outputStream.ToArray();
            }
            return decompressedData;
        }
    }
}
