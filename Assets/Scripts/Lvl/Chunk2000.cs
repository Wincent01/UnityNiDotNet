using System.IO;
using NiDotNet.NIF.Nodes;

namespace Lvl
{
    public class Chunk2000
    {
        public uint[] Ids { get; set; }
        
        public NiString[] SkyFilePaths { get; set; }
        
        public Chunk2000(BinaryReader reader)
        {
            var startPos = reader.BaseStream.Position;
            
            var headerSize = reader.ReadUInt32();

            var skySectionAdr = reader.ReadUInt32();

            var otherSectionAdr = reader.ReadUInt32();

            for (var i = 0; i < (headerSize - 8) / 4; i++)
            {
                reader.ReadSingle();
            }

            var idsCount = reader.ReadUInt32();

            Ids = new uint[idsCount];

            for (var i = 0; i < idsCount; i++)
            {
                Ids[i] = reader.ReadUInt32();
                
                reader.ReadSingle();
                reader.ReadSingle();
            }

            for (var i = 0; i < 6; i++)
            {
                reader.ReadSingle();
            }

            reader.BaseStream.Position = skySectionAdr;

            SkyFilePaths = new NiString[6];

            for (var i = 0; i < 6; i++)
            {
                SkyFilePaths[i] = new NiString(reader);
            }

            reader.BaseStream.Position = otherSectionAdr;

            var otherSectionSize = reader.ReadUInt32();
        }
    }
}