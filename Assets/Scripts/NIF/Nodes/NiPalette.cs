using System.IO;

namespace NiDotNet.NIF.Nodes
{
    public class NiPalette : NiObject
    {
        public byte HasAlpha { get; set; }

        public uint EntriesCount { get; set; }

        public NiByteColor4[] Palette { get; set; }

        public NiPalette(BinaryReader reader, NiFile niFile) : base(reader, niFile)
        {
            HasAlpha = reader.ReadByte();

            EntriesCount = reader.ReadUInt32(); // Should always be 16 or 256

            Palette = new NiByteColor4[EntriesCount];

            for (var i = 0; i < EntriesCount; i++)
            {
                Palette[i] = new NiByteColor4(reader, niFile);
            }
        }
    }
}