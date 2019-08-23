using System.IO;

namespace NiDotNet.NIF.Nodes
{
    public class NiBound : NiObject
    {
        public NiVector3 Center { get; set; }

        public float Radius { get; set; }

        public NiBound(BinaryReader reader, NiFile niFile) : base(reader, niFile)
        {
            Center = new NiVector3(reader, niFile);

            Radius = reader.ReadSingle();
        }
    }
}