using System.IO;
using NiDotNet.NIF.Enums;

namespace NiDotNet.NIF.Nodes
{
    public class NiMaterialColorController : NiPoint3InterpController
    {
        public MaterialColor MaterialColor { get; set; }

        public NiMaterialColorController(BinaryReader reader, NiFile niFile) : base(reader, niFile)
        {
            MaterialColor = (MaterialColor) reader.ReadUInt16();
        }
    }
}