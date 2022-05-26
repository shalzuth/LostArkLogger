using System;
using System.Collections.Generic;
using System.Linq;

namespace LostArkLogger
{
    public class BitReader : IDisposable
    {
        private byte[] Data;
        private Int32 BitOffset;
        private Int32 ByteOffset;
        public BitReader(Byte[] data, Int32 offset = 0)
        {
            Data = data;
            ByteOffset = offset;
        }
        public BitReader(BitReader data)
        {
            Data = data.Data;
            BitOffset = data.BitOffset;
            ByteOffset = data.ByteOffset;
        }
        public Int32 Position
        {
            get
            {
                return ByteOffset * 8 + BitOffset;
            }
            set
            {
                BitOffset = value % 8;
                ByteOffset = value / 8;
            }
        }
        public Int32 BitsLeft
        {
            get
            {
                return ((Data.Length - ByteOffset) - 1) * 8 + (8 - BitOffset);
            }
        }
        public Boolean ReadBit()
        {
            return ReadBits(1) == 1;
        }
        public UInt64 ReadDynamicValue(out Int32 size)
        {
            size = 8;
            if (ReadBit())
            {
                size *= 2;
                if (ReadBit()) size *= 2;
            }
            return ReadBits(size);
        }
        public UInt64 ReadBits(Int32 Count)
        {
            UInt64 Value = 0;
            Int32 ReadOffset = 0;
            while (Count > 0)
            {
                Int32 LeftInByte = 8 - BitOffset;
                Int32 ReadCount = Math.Min(Count, LeftInByte);
                if ((UInt64)Data.Length > (UInt64)ByteOffset)
                    Value |= (UInt64)((Data[ByteOffset] >> BitOffset) & ((1 << ReadCount) - 1)) << ReadOffset;
                ReadOffset += ReadCount;
                BitOffset += ReadCount;
                if (BitOffset == 8)
                {
                    BitOffset = 0;
                    ByteOffset++;
                }
                Count -= ReadCount;
            }

            return Value;
        }
        public Int64 ReadPackedInt()
        {
            var flag = ReadByte();
            var bytes = ReadBytes((flag >> 1) & 7);
            if (bytes.Length < 8) bytes = bytes.Concat(new Byte[] { 0, 0, 0, 0, 0, 0, 0, 0 }).ToArray();
            var result = (BitConverter.ToInt64(bytes, 0) << 4) | (uint)(flag >> 4);
            return (flag & 1) == 0 ? result : -result;
            //var valBits = (UInt16)ReadBits(4);
            //return ReadBits(4 + valBits * 4);
        }
        public UInt64 ReadSimpleInt()
        {
            var s = ReadUInt16();
            if ((s & 0xfff) < 0x81f)
            {
                ByteOffset -= 2;
                return ReadUInt64();
            }
            else return (UInt64)(s & 0xFFF | 0x11000);
        }
        // todo fix
        public UInt64 ReadFlag()
        {
            var flag = ReadByte();
            for(var i = 0; i < 6; i++) if (((flag >> i) & 1) != 0) ReadUInt32();
            if (((flag >> 6) & 1) != 0) ReadBytes(ReadUInt16());
            return 0;
        }
        public List<Object> ReadPackedValues(params int[] sizes)
        {
            var packedValues = new List<Object>();
            var flag = ReadByte();
            packedValues.Add(flag);
            for (var i = 0; i < 7; i++) if (((flag >> i) & 1) != 0) packedValues.Add(ReadBytes(sizes[i]));
            return packedValues;
        }
        public String ReadString()
        {
            var unicode = true;
            var stringBytes = new List<Byte>();
            var stringByte = 0u;
            var length = ReadUInt16();
            for (var i = 0; i < length; i++)
            {
                if (unicode)
                {
                    stringByte = ReadUInt16();
                    stringBytes.AddRange(BitConverter.GetBytes((UInt16)stringByte));
                }
                else
                {
                    stringByte = ReadByte();
                    stringBytes.Add((Byte)stringByte);
                }
            }
            var finalStringParsed = unicode ? System.Text.Encoding.Unicode.GetString(stringBytes.ToArray()) : System.Text.Encoding.UTF8.GetString(stringBytes.ToArray());
            return finalStringParsed;
        }
        public T Read<T>(int byteArraySize = 0)
        {
            if (typeof(T) == typeof(Byte)) return (T)(Object)ReadByte();
            if (typeof(T) == typeof(UInt16)) return (T)(Object)ReadUInt16();
            if (typeof(T) == typeof(UInt32)) return (T)(Object)ReadUInt32();
            if (typeof(T) == typeof(UInt64)) return (T)(Object)ReadUInt64();
            if (typeof(T) == typeof(Byte[])) return (T)(Object)ReadBytes(byteArraySize);
            return (T)Activator.CreateInstance(typeof(T), this);
        }
        public List<T> ReadList<T>(int byteArraySize = 0)
        {
            var num = ReadUInt16();
            var list = new List<T>();
            for(var i = 0; i < num; i++)
                list.Add(Read<T>(byteArraySize));
            return list;
        }
        public UInt32 BitReverse(UInt32 value, Byte numBits)
        {
            UInt32 a = 0;
            for (Int32 i = 0; i < numBits; i++)
                if ((value & (UInt32)(1 << i)) != 0)
                    a |= (UInt32)(1 << (numBits - 1 - i));
            return a;
        }
        public Byte ReadByte()
        {
            return (Byte)ReadBits(8);
        }
        public Byte[] ReadBytes(int count)
        {
            var bytes = new byte[count];
            for (var i = 0; i < count; i++)
            {
                bytes[i] = ReadByte();
            }

            return bytes;
        }
        public UInt16 ReadUInt16()
        {
            return (UInt16)ReadBits(16);
        }
        public UInt32 ReadUInt32()
        {
            return (UInt32)ReadBits(32);
        }
        public UInt64 ReadUInt64()
        {
            return (UInt64)ReadBits(64);
        }
        public void SkipBits(Int32 Count)
        {
            BitOffset += Count % 8;
            ByteOffset += Count / 8;
        }
        public void Dispose()
        {
            Data = null;
        }
    }
}