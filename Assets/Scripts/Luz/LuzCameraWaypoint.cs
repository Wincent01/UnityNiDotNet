using System.IO;
using NiDotNet.NIF.Nodes;

namespace Luz
{
    public class LuzCameraWaypoint : LuzPathWaypoint
    {
        public NiQuaternion Rotation { get; set; }
        
        public float Time { get; set; }
        
        public float Tension { get; set; }
        
        public float Continuity { get; set; }
        
        public float Bias { get; set; }
        
        public LuzCameraWaypoint(BinaryReader reader, LuzPathData data) : base(reader, data)
        {
            Rotation = new NiQuaternion(reader, null);
            
            Time = reader.ReadSingle();

            reader.ReadSingle();

            Tension = reader.ReadSingle();

            Continuity = reader.ReadSingle();

            Bias = reader.ReadSingle();
        }
    }
}