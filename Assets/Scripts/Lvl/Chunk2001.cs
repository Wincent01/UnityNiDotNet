using System.IO;
using Luz;

namespace Lvl
{
    public class Chunk2001
    {
        public uint ObjectCount { get; set; }
        
        public LvlObjectTemplate[] Objects { get; set; }
        
        public Chunk2001(BinaryReader reader, uint lvlVersion)
        {
            ObjectCount = reader.ReadUInt32();

            Objects = new LvlObjectTemplate[ObjectCount];

            for (var i = 0; i < ObjectCount; i++)
            {
                Objects[i] = new LvlObjectTemplate(reader, lvlVersion);
            }
        }
    }
}