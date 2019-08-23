using System.IO;
using NiDotNet.NIF.Nodes;

namespace Luz
{
    public class LuzMovingPlatformWaypoint : LuzPathWaypoint
    {
        public NiQuaternion Rotation { get; set; }
        
        public NiBoolean LockPlayer { get; set; }
        
        public float Speed { get; set; }
        
        public float Wait { get; set; }

        public NiString DepartSound { get; set; }
        
        public NiString ArriveSound { get; set; }
        
        public LuzMovingPlatformWaypoint(BinaryReader reader, LuzPathData data) : base(reader, data)
        {
            Rotation = new NiQuaternion(reader, null);
            
            LockPlayer = new NiBoolean(reader);

            Speed = reader.ReadSingle();

            Wait = reader.ReadSingle();

            if (data.Version < 13) return;
            DepartSound = new NiString(reader, true, true);

            ArriveSound = new NiString(reader, true, true);
        }
    }
}