using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LostArkLogger
{
    public class PKTDeathNotify
    {
        public UInt64 TargetId;
        public PKTDeathNotify(Byte[] bytes)
        {
            TargetId = BitConverter.ToUInt64(bytes, 0);
        }
    }
}
