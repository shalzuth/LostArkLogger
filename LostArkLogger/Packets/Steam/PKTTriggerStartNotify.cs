using System;
using System.Collections.Generic;
namespace LostArkLogger
{
    public partial class PKTTriggerStartNotify
    {
        public void SteamDecode(BitReader reader)
        {   
            TriggerID = reader.ReadUInt32();
            TriggerSignalType = reader.ReadUInt32();
            SourceID = reader.ReadUInt64();
           
            num =  reader.ReadUInt16();
            for(var i = 0; i < num; i++)
            {
                steps.Add(reader.ReadUInt64());
            }

        }
    }
}