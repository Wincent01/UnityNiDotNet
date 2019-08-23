using System.IO;

namespace NiDotNet.NIF.Nodes
{
    public class NiColor4 : NiObject
    {
        public float R { get; set; }

        public float G { get; set; }

        public float B { get; set; }

        public float A { get; set; }

        public NiColor4() : base(null, null)
        {
            
        }
        
        public NiColor4(BinaryReader reader, NiFile niFile) : base(reader, niFile)
        {
            R = reader.ReadSingle();

            G = reader.ReadSingle();

            B = reader.ReadSingle();

            A = reader.ReadSingle();
        }
        
        public static implicit operator NiColor3(NiColor4 c) => new NiColor3
        {
            R = c.R,
            G = c.G,
            B = c.B
        };
    }
}