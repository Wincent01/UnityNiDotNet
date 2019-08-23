using System.IO;

namespace NiDotNet.NIF.Nodes
{
    public class NiShaderTexDesc : NiObject
    {
        public NiBoolean HasMap { get; set; }

        public NiTexDesc Map { get; set; }

        public uint MapId { get; set; }

        public NiShaderTexDesc(BinaryReader reader, NiFile niFile) : base(reader, niFile)
        {
            HasMap = new NiBoolean(reader);

            if (!HasMap) return;
            Map = new NiTexDesc(reader, niFile);
            MapId = reader.ReadUInt32();
        }
    }
}