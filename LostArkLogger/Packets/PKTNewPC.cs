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
            //bitReader.ReadByte();
            PCTypeMaybe1 = bitReader.ReadByte();
            PCTypeMaybe2 = bitReader.ReadByte();
            PCTypeMaybe3 = bitReader.ReadByte();
            bitReader.ReadByte();
            if (PCTypeMaybe2 > 0) bitReader.ReadUInt64();
            if (PCTypeMaybe2 > 0 || PCTypeMaybe3 > 0)
            {
                bitReader.ReadUInt64();
                bitReader.ReadUInt32();
            }
            UnkId = bitReader.ReadUInt64();
            PlayerId = bitReader.ReadUInt64();
            Name = ReadString(bitReader, true);
            Two = bitReader.ReadByte();
            ClassId = bitReader.ReadUInt16();
        }
    }
}
