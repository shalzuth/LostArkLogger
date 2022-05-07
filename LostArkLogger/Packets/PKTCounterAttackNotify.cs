using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LostArkLogger
{
    public class PKTCounterAttackNotify
    {
        // 00-4C-B2-6D-65-02-00-00-00-D6-11-00-00-AC-95-EE-64-02-00-00-00-00
        public UInt64 EnemyId;
        public UInt64 PlayerId;
        public PKTCounterAttackNotify(Byte[] Bytes)
        {
            EnemyId = BitConverter.ToUInt64(Bytes, 1);
            PlayerId = BitConverter.ToUInt64(Bytes, 13);
        }
    }
}
