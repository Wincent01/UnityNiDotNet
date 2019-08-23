using System.IO;

namespace NiDotNet.NIF.Nodes
{
    public class NiColor3 : NiObject
    {
        public float R { get; set; }

        public float G { get; set; }

        public float B { get; set; }

        public NiColor3() : base(null, null)
        {
            
        }
        
        public NiColor3(BinaryReader reader, NiFile niFile) : base(reader, niFile)
        {
            R = reader.ReadSingle();

            G = reader.ReadSingle();

            B = reader.ReadSingle();
        }
        
        public static implicit operator NiColor4(NiColor3 c) => new NiColor4
        {
            R = c.R,
            G = c.G,
            B = c.B,
            A = 1f
        };
    }
}