using System.IO;
using Luz.Enums;
using NiDotNet.NIF.Nodes;

namespace Luz
{
    public class LuzCameraPath : LuzPathData
    {
        public NiString NextPath { get; set; }

        public LuzCameraPath(BinaryReader reader, uint version, NiString pathName, PathType type) : base(reader, version, pathName, type)
        {
            NextPath = new NiString(reader, true, true);

            if (Version >= 14)
                reader.ReadByte();
        }
    }
}