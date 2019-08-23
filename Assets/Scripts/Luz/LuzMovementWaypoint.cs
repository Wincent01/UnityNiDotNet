using System.IO;

namespace Luz
{
    public class LuzMovementWaypoint : LuzPathWaypoint
    {
        public LuzPathConfig[] Configs { get; set; }
        
        public LuzMovementWaypoint(BinaryReader reader, LuzPathData data) : base(reader, data)
        {
            var configCount = reader.ReadUInt32();
            Configs = new LuzPathConfig[configCount];

            for (var i = 0; i < configCount; i++)
            {
                Configs[i] = new LuzPathConfig(reader);
            }
        }
    }
}