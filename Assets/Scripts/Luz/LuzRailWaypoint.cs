using System.IO;

namespace Luz
{
    public class LuzRailWaypoint : LuzPathWaypoint
    {
        public LuzPathConfig[] Configs { get; set; }
        
        public LuzRailWaypoint(BinaryReader reader, LuzPathData data) : base(reader, data)
        {
            reader.ReadSingle();
            reader.ReadSingle();
            reader.ReadSingle();
            reader.ReadSingle();

            if (data.Version >= 17)
            {
                reader.ReadSingle();
            }
            
            var configCount = reader.ReadUInt32();
            Configs = new LuzPathConfig[configCount];

            for (var i = 0; i < configCount; i++)
            {
                Configs[i] = new LuzPathConfig(reader);
            }
        }
    }
}