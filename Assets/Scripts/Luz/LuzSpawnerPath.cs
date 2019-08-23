using System.IO;
using Luz.Enums;
using NiDotNet.NIF.Nodes;

namespace Luz
{
    public class LuzSpawnerPath : LuzPathData
    {
        public int SpawnedLot { get; set; }
        
        public int RespawnTime { get; set; }
        
        public int MaxSpawnCount { get; set; }
        
        public uint NumberToMaintain { get; set; }
        
        public long SpawnerObjectId { get; set; }
        
        public NiBoolean ActivateSpawnerNetworkOnLoad { get; set; }

        public LuzSpawnerPath(BinaryReader reader, uint version, NiString pathName, PathType type) : base(reader, version, pathName, type)
        {
            SpawnedLot = reader.ReadInt32();

            RespawnTime = reader.ReadInt32();

            MaxSpawnCount = reader.ReadInt32();

            NumberToMaintain = reader.ReadUInt32();

            SpawnerObjectId = reader.ReadInt64();
            
            ActivateSpawnerNetworkOnLoad = new NiBoolean(reader);
        }
    }
}