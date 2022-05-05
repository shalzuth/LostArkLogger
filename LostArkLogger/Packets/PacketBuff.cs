namespace LostArkLogger.Packets
{
    public class PacketBuff
    {
        public int size { get; set; }
        public ushort opcode { get; set; }
        public byte[] data { get; set; }
    }
}
