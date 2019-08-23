using System.IO;
using NiDotNet.NIF.Nodes;

namespace Luz
{
    public class LuzSpawnerWaypoint : LuzPathWaypoint
    {
        public NiQuaternion Rotation { get; set; }
        
        public LuzPathConfig[] Configs { get; set; }

        public LuzSpawnerWaypoint(BinaryReader reader, LuzPathData data) : base(reader, data)
        {
            Rotation = new NiQuaternion(reader, null);
            
            var configCount = reader.ReadUInt32();
            Configs = new LuzPathConfig[configCount];

            for (var i = 0; i < configCount; i++)
            {
                Configs[i] = new LuzPathConfig(reader);
            }
        }
    }
}