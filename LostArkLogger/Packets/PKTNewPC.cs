using System;
using System.Collections.Generic;
using System.Text;

namespace LostArkLogger
{
    public class PKTNewPC
    {
        public Byte PCTypeMaybe1;
        public Byte PCTypeMaybe2;
        public Byte PCTypeMaybe3;
        public UInt64 UnkId;
        public UInt64 PlayerId;
        public String Name;
        public Byte Two;
        public UInt16 ClassId;

        public static String ReadString(BitReader reader, Boolean unicode)
        {
            var stringBytes = new List<Byte>();
            var stringByte = 0u;
            var length = reader.ReadUInt16();
            for (var i = 0; i < length; i++)
            {
                if (unicode)
                {
                    stringByte = reader.ReadUInt16();
                    stringBytes.AddRange(BitConverter.GetBytes((UInt16)stringByte));
                }
                else
                {
                    stringByte = reader.ReadByte();
                    stringBytes.Add((Byte)stringByte);
                }
            }
            var finalStringParsed = unicode ? Encoding.Unicode.GetString(stringBytes.ToArray()) : Encoding.UTF8.GetString(stringBytes.ToArray());
            return finalStringParsed;
        }
        public PKTNewPC(Byte[] Bytes)
        {
            var bitReader = new BitReader(Bytes);
            bitReader.ReadByte();
            if (bitReader.ReadByte() == 1)
                bitReader.ReadUInt32();
            if (bitReader.ReadByte() == 1)
            {
                bitReader.ReadUInt32();
                if (bitReader.ReadByte() == 1)
                {
                    bitReader.ReadBits(8 * 12);
                }

                bitReader.ReadBits(8 * 12);

                bitReader.ReadUInt32();
            }

            if (bitReader.ReadByte() == 1)
            {
                bitReader.ReadBits(8 * 20);
            }

            //PlayerStruct
            bitReader.ReadByte();
            var count = bitReader.ReadUInt16();
            if (count <= 30)
            {
                for (var i = 0; i < count; i++)
                {
                    var size = bitReader.ReadUInt16();
                    if (size <= 3)
                        bitReader.ReadBits(8 * 14 * size);
                    bitReader.ReadUInt32();
                    bitReader.ReadUInt16();
                    bitReader.ReadUInt16();
                    if ((bitReader.ReadUInt16() & 0xfff) < 0x81)
                        bitReader.ReadBits(8 * 6);
                }
            }

            bitReader.ReadUInt32();
            bitReader.ReadByte();
            bitReader.ReadUInt16();
            bitReader.ReadBits(8 * 25);
            PlayerId = bitReader.ReadUInt64();
            //TODO: get classId & name, update made it more complex, no priority
            ClassId = 0;
            Name = "Placeholder";
        }
    }
}
