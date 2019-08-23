using System.IO;

namespace NiDotNet.NIF.Nodes
{
    public class NiFloat : NiObject
    {
        public float Value { get; set; }

        public NiFloat(BinaryReader reader, NiFile niFile) : base(reader, niFile)
        {
            Value = reader.ReadSingle();
        }

        public static implicit operator float(NiFloat f) => f.Value;
    }
}