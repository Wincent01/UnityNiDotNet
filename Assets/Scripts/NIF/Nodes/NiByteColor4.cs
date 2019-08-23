using System.IO;

namespace NiDotNet.NIF.Nodes
{
    public class NiByteColor4 : NiObject
    {
        public byte R { get; set; }

        public byte G { get; set; }

        public byte B { get; set; }

        public byte A { get; set; }

        public NiByteColor4(BinaryReader reader, NiFile niFile) : base(reader, niFile)
        {
            R = reader.ReadByte();

            G = reader.ReadByte();

            B = reader.ReadByte();

            A = reader.ReadByte();
        }

        public static implicit operator NiColor4(NiByteColor4 c) => new NiColor4
        {
            R = c.R / 255f,
            G = c.G / 255f,
            B = c.B / 255f,
            A = c.A / 255f,
        };
    }
}