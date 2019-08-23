using System.IO;
using Luz.Enums;
using NiDotNet.NIF.Nodes;

namespace Luz
{
    public class LuzMovingPlatformPath : LuzPathData
    {
        public NiString MovingPlatformSound { get; set; }

        public LuzMovingPlatformPath(BinaryReader reader, uint version, NiString pathName, PathType type) : base(reader, version, pathName, type)
        {
            if (Version >= 18)
                reader.ReadByte();
            else if (Version >= 13)
                MovingPlatformSound = new NiString(reader, true, true);
        }
    }
}