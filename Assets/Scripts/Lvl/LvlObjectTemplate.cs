using System.IO;
using Luz;
using NiDotNet.NIF.Nodes;

namespace Lvl
{
    public class LvlObjectTemplate
    {
        public ulong ObjectId { get; set; }
        
        public int Lot { get; set; }
        
        public NiVector3 Position { get; set; }
        
        public NiQuaternion Rotation { get; set; }
        
        public float Scale { get; set; }
        
        public LegoDataDictionary Ldf { get; set; }
        
        public LvlObjectTemplate(BinaryReader reader, uint lvlVersion)
        {
            ObjectId = reader.ReadUInt64() | 70368744177664;

            Lot = reader.ReadInt32();

            if (lvlVersion >= 0x26)
            {
                reader.ReadUInt32();
            }

            if (lvlVersion >= 0x20)
            {
                reader.ReadUInt32();
            }
            
            Position = new NiVector3(reader, null);

            Rotation = new NiQuaternion(reader, null);

            Scale = reader.ReadSingle();

            Ldf = LegoDataDictionary.FromString(new NiString(reader, true));

            if (lvlVersion >= 0x7)
            {
                reader.ReadUInt32();
            }
        }
    }
}