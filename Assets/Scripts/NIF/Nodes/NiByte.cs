using System.IO;

namespace NiDotNet.NIF.Nodes
{
    public class NiByte : NiObject
    {
        public byte Value { get; set; }

        public NiByte(BinaryReader reader, NiFile niFile) : base(reader, niFile)
        {
            Value = reader.ReadByte();
        }

        public static implicit operator byte(NiByte b) => b.Value;
    }
}