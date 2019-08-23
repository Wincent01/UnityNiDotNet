using System.IO;

namespace NiDotNet.NIF.Nodes
{
    public class NiSingleInterpController : NiInterpController
    {
        public NiRef<NiInterpolator> Interpolator { get; set; }

        public NiSingleInterpController(BinaryReader reader, NiFile niFile) : base(reader, niFile)
        {
            Interpolator = new NiRef<NiInterpolator>(niFile, reader.ReadInt32());
        }
    }
}