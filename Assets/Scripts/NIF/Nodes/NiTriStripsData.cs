using System.IO;

namespace NiDotNet.NIF.Nodes
{
    public class NiTriStripsData : NiTriBasedGeomData
    {
        public ushort StripsCount { get; set; }

        public ushort StripsLengths { get; set; }

        public NiBoolean HasPoints { get; set; }

        public ushort[][] Points { get; set; }

        public NiTriStripsData(BinaryReader reader, NiFile niFile) : base(reader, niFile)
        {
            StripsCount = reader.ReadUInt16();

            StripsLengths = reader.ReadUInt16();

            HasPoints = new NiBoolean(reader);

            if (!HasPoints) return;
            Points = new ushort[StripsCount][];

            for (var i = 0; i < StripsCount; i++)
            {
                Points[i] = new ushort[StripsLengths];
                for (var j = 0; j < StripsLengths; j++)
                {
                    Points[i][j] = reader.ReadUInt16();
                }
            }
        }
    }
}