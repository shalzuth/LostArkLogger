namespace LostArkLogger
{
    static class Xor
    {
        static byte[] XorTable = ObjectSerialize.Decompress(Properties.Resources.xor);
        public static void Cipher(byte[] data, int seed, byte[] xorKey = null)
        {
            if (xorKey == null) xorKey = XorTable;
            for (int i = 0; i < data.Length; i++) data[i] = (byte)(data[i] ^ xorKey[seed++ % xorKey.Length]);
        }
    }
}
