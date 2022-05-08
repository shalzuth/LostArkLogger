using System;
using System.Collections.Generic;

namespace LostArkLogger
{
    public class PKTAuctionSearchResult
    {
        /*
         * 00-00-00-00-01-00-76-0D-7D-02-00-00-00-00-01-00-00-00-2E-DF-30-01-00-00-A0-3C-B2-2C-B5-0C-00-00-58-00-01-00-00-00-00-00-00-00-01-00-00-00-1F-18-6C-17-01-00-00-00-00-00-00-00-00-00-00-00-05-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-05-00-78-00-00-00-01-01-00-00-02-14-00-00-00-C2-01-00-00-45-01-00-00-C2-01-00-00-01-00-00-00-78-00-00-00-01-01-00-00-02-13-00-00-00-BC-01-00-00-45-01-00-00-C2-01-00-00-01-00-00-00-67-00-00-00-02-01-00-00-03-22-03-00-00-02-00-00-00-01-00-00-00-03-00-00-00-01-00-00-00-67-00-00-00-01-01-00-00-03-FD-00-00-00-02-00-00-00-02-00-00-00-03-00-00-00-01-00-00-00-67-00-00-00-01-01-00-00-03-6D-00-00-00-03-00-00-00-02-00-00-00-03-00-00-00-01-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-01-00-00-00-13-00-00-00-00-00-00-00-27-00-00-00-00-00-00-00-01-00-00-00-00-00-00-00-01-E6-57-C8-E9-77-BC-00-00-00-00-00-00-00-00-00-00-00-13-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-14-32-05-00-01-00-00-00
         */

        // WARNING: Incomplete packet. This assumes all of the search result items are accessories with 2 stats and 3 engravings.

        public UInt16 NumItems;
        public List<Item> Items;

        public class Item
        {
            public UInt32 Id;
            public List<ItemStat> Stats;
            public List<ItemStat> Engravings;

            public override string ToString()
            {
                return Id + ", " +
                    AuctionItem.getStatName(Stats[0].Id) + "-" + Stats[0].Value + ", " +
                    AuctionItem.getStatName(Stats[1].Id) + "-" + Stats[1].Value + ", " +
                    AuctionItem.getEngravingName(Engravings[0].Id) + "-" + Engravings[0].Value + ", " +
                    AuctionItem.getEngravingName(Engravings[1].Id) + "-" + Engravings[1].Value + ", " +
                    AuctionItem.getEngravingName(Engravings[2].Id) + "-" + Engravings[2].Value;
            }
        }

        public class ItemStat
        {
            public UInt32 Id;
            public UInt32 Value;
        }

        public PKTAuctionSearchResult(Byte[] Bytes)
        {
            Items = new List<Item>();

            var bitReader = new BitReader(Bytes);

            bitReader.ReadUInt32(); // first 4 bytes are always zero ?

            NumItems = bitReader.ReadUInt16();

            bitReader.ReadUInt64(); // 8 bytes of something
            bitReader.ReadUInt32(); // should be "1"
            bitReader.ReadUInt64(); // 8 bytes of something again

            for (UInt32 i = 0; i < NumItems; i++)
            {
                var item = new Item
                {
                    Stats = new List<ItemStat>(),
                    Engravings = new List<ItemStat>(),

                    Id = bitReader.ReadUInt32()
                };

                for (int j = 0; j < 64; j++) // don't know what's going on here, need to investigate this
                {
                    bitReader.ReadByte();
                }

                var stat1 = new ItemStat();
                stat1.Id = bitReader.ReadUInt32();
                stat1.Value = bitReader.ReadUInt32();
                item.Stats.Add(stat1);

                for (int j = 0; j < 21; j++) // don't know what's going on here, need to investigate this
                {
                    bitReader.ReadByte();
                }

                var stat2 = new ItemStat();
                stat2.Id = bitReader.ReadUInt32();
                stat2.Value = bitReader.ReadUInt32();
                item.Stats.Add(stat2);

                // NOTE: 21 bytes between stats/engravings!

                for (int j = 0; j < 21; j++) // don't know what's going on here, need to investigate this
                {
                    bitReader.ReadByte();

                }

                var eng1 = new ItemStat();
                eng1.Id = bitReader.ReadUInt32();
                eng1.Value = bitReader.ReadUInt32();
                item.Engravings.Add(eng1);

                for (int j = 0; j < 21; j++) // don't know what's going on here, need to investigate this
                {
                    bitReader.ReadByte();

                }

                var eng2 = new ItemStat();
                eng2.Id = bitReader.ReadUInt32();
                eng2.Value = bitReader.ReadUInt32();
                item.Engravings.Add(eng2);

                for (int j = 0; j < 21; j++) // don't know what's going on here, need to investigate this
                {
                    bitReader.ReadByte();

                }

                var eng3 = new ItemStat();
                eng3.Id = bitReader.ReadUInt32();
                eng3.Value = bitReader.ReadUInt32();
                item.Engravings.Add(eng3);

                item.ToString();
                Items.Add(item);

                for (int j = 0; j < 110; j++) // this makes it jump to just before the ID of the next item. stuff like max page size is here
                {
                    bitReader.ReadByte();
                }
            }
        }
    }
}
