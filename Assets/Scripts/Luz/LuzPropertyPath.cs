using System.IO;
using Luz.Enums;
using NiDotNet.NIF.Nodes;

namespace Luz
{
    public class LuzPropertyPath : LuzPathData
    {
        public int Price { get; set; }
        
        public int RentalTime { get; set; }
        
        public ulong AssociatedZone { get; set; }
        
        public NiString DisplayName { get; set; }
        
        public NiString DisplayDescription { get; set; }
        
        public int CloneLimit { get; set; }
        
        public float ReputationMultiplier { get; set; }
        
        public RentalTimeUnit TimeUnit { get; set; }
        
        public AchievementRequired Achievement { get; set; }
        
        public NiVector3 PlayerZonePoint { get; set; }
        
        public float MaxBuildHeight { get; set; }

        public LuzPropertyPath(BinaryReader reader, uint version, NiString pathName, PathType type) : base(reader, version, pathName, type)
        {
            reader.ReadInt32();

            Price = reader.ReadInt32();

            RentalTime = reader.ReadInt32();

            AssociatedZone = reader.ReadUInt64();

            DisplayName = new NiString(reader, true, true);
            
            DisplayDescription = new NiString(reader, true);

            reader.ReadInt32();

            CloneLimit = reader.ReadInt32();

            ReputationMultiplier = reader.ReadSingle();

            TimeUnit = (RentalTimeUnit) reader.ReadInt32();

            Achievement = (AchievementRequired) reader.ReadInt32();

            PlayerZonePoint = new NiVector3(reader, null);

            MaxBuildHeight = reader.ReadSingle();
        }
    }
}