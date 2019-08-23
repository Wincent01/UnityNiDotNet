using System.IO;

namespace Lvl
{
    public class Chunk1000
    {
        public uint LvlVersion { get; set; }
        
        public Chunk1000(BinaryReader reader)
        {
            LvlVersion = reader.ReadUInt32();

            for (var i = 0; i < 4; i++)
            {
                reader.ReadUInt32();
            }
        }
    }
}