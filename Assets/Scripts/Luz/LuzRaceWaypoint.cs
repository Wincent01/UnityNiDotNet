using System.IO;
using NiDotNet.NIF.Nodes;

namespace Luz
{
    public class LuzRaceWaypoint : LuzPathWaypoint
    {
        public NiQuaternion Rotation { get; set; }
        
        public LuzRaceWaypoint(BinaryReader reader, LuzPathData data) : base(reader, data)
        {
            Rotation = new NiQuaternion(reader, null);

            reader.ReadByte();
            reader.ReadByte();

            reader.ReadSingle();
            reader.ReadSingle();
            reader.ReadSingle();
        }
    }
}