using System.IO;
using NiDotNet.NIF.Nodes;

namespace Luz
{
    public class LuzPathWaypoint
    {
        private LuzPathData PathData { get; set; }
        
        public NiVector3 Position { get; set; }

        public LuzPathWaypoint(BinaryReader reader, LuzPathData data)
        {
            Position = new NiVector3(reader, null);

            PathData = data;
        }
    }
}