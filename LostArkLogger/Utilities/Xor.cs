namespace LostArkLogger
{
    static class Xor
    {
        public static void Cipher(byte[] data, int seed, byte[] xorKey = null)
        {
            for (int i = 0; i < data.Length; i++) data[i] = (byte)(data[i] ^ xorKey[seed++ % xorKey.Length]);
        }
    }
}
